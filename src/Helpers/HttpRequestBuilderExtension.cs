using System.Security.Claims;
using Tryitter.src.Entities;

namespace Tryitter.Helpers
{
    public static class HttpRequestBuilderExtension
    {
        public static AuthenticationPayload GetAuthenticationPayload(this HttpRequest request)
        {
            var identitdy = request.HttpContext.User.Identity as ClaimsIdentity;
            if (identitdy is not null)
            {
                var StudentId = identitdy.FindFirst("StudentId")?.Value;
                var email = identitdy.FindFirst(ClaimTypes.Email)?.Value;

                return new AuthenticationPayload() { StudentId = new Guid(StudentId!), Email = email! };
            }
            return new AuthenticationPayload();
        }
    }
}
