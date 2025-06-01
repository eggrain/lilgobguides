using lilgobguides.Data;
using lilgobguides.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lilgobguides.Pages.Posts;

public class SkillingModel(AppDbContext db) : PageModel
{
    private readonly AppDbContext _db = db;

    public List<Post> Posts { get; private set; } = [];

    public async Task OnGet()
    {
        Posts = await _db.Posts.Where(p => p.Categorization.Skilling == true)
                        .AsNoTracking().ToListAsync();
    }
}