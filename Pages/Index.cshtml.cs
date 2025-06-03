using lilgobguides.Data;
using lilgobguides.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lilgobguides.Pages;

public class IndexModel(AppDbContext db) : PageModel
{
    private readonly AppDbContext _db = db;

    public List<Post> Featured { get; private set;  } = [];

    public async Task OnGet()
    {
        Featured = await _db.Posts.Where(p => p.Featured == true)
                                .AsNoTracking().ToListAsync();
    }
}
