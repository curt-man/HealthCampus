namespace HealthCampus.Services.AppFileAPI.Services
{
    public interface IMediaService
    {
        public Stream CompressImage(Stream imageStream);
        public int GetMediaFileDuration(Stream fileContentStream, ILogger logger);
    }
}