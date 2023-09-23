using HealthCampus.CommonUtilities.Enums;

namespace HealthCampus.Services.AppUserAPI.Models.Dtos
{
    public class AppUserAssignRoleRequestDto
    {
        public Guid UserId { get; set; }
        public RolesEnum Role { get; set; }
    }
}
