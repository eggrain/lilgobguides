using lilgobguides.Data;
using lilgobguides.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lilgobguides.Pages.Posts;

public class DetailsModel(AppDbContext db) : PageModel
{
    private readonly AppDbContext _db = db;

    public Post? Post { get; set;  }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        Post = await _db.Posts.AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (Post == null) return NotFound();

        return Page();
    }
}

