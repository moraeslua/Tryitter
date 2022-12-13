using Microsoft.EntityFrameworkCore;
using Tryitter.Interfaces.Repository;
using Tryitter.Models;
using Tryitter.src.Database.SqlServer;

namespace Tryitter.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;
        public StudentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Student> Create(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async void Delete(Guid id)
        {
            var student = _context.Students.FindAsync(id);
            _context.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Student>> ReadAll()
        {
            return await _context.Students.AsNoTracking().ToListAsync();
        }

        public async Task<Student> ReadById(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            return student!;
        }
        public async Task<Student> ReadByEmail(string email)
        {
            var student = await _context.Students.FirstOrDefaultAsync(student => student.Email == email);
            return student!;
        }

        public async Task<Student> Update(Student student)
        {
            var previousStudent = await _context.Students.FindAsync(student.Id);

            previousStudent!.FullName = student.FullName;
            previousStudent.Email = student.Email;
            previousStudent.Status = student.Status;
            previousStudent.Module = student.Module;
            previousStudent.Password = student.Password;

            await _context.SaveChangesAsync();
            return student;
        }
    }
}
