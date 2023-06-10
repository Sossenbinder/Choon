using Azure.Storage.Blobs;
using Domains.FormCheck.Models.Configuration;
using Domains.FormCheck.Persistence;
using Domains.FormCheck.Persistence.Media;
using Domains.FormCheck.Services;
using Infrastructure.Models.Options;
using Microsoft.EntityFrameworkCore;
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
				.RegisterAzureStorageMediaHandling()
				.RegisterSqlStorageHandling();
		}

		private static IServiceCollection RegisterAzureStorageMediaHandling(this IServiceCollection services)
		{
			return services
				.AddSingleton(sp => new BlobServiceClient(sp.GetRequiredService<IOptions<FormCheckAzureStorageSettings>>().Value.ConnectionString))
				.AddSingleton<IFormCheckMediaRepository, AzureStorageFormCheckMediaRepository>();
		}

		private static IServiceCollection RegisterSqlStorageHandling(this IServiceCollection services)
		{
			return services
				.AddDbContextFactory<FormCheckDbContext>((sp, options) =>
				{
					var sqlOptions = sp.GetRequiredService<IOptions<SqlOptions>>();
					options.UseSqlServer(sqlOptions.Value.ConnectionString);
				})
				.AddSingleton<IFormCheckRepository, FormCheckSqlRepository>();
		}
	}
}