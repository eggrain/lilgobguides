using lilgobguides.Data;
using lilgobguides.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lilgobguides.Pages;

public class IndexModel(AppDbContext db) : PageModel
{
    private readonly AppDbContext _db = db;

    public Post? FeaturedPost { get; private set; }

    public List<Post> Posts { get; private set; } = [];

    public async Task OnGetAsync()
    {
        List<Post> allPosts = await _db.Posts
            .AsNoTracking()
            .Include(post => post.Categorization)
            .OrderByDescending(post => post.CreatedAt)
            .ToListAsync();

        FeaturedPost = allPosts.FirstOrDefault(post => post.Featured);

        Posts = FeaturedPost is null
            ? allPosts
            : allPosts
                .Where(post => post.Id != FeaturedPost.Id)
                .ToList();
    }
}