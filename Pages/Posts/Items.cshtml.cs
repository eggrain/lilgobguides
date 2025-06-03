using lilgobguides.Data;
using Microsoft.EntityFrameworkCore;

namespace lilgobguides.Pages.Posts;

public class ItemsModel(AppDbContext db) : CategoryPageModel(db)
{
    public override async Task OnGet()
    {
        Posts = await _db.Posts.Where(p => p.Categorization.Item == true)
                        .AsNoTracking().ToListAsync();
    }
}