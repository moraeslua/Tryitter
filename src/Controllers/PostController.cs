using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Helpers;
using Tryitter.src.Dto;
using Tryitter.src.Interfaces.Services;

namespace Tryitter.Controllers
{
    [ApiController]
    [Route("posts")]
    public class PostController : Controller
    {
        public IPostService _postService { get; set; }
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(CreatePostRequestDto request)
        {
            var result = await _postService.Create(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var post = await _postService.ReadOne(id);
            return Ok(post);
        }

        [HttpGet("student/latest")]
        [Authorize]
        public async Task<IActionResult> GetStudentLastPostAsync()
        {
            var payload = Request.GetAuthenticationPayload();
            var post = await _postService.ReadStudentLastPostAsync(payload.StudentId);
            return Ok(post);
        }

        [HttpGet("another-student/latest")]
        [Authorize]
        public async Task<IActionResult> GetAnotherStudentLastPostAsync(Guid id)
        {
            var post = await _postService.ReadStudentLastPostAsync(id);
            return Ok(post);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var posts = await _postService.ReadAll();
            return Ok(posts);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdatePostRequestDto request)
        {
            var postUpdated = await _postService.Update(id, request);
            return Ok(postUpdated);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _postService.Delete(id);
            return Ok();
        }
    }
}
