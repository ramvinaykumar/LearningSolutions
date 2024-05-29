using AutoMapper;
using EmpAdmin.EFCore.DBFirst.API.Models.Dto;
using EmpAdmin.EFCore.DBFirst.API.Models.Entities;

namespace EmpAdmin.EFCore.DBFirst.API.Models.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() 
        { 
            CreateMap<Employee, EmployeeDto>(); 
        }
    }
}
