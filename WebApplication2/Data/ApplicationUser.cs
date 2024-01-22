using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Data
{
    public class ApplicationUser : IdentityUser
    {
        public String NameFirst { get; set; } = null!; 
        public String NameLast { get; set;} = null!;
    }
}
