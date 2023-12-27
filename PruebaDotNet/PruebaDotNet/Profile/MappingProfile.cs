using AutoMapper;
using PruebaDotNet.Models;

namespace PruebaDotNet.Profile
{
    public class MappingProfile 
    {

        public MappingProfile()
        {
            //CreateMap<object, Memployee>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GetProperty("id").ToString()))
            //    .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.GetProperty("employee_name").ToString()))
            //    .ForMember(dest => dest.EmployeeSalary, opt => opt.MapFrom(src => src.GetProperty("employee_salary").ToString()))
            //    .ForMember(dest => dest.EmployeeAge, opt => opt.MapFrom(src => src.GetProperty("employee_age").ToString()))
            //    .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.GetProperty("profile_image").ToString()));
        }

    }
}
