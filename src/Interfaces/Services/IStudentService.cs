using Tryitter.Dto;
using Tryitter.Models;
using Tryitter.src.Dto;
using Tryitter.src.Entities;

namespace Tryitter.src.Interfaces.Services
{
    public interface IStudentService
    {
        Task<StudentAuthenticatedOutput> Create(CreateStudentRequestDto request);
        Task<StudentAuthenticatedOutput> Authenticate(AuthorizeRequestDto request);
        Task<Student> ReadById(Guid id);
        Task<Student> ReadByEmail(string email);
        Task<List<Student>> ReadAll();
        Task<Student> Update(Guid studentId, UpdateStudentRequestDto request);
        Task Delete(Guid id);
    }
}
