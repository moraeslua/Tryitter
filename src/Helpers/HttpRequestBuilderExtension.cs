using System.Security.Claims;

namespace Tryitter.Helpers
{
    public static class HttpRequestBuilderExtension
    {
        public static AuthenticationPayload GetAuthenticationPayload(this HttpRequest request)
        {
            var identitdy = request.HttpContext.User.Identity as ClaimsIdentity;
            if (identitdy is not null)
            {
                var userId = identitdy.FindFirst("UserId")?.Value;
                var email = identitdy.FindFirst(ClaimTypes.Email)?.Value;

                return new AuthenticationPayload() { UserId = new Guid(userId!), Email = email! };
            }
            return new AuthenticationPayload();
        }
    }
}
