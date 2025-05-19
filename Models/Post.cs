namespace lilgobguides.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string AuthorId { get; set; } = default!;
}
