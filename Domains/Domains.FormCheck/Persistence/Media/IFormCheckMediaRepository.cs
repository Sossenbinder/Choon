namespace Domains.FormCheck.Persistence.Media
{
	internal interface IFormCheckMediaRepository
	{
		Task<string> Persist(Stream mediaStream);
	}
}