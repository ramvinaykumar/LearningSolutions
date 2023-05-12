using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ATS.EFCore.DBFirst.API.Models
{
    public partial class LearningContext : DbContext
    {
        public LearningContext()
        {
        }

        public LearningContext(DbContextOptions<LearningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<BasicMaster> BasicMasters { get; set; } = null!;
        public virtual DbSet<Candidate> Candidates { get; set; } = null!;
        public virtual DbSet<CandidateHistory> CandidateHistories { get; set; } = null!;
        public virtual DbSet<PresentStatus> PresentStatuses { get; set; } = null!;
        public virtual DbSet<Recruiter> Recruiters { get; set; } = null!;
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=RV-KUMAR-1TML3\\SQLEXPRESS;Database=Learning;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasicMaster>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataFor).HasMaxLength(50);

                entity.Property(e => e.DataText).HasMaxLength(50);

                entity.Property(e => e.DataValue).HasMaxLength(50);
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.Address).HasMaxLength(1000);

                entity.Property(e => e.Ctc).HasColumnName("CTC");

                entity.Property(e => e.Ectc).HasColumnName("ECTC");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.MiddleName).HasMaxLength(100);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.PrimarySkill).HasMaxLength(100);
            });

            modelBuilder.Entity<CandidateHistory>(entity =>
            {
                entity.HasKey(e => e.HistroyId);

                entity.ToTable("CandidateHistory");

                entity.HasIndex(e => e.CandidateId, "IX_CandidateHistory_CandidateID");

                entity.HasIndex(e => e.RecruiterUserId, "IX_CandidateHistory_RecruiterUserID");

                entity.Property(e => e.HistroyId).HasColumnName("HistroyID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.CandidateStatus).HasMaxLength(50);

                entity.Property(e => e.Feedback).HasMaxLength(2000);

                entity.Property(e => e.RecruiterUserId).HasColumnName("RecruiterUserID");

                entity.Property(e => e.ResumeStatus).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.CandidateHistories)
                    .HasForeignKey(d => d.CandidateId);

                entity.HasOne(d => d.RecruiterUser)
                    .WithMany(p => p.CandidateHistories)
                    .HasForeignKey(d => d.RecruiterUserId);
            });

            modelBuilder.Entity<PresentStatus>(entity =>
            {
                entity.ToTable("PresentStatus");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PresentType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength()
                    .HasComment("F - Full Day, H - Half Day, A - Absent");
            });

            modelBuilder.Entity<Recruiter>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("RefreshToken");

                entity.HasIndex(e => e.AccountId, "IX_RefreshToken_AccountId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.AccountId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(500)
                    .HasColumnName("EmailID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
