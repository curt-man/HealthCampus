namespace HealthCampus.Services.AppFileAPI.Services.IService
{
    public interface IMediaService
    {
        public Stream CompressImage(Stream imageStream);
        public int GetMediaFileDuration(Stream fileContentStream);
    }
}