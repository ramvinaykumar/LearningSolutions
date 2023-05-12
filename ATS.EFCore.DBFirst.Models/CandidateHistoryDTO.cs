using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.EFCore.DBFirst.Models
{
    public class CandidateHistoryDTO
    {
        public int HistroyID { get; set; }

        // Foreign key for Recruiter
        public int UserID { get; set; }

        // Foreign key for Candidate
        public int CandidateID { get; set; }

        public string? ResumeStatus { get; set; }

        public string? CandidateStatus { get; set; }

        public string? Feedback { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsCommentArchieved { get; set; }
    }
}
