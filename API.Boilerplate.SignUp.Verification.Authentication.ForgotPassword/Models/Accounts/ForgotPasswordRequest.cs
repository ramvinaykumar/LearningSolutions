using System.ComponentModel.DataAnnotations;

namespace API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Models.Accounts
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
