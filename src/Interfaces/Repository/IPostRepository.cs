using Tryitter.Models;

namespace Tryitter.Interfaces.Repository
{
    public interface IPostRepository
    {
        Task<Post> Create(Post post);
        Task<Post> ReadOne(Guid id);
        Task<Post> ReadLastOne(Guid id);
        Task<List<Post>> ReadAll();
        Task<List<Post>> ReadStudentAllPosts(Guid studentId);
        Task<Post> Update(Post post);
        Task Delete(Guid id);
    }
}
