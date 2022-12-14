using Tryitter.Models;

namespace Tryitter.Interfaces.Repository
{
    public interface IStudentRepository
    {
        Task<Student> Create(Student student);
        Task<Student> ReadById(Guid id);
        Task<Student> ReadByEmail(string email);
        Task<List<Student>> ReadAll();
        Task<Student> Update(Student student);
        void Delete(Guid id);
    }
}
