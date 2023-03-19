using Azure.Storage.Blobs;

namespace Domains.FormCheck.Persistence.Media
{
	internal class AzureStorageFormCheckMediaRepository : IFormCheckMediaRepository
	{
		private readonly BlobServiceClient _blobServiceClient;

		public AzureStorageFormCheckMediaRepository(BlobServiceClient blobServiceClient)
		{
			_blobServiceClient = blobServiceClient;
		}

		public Task<string> Persist(Stream mediaStream)
		{
			throw new NotImplementedException();
		}
	}
}