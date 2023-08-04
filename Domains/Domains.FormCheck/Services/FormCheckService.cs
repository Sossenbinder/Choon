using Domains.FormCheck.Persistence;
using Domains.FormCheck.Persistence.Media;

namespace Domains.FormCheck.Services
{
	internal class FormCheckService : IFormCheckService
	{
		private readonly IFormCheckMediaRepository _formCheckMediaRepository;

		private readonly IFormCheckRepository _formCheckRepository;

		public FormCheckService(
			IFormCheckMediaRepository formCheckMediaRepository,
			IFormCheckRepository formCheckRepository)
		{
			_formCheckMediaRepository = formCheckMediaRepository;
			_formCheckRepository = formCheckRepository;
		}

		public async Task Add(string fileName, Stream stream)
		{
			try
			{
				var assetUri = await _formCheckMediaRepository.Persist(fileName, stream);

				var model = new Models.FormCheckDto()
				{
					AssetUrl = assetUri.ToString()
				};

				await _formCheckRepository.Store(model);
			}
			catch (Exception ex)
			{
			}
		}
	}
}