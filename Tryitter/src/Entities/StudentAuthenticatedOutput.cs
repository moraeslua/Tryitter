using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tryitter.Models;

namespace Tryitter.src.Entities
{
    public class StudentAuthenticatedOutput
    {
        public Student Student { get; set; } = new Student();
        public string Token { get; set; } = string.Empty;

    }
}
