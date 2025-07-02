using lilgobguides.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace lilgobguides.Pages.Admin;

[Authorize]
public class IndexModel(AppDbContext db) : PageModel
{
    private readonly AppDbContext _db = db;
    public List<Post> Posts { get; private set; } = [];

    public async Task<IActionResult> OnGetAsync()
    {
        Posts = await _db.Posts.ToListAsync();

        return Page();
    }
}
