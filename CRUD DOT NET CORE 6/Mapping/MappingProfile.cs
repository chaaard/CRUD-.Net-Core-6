using AutoMapper;
using CRUD.Application.DTOs;
using CRUD.Domain.Entities;

namespace CRUD_DOT_NET_CORE_6.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Users, UserDto>();
            CreateMap<UserDto, Users>();
        }
    }
}
