using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lilgobguides.Models;

public class PostCategorization
{
    public bool Skilling { get; set; }
    public bool Minigame { get; set; }
    public bool Item { get; set; }
    public bool Boss { get; set; }

    [Key, ForeignKey(nameof(Post))]
    public string PostId { get; set; } = null!;
    public Post Post { get; set; } = null!;
}