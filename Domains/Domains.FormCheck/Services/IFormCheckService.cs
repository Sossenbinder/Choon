namespace Domains.FormCheck.Services
{
	public interface IFormCheckService
	{
		Task Add(string fileName, Stream stream);
	}
}