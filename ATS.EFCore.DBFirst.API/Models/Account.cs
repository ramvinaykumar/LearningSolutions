using System;
using System.Collections.Generic;

namespace ATS.EFCore.DBFirst.API.Models
{
    public partial class Account
    {
        public Account()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public bool AcceptTerms { get; set; }
        public int Role { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
