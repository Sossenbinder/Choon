using System.Net;
using Choon.Api.Features.Common.Web.Attributes;
using Choon.Api.Features.Features.FormCheck.Models;
using Choon.Api.Features.Features.FormCheck.Services;
using Microsoft.AspNetCore.Mvc;

namespace Choon.Api.Features.Features.FormCheck.Api;

[ApiController]
[Route("[controller]")]
public class FormCheckController(FormCheckService formCheckService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add(IFormFile? file, [MultipartFormJson] CreateFormCheckRequest request)
    {
        if (file is null)
        {
            return Problem("File not found", statusCode: (int) HttpStatusCode.BadRequest);
        }

        await using var fileStream = file.OpenReadStream();

        await formCheckService.Add(file.FileName, fileStream);

        return Ok();
    }
}