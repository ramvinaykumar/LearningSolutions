using System;
using System.Collections.Generic;

namespace ATS.EFCore.DBFirst.API.Models
{
    public partial class Candidate
    {
        public Candidate()
        {
            CandidateHistories = new HashSet<CandidateHistory>();
        }

        public int CandidateId { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string? Address { get; set; }
        public string PrimarySkill { get; set; } = null!;
        public string TechSkills { get; set; } = null!;
        public string? Domain { get; set; }
        public string? Ctc { get; set; }
        public string? Ectc { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<CandidateHistory> CandidateHistories { get; set; }
    }
}
