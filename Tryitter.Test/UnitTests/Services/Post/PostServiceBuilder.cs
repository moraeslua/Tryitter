using Tryitter.src.Dto;
using FizzWare.NBuilder;

namespace TestProject1.UnitTests.Services.Student
{
    public class PostServiceBuilder
    {
        public static UpdatePostRequestDto GetUpdatePostRequestDto() =>
            Builder<UpdatePostRequestDto>
            .CreateNew()
            .WithFactory(() => new UpdatePostRequestDto() { Text = "new text", ImageUrl = "new image url" })
            .Build();

        public static CreatePostRequestDto GetCreatePostRequestDto() =>
            Builder<CreatePostRequestDto>
            .CreateNew()
            .WithFactory(() => new CreatePostRequestDto() { StudentId = StudentServiceBuilder.GetStudent().Id, Text = "text", ImageUrl = "image url" })
            .Build();

        public static Tryitter.Models.Post GetPost() =>
            Builder<Tryitter.Models.Post>
            .CreateNew()
            .WithFactory(() => new Tryitter.Models.Post() { Id = Guid.NewGuid(), StudentId = StudentServiceBuilder.GetStudent().Id, Text = "text", ImageUrl = "image url" })
            .Build();

        public static Tryitter.Models.Post GetPostUpdated() =>
            Builder<Tryitter.Models.Post>
            .CreateNew()
            .WithFactory(() => new Tryitter.Models.Post() { Id = Guid.NewGuid(), StudentId = StudentServiceBuilder.GetStudent().Id, Text = "new text", ImageUrl = "new image url" })
            .Build();        
        
        public static List<Tryitter.Models.Post> GetStudentPosts() =>
            Builder<List<Tryitter.Models.Post>>
            .CreateNew()
            .WithFactory(() => new List<Tryitter.Models.Post>()
            {
                new Tryitter.Models.Post() { Id = Guid.NewGuid(), StudentId = StudentServiceBuilder.GetStudent().Id, Text = "text", ImageUrl = "image url" },
                new Tryitter.Models.Post() { Id = Guid.NewGuid(), StudentId = StudentServiceBuilder.GetStudent().Id, Text = "text 2", ImageUrl = "image url 2" },
            })
            .Build();
    }
}
