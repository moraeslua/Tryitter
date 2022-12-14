namespace Tryitter.src.Dto
{
    public class CreatePostRequestDto
    {
        public Guid StudentId { get; set; }

        public string Text { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
