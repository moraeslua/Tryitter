using FluentAssertions;
using Gwtdo;
using Moq;
using Moq.AutoMock;
using Tryitter.Interfaces.Repository;
using Tryitter.Interfaces.Services;
using Tryitter.src.Entities;
using Tryitter.src.Interfaces.Services;
using Tryitter.src.Services;

namespace TestProject1.UnitTests.Services.Student
{
    using arrange = Arrange<StudentServiceFixture>;
    using act = Act<StudentServiceFixture>;
    using assert = Assert<StudentServiceFixture>;
    public class StudentServiceFixture : IFixture
    {
        public AutoMocker AutoMoq { get; set; }
        public IStudentService StudentService { get; set; }
        public Mock<IStudentRepository> StudentRepositoryMock { get; set; }
        public Mock<ITokenService> TokenServiceMock { get; set; }

        public StudentAuthenticatedOutput StudentAuthenticatedResult;
        public Tryitter.Models.Student Result;
        public void Setup()
        {
            AutoMoq = new AutoMocker();
        }
    }

    //Given
    public static class Setup
    {
        public static arrange My_student_repository_is_initialized(this arrange fixture)
        {
            return fixture.Setup(f => f.StudentRepositoryMock = f.AutoMoq.GetMock<IStudentRepository>());
        }

        public static arrange My_student_repository_returns_null(this arrange fixture)
        {
            return fixture
                .Setup(f => f.StudentRepositoryMock
                .Setup(x => x.ReadByEmail(It.IsAny<string>()))
                .Returns(Task.FromResult<Tryitter.Models.Student>(null!)));
        }
        public static arrange My_student_repository_read_by_email_returns_student(this arrange fixture)
        {
            return fixture
                .Setup(f => f.StudentRepositoryMock
                .Setup(x => x.ReadByEmail(It.IsAny<string>()))
                .Returns(Task.FromResult(StudentServiceBuilder.GetStudent())));
        }

        public static arrange My_student_repository_returns_student_created(this arrange fixture)
        {
            return fixture
                .Setup(f => f.StudentRepositoryMock
                .Setup(x => x.Create(It.IsAny<Tryitter.Models.Student>()))
                .Returns(Task.FromResult(StudentServiceBuilder.GetStudent())));
        }

        public static arrange My_student_repository_read_by_id_returns_student(this arrange fixture)
        {
            return fixture
                .Setup(f => f.StudentRepositoryMock
                .Setup(x => x.ReadById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(StudentServiceBuilder.GetStudent())));
        }

        public static arrange My_student_repository_returns_student_updated(this arrange fixture)
        {
            return fixture
                .Setup(f => f.StudentRepositoryMock
                .Setup(x => x.Update(It.IsAny<Tryitter.Models.Student>()))
                .Returns(Task.FromResult(StudentServiceBuilder.GetStudentWithNewStatus())));
        }

        public static arrange My_token_service_is_initialized(this arrange fixture)
        {
            return fixture.Setup(f => f.TokenServiceMock = f.AutoMoq.GetMock<ITokenService>());
        }

        public static arrange My_token_service_returns_new_token(this arrange fixture)
        {
            return fixture
                .Setup(f => f.TokenServiceMock
                .Setup(x => x.GenerateToken(It.IsAny<Tryitter.Models.Student>()))
                .Returns("new token"));
        }

        public static arrange I_have_a_student_service(this arrange fixture)
        {
            return fixture.Setup(f => f.StudentService = new StudentService(f.StudentRepositoryMock.Object, f.TokenServiceMock.Object));
        }
    }

    // When
    public static class Exercise
    {
        public static act I_ask_to_create_a_new_student(this act fixture)
        {
            return fixture.It(async f => f.StudentAuthenticatedResult = await f.StudentService.Create(StudentServiceBuilder.GetCreateStudentRequestDto()));

        }
        public static act I_ask_to_update_a_student(this act fixture)
        {
            return fixture.It(async f => f.Result = await f.StudentService.Update(Guid.NewGuid(), StudentServiceBuilder.GetUpdateStudentRequestDto()));

        }
        public static act I_ask_to_authenticate_a_student(this act fixture)
        {
            return fixture.It(async f => f.StudentAuthenticatedResult = await f.StudentService.Authenticate(StudentServiceBuilder.GetAuthenticateStudentDto()));

        }

        public static act I_ask_to_read_a_student_by_email(this act fixture)
        {
            return fixture.It(async f => f.Result = await f.StudentService.ReadByEmail(StudentServiceBuilder.GetStudent().Email));

        }

    }

    // Then
    public static class Verify
    {
        public static assert I_should_have_created_a_new_student(this assert assert)
        {
            assert.Expect(ex =>
            {
                ex.StudentAuthenticatedResult.Should().NotBeNull();
            });

            return assert;
        }
        public static assert I_should_have_updated_a_student(this assert assert)
        {
            assert.Expect(ex =>
            {
                ex.Result.Should().NotBeNull();
            });

            return assert;
        }

        public static assert I_should_have_authenticated_a_student(this assert assert)
        {
            assert.Expect(ex =>
            {
                ex.StudentAuthenticatedResult.Should().NotBeNull();
            });

            return assert;
        }

        public static assert I_should_have_student_data(this assert assert)
        {
            assert.Expect(ex =>
            {
                ex.Result.Should().NotBeNull();
            });

            return assert;
        }

    }
}
