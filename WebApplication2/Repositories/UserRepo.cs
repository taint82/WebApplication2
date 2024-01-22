using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class UserRepo : UserRepository
    {
        private readonly ApplicationDBContext _dBContext;
        private readonly IMapper _mapper;

        public UserRepo(ApplicationDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }
        public async Task<int> AddUsersAsync(UserModel userModel)
        {
            var userModelNew = _mapper.Map<Users>(userModel);
            _dBContext.Users!.Add(userModelNew);
            await _dBContext.SaveChangesAsync();
            return userModelNew.Id;
        }

        public async Task DeleteUsersAsync(int Id)
        {
            var userDelete = _dBContext.Users!.SingleOrDefault(u => u.Id == Id);
            if(userDelete != null)
            {
                _dBContext.Users!.Remove(userDelete);
                await _dBContext.SaveChangesAsync();
            }         
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var users = await _dBContext.Users!.ToListAsync();
            return _mapper.Map<List<UserModel>>(users);
        }

        public async Task<UserModel> GetUsersAsync(int Id)
        {
            var user = await _dBContext.Users!.FindAsync(Id);
            return _mapper.Map<UserModel>(user);
        }

        public async Task UpdateUsersAsync(int Id, UserModel userModel)
        {
            if(Id == userModel.Id)
            {
                var userUpdate = _mapper.Map<Users>(userModel);
                _dBContext.Users!.Update(userUpdate);
                await _dBContext.SaveChangesAsync();
            }
        }
    }
}
