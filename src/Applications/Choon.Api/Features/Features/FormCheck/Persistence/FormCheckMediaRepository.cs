using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Choon.Api.Features.Common.Util;

namespace Choon.Api.Features.Features.FormCheck.Persistence;

public class FormCheckMediaRepository
{
    private readonly AsyncLazy<BlobContainerClient> _blobContainerClient;

    public FormCheckMediaRepository(BlobServiceClient blobServiceClient)
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