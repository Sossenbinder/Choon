using Choon.Api.Features.Common.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Choon.Api.Features.Common.Infrastructure.Persistence;

public class ChoonDbContext(DbContextOptions<ChoonDbContext> options) 
    : DbContext(options)
{
    public DbSet<FormCheckEntity> FormChecks { get; set; } = null!;
}