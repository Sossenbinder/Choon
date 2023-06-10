using Domains.FormCheck.Models;

namespace Domains.FormCheck.Persistence
{
	internal interface IFormCheckRepository
	{
		Task<FormCheckDto> Store(FormCheckDto formCheckDto);
	}
}