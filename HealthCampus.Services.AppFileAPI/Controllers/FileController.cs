using AutoMapper;
using Azure.Core;
using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AppFileAPI.Data;
using HealthCampus.Services.AppFileAPI.Models.Dto;
using HealthCampus.Services.AppFileAPI.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCampus.Services.AppFileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private ResponseDto response = new ResponseDto();

        private void SetErrorMessageToResponse(string message)
        {
            response.IsSuccess = false;
            response.Message = message;
        }

        private readonly IBlobService _blobService;
        private readonly AppFileDbContext _context;
        private readonly IMapper _mapper;

        public FileController(IBlobService blobService, AppFileDbContext appFileDbContext, IMapper mapper)
        {
            _blobService = blobService;
            _context = appFileDbContext;
            _mapper = mapper;
        }

        [HttpGet("Get/Id/{id}")]
        public async Task<ResponseDto> GetFile(AppFileRequestDto request)
        {
            try
            {
                var blob = await _blobService.GetBlobAsync(request.BlobName.ToString()!, request.Container);
                response.Result = File(blob.Content.ToArray(), blob.Details.ContentType);
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return response;
        }


    }
}
