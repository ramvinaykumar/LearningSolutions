using EmpAdmin.EFCore.DBFirst.API.Models.Dto;

namespace EmpAdmin.EFCore.DBFirst.API.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeeAsync();

        Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);

        Task<EmployeeDto> CreateEmployeeAsync(AddEditEmployeeDto employee);

        Task<EmployeeDto> UpdateEmployeeAsync(Guid id, AddEditEmployeeDto employee);

        Task DeleteEmployeeAsync(Guid id);
    }
}
