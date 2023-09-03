using AutoMapper;
using HealthCampus.Services.AppFileAPI.Data;
using HealthCampus.Services.AppFileAPI.Models;
using HealthCampus.Services.AppFileAPI.Models.Dto;
using HealthCampus.Services.AppFileAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Data.Entity.Core;
using System.Drawing;
using System.IO.Compression;
using HealthCampus.Services.AppFileAPI.Utilities;
using static System.Net.WebRequestMethods;
using HealthCampus.CommonUtilities.Dto;

namespace HealthCampus.Services.AppFileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppFileController : ControllerBase
    {
        private ResponseDto response = new ResponseDto();

        private void SetErrorMessageToResponse(string message)
        {
            response.IsSuccess = false;
            response.Message = message;
        }

        private readonly IBlobService _blobService;
        private readonly IMediaService _mediaService;
        private readonly AppFileDbContext _context;
        private readonly IMapper _mapper;
        private ILogger<AppFileController> _logger;


        public AppFileController(IBlobService blobService, AppFileDbContext appFileDbContext, IMapper mapper, ILogger<AppFileController> logger, IMediaService mediaService)
        {
            _blobService = blobService;
            _context = appFileDbContext;
            _mapper = mapper;
            _logger = logger;
            _mediaService = mediaService;
        }

        [HttpGet("{fileId}")]
        public async Task<ResponseDto> GetAppFile(string fileId)
        {
            try
            {
                var appFile = await _context.AppFiles.FirstOrDefaultAsync(x => x.Id.ToString() == fileId);

                response.Result = _mapper.Map<AppFileResponseDto>(appFile);
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return response;
        }

        [HttpGet("list")]
        public async Task<ResponseDto> GetListOfAppFiles()
        {
            try
            {
                var appFiles = await _context.AppFiles.ToListAsync();
                response.Result = _mapper.Map<IEnumerable<AppFileResponseDto>>(appFiles);
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return response;
        }


        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<ResponseDto> UploadAppFile([FromForm] AppFileRequestDto request)
        {
            try
            {
                // check if user exists
                ////////////////////////
                AppFile? appFile;
                IFormFile file = request.FormFile;

                if (file == null || file.Length == 0)
                {
                    throw new ArgumentNullException(nameof(file), "File is not attached");

                }

                else
                {
                    Guid appFileGuid;
                    if (request!.BlobName == null)
                    {
                        appFileGuid = Guid.NewGuid();
                        appFile = new AppFile()
                        {
                            Id = appFileGuid,
                            UploadedAt = DateTime.UtcNow,
                            UploadedByUserId = request.UserId
                        };
                    }
                    else
                    {
                        appFileGuid = (Guid)(request!.BlobName);
                        appFile = await _context.AppFiles.FirstOrDefaultAsync(x =>
                            x.Id == request!.BlobName);

                        if (appFile == null)
                        {
                            throw new ObjectNotFoundException("File not found");
                        }
                        else
                        {
                            appFile.ModifiedAt = DateTime.UtcNow;
                            appFile.ModifiedByUserId = request.UserId;
                        }

                    }

                    int fileSize = Convert.ToInt32(file.Length / 1024L);
                    string fileOriginalName = file.FileName;
                    string fileExtension = Path.GetExtension(file.FileName);

                    FileContentType? fileContentType = _context.FileContentTypes.FirstOrDefault(x => x.Extension == fileExtension);
                    if (fileContentType == null)
                    {
                        throw new ArgumentException(nameof(file), "File extension is not supported");
                    }

                    if (fileContentType.MediaType == MediaType.Audio || fileContentType.MediaType == MediaType.Video)
                    {
                        using (var stream = file.OpenReadStream())
                        {
                            int fileDuration = _mediaService.GetMediaFileDuration(stream, _logger);
                            appFile.Duration = fileDuration;
                        }
                    }

                    //if (fileContentType.MediaType == MediaType.Image)
                    //{
                    //    using (Stream compressedImage = _mediaService.CompressImage(file.OpenReadStream()))
                    //    {
                    //        await _blobService.UploadFileBlobAsync(appFileGuid.ToString(), compressedImage, file.ContentType, request.Container);
                    //        appFile.ThumbnailUrl = $"https://{request.StorageAccount}.blob.core.windows.net/{request.Container}/{appFileGuid}.thumbnail";
                    //    }
                    //}

                    await _blobService.UploadFileBlobAsync(appFileGuid.ToString(), file.OpenReadStream(), file.ContentType, request.Container);
                    appFile.Url = $"https://{request.StorageAccount}.blob.core.windows.net/{request.Container}/{appFileGuid}";

                    appFile.BlobContainer = request.Container;
                    appFile.ContentTypeId = fileContentType.Id;
                    appFile.OriginalName = fileOriginalName;
                    appFile.Size = fileSize;

                    if (request.BlobName == null)
                    {
                        await _context.AppFiles.AddAsync(appFile);
                    }
                    else
                    {
                        _context.AppFiles.Update(appFile);
                    }
                    await _context.SaveChangesAsync();

                    response.Result = appFile;
                }
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return response;
        }



    }
}
