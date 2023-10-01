using HealthCampus.Services.AppFileAPI.Models;

namespace HealthCampus.Services.AppFileAPI.Data
{
    public class Seeder
    {
        private readonly AppFileDbContext _context;
        private readonly Random _random = new Random();

        public Seeder(AppFileDbContext context)
        {
            _context = context;
        }

        private void SeedFileContentTypes()
        {
            if (_context.FileContentTypes.Any())
            {
                return;
            }
            _context.FileContentTypes.AddRange(
                // Image formats
                new FileContentType { Id = 11, MediaType = "image", SubType = "jpeg", Extension = ".jpg", Description = "Joint Photographic Experts Group" },
                new FileContentType { Id = 12, MediaType = "image", SubType = "jpeg", Extension = ".jpeg", Description = "Joint Photographic Experts Group" },
                new FileContentType { Id = 13, MediaType = "image", SubType = "gif", Extension = ".gif", Description = "Graphics Interchange Format" },
                new FileContentType { Id = 14, MediaType = "image", SubType = "bmp", Extension = ".bmp", Description = "Windows Bitmap" },
                new FileContentType { Id = 15, MediaType = "image", SubType = "tiff", Extension = ".tiff", Description = "Tagged Image File Format" },
                new FileContentType { Id = 16, MediaType = "image", SubType = "webp", Extension = ".webp", Description = "WebP image format" },
                new FileContentType { Id = 17, MediaType = "image", SubType = "svg+xml", Extension = ".svg", Description = "Scalable Vector Graphics" },
                new FileContentType { Id = 18, MediaType = "image", SubType = "x-icon", Extension = ".ico", Description = "Windows Icon file format" },
                new FileContentType { Id = 19, MediaType = "image", SubType = "apng", Extension = ".apng", Description = "Animated Portable Network Graphics" },
                new FileContentType { Id = 20, MediaType = "image", SubType = "avif", Extension = ".avif", Description = "AV1 Image File Format" },
                new FileContentType { Id = 21, MediaType = "image", SubType = "heif", Extension = ".heif", Description = "High Efficiency Image Format (.HEIC/.HEIF)" },
                new FileContentType { Id = 22, MediaType = "image", SubType = "heic", Extension = ".heic", Description = "High Efficiency Image Format (.HEIC/.HEIF)" },
                new FileContentType { Id = 23, MediaType = "image", SubType = "png", Extension = ".png", Description = "Portable Network Graphics" },

                // Application formats
                new FileContentType { Id = 31, MediaType = "application", SubType = "msword", Extension = ".doc", Description = "Microsoft Word" },
                new FileContentType { Id = 32, MediaType = "application", SubType = "vnd.openxmlformats-officedocument.wordprocessingml.document", Extension = ".docx", Description = "Microsoft Word Open XML document" },
                new FileContentType { Id = 33, MediaType = "application", SubType = "vnd.ms-excel", Extension = ".xls", Description = "Microsoft Excel Binary File Format" },
                new FileContentType { Id = 34, MediaType = "application", SubType = "vnd.openxmlformats-officedocument.spreadsheetml.sheet", Extension = ".xlsx", Description = "Microsoft Excel Open XML spreadsheet" },
                new FileContentType { Id = 35, MediaType = "application", SubType = "vnd.ms-powerpoint", Extension = ".ppt", Description = "Microsoft PowerPoint" },
                new FileContentType { Id = 36, MediaType = "application", SubType = "vnd.openxmlformats-officedocument.presentationml.presentation", Extension = ".pptx", Description = "PowerPoint Open XML presentation" },
                new FileContentType { Id = 37, MediaType = "application", SubType = "pdf", Extension = ".pdf", Description = "Portable Document Format" },
                new FileContentType { Id = 38, MediaType = "application", SubType = "rtf", Extension = ".rtf", Description = "Rich Text Format" },
                new FileContentType { Id = 39, MediaType = "application", SubType = "zip", Extension = ".zip", Description = "Compressed ZIP Archive" },
                new FileContentType { Id = 40, MediaType = "application", SubType = "x-rar-compressed", Extension = ".rar", Description = "RAR Archive" },
                new FileContentType { Id = 41, MediaType = "application", SubType = "x-7z-compressed", Extension = ".7z", Description = "7-Zip Archive" },

                // Video formats
                new FileContentType { Id = 51, MediaType = "video", SubType = "avi", Extension = ".avi", Description = "Audio Video Interleave" },
                new FileContentType { Id = 52, MediaType = "video", SubType = "x-flv", Extension = ".flv", Description = "Flash Video" },
                new FileContentType { Id = 53, MediaType = "video", SubType = "x-ms-wmv", Extension = ".wmv", Description = "Windows Media Video" },
                new FileContentType { Id = 54, MediaType = "video", SubType = "quicktime", Extension = ".mov", Description = "QuickTime" },
                new FileContentType { Id = 55, MediaType = "video", SubType = "mp4", Extension = ".mp4", Description = "MPEG" },
                new FileContentType { Id = 56, MediaType = "video", SubType = "ogg", Extension = ".ogg", Description = "Ogg" },
                new FileContentType { Id = 57, MediaType = "video", SubType = "x-m4v", Extension = ".m4v", Description = "MPEG-4 Part 14 video file format" },
                new FileContentType { Id = 58, MediaType = "video", SubType = "x-matroska", Extension = ".mkv", Description = "Matroska Multimedia BlobContainer" },

                //Audio formats
                new FileContentType { Id = 61, MediaType = "audio", SubType = "mpeg", Extension = ".mp3", Description = "MPEG-1 or MPEG-2 Audio Layer III" },
                new FileContentType { Id = 62, MediaType = "audio", SubType = "wav", Extension = ".wav", Description = "Waveform Audio File Format" },
                new FileContentType { Id = 63, MediaType = "audio", SubType = "x-ms-wma", Extension = ".wma", Description = "Windows Media Audio" },
                new FileContentType { Id = 64, MediaType = "audio", SubType = "aac", Extension = ".aac", Description = "Advanced Audio Codec" },
                new FileContentType { Id = 65, MediaType = "audio", SubType = "aiff", Extension = ".aiff", Description = "Audio Interchange File Format" },

                //Text formats
                new FileContentType { Id = 71, MediaType = "text", SubType = "csv", Extension = ".csv", Description = "Comma-Separated Values" },
                new FileContentType { Id = 72, MediaType = "text", SubType = "plain", Extension = ".txt", Description = "Plain text" },
                new FileContentType { Id = 73, MediaType = "text", SubType = "html", Extension = ".html", Description = "HyperText Markup Language" }
            );
            _context.SaveChanges();
        }


        public void SeedData()
        {
            SeedFileContentTypes();
        }

        Stack<int> getRandomNumberStack(int minValue, int maxValue)
        {
            Stack<int> numbers = new Stack<int>(Enumerable.Range(minValue, maxValue).OrderBy(x => _random.Next()).Take(maxValue - minValue));
            return numbers;
        }
    }
}
