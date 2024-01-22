using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;

namespace WebApplication2.Models
{
    public class AccountResModel
    {
        public IList<string> role { get; set; }
        public JwtSecurityToken token { get; set; }
    }
}
