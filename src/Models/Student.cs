using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tryitter.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(300)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Module { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? Password { get; set; }

        [JsonIgnore]
        public List<Post>? Posts { get; set; }
    }
}
