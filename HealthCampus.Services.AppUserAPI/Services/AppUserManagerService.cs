using AutoMapper;
using Azure;
using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Data;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Models.Dtos;
using HealthCampus.Services.AppUserAPI.Models.Dtos.Mappers;
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


        public async Task<List<AppUserResponseDto>> GetAllAsync()
        {
            var users = new List<AppUserResponseDto>();
            await foreach (var user in _userManager.Users.AsAsyncEnumerable())
            {
                users.Add(user.ToAppUserResponse());
            }
            return users;
        }

        public async Task<AppUserResponseDto> GetAsync(Guid id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new Exception();
            }
            var dto = user.ToAppUserResponse();
            return dto;
        }

        public async Task<AppUserResponseDto> GetAsync(string username)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
            {
                throw new Exception();
            }
            var dto = user.ToAppUserResponse();
            return dto;
        }

        public async Task<AppUser> RegisterAsync(AdminAppUserRegisterRequestDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.EmailAddress);
            if (user != null)
            {
                throw new Exception("User already exists!");
            }

            user = request.ToAppUser();

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                string errors = String.Join(Environment.NewLine, result.Errors);
                throw new ArgumentException(errors);
            }

            return user;
        }

        public async Task<AppUser> RegisterAsync(AppUserRegisterRequestDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.EmailAddress);
            if (user != null)
            {
                throw new Exception("User already exists!");
            }

            user = request.ToAppUser();

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                string errors = String.Join(Environment.NewLine, result.Errors);
                throw new ArgumentException(errors);
            }

            return user;
        }



        public async Task AssignRoleAsync(AppUserAssignRoleRequestDto dto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == dto.UserId);
            if(user==null)
            {
                throw new Exception("User does not exist.");
            }

            var result = await _userManager.AddToRoleAsync(user, dto.Role.ToString());

            if (!result.Succeeded)
            {
                string errors = String.Join(Environment.NewLine, result.Errors);
                throw new ArgumentException(errors);
            }
        }

        public async Task AssignRoleAsync(AppUser user, RolesEnum role)
        {

            var result = await _userManager.AddToRoleAsync(user, role.ToString());

            if (!result.Succeeded)
            {
                string errors = String.Join(Environment.NewLine, result.Errors);
                throw new ArgumentException(errors);
            }
        }

        public async Task<string> LogInAsync(AppUserLoginRequestDto request)
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


        public async Task<string> LogInAsync(AppUser user, string password)
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

        public async Task UpdateAsync(AppUserUpdateRequestDto dto)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if(user == null)
            {
                throw new Exception("User does not exist!");
            }
            dto.ToAppUser(user);

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                string errors = String.Join(Environment.NewLine, result.Errors);
                throw new ArgumentException(errors);
            }

        }

        public async Task DeleteAsync(Guid appUserId)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == appUserId);
            if (user == null)
            {
                throw new Exception("User does not exist!");
            }
            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                string errors = String.Join(Environment.NewLine, result.Errors);
                throw new ArgumentException(errors);
            }
        }



    }
}
