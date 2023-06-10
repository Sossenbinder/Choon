using Domains.FormCheck.Models;

namespace Domains.FormCheck.Persistence.Entities
{
	internal class FormCheckEntity
	{
		public int Id { get; set; }

		public string AssetUrl { get; set; } = default!;

		public FormCheckDto ToModel()
		{
			return new FormCheckDto()
			{
				Id = Id,
				AssetUrl = AssetUrl,
			};
		}

		public static FormCheckEntity FromModel(FormCheckDto model)
		{
			return new FormCheckEntity()
			{
				Id = model.Id,
				AssetUrl = model.AssetUrl,
			};
		}
	}
}