using Domains.FormCheck.Models;
using Domains.FormCheck.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domains.FormCheck.Persistence
{
	internal class FormCheckSqlRepository : IFormCheckRepository
	{
		private readonly IDbContextFactory<FormCheckDbContext> _dbContextFactory;

		public FormCheckSqlRepository(IDbContextFactory<FormCheckDbContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public async Task<FormCheckDto> Store(FormCheckDto formCheckDto)
		{
			await using var ctx = _dbContextFactory.CreateDbContext();

			var entity = FormCheckEntity.FromModel(formCheckDto);

			ctx.FormChecks.Add(entity);

			await ctx.SaveChangesAsync();

			return entity.ToModel();
		}
	}
}