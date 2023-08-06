using auth_service.Application.DTOs.User.Register;
using auth_service.Domain.Models;
using AutoMapper;

namespace auth_service.Infrastructure.Mapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles() 
        {
            CreateMap<RegisterUserRequestDTO, User>()
                .ForMember(dest =>
                    dest.UserName,
                    opt => opt.MapFrom(src => src.Email));
        }
    }
}
