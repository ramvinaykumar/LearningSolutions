using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Entities
{
    public class CandidateHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistroyID { get; set; }

        [MaxLength(50)]
        public string ResumeStatus { get; set; }

        [MaxLength(50)]
        public string CandidateStatus { get; set; }

        [MaxLength(2000)]
        public string Feedback { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public bool IsCommentArchieved { get; set; }

        // Foreign key for Recruiter
        public int UserID { get; set; }
        public Recruiter Recruiter { get; set; }

        // Foreign key for Candidate
        public int CandidateID { get; set; }
        public Candidate Candidate { get; set; }     
    }
}
