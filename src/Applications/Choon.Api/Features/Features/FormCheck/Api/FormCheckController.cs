using Choon.Api.Common.Web.Attributes;
using Choon.Api.Features.Features.FormCheck.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Choon.Api.Features.Features.FormCheck.Api;

[ApiController]
[Route("[controller]")]
public class FormCheckController(
    FormCheckService formCheckService,
    IValidator<FormCheckController.CreateFormCheckRequest> createFormCheckRequestValidator) : ControllerBase
{
    public record CreateFormCheckRequest(string Header, string? Description);

    public class CreateFormCheckRequestValidator : AbstractValidator<CreateFormCheckRequest>
    {
        public CreateFormCheckRequestValidator()
        {
            RuleFor(x => x.Header).NotEmpty().WithMessage("Header must be set");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(IFormFile file, [MultipartFormJson] CreateFormCheckRequest request)
    {
        var validationResult = await createFormCheckRequestValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return ValidationProblem(validationResult.Errors.First().ErrorMessage);
        }

        await using var fileStream = file.OpenReadStream();

        await formCheckService.Add(file.FileName, fileStream);

        return Ok();
    }
}