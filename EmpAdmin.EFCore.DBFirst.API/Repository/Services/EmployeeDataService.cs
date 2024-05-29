using EmpAdmin.EFCore.DBFirst.API.Data;
using EmpAdmin.EFCore.DBFirst.API.Models.Entities;
using EmpAdmin.EFCore.DBFirst.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmpAdmin.EFCore.DBFirst.API.Repository.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeDataService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        public async Task DeleteAsync(Guid id)
        {
            var employee = await GetEmployeeById(id);
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return await GetEmployeeById(id);
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        private async Task<Employee> GetEmployeeById(Guid id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found");
            }
            return employee;
        }
    }
}
