using AutoMapper;
using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Requests;

namespace PhotoSi.Users.Application.Mappers;
public class MappingUser : Profile
{
    public MappingUser()
    {
        CreateMap<User, UserDto>();
        CreateMap<Location, LocationDto>();
    }
}
