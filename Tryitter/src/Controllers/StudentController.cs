using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Dto;
using Tryitter.Helpers;
using Tryitter.src.Dto;
using Tryitter.src.Entities;
using Tryitter.src.Interfaces.Services;

namespace Tryitter.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController : Controller
    {
        public IStudentService _studentService { get; private set; }
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult<StudentAuthenticatedOutput>> RegisterAsync([FromBody] CreateStudentRequestDto request)
        {
            var result = await _studentService.Create(request);
            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<StudentAuthenticatedOutput>> Authenticate([FromBody] AuthorizeRequestDto request)
        {
            var result = await _studentService.Authenticate(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        //[ProducesResponseType(typeof(Student), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var payload = Request.GetAuthenticationPayload();
            var student = await _studentService.ReadById(payload.StudentId);
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var students = await _studentService.ReadAll();
            return Ok(students);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateStudentRequestDto request)
        {
            var payload = Request.GetAuthenticationPayload();
            var studentUpdated = await _studentService.Update(payload.StudentId, request);
            return Ok(studentUpdated);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var payload = Request.GetAuthenticationPayload();
            await _studentService.Delete(payload.StudentId);
            return Ok();
        }
    }
}
