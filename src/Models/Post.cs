using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tryitter.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("Student")]
        public Guid StudentId { get; set; }

        [Required]
        [MaxLength(300)]
        public string Text { get; set; } = string.Empty;

        [MaxLength(255)]
        public string ImageUrl { get; set; } = string.Empty;

        [JsonIgnore]
        public Student? Student { get; set; }
    }
}
