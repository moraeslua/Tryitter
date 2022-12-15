using Tryitter.src.Dto;
using FizzWare.NBuilder;
using Tryitter.Dto;

namespace TestProject1.UnitTests.Services.Student
{
    public class StudentServiceBuilder
    {
        private static readonly Guid StudentId = new("ba2c231b-5b92-4724-8d13-8ac5870be80f");
        public static CreateStudentRequestDto GetCreateStudentRequestDto() =>
            Builder<CreateStudentRequestDto>
            .CreateNew()
            .WithFactory(() => new CreateStudentRequestDto() { FullName = "Test name", Email = "test@email.com", Module = "Backend", Password = "pass", Status = "available" })
            .Build();        
        public static UpdateStudentRequestDto GetUpdateStudentRequestDto() =>
            Builder<UpdateStudentRequestDto>
            .CreateNew()
            .WithFactory(() => new UpdateStudentRequestDto() { Status = "new status" })
            .Build();        
        
        public static Tryitter.Models.Student GetStudent() =>
            Builder<Tryitter.Models.Student>
            .CreateNew()
            .WithFactory(() => new Tryitter.Models.Student() { Id = StudentId, FullName = "Test name", Email = "test@email.com", Module = "Backend", Password = "pass", Status = "available" })
            .Build();        
        
        public static Tryitter.Models.Student GetStudentWithNewStatus() =>
            Builder<Tryitter.Models.Student>
            .CreateNew()
            .WithFactory(() => new Tryitter.Models.Student() { Id = StudentId, FullName = "Test name", Email = "test@email.com", Module = "Backend", Password = "pass", Status = "new status" })
            .Build();


       public static AuthorizeRequestDto GetAuthenticateStudentDto() =>
            Builder<AuthorizeRequestDto>
            .CreateNew()
            .WithFactory(() => new AuthorizeRequestDto() { Email = "test@email.com", Password = "pass" })
            .Build();



    }
}
