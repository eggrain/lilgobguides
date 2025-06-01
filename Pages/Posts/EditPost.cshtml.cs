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
    public Post Post { get; set; } = new();

    private async Task<Post?> LoadPost(string id, bool asNoTracking)
    {
        var q1 = _db.Posts.Include(p => p.Categorization);

        var q2 = (asNoTracking == false) ? q1 : q1.AsNoTracking();

        return await q2.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id == null) return NotFound();

        Post? post = await LoadPost(id, true);

        if (post == null) return NotFound();
        Post = post;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {
        Console.WriteLine($"Prebind: Post.Categorization == null? {Post.Categorization == null}");
        foreach (var kv in ModelState
           .Where(kv => kv.Value.Errors.Count > 0))
{
    Console.WriteLine($"{kv.Key}: {string.Join(", ", kv.Value.Errors.Select(e => e.ErrorMessage))}");
}

        if (!ModelState.IsValid)
        {
            Console.WriteLine("It was not valid -");
            return Page();
        }

        Post? existing = await LoadPost(id, false);

        if (existing == null) return NotFound();

        existing.Categorization ??= new() { PostId = Post.Id };

        existing.Title = Post.Title;
        existing.Content = Post.Content;
        existing.Categorization.Skilling = Post.Categorization.Skilling;
        existing.Categorization.Minigame = Post.Categorization.Minigame;
        existing.Categorization.Item = Post.Categorization.Item;
        existing.Categorization.Boss = Post.Categorization.Boss;

        await _db.SaveChangesAsync();

        return RedirectToPage("/Posts/ShowPost", new { Post.Id });
    }
}