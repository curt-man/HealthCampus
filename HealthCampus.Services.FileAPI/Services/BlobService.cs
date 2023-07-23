using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using HealthCampus.Services.FileAPI.Services;

namespace HealthCampus.Services.FileAPI.Services;

public class BlobService : IBlobService
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    public async Task<BlobItem> GetBlobAsync(string name)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("profilePictures");
        var blobClient = containerClient.GetBlobClient(name);
        var blobDownloadInfo = await blobClient.DownloadContentAsync();
        var blobInfo = blobDownloadInfo.Value;
        return new BlobItem();
    }

    public async Task DeleteBlobAsync(string name)
    {
        
        throw new NotImplementedException();
    }


    public async Task<List<string>> ListBlobAsync()
    {
        throw new NotImplementedException();
    }

    public async Task UploadFileBlobAsync(string filePath, string fileName)
    {
        throw new NotImplementedException();
    }

    public async Task UploadStreamBlobAsync(Stream stream, string fileName)
    {
        throw new NotImplementedException();
    }
}