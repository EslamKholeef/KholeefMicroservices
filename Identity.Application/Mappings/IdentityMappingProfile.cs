using AutoMapper;
using Identity.Application.Commands.RegisterCommand;
using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Mappings
{
    public class IdentityMappingProfile: Profile
    {
        public IdentityMappingProfile()
        {
            CreateMap<RegisterUserCommand, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
        }
            
    }
}
