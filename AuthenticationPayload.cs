namespace Tryitter
{
    public class AuthenticationPayload
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
