using Azure.Storage.Blobs.Models;

namespace HealthCampus.Services.AppFileAPI.Services
{
    public interface IBlobService
    {
        public Task<BlobDownloadResult> GetBlobAsync(string name);

        public Task<List<string>> ListBlobAsync();

        public Task UploadFileBlobAsync(string fileName, Stream fileStreamData, string fileType);

        public Task DeleteBlobAsync(string name);
    }
}
