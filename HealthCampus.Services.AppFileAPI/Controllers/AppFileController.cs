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
        private readonly IAppFileManagerService _appFileManager;

        public AppFileController(IAppFileManagerService appFileManagerService)
        {
            _appFileManager = appFileManagerService;
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<List<AppFile>>> GetAppFilesAsync()
        {
            var appFiles = await _appFileManager.GetAllAsync();
            return Ok(appFiles);
        }

        [HttpGet]
        [Route("Get/Id/{id}")]
        public async Task<ActionResult<AppFile>> Get(Guid id)
        {
            var appFile = await _appFileManager.GetAsync(id);
            return Ok(appFile);
        }

        [HttpPost]
        [Route("Upload")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<ActionResult> Upload([FromForm] AppFileRequestDto request)
        {
            var appUserId = User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
            if (appUserId == null)
                throw new NotFoundException("User does not exist.");

            var appFileId = await _appFileManager.UploadAsync(request, new Guid(appUserId));

            return Created(String.Empty, null);
        }


        [HttpDelete]
        [Route("Delete/Id/{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(Guid id)
        {
            var appUserId = User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
            if (appUserId == null)
                throw new NotFoundException("User does not exist.");

            await _appFileManager.DeleteAsync(id, new Guid(appUserId));

            return NoContent();
        }


        [HttpGet]
        [Route("Download/Id/{id}")]
        public async Task<ActionResult<string>> Download(Guid id)
        {
            var file = await _appFileManager.DownloadAsync(id);
            if (file == null)
                throw new NotFoundException("File not found");
            var fileInBase64 = Convert.ToBase64String(file.FileContents);

            return Ok(fileInBase64);
        }

    }
}
