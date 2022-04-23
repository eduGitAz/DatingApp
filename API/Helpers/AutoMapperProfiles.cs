using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppCompany, CompanyDto>();
            CreateMap<AppCustomer, CustomerDto>();
            CreateMap<AppDevice, DeviceDto>();
            CreateMap<MemberUpdateDto, AppUser>();
        }
    }
}