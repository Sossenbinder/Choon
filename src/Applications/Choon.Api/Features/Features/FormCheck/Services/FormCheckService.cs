using Ardalis.Result;
using Choon.Api.Features.Features.FormCheck.Persistence;

namespace Choon.Api.Features.Features.FormCheck.Services;

public class FormCheckService(
    FormCheckMediaRepository formCheckMediaRepository,
    FormCheckRepository formCheckRepository)
{
    public async Task<Result> Add(string fileName, Stream stream)
    {
		try
		{
			var assetUri = await formCheckMediaRepository.Persist(fileName, stream);

			var model = new Models.FormCheckDto()
			{
				AssetUrl = assetUri.ToString()
			};

			await formCheckRepository.Store(model);

			return Result.Success();
		}
		catch (Exception ex)
		{
			return Result.Error(ex.Message);
		}
	}
}