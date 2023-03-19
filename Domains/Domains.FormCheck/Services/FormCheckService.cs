using Domains.FormCheck.Persistence.Media;

namespace Domains.FormCheck.Services
{
	internal class FormCheckService : IFormCheckService
	{
		private readonly IFormCheckMediaRepository _formCheckMediaRepository;

		public FormCheckService(IFormCheckMediaRepository formCheckMediaRepository)
		{
			_formCheckMediaRepository = formCheckMediaRepository;
		}

		public async Task Add(Stream stream)
		{
			await _formCheckMediaRepository.Persist(stream);
		}
	}
}