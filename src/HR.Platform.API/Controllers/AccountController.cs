using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace HR.Platform.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly string _frontendURL;

        public AccountController()
        {
            _frontendURL = Environment.GetEnvironmentVariable("FRONTEND_URL");
        }

        [HttpGet]
        [Route("[controller]/Register", Name = "Register")]
        [Route("[controller]/Login", Name = "Login")]
        public IActionResult LoginOrRegisterAsync([FromQuery] string scheme)
        {
            if (!string.Equals(scheme, GoogleDefaults.AuthenticationScheme, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException(nameof(scheme));
            }

            return new ChallengeResult(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = _frontendURL });
        }
    }
}