using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public ProductsController(UserRepository repository)
        {
            _userRepository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _userRepository.GetAllUsersAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            var user = await _userRepository.GetUsersAsync(Id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUsersAsync(UserModel userModel)
        {
            try
            {
                var newUserId = await _userRepository.AddUsersAsync(userModel);
                //return CreatedAtAction(nameof(GetUserById),
                //        new { Controller = "ProductsController", newUserId }, newUserId);
                var user = await _userRepository.GetUsersAsync(newUserId);
                return user == null ? NotFound() : Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{Id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUserAsync(int Id, UserModel userModel)
        {   
            if(Id != userModel.Id)
            {
                return NotFound(Id);
            }
            await _userRepository.UpdateUsersAsync(Id, userModel);
            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserAsync(int Id)
        {
            await _userRepository.DeleteUsersAsync(Id);
            return Ok();
        }
    }
}
