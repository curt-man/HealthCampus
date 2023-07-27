using HealthCampus.Services.AppFileAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCampus.Services.AppFileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppFileController : ControllerBase
    {
        private readonly IBlobService _blobService;

        public AppFileController(IBlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetFile(string fileName)
        {
            var blob = await _blobService.GetBlobAsync(fileName);
            return File(blob.Content.ToArray(), blob.Details.ContentType);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<string>>> GetFiles()
        {
            var namesOfBlobs = await _blobService.ListBlobAsync();
            return Ok(namesOfBlobs);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("File not selected");

            await _blobService.UploadFileBlobAsync(file.FileName, file.OpenReadStream(), file.ContentType);
            return Content("File uploaded successfully");
        }

        [HttpPost("delete/{fileName}")]
        public async Task<IActionResult> DeleteFile(string fileName)
        {
            await _blobService.DeleteBlobAsync(fileName);
            return Content("File deleted successfully");
        }

    }
}
