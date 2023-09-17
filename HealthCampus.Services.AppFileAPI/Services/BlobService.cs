using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using HealthCampus.Services.AppFileAPI.Services.IService;

namespace HealthCampus.Services.AppFileAPI.Services;

public class BlobService : IBlobService
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    public async Task<BlobDownloadResult> GetBlobAsync(string blobName, string container)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(container);
        var blobClient = containerClient.GetBlobClient(blobName);
        var blobDownloadResult = await blobClient.DownloadContentAsync();
        var blob = blobDownloadResult.Value;
        return blob;
    }

    public async Task UploadFileBlobAsync(string blobName, Stream blobStreamData, string blobContentType, string container)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(container);
        var blobClient = containerClient.GetBlobClient(blobName);
        await blobClient.UploadAsync(blobStreamData, new BlobHttpHeaders { ContentType = blobContentType });

    }

    public async Task DeleteBlobAsync(string blobName, string container)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(container);
        var blobClient = containerClient.GetBlobClient(blobName);
        await blobClient.DeleteIfExistsAsync();
    }

}