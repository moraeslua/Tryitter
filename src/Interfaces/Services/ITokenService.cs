using Tryitter.Models;

namespace Tryitter.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(Student student);
    }
}
