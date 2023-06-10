using Domains.FormCheck.Services;

namespace Choon.Api.Endpoints
{
	public static class FormCheckEndpoints
	{
		public static IEndpointRouteBuilder AddFormCheckEndpoints(this IEndpointRouteBuilder builder)
		{
			builder
				.MapGroup("formcheck")
				.AddGroupedEndpoints();

			return builder;
		}

		private static void AddGroupedEndpoints(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder
				.MapPost("/", async (IFormFile file, IFormCheckService formCheckService) =>
				{
					await using var fileStream = file.OpenReadStream();

					await formCheckService.Add(file.FileName, fileStream);
				});
		}
	}
}