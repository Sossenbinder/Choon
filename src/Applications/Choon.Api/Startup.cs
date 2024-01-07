using Domains.FormCheck.DI;
using Domains.FormCheck.Models.Configuration;
using Infrastructure.Models.Options;

namespace Choon.Api
{
	internal static class Startup
	{
		public static void Setup(WebApplicationBuilder builder)
		{
			RegisterOptions(builder.Services, builder.Configuration);
			RegisterModules(builder.Services);
		}

		private static void RegisterOptions(IServiceCollection serviceCollection, IConfiguration configuration)
		{
			serviceCollection.Configure<FormCheckAzureStorageSettings>(configuration.GetSection(ConfigurationSections.FormCheckAzureStorageSettings));
			serviceCollection.Configure<SqlOptions>(configuration.GetSection(ConfigurationSections.SqlOptionsSettings));
		}

		private static void RegisterModules(IServiceCollection serviceCollection)
		{
			serviceCollection.RegisterFormCheckModule();
		}
	}
}