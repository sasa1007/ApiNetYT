using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Comment;

public class CreateCommentDto
{
    [Required]
    [MinLength(3, ErrorMessage = "Comment title min length is 3")]
    [MaxLength(250, ErrorMessage = "Comment title max length is 100")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MinLength(3, ErrorMessage = "Comment content min length is 3")]
    [MaxLength(250, ErrorMessage = "Comment content max length is 100")]

    public string Content { get; set; } = string.Empty;
}