using AutoMapper;
using Registration.Business.Models;
using Registration.Infrastructure.Entities;

namespace Registration.Business.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, CreateUserDTO>().ReverseMap();
        CreateMap<User, UpdateUserDTO>().ReverseMap();
        CreateMap<ReadUserDTO, User>().ReverseMap();
    }
}
