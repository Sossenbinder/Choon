using Domains.FormCheck.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domains.FormCheck.Persistence
{
	internal class FormCheckDbContext : DbContext
	{
		public DbSet<FormCheckEntity> FormChecks { get; set; }

		public FormCheckDbContext()
		{
		}

		public FormCheckDbContext(DbContextOptions<FormCheckDbContext> options)
			: base(options)
		{
		}
	}
}