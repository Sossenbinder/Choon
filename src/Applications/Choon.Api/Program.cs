using Choon.Api;
using Choon.Api.Common.Web.Models;
using Choon.Api.Features.Common.Infrastructure.Persistence;
using Choon.Api.Features.Common.Infrastructure.Persistence.Options;
using Choon.Api.Features.Features.FormCheck;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

ConfigureOptions(builder, configuration);

RegisterServices(builder, configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(options =>
{
    var corsOptions = app.Services.GetRequiredService<IOptions<CorsOptions>>().Value;
	options.WithOrigins(corsOptions.AllowedOrigins.ToArray())
		.AllowAnyHeader()
		.AllowAnyMethod();
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();

IServiceCollection ConfigureOptions(WebApplicationBuilder webApplicationBuilder, ConfigurationManager configurationManager)
{
    return webApplicationBuilder.Services
        .AddOptions<SqlOptions>()
        .BindConfiguration(ConfigurationSections.SqlOptionsSettings)
        .Services
        .AddOptions<CorsOptions>()
        .BindConfiguration(ConfigurationSections.CorsSettings)
        .ValidateDataAnnotations()
        .ValidateOnStart()
        .Services;
}

IServiceCollection RegisterServices(WebApplicationBuilder webApplicationBuilder, ConfigurationManager configuration1)
{
    return webApplicationBuilder.Services
        .AddDbContext<ChoonDbContext>((sp, options) =>
        {
            var sqlOptions = sp.GetRequiredService<IOptions<SqlOptions>>().Value;
            options.UseSqlServer(sqlOptions.ConnectionString);
        })
        .RegisterFormCheckModule(configuration1);
}