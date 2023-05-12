using System;
using System.Collections.Generic;

namespace ATS.EFCore.DBFirst.API.Models
{
    public partial class CandidateHistory
    {
        public int HistroyId { get; set; }
        public string? ResumeStatus { get; set; }
        public string? CandidateStatus { get; set; }
        public string? Feedback { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsCommentArchieved { get; set; }
        public int UserId { get; set; }
        public int? RecruiterUserId { get; set; }
        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; } = null!;
        public virtual Recruiter? RecruiterUser { get; set; }
    }
}
