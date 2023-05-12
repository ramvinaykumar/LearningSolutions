using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Entities
{
    public class BasicMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string DataValue { get; set; }

        [Required]
        [MaxLength(50)]
        public string DataText { get; set; }

        [Required]
        [MaxLength(50)]
        public string DataFor { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
