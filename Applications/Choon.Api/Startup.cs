using Domains.FormCheck.DI;
using Domains.FormCheck.Models.Configuration;

namespace Choon.Api
{
	internal static class Startup
	{
		public static void Setup(WebApplicationBuilder builder)
		{
			RegisterOptions(builder.Services, builder.Configuration);
			RegisterModules(builder.Services);
		}

		private static IServiceCollection RegisterOptions(IServiceCollection serviceCollection, IConfiguration configuration)
		{
			return serviceCollection
				.Configure<FormCheckAzureStorageSettings>(configuration.GetSection(ConfigurationSections.FormCheckAzureStorageSettings));
		}

		private static IServiceCollection RegisterModules(IServiceCollection serviceCollection)
		{
			return serviceCollection
				.RegisterFormCheckModule();
		}
	}
}