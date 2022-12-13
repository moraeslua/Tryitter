using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tryitter.Models;

namespace Tryitter.src.Dto
{
    public class UpdateStudentRequestDto
    {
        public string? FullName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? Module { get; set; } = string.Empty;
        public string? Status { get; set; } = string.Empty;
        public string? Password { get; set; }
    }
}
