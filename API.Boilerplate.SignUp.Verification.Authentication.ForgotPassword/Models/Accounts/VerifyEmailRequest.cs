using System.ComponentModel.DataAnnotations;

namespace API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Models.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
