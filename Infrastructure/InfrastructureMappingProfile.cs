﻿using AutoMapper;
using Infrastructure.Identity;
using System;
using VideoVault.Application.Common.Models;
using VideoVault.Domain.Entities;

namespace Infrastructure
{
    public class InfrastructureMappingProfile : Profile
    {
        public InfrastructureMappingProfile()
        {
            CreateMap<UserDto, Customer>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.CustomerId));
            CreateMap<UserDto, ApplicationUser>()
                .ForMember(dest => dest.Id, o => o.MapFrom(src => src.Id))
                .ForMember(dest => dest.Customer, o => o.MapFrom(src => src))
                .ForMember(dest => dest.UserRoles, o => o.MapFrom(src => src.Roles));
            CreateMap<ApplicationUser, UserDto>()
                .ForMember(dest => dest.Id, o => o.MapFrom(src => Guid.Parse(src.Id)))
                .ForMember(dest => dest.CustomerId, o => o.MapFrom(src => src.Customer.Id))
                .ForMember(dest => dest.Roles, o => o.MapFrom(src => src.UserRoles));
        }
    }
}