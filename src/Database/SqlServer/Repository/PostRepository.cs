using Microsoft.EntityFrameworkCore;
using Tryitter.Interfaces.Repository;
using Tryitter.Models;
using Tryitter.src.Database.SqlServer;

namespace Tryitter.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;
        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Post> Create(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task Delete(Guid id)
        {
            var post = _context.Posts.FindAsync(id);
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Post>> ReadAll()
        {
            return await _context.Posts.AsNoTracking().ToListAsync();
        }

        public async Task<Post> ReadLastOne(Guid userId)
        {
            var lastPost = await _context.Posts.Where(x => x.StudentId == userId).FirstAsync();
            return lastPost!;
        }

        public async Task<Post> ReadOne(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            return post!;
        }

        public async Task<List<Post>> ReadStudentAllPosts(Guid userId)
        {
            var posts = await _context.Posts.AsNoTracking().Where(x => x.StudentId == userId).ToListAsync();
            return posts;
        }

        public async Task<Post> Update(Post post)
        {
            var previousPost = await _context.Posts.FindAsync(post.Id);

            previousPost!.Text = post.Text;
            previousPost.ImageUrl = post.ImageUrl;

            await _context.SaveChangesAsync();
            return post;
        }
    }
}
