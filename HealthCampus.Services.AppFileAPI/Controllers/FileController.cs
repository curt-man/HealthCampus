using AutoMapper;
using Azure.Core;
using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AppFileAPI.Data;
using HealthCampus.Services.AppFileAPI.Models.Dto;
using HealthCampus.Services.AppFileAPI.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCampus.Services.AppFileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        private readonly IAppFileManagerService _appFileManager;

        public FileController(IAppFileManagerService appFileManager)
        {
            _appFileManager = appFileManager;
        }

        [HttpGet]
        [Route("Download/Id/{id}")]
        public async Task<FileContentResult?> Download(Guid id)
        {
            FileContentResult? result = null;
            try
            {
                var file = await _appFileManager.DownloadAsync(id);
                result = file;
            }
            catch (Exception)
            {

            }
            return result;
        }


    }
}
