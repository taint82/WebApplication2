using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication2.Data;
using WebApplication2.Helpers;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class AccountRepo : AccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountRepo(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,IConfiguration configuration, RoleManager<IdentityRole> roleManager) 
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
        }
        public async Task<string> SignInAsync(SignInModel signInModel)
        {   
            var user = await userManager.FindByEmailAsync(signInModel.Email);
            var passWordValid = await userManager.CheckPasswordAsync(user, signInModel.Password);
            if (user == null || !passWordValid)
            {
                return string.Empty;
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, signInModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var userRole = await userManager.GetRolesAsync(user);
            foreach (var role in userRole)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:IssuerSigningKeySecret"]));
            //byte[] keyBytes = new byte[64]; // 64 bytes = 512 bits
                                            // Thực hiện logic để tạo giá trị ngẫu nhiên cho keyBytes

            // Sử dụng keyBytes trong SigningCredentials
            //var _authKey = new SymmetricSecurityKey(keyBytes);
            //var signingCredentials = new SigningCredentials(_authKey, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel signUpModel)
        {
            var user = new ApplicationUser
            {
                NameFirst = signUpModel.NameFirst,
                NameLast = signUpModel.NameLast,
                Email = signUpModel.Email,
                UserName = signUpModel.Email
            };
            var result = await userManager.CreateAsync(user, signUpModel.Password);

            if(result.Succeeded)
            {
                //kiem tra role Customer da co chua
                if(!await roleManager.RoleExistsAsync(ApplicationRole.Customer))
                {
                    await roleManager.CreateAsync(new IdentityRole(ApplicationRole.Customer));
                }
                await userManager.AddToRoleAsync(user, ApplicationRole.Customer);
            }

            return result;
        }
            

    }
}

