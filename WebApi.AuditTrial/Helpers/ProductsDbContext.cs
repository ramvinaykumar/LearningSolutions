using Microsoft.EntityFrameworkCore;
using WebApi.AuditTrial.Models;

namespace WebApi.AuditTrial.Helpers
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<AuditLog> AuditLogs { get; set; } = default!;
    }
}
