using Tryitter.Interfaces.Repository;
using Tryitter.Models;
using Tryitter.src.Dto;
using Tryitter.src.Exceptions;
using Tryitter.src.Interfaces.Services;

namespace Tryitter.src.Services
{
    public class PostService : IPostService
    {
        public IPostRepository _postRepository { get; set; }
        public IStudentService _studentService { get; set; }
        public PostService(IPostRepository postRepository, IStudentService studentService)
        {
            _postRepository = postRepository;
            _studentService = studentService;
        }

        public async Task<Post> Create(CreatePostRequestDto request)
        {
            var post = new Post()
            {
                Id = Guid.NewGuid(),
                StudentId = request.StudentId,
                ImageUrl = request.ImageUrl,
                Text = request.Text,
            };
            
            var newPost = await  _postRepository.Create(post);
            return newPost;
        }

        public async Task Delete(Guid id)
        {
            await ReadOne(id);
            await _postRepository.Delete(id);
        }

        public async Task<List<Post>> ReadAll()
        {
            var posts = await _postRepository.ReadAll();
            return posts;
        }

        public Task<Post> ReadOne(Guid id)
        {
            var post = _postRepository.ReadOne(id);
            if (post is null) throw new NotFoundException("Post does not exists");
            return post;
        }

        public async Task<Post> ReadStudentLastPostAsync(Guid studentId)
        {
            await _studentService.ReadById(studentId);
            var post = await _postRepository.ReadLastOne(studentId);
            return post;
        }

        public async Task<Post> Update(Guid id, UpdatePostRequestDto request)
        {
            var previousPost = await ReadOne(id);
            
            var postToUpdate = new Post()
            {
                Id = previousPost.Id,
                StudentId = previousPost.StudentId,
                ImageUrl = request.ImageUrl,
                Text = request.Text
            };
            
            var updated = await _postRepository.Update(postToUpdate);
            return updated;
        }

        public async Task<List<Post>> ReadStudentAllPosts(Guid studentId)
        {
            await _studentService.ReadById(studentId);
            var posts = await _postRepository.ReadStudentAllPosts(studentId);
            return posts;
        }
    }
}
