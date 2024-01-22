using static WebApplication2.Helpers.ApplicationRole;

namespace WebApplication2.Utilities
{
    public static class RoleExtensions
    {
        public static string ToRoleString(this Role role)
        {
            return role.ToString();
        }
    }

}
