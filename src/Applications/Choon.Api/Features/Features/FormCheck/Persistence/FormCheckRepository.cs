using Choon.Api.Features.Common.Infrastructure.Persistence;
using Choon.Api.Features.Common.Infrastructure.Persistence.Entities;
using Choon.Api.Features.Features.FormCheck.Models;

namespace Choon.Api.Features.Features.FormCheck.Persistence;

public class FormCheckRepository(ChoonDbContext ctx)
{
    public async Task<FormCheckDto> Store(FormCheckDto formCheckDto)
    {
		var entity = FormCheckEntity.FromModel(formCheckDto);

		ctx.FormChecks.Add(entity);

		await ctx.SaveChangesAsync();

		return entity.ToModel();
	}
}