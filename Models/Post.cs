using System.ComponentModel.DataAnnotations;

namespace lilgobguides.Models;

public class Post
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
