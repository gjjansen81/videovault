using AutoMapper;
using Infrastructure.Identity;
using VideoVault.Application.Common.Models;

namespace Infrastructure
{
    public class InfrastructureMappingProfile : Profile
    {
        public InfrastructureMappingProfile()
        {
            CreateMap<UserDto, ApplicationUser>()
                .ForMember(dest => dest.Customer, o => o.MapFrom(src => src.Customer))
                .ForMember(dest => dest.UserRoles, o => o.MapFrom(src => src.Roles));
        }
    }
}