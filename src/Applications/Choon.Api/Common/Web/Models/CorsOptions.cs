using System.ComponentModel.DataAnnotations;

namespace Choon.Api.Common.Web.Models;

public class CorsOptions
{
    [MinLength(1)]
    public List<string> AllowedOrigins { get; set; } = [];
}