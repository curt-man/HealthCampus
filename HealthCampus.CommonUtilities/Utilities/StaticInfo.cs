using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCampus.CommonUtilities.Utilities
{
    public static class RolesAndPasswords
    {
        public static (string Role, string Password) Admin = ("Admin", "123Admin");
        public static (string Role, string Password) SysAdmin = ("SysAdmin", "123SysAdmin");
        public static (string Role, string Password) Employee = ("Employee", "123Employee");
        public static (string Role, string Password) User = ("User", "123User");
        public static (string Role, string Password) Guest = ("Guest", string.Empty);
    }

}
