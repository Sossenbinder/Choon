namespace Domains.FormCheck.Persistence.Media
{
	internal interface IFormCheckMediaRepository
	{
		Task<Uri> Persist(string fileName, Stream mediaStream);
	}
}