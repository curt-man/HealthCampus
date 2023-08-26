using AutoMapper;
using HealthCampus.CommonUtilities.Dto;
using HealthCampus.Services.AuthenticationServiceAPI.Data;
using HealthCampus.Services.AuthenticationServiceAPI.Models;
using HealthCampus.Services.AuthenticationServiceAPI.Models.Dto;
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

        private readonly JwtConfig _jwtConfig;
        private readonly AuthenticationDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationController(IOptions<JwtConfig> jwtConfig, UserManager<AppUser> userManager, AuthenticationDbContext authenticationDbContext)
        {
            _jwtConfig = jwtConfig.Value;
            _userManager = userManager;
            _dbContext = authenticationDbContext;
            _response = new ResponseDto();
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<ResponseDto>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();
                _response.Result = users;
            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return Ok(_response);
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

                var jwtToken = GenerateJwtToken(user);
                _response.Message = jwtToken;

            }
            catch (Exception ex)
            {
                SetErrorMessageToResponse(ex.Message);
            }
            return Ok(_response);
        }

        [NonAction]
        private string GenerateJwtToken(AppUser user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.SecretKey);
            var listOfClaims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Iss, _jwtConfig.Issuer),
                new Claim(JwtRegisteredClaimNames.Aud, _jwtConfig.Audience),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            };
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(listOfClaims),
                Expires = DateTime.UtcNow.Add(_jwtConfig.ExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = jwtHandler.CreateToken(tokenDescriptor);
            var jwt = jwtHandler.WriteToken(securityToken);
            return jwt;
        }


        //[HttpPost("login")]
        //public async Task<ResponseDto> LoginAsync([FromBody] UserLoginDto userLoginDto)
        //{
        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(userLoginDto.Email, userLoginDto.Password, false, false);

        //        if (!result.Succeeded)
        //        {
        //            SetErrorMessageToResponse("Invalid login attempt!");
        //        }
        //        else
        //        {
        //            _response.IsSuccess = true;
        //            _response.Result = "User logged in successfully!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SetErrorMessageToResponse(ex.Message);
        //    }
        //    return _response;
        //}

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
