using Tryitter.Models;
using Tryitter.src.Dto;

namespace Tryitter.src.Interfaces.Services
{
    public interface IPostService
    {
        Task<Post> Create(CreatePostRequestDto request);
        Task<Post> ReadOne(Guid id);
        Task<Post> ReadStudentLastPostAsync(Guid studentId);
        Task<List<Post>> ReadAll();
        Task<List<Post>> ReadStudentAllPosts(Guid studentId);
        Task<Post> Update(Guid id, UpdatePostRequestDto request);
        Task Delete(Guid id);
    }
}
