using System.ComponentModel.DataAnnotations;

namespace lilgobguides.Models;

public class Post
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [Required]
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public PostCategorization Categorization { get; set; } = new();

    public Post()
    {
        Categorization.PostId = Id;
    }

    public byte[]? HeaderImageData { get; set; }

    // (e.g. "image/png")
    public string? HeaderImageContentType { get; set; }
}
