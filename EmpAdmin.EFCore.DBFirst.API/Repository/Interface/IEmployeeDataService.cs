using EmpAdmin.EFCore.DBFirst.API.Models.Entities;

namespace EmpAdmin.EFCore.DBFirst.API.Repository.Interface
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<Employee>> GetAllAsync();

        Task<Employee> GetByIdAsync(Guid id);

        Task<Employee> CreateAsync(Employee employee);

        Task<Employee> UpdateAsync(Employee employee);

        Task DeleteAsync(Guid id);
    }
}
