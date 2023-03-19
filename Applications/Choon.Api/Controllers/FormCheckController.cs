using Domains.FormCheck.Services;
using Microsoft.AspNetCore.Mvc;

namespace Choon.Api.Controllers;

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
	public async Task Add(IFormFile file)
	{
		await using var fileStream = file.OpenReadStream();

		await _formCheckService.Add(fileStream);
	}
}