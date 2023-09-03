using HealthCampus.CommonUtilities.Attributes;
using HealthCampus.CommonUtilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HealthCampus.CommonUtilities.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum source)
        {
            var type = source.GetType();
            var attribute = type.GetCustomAttribute<EnumDescriptionAttribute>(false);
            return attribute?.Text ?? source.ToString();
        }

        public static string GetRoleDefaultPassword(this RolesEnum role) => role switch
        {
            RolesEnum.Admin => "123Admin",
            RolesEnum.SysAdmin => "123SysAdmin",
            RolesEnum.Employee => "123Employee",
            RolesEnum.User => "123User",
            RolesEnum.Guest => "123Guest",
            _ => string.Empty,
        };
    }
}
