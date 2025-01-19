using System.ComponentModel.DataAnnotations;

namespace Data.DTOs;

public class CommentAddDTO
{
    [Required]
    public string Content { get; set; } = null!;
    [Required]
    public int TicketId { get; set; }
    [Required]
    public int UserId { get; set; }
}
