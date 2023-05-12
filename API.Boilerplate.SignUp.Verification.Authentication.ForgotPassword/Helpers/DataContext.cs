using API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<BasicMaster> BasicMasters { get; set; }

        public DbSet<Recruiter> Recruiters { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<CandidateHistory> CandidateHistory { get; set; }

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));

        }
    }
}