using Microsoft.AspNetCore.Identity;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface AccountRepository
    {   
        public Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        public Task<AccountResModel> SignInAsync(SignInModel signInModel);
    }
}
