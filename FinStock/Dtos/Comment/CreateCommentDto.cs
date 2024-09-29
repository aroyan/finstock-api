using System.ComponentModel.DataAnnotations;

namespace FinStock.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 characters and more")]
        [MaxLength(280, ErrorMessage = "Title must not be more than 280 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Comment must be 5 characters and more")]
        public string Content { get; set; } = string.Empty;
    }
}