using Choon.Api.Features.Common.Infrastructure.Persistence.Entities;
using Choon.Api.Features.Common.Web.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Choon.Api.Features.Common.Infrastructure.Persistence;

public class ChoonDbContext(DbContextOptions<ChoonDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<FormCheckEntity> FormChecks { get; set; } = null!;
}