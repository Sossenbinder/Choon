using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Common.Utils;

namespace Domains.FormCheck.Persistence.Media
{
	internal class AzureStorageFormCheckMediaRepository : IFormCheckMediaRepository
	{
		private readonly AsyncLazy<BlobContainerClient> _blobContainerClient;

		public AzureStorageFormCheckMediaRepository(BlobServiceClient blobServiceClient)
		{
			_blobContainerClient = new AsyncLazy<BlobContainerClient>(async () =>
			{
				var client = blobServiceClient.GetBlobContainerClient("formcheckmedia");

				await client.CreateIfNotExistsAsync(PublicAccessType.Blob);

				return client;
			});
		}

		public async Task<Uri> Persist(string fileName, Stream mediaStream)
		{
			var containerClient = await _blobContainerClient;

			fileName = fileName[..fileName.LastIndexOf('.')];

			var blobClient = containerClient.GetBlobClient(fileName);

			await blobClient.UploadAsync(mediaStream, true);

			return blobClient.Uri;
		}
	}
}