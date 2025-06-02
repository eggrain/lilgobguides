using lilgobguides.Data;
using lilgobguides.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lilgobguides.Pages.Posts;

public class ShowPostModel(AppDbContext db) : PageModel
{
    private readonly AppDbContext _db = db;

    public Post Post { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id == null) return NotFound();

        Post? post = await _db.Posts.AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (post == null) return NotFound();

        Post = post;
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(string? id)
    {
        if (id == null) return NotFound();

        Post? post = await _db.Posts.FirstOrDefaultAsync(p => p.Id == id);
        if (post == null) return NotFound();

        _db.Posts.Remove(post);
        await _db.SaveChangesAsync();

        return RedirectToPage("/Index");
    }
}

