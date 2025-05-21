using lilgobguides.Data;
using lilgobguides.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lilgobguides.Pages;

public class IndexModel(ILogger<IndexModel> logger, AppDbContext db) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly AppDbContext _db = db;

    public List<Post> Posts { get; private set;  } = [];

    public async Task OnGet()
    {
        Posts = await _db.Posts.AsNoTracking().ToListAsync();
    }
}
