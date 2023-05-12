using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Models.BasicMaster
{
    public class MasterTableRequest
    {
        [Required]
        [MaxLength(20, ErrorMessage ="Data value is required.")]
        public string DataValue { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Data text is required.")]
        public string DataText { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Data text is required.")]
        public string DataFor { get; set; }

        [JsonIgnore]
        public bool IsActive { get; set; }
    }
}
