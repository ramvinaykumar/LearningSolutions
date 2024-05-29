using CodeFirst.EFCore.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.EFCore.API.DBContext
{
    public class CodeFirstDbContext : DbContext
    {
        public CodeFirstDbContext(DbContextOptions<CodeFirstDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
