using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tryitter.Models;

namespace Tryitter.src.Dto
{
    public class UpdatePostRequestDto
    {
        public string Text { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

    }
}
