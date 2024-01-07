using Microsoft.AspNetCore.Mvc;

namespace Choon.Api.Features.Account
{
	[ApiController]
	[Route("[controller]")]
	public class AccountController : ControllerBase
	{
		[HttpPost]
		[Route("identify")]
		public async Task<IActionResult> Identify()
		{
			return Ok();
		}
	}
}