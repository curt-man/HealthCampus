using AutoMapper;
using Azure;
using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Data;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Models.Dtos;
using HealthCampus.Services.AppUserAPI.Services.IServices;
using HealthCampus.Services.AppUserAPI.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.AppUserAPI.Services
{
    public class AppUserManagerService : IAppUserManagerService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGeneratorService _jwtGenerator;

        public AppUserManagerService(UserManager<AppUser> userManager, IJwtGeneratorService jwtGenerator)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }


        public async Task<List<AppUserResponseDto>> GetAll()
        {
            var users = new List<AppUserResponseDto>();
            await foreach (var user in _userManager.Users.AsAsyncEnumerable())
            {
                users.Add(AppUserResponseDto.FromAppUser(user));
            }
            return users;
        }

        public async Task<AppUserResponseDto> Get(Guid id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new Exception();
            }
            var dto = AppUserResponseDto.FromAppUser(user);
            return dto;
        }

        public async Task<AppUserResponseDto> Get(string username)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
            {
                throw new Exception();
            }
            var dto = AppUserResponseDto.FromAppUser(user);
            return dto;
        }

        public async Task<AppUser> Register<T>(T request) where T : IAppUserRegisterRequestDto
        {
            var user = await _userManager.FindByEmailAsync(request.EmailAddress);
            if (user != null)
            {
                throw new Exception("User already exists!");
            }

            user = T.ToAppUser(request);

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

            return user;
        }

        public async Task AssignRole(AppUserAssignRoleRequestDto dto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == dto.UserId);
            if(user==null)
            {
                throw new Exception("User does not exist.");
            }

            var result = await _userManager.AddToRoleAsync(user, dto.Role.ToString());

            if (!result.Succeeded)
            {
                string errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += error.Description + Environment.NewLine;
                }
                throw new ArgumentException(errors);
            }
        }

        public async Task AssignRole(AppUser user, RolesEnum role)
        {

            var result = await _userManager.AddToRoleAsync(user, role.ToString());

            if (!result.Succeeded)
            {
                string errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += error.Description + Environment.NewLine;
                }
                throw new ArgumentException(errors);
            }
        }

        public async Task<string> LogIn(AppUserLoginRequestDto request)
        {
            AppUser? user = request.EmailOrUsername.Contains("@")
                ? await _userManager.FindByEmailAsync(request.EmailOrUsername)
                : await _userManager.FindByNameAsync(request.EmailOrUsername);


            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            var roles = await _userManager.GetRolesAsync(user);

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                throw new Exception("Invalid credentials");
            }

            string token = _jwtGenerator.GenerateToken(user, roles);
            return token;
        }


        public async Task<string> LogIn(AppUser user, string password)
        {

            var roles = await _userManager.GetRolesAsync(user);

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);

            if (!isPasswordValid)
            {
                throw new Exception("Invalid credentials");
            }

            string token = _jwtGenerator.GenerateToken(user, roles);
            return token;
        }

        public async Task Update(AppUserUpdateRequestDto dto)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if(user == null)
            {
                throw new Exception("User does not exist!");
            }
            AppUserUpdateRequestDto.MapToAppUser(dto, user);

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                string errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += error.Description + Environment.NewLine;
                }
                throw new ArgumentException(errors);
            }

        }

        public async Task Delete(Guid appUserId)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == appUserId);
            if (user == null)
            {
                throw new Exception("User does not exist!");
            }
            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                string errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += error.Description + Environment.NewLine;
                }
                throw new ArgumentException(errors);
            }
        }



    }
}
