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
            CreateMap<MemberAddDto, AppUser>();
            CreateMap<CustomerUpdateDto, AppCustomer>();
            CreateMap<AppOrder, OrderDto>();
            CreateMap<OrderUpdateDto, AppOrder>();
            CreateMap<CompanyUpdateDto, AppCompany>();
            CreateMap<DeviceUpdateDto, AppDevice>();
            CreateMap<AppOrderStatus, OrderStatusDto>();
            CreateMap<AppOrderType, OrderTypeDto>();
            CreateMap<AppUseOfRefrigernat, UseOfRefrigernatDto>();
            CreateMap<AppRefrigerant, RefrigerantDto>();
        }
    }
}