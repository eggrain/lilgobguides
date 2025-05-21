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

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        Post? post = await _db.Posts.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

        if (post == null) return NotFound();
        Post = post;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("It was not valid -");
            return Page();
        }

        _db.Entry(Post).State = EntityState.Modified;
        await _db.SaveChangesAsync();

        return RedirectToPage("/Posts/ShowPost", new { Post.Id });
    }
}