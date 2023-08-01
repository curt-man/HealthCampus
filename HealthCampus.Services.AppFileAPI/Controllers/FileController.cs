using AutoMapper;
using Azure.Core;
using HealthCampus.Services.AppFileAPI.Data;
using HealthCampus.Services.AppFileAPI.Models.Dto;
using HealthCampus.Services.AppFileAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCampus.Services.AppFileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IBlobService _blobService;
        private ResponseDto _response = new();
        private readonly AppFileDbContext _context;
        private readonly IMapper _mapper;

        public FileController(IBlobService blobService, AppFileDbContext appFileDbContext, IMapper mapper)
        {
            _blobService = blobService;
            _context = appFileDbContext;
            _mapper = mapper;
        }

        [HttpGet("{fileId}")]
        public async Task<ResponseDto> GetFile(AppFileRequestDto request)
        {
            try
            {
                var blob = await _blobService.GetBlobAsync(request.BlobName.ToString()!, request.Container);
                _response.Result = File(blob.Content.ToArray(), blob.Details.ContentType);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


    }
}
