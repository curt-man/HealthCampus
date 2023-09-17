using Azure.Storage.Blobs.Models;

namespace HealthCampus.Services.AppFileAPI.Services.IService
{
    public interface IBlobService
    {

        public Task DeleteBlobAsync(string blobName, string container);
        public Task<BlobDownloadResult> GetBlobAsync(string blobName, string container);
        public Task UploadFileBlobAsync(string blobName, Stream blobStreamData, string blobContentType, string container);

        //public Task<FileStream> DownloadBlobAsync(string fileId);

    }
}
