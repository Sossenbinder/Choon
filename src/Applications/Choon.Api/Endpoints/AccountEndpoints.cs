using Domains.FormCheck.Services;
using Microsoft.AspNetCore.Mvc;

namespace Choon.Api.Endpoints
{
	public static class AccountEndpoints
	{
		public static IEndpointRouteBuilder AddAccountEndpoints(this IEndpointRouteBuilder builder)
		{
			builder
				.MapGroup("account")
				.AddGroupedEndpoints();

			return builder;
		}

		private static void AddGroupedEndpoints(this RouteGroupBuilder routeGroupBuilder)
		{
			routeGroupBuilder
				.MapPost("/identify", async (HttpContext context) =>
				{
					await Task.CompletedTask;
					return Results.Ok();
				});
		}
	}
}