using lilgobguides.Data;
using lilgobguides.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lilgobguides.Pages.Posts;

public class EditPostModel(AppDbContext db) : PageModel
{
    private readonly AppDbContext _db = db;

    [BindProperty]
    public Post Post { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id == null) return NotFound();

        Post? post = await _db.Posts.Where(p => p.Id == id)
                    .AsNoTracking().FirstOrDefaultAsync();

        if (post == null) return NotFound();
        Post = post;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("Model validation failed");
            return Page();
        }

        Post? post = await _db.Posts.Where(p => p.Id == id)
                            .FirstOrDefaultAsync();

        if (post == null) return NotFound();

        post.Categorization ??= new() { PostId = Post.Id };

        post.Title = Post.Title;
        post.Content = Post.Content;
        post.Categorization.Skilling = Post.Categorization.Skilling;
        post.Categorization.Minigame = Post.Categorization.Minigame;
        post.Categorization.Item = Post.Categorization.Item;
        post.Categorization.Boss = Post.Categorization.Boss;

        await _db.SaveChangesAsync();

        return RedirectToPage("/Posts/ShowPost", new { Post.Id });
    }
}