using ActiveEdge.Models;
using ActiveEdge.Models.DTOs;
using AutoMapper;

namespace ActivEdge.Data.MapperProfile
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap()
                .ForMember(
                    dest => dest.Join_Date,
                    option => option.MapFrom(src => src.Join_Date.ToString("yyyy-MM-dd"))
                );
        }
    }
}