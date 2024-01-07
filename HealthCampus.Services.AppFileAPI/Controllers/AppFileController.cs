using AutoMapper;
using HealthCampus.Services.AppFileAPI.Data;
using HealthCampus.Services.AppFileAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Data.Entity.Core;
using System.Drawing;
using System.IO.Compression;
using HealthCampus.Services.AppFileAPI.Utilities;
using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AppFileAPI.Services.IService;
using Microsoft.AspNetCore.Authorization;
using HealthCampus.Services.AppFileAPI.Services;
using System.Data.Entity;
using HealthCampus.Services.AppFileAPI.Dtos;
using HealthCampus.CommonUtilities.Exceptions;

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

        private readonly IAppFileManagerService _appFileManager;

        public AppFileController(IAppFileManagerService appFileManagerService)
        {
            _appFileManager = appFileManagerService;
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ResponseDto> GetAppFilesAsync()
        {
            try
            {
                var appFiles = await _appFileManager.GetAllAsync();

                response.Result = appFiles;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Get/Id/{id}")]
        public async Task<ResponseDto> Get(Guid id)
        {
            try
            {
                var appFile = await _appFileManager.GetAsync(id);

                response.Result = appFile;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("Upload")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<ResponseDto> Upload([FromForm] AppFileRequestDto request)
        {
            try
            {
                var appUserId = User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
                if (appUserId == null)
                    throw new NotFoundException("User does not exist.");

                var appFileId = await _appFileManager.UploadAsync(request, new Guid(appUserId));
                response.Result = appFileId;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return response;
        }


        [HttpDelete]
        [Route("Delete/Id/{id}")]
        [Authorize]
        public async Task<ResponseDto> Delete(Guid id)
        {
            try
            {
                var appUserId = User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
                if (appUserId == null)
                    throw new NotFoundException("User does not exist.");

                await _appFileManager.DeleteAsync(id, new Guid(appUserId));
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return response;
        }


        [HttpGet]
        [Route("Download/Id/{id}")]
        public async Task<ResponseDto> Download(Guid id)
        {
            try
            {
                var file = await _appFileManager.DownloadAsync(id);
                response.Result = file;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return response;
        }

    }
}
