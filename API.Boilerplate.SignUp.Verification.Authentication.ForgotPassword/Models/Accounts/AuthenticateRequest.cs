using System.ComponentModel.DataAnnotations;

namespace API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Models.Accounts
{
    public class AuthenticateRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
