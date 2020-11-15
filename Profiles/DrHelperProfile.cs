using AutoMapper;
using DrHelperBack.DTOs;
using DrHelperBack.Models;

namespace DrHelperBack.Profiles
{
    public class DrHelperProfile : Profile
    {
        public DrHelperProfile()
        {
            //Source -> Target
            CreateMap<Disease, DiseaseReadDTO>();
            CreateMap<DiseaseCreateDTO, Disease>();
            CreateMap<Disease, DiseaseCreateDTO>();

            CreateMap<UserType, UserTypeReadDTO>();
            CreateMap<UserTypeCreateDTO, UserType>();
            CreateMap<UserType, UserTypeCreateDTO>();

            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();
            CreateMap<User, UserCreateDTO>();

            CreateMap<Medicine, MedicineReadDTO>();
            CreateMap<MedicineCreateDTO, Medicine>();
            CreateMap<Medicine, MedicineCreateDTO>();
        }
    }
}
