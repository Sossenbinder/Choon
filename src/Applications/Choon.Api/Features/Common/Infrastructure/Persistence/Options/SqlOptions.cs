using System.ComponentModel.DataAnnotations;

namespace Choon.Api.Features.Common.Infrastructure.Persistence.Options;

public class SqlOptions
{
    [Required]
    public string ConnectionString { get; set; } = default!;
}