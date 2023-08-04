using FluentResults;

namespace Domains.FormCheck.Services
{
	public interface IFormCheckService
	{
		Task<Result> Add(string fileName, Stream stream);
	}
}