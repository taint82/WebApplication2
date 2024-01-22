using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountRepository _accountRepos;

        public AccountController(AccountRepository accountRepository) 
        {
            _accountRepos = accountRepository;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp (SignUpModel signUpModel)
        {
            var result = await _accountRepos.SignUpAsync(signUpModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return StatusCode(500);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn (SignInModel signInModel)
        {
            var result = await _accountRepos.SignInAsync(signInModel);
            if (result==null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
