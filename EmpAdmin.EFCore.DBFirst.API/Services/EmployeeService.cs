using AutoMapper;
using EmpAdmin.EFCore.DBFirst.API.Data;
using EmpAdmin.EFCore.DBFirst.API.Interface;
using EmpAdmin.EFCore.DBFirst.API.Models.Dto;
using EmpAdmin.EFCore.DBFirst.API.Models.Entities;
using EmpAdmin.EFCore.DBFirst.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmpAdmin.EFCore.DBFirst.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDataService _employeeDataService;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeDataService employeeDataService, IMapper mapper)
        {
            this._employeeDataService = employeeDataService;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(AddEditEmployeeDto employeeDto)
        {
            var createEmployeeDto = new EmployeeDto();

            var employee = new Employee
            {
                Address = employeeDto.Address,
                Designation = employeeDto.Designation,
                Email = employeeDto.Email,
                Name = employeeDto.Name,
                Phone = employeeDto.Phone,
                Salary = employeeDto.Salary,
            };

            var newEmployee = await _employeeDataService.CreateAsync(employee);
            return _mapper.Map(newEmployee, createEmployeeDto);
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            await _employeeDataService.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeeAsync()
        {
            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();
            var employeeList = await _employeeDataService.GetAllAsync();
            return _mapper.Map(employeeList, employees);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid id)
        {
            var employeeDto = new EmployeeDto();
            var empData = await _employeeDataService.GetByIdAsync(id);
            return _mapper.Map(empData, employeeDto);
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(Guid id, AddEditEmployeeDto employeeDto)
        {
            var updateEmployeeDto = new EmployeeDto();

            var employee = new Employee
            {
                Id = id,
                Address = employeeDto.Address,
                Designation = employeeDto.Designation,
                Email = employeeDto.Email,
                Name = employeeDto.Name,
                Phone = employeeDto.Phone,
                Salary = employeeDto.Salary,
            };

            var updateEmployee = await _employeeDataService.UpdateAsync(employee);
            return _mapper.Map(updateEmployee, updateEmployeeDto);
        }
    }
}
