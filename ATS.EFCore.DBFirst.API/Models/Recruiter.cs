using System;
using System.Collections.Generic;

namespace ATS.EFCore.DBFirst.API.Models
{
    public partial class Recruiter
    {
        public Recruiter()
        {
            CandidateHistories = new HashSet<CandidateHistory>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string? Location { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<CandidateHistory> CandidateHistories { get; set; }
    }
}
