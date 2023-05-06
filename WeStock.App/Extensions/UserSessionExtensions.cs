using System.Net;
using System.Security.Claims;
using WeStock.App.Auth;
using WeStock.App.Exceptions;

namespace WeStock.App.Extensions
{
    public static class UserSessionExtensions
    {
        public static UserClaims GetUserClaims(this ClaimsPrincipal session)
        {
            if(session is null)
            {
                throw new ProblemDetailsException("User claims not found in token!", 
                    HttpStatusCode.Unauthorized);
            }

            var userClaims = new UserClaims();

            var id = session.Claims.FirstOrDefault(c => c.Type == nameof(userClaims.Id))?.Value 
                ?? throw new ProblemDetailsException("User id not found in token", HttpStatusCode.Unauthorized);

            var userName = session.Claims.FirstOrDefault(c => c.Type == nameof(userClaims.UserName))?.Value 
                ?? throw new ProblemDetailsException("Username not found in token", HttpStatusCode.Unauthorized);

            var displayName = session.Claims.FirstOrDefault(c => c.Type == nameof(userClaims.DisplayName))?.Value
                ?? throw new ProblemDetailsException("Display name not found in token", HttpStatusCode.Unauthorized);

            userClaims.Id = Convert.ToInt32(id);
            userClaims.UserName = userName;
            userClaims.DisplayName = displayName;

            return userClaims;
        }
    }
}
