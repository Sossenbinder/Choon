using System.Net;
using Choon.Api.Endpoints.FormCheck.Models;
using Choon.Api.Extensions;
using Domains.FormCheck.Services;
using Microsoft.AspNetCore.Mvc;

namespace Choon.Api.Endpoints.FormCheck
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
				.MapPost("/", async (IFormFileCollection formFileCollection, [FromForm] CreateFormCheckRequest test, IFormCheckService formCheckService) =>
				{
					var file = formFileCollection.GetFile("file");
					if (file is null)
					{
						return Results.Problem("File not found", statusCode: (int) HttpStatusCode.BadRequest);
					}

					var request = formFileCollection["request"];
					if (request is null)
					{
						return Results.Problem("Json not found", statusCode: (int) HttpStatusCode.BadRequest);
					}

					var createFormCheckRequest = request.Deserialize<CreateFormCheckRequest>();


					await using var fileStream = file.OpenReadStream();

					await formCheckService.Add(file.FileName, fileStream);

					return Results.Ok();
				});
		}
	}
}