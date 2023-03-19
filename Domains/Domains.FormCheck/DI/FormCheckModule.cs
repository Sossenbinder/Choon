using Azure.Storage.Blobs;
using Domains.FormCheck.Models.Configuration;
using Domains.FormCheck.Persistence.Media;
using Domains.FormCheck.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Domains.FormCheck.DI
{
	public static class FormCheckModule
	{
		public static IServiceCollection RegisterFormCheckModule(this IServiceCollection services)
		{
			return services
				.AddSingleton<IFormCheckService, FormCheckService>()
				.RegisterAzureStorageMediaHandling();
		}

		private static IServiceCollection RegisterAzureStorageMediaHandling(this IServiceCollection services)
		{
			return services
				.AddSingleton(sp => new BlobServiceClient(sp.GetRequiredService<IOptions<FormCheckAzureStorageSettings>>().Value.ConnectionString))
				.AddSingleton<IFormCheckMediaRepository, AzureStorageFormCheckMediaRepository>();
		}
	}
}