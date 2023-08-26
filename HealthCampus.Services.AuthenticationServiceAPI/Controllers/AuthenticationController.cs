using AutoMapper;
using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AuthenticationServiceAPI.Data;
using HealthCampus.Services.AuthenticationServiceAPI.Models;
using HealthCampus.Services.AuthenticationServiceAPI.Models.Dto;
using HealthCampus.Services.AuthenticationServiceAPI.Services;
using HealthCampus.Services.AuthenticationServiceAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NAudio.SoundFont;
using System.Drawing.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Text;
using System.Xml;

namespace HealthCampus.Services.AuthenticationServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ResponseDto _response;

        private void SetErrorMessageToResponse(string message)
        {
            _response.IsSuccess = false;
            _response.Message = message;
        }

        private readonly JwtService _jwtService;
        private readonly AuthenticationDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public AuthenticationController(UserManager<AppUser> userManager, AuthenticationDbContext authenticationDbContext, RoleManager<IdentityRole<Guid>> roleManager, JwtService jwtService)
        {
            _userManager = userManager;
            _dbContext = authenticationDbContext;
            _roleManager = roleManager;
            _response = new ResponseDto();
            _jwtService = jwtService;
        }


        [HttpGet]
        [Route("GetLanguages")]
        public async Task<ActionResult<ResponseDto>> GetLanguagesAsync()
        {
            try
            {
                var languages = await _dbContext.Languages.ToListAsync();
                _response.Result = languages;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return Ok(_response);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<ResponseDto>> RegisterAsync([FromBody] AppUserRegistrationRequestDto request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.EmailAddress);
                if (user != null)
                {
                    throw new Exception("User already exists!");
                }
                user = new AppUser()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.EmailAddress,
                    UserName = request.EmailAddress,
                    RegistrationDate = DateTime.UtcNow
                };

                if (!(await _roleManager.RoleExistsAsync(request.AppRole)))
                {
                    throw new ArgumentException(request.AppRole);
                }
                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    string errors = string.Empty;
                    foreach (var error in result.Errors)
                    {
                        errors += error.Description + Environment.NewLine;
                    }
                    throw new ArgumentException(errors);
                }

                result = await _userManager.AddToRoleAsync(user, request.AppRole);
                if (!result.Succeeded)
                {
                    string errors = string.Empty;
                    foreach (var error in result.Errors)
                    {
                        errors += error.Description + Environment.NewLine;
                    }
                    throw new ArgumentException(errors);
                }
                _response.Result = user;

                var jwtToken = _jwtService.GenerateJwtToken(user);
                _response.Message = jwtToken;

            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return Ok(_response);
        }



        [HttpPost("login")]
        public async Task<ResponseDto> LoginAsync([FromBody] AppUserLoginRequestDto request)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userLoginDto.Email, userLoginDto.Password, false, false);

                if (!result.Succeeded)
                {
                    SetErrorMessageToResponse("Invalid login attempt!");
                }
                else
                {
                    _response.IsSuccess = true;
                    _response.Result = "User logged in successfully!";
                }
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return _response;
        }

        //[HttpPost("logout")]
        //public async Task<ResponseDto> LogoutAsync()
        //{
        //    try
        //    {
        //        await _signInManager.SignOutAsync();
        //        _response.IsSuccess = true;
        //        _response.Result = "User logged out successfully!";
        //    }
        //    catch (Exception ex)
        //    {
        //        SetErrorMessageToResponse(ex.Message);
        //    }
        //    return _response;
        //}
    }
}
