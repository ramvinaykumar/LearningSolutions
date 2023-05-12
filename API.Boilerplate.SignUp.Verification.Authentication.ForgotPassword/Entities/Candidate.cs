using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Entities
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        public string Mobile { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        [MaxLength(1000)]
        public string Address { get; set; }

        [Required]
        [MaxLength(100)]
        public string PrimarySkill { get; set; }

        [Required]
        public string TechSkills { get; set; }

        public string Domain { get; set; }

        public string CTC { get; set; }

        public string ECTC { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
