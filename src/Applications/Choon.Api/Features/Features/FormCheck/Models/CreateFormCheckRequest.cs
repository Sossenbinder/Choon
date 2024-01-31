namespace Choon.Api.Features.Features.FormCheck.Models;

public record CreateFormCheckRequest(
    string? FileName,
    string? Header,
    string? Description);