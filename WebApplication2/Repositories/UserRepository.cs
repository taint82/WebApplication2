using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface UserRepository
    {
        public Task<List<UserModel>> GetAllUsersAsync();
        public Task<UserModel> GetUsersAsync(int Id);
        public Task<int> AddUsersAsync(UserModel userModel);
        public Task UpdateUsersAsync(int Id, UserModel userModel);
        public Task DeleteUsersAsync(int Id);
    }
}
