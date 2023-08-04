namespace Domains.FormCheck.Models
{
	internal class FormCheckDto
	{
		public string UserId { get; set; }

		public int Id { get; set; }

		public string AssetUrl { get; set; }

		public string Header { get; set; } = default!;

		public string Description { get; set; } = default!;
	}
}