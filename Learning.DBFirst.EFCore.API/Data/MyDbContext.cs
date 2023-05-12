using Learning.DBFirst.EFCore.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Learning.DBFirst.EFCore.API.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Cake> Cake { get; set; }
    }
}
