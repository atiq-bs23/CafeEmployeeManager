using AutoMapper;
using CafeEmployeeManager.Application.DTOs;
using CafeEmployeeManager.Core.Entities;


namespace CafeEmployeeManager.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Cafe, CafeDto>().ReverseMap();
            CreateMap<EmployeeCafeAssignment, EmployeeCafeAssignmentDto>().ReverseMap();

        }
    }
}
