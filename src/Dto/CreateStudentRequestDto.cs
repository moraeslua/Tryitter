using System.ComponentModel.DataAnnotations;

namespace Tryitter.Dto
{
    public class CreateStudentRequestDto
    {
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Module { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
