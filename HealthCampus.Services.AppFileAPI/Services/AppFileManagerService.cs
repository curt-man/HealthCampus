using AutoMapper;
using HealthCampus.Services.AppFileAPI.Controllers;
using HealthCampus.Services.AppFileAPI.Data;
using HealthCampus.Services.AppFileAPI.Models.Dto;
using HealthCampus.Services.AppFileAPI.Services.IService;
using Microsoft.AspNetCore.Identity;
using System.Data.Entity;

namespace HealthCampus.Services.AppFileAPI.Services
{
    public class AppFileManagerService : IAppFileManagerService
    {
        private readonly IBlobService _blobService;
        private readonly IMediaService _mediaService;
        private readonly IMapper _mapper;
        private readonly ILogger<AppFileController> _logger;
        private readonly AppFileDbContext _dbContext;

        public AppFileManagerService(IBlobService blobService, IMediaService mediaService, IMapper mapper, ILogger<AppFileController> logger, AppFileDbContext dbContext)
        {
            _blobService = blobService;
            _mediaService = mediaService;
            _mapper = mapper;
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<List<AppFileResponseDto>> GetAppFilesAsync()
        {
            var appFiles = new List<AppFileResponseDto>();
            await foreach (var appFile in _dbContext.AppFiles.AsAsyncEnumerable())
            {
                appFiles.Add(AppFileResponseDto.FromAppFile(appFile));
            }
            return appFiles;

        }
    }
}
