using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace lilgobguides.Models;

public class PostCategorization
{
    [Key, ForeignKey(nameof(Post))]
    public string PostId { get; set; } = null!;
    [ValidateNever]
    public Post? Post { get; set; } = null!;
    public bool Skilling { get; set; }
    public bool Minigame { get; set; }
    public bool Item { get; set; }
    public bool Boss { get; set; }
}