using Choon.Api;
using Choon.Api.Common.Web.Models;
using Choon.Api.Features.Common;
using Choon.Api.Features.Common.Infrastructure.Persistence;
using Choon.Api.Features.Common.Infrastructure.Persistence.Options;
using Choon.Api.Features.Common.Web.Auth;
using Choon.Api.Features.Common.Web.Auth.Middleware;
using Choon.Api.Features.Features.FormCheck;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Identity
builder.Services.AddAuthorization();
builder.Services
    .AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<ChoonDbContext>();

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
app.MapIdentityApi<User>();

app.UseMiddleware<UserDetectionMiddleware>();

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
        .RegisterCommonFeatureModule()
        .RegisterFormCheckModule(configuration1);
}

// Necessary for WebApplicationFactory later on
namespace Choon.Api
{
    public partial class Program { }
}