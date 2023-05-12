using API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Controllers
{
    [Controller]
    public abstract class BaseController : ControllerBase
    {
        // returns the current authenticated account (null if not logged in)
        public Account Account => (Account)HttpContext.Items["Account"];
    }
}
