using FluentAssertions;
//using Moq;
//using Tryitter.Dto;
//using Tryitter.Interfaces.Repository;
//using Tryitter.Interfaces.Services;
//using Tryitter.src.Interfaces.Services;
//using Tryitter.src.Services;

namespace Tryitter.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var soma = 1 + 1;
            soma.Should().Be(2);
            //// Arrange
            //var createStudentDto = new CreateStudentRequestDto
            //{
            //    FullName = "Test 1",
            //    Email = "test@test.com",
            //    Module = "Back",
            //    Password = "123",
            //    Status = "available"

            //};
            //var repositoryMock = new Mock<IStudentRepository>();
            //var tokenService = new Mock<ITokenService>();
            //IStudentService sut = new StudentService(
            //  repositoryMock.Object,
            //  tokenService.Object
            //);

            //// Act
            //var result = sut.Create(createStudentDto);

            //// Assert
            //result.Should().NotBeNull();
        }
    }
}