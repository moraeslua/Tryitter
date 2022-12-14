namespace Tryitter.src.Entities
{
    public class AuthenticationPayload
    {
        public Guid StudentId { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
