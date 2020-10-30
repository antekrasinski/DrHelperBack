using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DrHelperBack.DTOs;
using DrHelperBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrHelperBack.Profiles
{
    public class DrHelperProfile : Profile
    {
        public DrHelperProfile()
        {
            //Source -> Target
            CreateMap<UserType, UserTypeReadDTO>();
            CreateMap<UserTypeCreateDTO, UserType>();
            CreateMap<UserType, UserTypeCreateDTO>();
        }
    }
}
