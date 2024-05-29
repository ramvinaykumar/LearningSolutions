using EmpAdmin.EFCore.DBFirst.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmpAdmin.EFCore.DBFirst.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
