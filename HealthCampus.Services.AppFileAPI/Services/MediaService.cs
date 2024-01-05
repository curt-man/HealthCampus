using HealthCampus.Services.AppFileAPI.Services.IService;
using MediaInfo;
using System.Drawing;
using System.Drawing.Imaging;

namespace HealthCampus.Services.AppFileAPI.Services
{
    public class MediaService : IMediaService
    {
        public int GetMediaFileDuration(Stream fileContentStream)
        {
            var file = new MediaInfoWrapper(fileContentStream);

            if (!file.Success)
            {
                throw new ArgumentException("Media file is corrupted");
            }

            int duration = file.Duration / 1000;
            return duration;
        }

        public Stream CompressImage(Stream imageStream)
        {
            // Load the image from the stream
            Image image = Image.FromStream(imageStream);

            // Get the codec info for JPEG images
            ImageCodecInfo jpegCodec = ImageCodecInfo.GetImageEncoders().First(codec => codec.FormatID == ImageFormat.Jpeg.Guid);

            // Set the quality parameter to 50 to compress the image to half its size
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 50L);

            // Create a memory stream to store the compressed image
            MemoryStream compressedStream = new MemoryStream();
            // Save the compressed image to the memory stream
            image.Save(compressedStream, jpegCodec, encoderParams);
            compressedStream.Position = 0;
            // Return the compressed image as a byte array
            return compressedStream;
        }


    }
}
