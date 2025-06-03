using lilgobguides.Data;
using lilgobguides.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lilgobguides.Pages.Posts;

public class MinigamesModel(AppDbContext db) : CategoryPageModel(db)
{
    public override async Task OnGet()
    {
        Posts = await _db.Posts.Where(p => p.Categorization.Minigame == true)
                        .AsNoTracking().ToListAsync();
    }
}