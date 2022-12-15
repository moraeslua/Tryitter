using FluentAssertions;
using Gwtdo;
using Moq;
using Moq.AutoMock;
using TestProject1.UnitTests.Services.Student;
using Tryitter.Interfaces.Repository;
using Tryitter.src.Interfaces.Services;
using Tryitter.src.Services;

namespace TestProject1.UnitTests.Services.Post
{
    using arrange = Arrange<PostServiceFixture>;
    using act = Act<PostServiceFixture>;
    using assert = Assert<PostServiceFixture>;
    public class PostServiceFixture : IFixture
    {
        public AutoMocker AutoMoq { get; set; }
        public IPostService PostService { get; set; }
        public Mock<IPostRepository> PostRepositoryMock { get; set; }
        public Mock<IStudentService> StudentServiceMock { get; set; }

        public Tryitter.Models.Post Result;
        public List<Tryitter.Models.Post> PostsListResult;
        public void Setup()
        {
            AutoMoq = new AutoMocker();
        }
    }

    //Given
    public static class Setup
    {
        public static arrange My_post_repository_is_initialized(this arrange fixture)
        {
            return fixture.Setup(f => f.PostRepositoryMock = f.AutoMoq.GetMock<IPostRepository>());
        }

        public static arrange My_post_repository_returns_post_created(this arrange fixture)
        {
            return fixture
                .Setup(f => f.PostRepositoryMock
                .Setup(x => x.Create(It.IsAny<Tryitter.Models.Post>()))
                .Returns(Task.FromResult(PostServiceBuilder.GetPost())));
        }

        public static arrange My_post_repository_read_by_id_returns_post_data(this arrange fixture)
        {
            return fixture
                .Setup(f => f.PostRepositoryMock
                .Setup(x => x.ReadOne(It.IsAny<Guid>()))
                .Returns(Task.FromResult(PostServiceBuilder.GetPost())));
        }

        public static arrange My_post_repository_returns_post_updated(this arrange fixture)
        {
            return fixture
                .Setup(f => f.PostRepositoryMock
                .Setup(x => x.Update(It.IsAny<Tryitter.Models.Post>()))
                .Returns(Task.FromResult(PostServiceBuilder.GetPostUpdated())));
        }        
        public static arrange My_post_repository_returns_posts_list(this arrange fixture)
        {
            return fixture
                .Setup(f => f.PostRepositoryMock
                .Setup(x => x.ReadStudentAllPosts(StudentServiceBuilder.GetStudent().Id))
                .Returns(Task.FromResult(PostServiceBuilder.GetStudentPosts())));
        }        
        public static arrange My_student_service_returns_student_data(this arrange fixture)
        {
            return fixture
                .Setup(f => f.StudentServiceMock
                .Setup(x => x.ReadById(StudentServiceBuilder.GetStudent().Id))
                .Returns(Task.FromResult(StudentServiceBuilder.GetStudent())));
        }

        public static arrange My_student_service_is_initialized(this arrange fixture)
        {
            return fixture.Setup(f => f.StudentServiceMock = f.AutoMoq.GetMock<IStudentService>());
        }
        public static arrange I_have_a_post_service(this arrange fixture)
        {
            return fixture.Setup(f => f.PostService = new PostService(f.PostRepositoryMock.Object, f.StudentServiceMock.Object));
        }
    }

    // When
    public static class Exercise
    {
        public static act I_ask_to_create_a_new_post(this act fixture)
        {
            return fixture.It(async f => f.Result = await f.PostService.Create(PostServiceBuilder.GetCreatePostRequestDto()));

        }
        public static act I_ask_to_update_a_post(this act fixture)
        {
            return fixture.It(async f => f.Result = await f.PostService.Update(Guid.NewGuid(), PostServiceBuilder.GetUpdatePostRequestDto()));

        }

        public static act I_ask_to_read_a_student_posts_list(this act fixture)
        {
            return fixture.It(async f => f.PostsListResult = await f.PostService.ReadStudentAllPosts(StudentServiceBuilder.GetStudent().Id));

        }

    }

    // Then
    public static class Verify
    {
        public static assert I_should_have_created_a_new_post(this assert assert)
        {
            assert.Expect(ex =>
            {
                ex.Result.Should().NotBeNull();
            });

            return assert;
        }
        public static assert I_should_have_updated_a_post(this assert assert)
        {
            assert.Expect(ex =>
            {
                ex.Result.Should().NotBeNull();
            });

            return assert;
        }        
        public static assert I_should_have_a_posts_list(this assert assert)
        {
            assert.Expect(ex =>
            {
                ex.PostsListResult.Should().NotBeNull();
            });

            return assert;
        }
    }
}
