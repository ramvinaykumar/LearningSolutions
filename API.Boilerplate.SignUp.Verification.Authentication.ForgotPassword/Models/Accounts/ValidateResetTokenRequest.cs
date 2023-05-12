using System.ComponentModel.DataAnnotations;

namespace API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Models.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
