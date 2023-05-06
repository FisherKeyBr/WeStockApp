using Microsoft.AspNetCore.Mvc;
using WeStock.App.Auth;
using WeStock.App.Extensions;
using WeStock.Domain.Entities;

namespace WeStock.App.Controllers
{
    public class BaseController : ControllerBase
    {
        protected UserClaims GetUserClaims()
        {
            var currentUserSession = HttpContext.User.GetUserClaims();
            return currentUserSession;
        }
    }
}
