using System.Net;
using Choon.Api.Attributes;
using Choon.Api.Features.FormCheck.Models;
using Domains.FormCheck.Services;
using Microsoft.AspNetCore.Mvc;

namespace Choon.Api.Features.FormCheck
{
	[ApiController]
	[Route("[controller]")]
	public class FormCheckController : ControllerBase
	{
		private readonly IFormCheckService _formCheckService;

		public FormCheckController(IFormCheckService formCheckService)
		{
			_formCheckService = formCheckService;
		}

		[HttpPost]
		public async Task<IActionResult> Add(IFormFile? file, [MultipartFormJson] CreateFormCheckRequest request)
		{
			if (file is null)
			{
				return Problem("File not found", statusCode: (int) HttpStatusCode.BadRequest);
			}

			await using var fileStream = file.OpenReadStream();

			await _formCheckService.Add(file.FileName, fileStream);

			return Ok();
		}
	}
}