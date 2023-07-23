using Azure.Storage.Blobs.Models;

namespace HealthCampus.Services.FileAPI.Services
{
    public interface IBlobService
    {
        public Task<BlobInfo> GetBlobAsync(string name);

        public Task<List<string>> ListBlobAsync();

        public Task UploadFileBlobAsync(string filePath, string fileName);

        public Task UploadStreamBlobAsync(Stream stream, string fileName);

        public Task DeleteBlobAsync(string name);
    }
}
