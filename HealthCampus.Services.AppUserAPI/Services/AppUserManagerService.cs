using AutoMapper;
using HealthCampus.CommonUtilities.Enums;
using HealthCampus.Services.AppUserAPI.Models;
using HealthCampus.Services.AppUserAPI.Models.Dto.Request;
using HealthCampus.Services.AppUserAPI.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace HealthCampus.Services.AppUserAPI.Services
{
    public class AppUserManagerService : IAppUserManagerService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IJwtGeneratorService _jwtGenerator;
        private readonly IMapper _mapper;

        public AppUserManagerService(UserManager<AppUser> userManager, RoleManager<IdentityRole<Guid>> roleManager, IJwtGeneratorService jwtGenerator, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtGenerator = jwtGenerator;
            _mapper = mapper;
        }

        public async Task<AppUser> RegisterAppUser<T>(T request) where T : AppUserRegisterRequestDto
        {
            var user = await _userManager.FindByEmailAsync(request.EmailAddress);
            if (user != null)
            {
                throw new Exception("User already exists!");
            }

            user = _mapper.Map<T, AppUser>(request);

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

        public async Task AssignRoleToAppUser(AppUser user, RolesEnum role)
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

        public async Task<string> LogInAppUser(AppUserLoginRequestDto request)
        {
            AppUser user;
            if (request.EmailOrUsername.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(request.EmailOrUsername);
            }
            else
            {
                user = await _userManager.FindByNameAsync(request.EmailOrUsername);
            }
            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                throw new Exception("Invalid credentials");
            }

            string token = _jwtGenerator.GenerateToken(user);
            return token;
        }


        public async Task<string> LogInAppUser(AppUser user, string password)
        {
            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);

            if (!isPasswordValid)
            {
                throw new Exception("Invalid credentials");
            }

            string token = _jwtGenerator.GenerateToken(user);
            return token;
        }

        public async Task UpdateAppUser(AppUserUpdateRequestDto request)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                throw new Exception("User doesn't exist!");
            }

            user = _mapper.Map<AppUserUpdateRequestDto, AppUser>(request);

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



    }
}
