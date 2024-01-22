using AutoMapper;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Users, UserModel>().ReverseMap();
        }

    }
}
