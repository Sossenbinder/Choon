using Azure.Storage.Blobs;
using Choon.Api.Features.Features.FormCheck.Models.Configuration;
using Choon.Api.Features.Features.FormCheck.Persistence;
using Choon.Api.Features.Features.FormCheck.Services;
using Microsoft.Extensions.Options;

namespace Choon.Api.Features.Features.FormCheck;

internal static class FormCheckModule
{
    public static IServiceCollection RegisterFormCheckModule(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .Configure<FormCheckAzureStorageSettings>(configuration.GetSection(ConfigurationSections.FormCheckAzureStorageSettings))
            .AddSingleton(sp => new BlobServiceClient(sp.GetRequiredService<IOptions<FormCheckAzureStorageSettings>>().Value.ConnectionString))
            .AddScoped<FormCheckService>()
            .AddScoped<FormCheckRepository>()
            .AddScoped<FormCheckMediaRepository>();
    }
}