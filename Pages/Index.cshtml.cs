using lilgobguides.Data;
using lilgobguides.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lilgobguides.Pages;

public class IndexModel(AppDbContext db) : PageModel
{
    private readonly AppDbContext _db = db;

    public List<Post> Posts { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Posts = await _db.Posts
            .AsNoTracking()
            .OrderByDescending(post => post.CreatedAt)
            .ToListAsync();
    }
}