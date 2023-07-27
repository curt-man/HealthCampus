using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using HealthCampus.Services.AppFileAPI.Services;

namespace HealthCampus.Services.AppFileAPI.Services;

public class BlobService : IBlobService
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    public async Task<BlobDownloadResult> GetBlobAsync(string name)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("profilepictures");
        var blobClient = containerClient.GetBlobClient(name);
        var blobDownloadResult = await blobClient.DownloadContentAsync();
        var blob = blobDownloadResult.Value;
        return blob;
    }

    public async Task<List<string>> ListBlobAsync()
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("profilepictures");
        var items = new List<string>();
        await foreach (var blobItem in containerClient.GetBlobsAsync())
        {
            items.Add(blobItem.Name);
        }
        return items;
    }


    public async Task UploadFileBlobAsync(string fileName, Stream fileStreamData, string fileType)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("profilepictures");
        var blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.UploadAsync(fileStreamData, new BlobHttpHeaders { ContentType = fileType });

    }

    public async Task DeleteBlobAsync(string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("profilepictures");
        var blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.DeleteIfExistsAsync();
    }

}