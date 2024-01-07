using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Domains.FormCheck.Persistence.Migration
{
	internal class FormCheckMigrationContextFactory : IDesignTimeDbContextFactory<FormCheckDbContext>
	{
		public FormCheckMigrationContextFactory()
		{
		}

		public FormCheckDbContext CreateDbContext(string[] args)
		{
			var connectionString = args.Length == 0 ? "Unknown" : args[0];

			var options = new DbContextOptionsBuilder<FormCheckDbContext>()
				.UseSqlServer(connectionString)
				.Options;

			return new FormCheckDbContext(options);
		}
	}
}