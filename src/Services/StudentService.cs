using Tryitter.Dto;
using Tryitter.Interfaces.Repository;
using Tryitter.Interfaces.Services;
using Tryitter.Models;
using Tryitter.src.Dto;
using Tryitter.src.Exceptions;
using Tryitter.src.Interfaces.Services;

namespace Tryitter.src.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ITokenService _tokenService;

        public StudentService(IStudentRepository studentRepository, ITokenService tokenService)
        {
            _studentRepository = studentRepository;
            _tokenService = tokenService;
        }

        public async Task<object> Create(CreateStudentRequestDto request)
        {
            var studentExists = await _studentRepository.ReadByEmail(request.Email);
            if (studentExists is not null) throw new ConflictException("Student is already registered");

            var student = new Student
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                FullName = request.FullName,
                Module = request.Module,
                Status = request.Status,
                Password = request.Password,
            };

            var newStudent = await _studentRepository.Create(student);
            var token = _tokenService.GenerateToken(student);

            return new { newStudent, token };
        }

        public async Task<object> Authenticate(AuthorizeRequestDto request)
        {
            var student = await _studentRepository.ReadByEmail(request.Email);
            if (student is null) throw new NotFoundException("Student does not exists");

            var credentialsMatch = request.Password == student.Password;
            if (!credentialsMatch) throw new UnauthorizedException("Credentials does not match");

            var token = _tokenService.GenerateToken(student);
            return new { student, token };
        }


        public async Task Delete(Guid id)
        {
            await ReadById(id);
            _studentRepository.Delete(id);
        }

        public async Task<List<Student>> ReadAll()
        {
            return await _studentRepository.ReadAll();
        }

        public async Task<Student> ReadByEmail(string email)
        {
            var student = await _studentRepository.ReadByEmail(email);
            if (student is null) throw new NotFoundException("Student does not exists");
            return student;
        }

        public async Task<Student> ReadById(Guid id)
        {
            var student = await _studentRepository.ReadById(id);
            if (student is null) throw new NotFoundException("Student does not exists");
            return student;
        }

        public async Task<Student> Update(Guid studentId, UpdateStudentRequestDto request)
        {
            var previousStudent = await ReadById(studentId);

            if (request.Email != "" && request.Email is not null)
            {
                var emailIsInUse = await _studentRepository.ReadByEmail(request.Email);
                if (emailIsInUse is not null) throw new ConflictException("Email is already in use");

            }

            var studentToUpdate = new Student()
            {
                Id = previousStudent.Id,
                FullName = string.IsNullOrEmpty(request.FullName) ? previousStudent.FullName : request.FullName,
                Email = string.IsNullOrEmpty(request.Email) ? previousStudent.Email : request.Email,
                Module = string.IsNullOrEmpty(request.Module) ? previousStudent.Module : request.Module,
                Status = string.IsNullOrEmpty(request.Status) ? previousStudent.Status : request.Status,
                Password = string.IsNullOrEmpty(request.Password) ? previousStudent.Password : request.Password,
            };

            var studentUpdated = await _studentRepository.Update(studentToUpdate);
            return studentUpdated;
        }
    }
}
