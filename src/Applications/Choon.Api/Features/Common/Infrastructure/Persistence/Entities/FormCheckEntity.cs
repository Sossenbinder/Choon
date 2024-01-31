using Choon.Api.Features.Features.FormCheck.Models;

namespace Choon.Api.Features.Common.Infrastructure.Persistence.Entities;

public class FormCheckEntity
{
    public string UserId { get; set; }

    public int Id { get; set; }

    public string AssetUrl { get; set; } = default!;

    public string Header { get; set; } = default!;

    public string Description { get; set; } = default!;

    public FormCheckDto ToModel()
    {
		return new FormCheckDto()
		{
			Id = Id,
			AssetUrl = AssetUrl,
			Description = Description,
			Header = Header,
			UserId = UserId
		};
	}

    public static FormCheckEntity FromModel(FormCheckDto model)
    {
		return new FormCheckEntity()
		{
			Id = model.Id,
			AssetUrl = model.AssetUrl,
			Description = model.Description,
			Header = model.Description,
			UserId = model.UserId
		};
	}
}