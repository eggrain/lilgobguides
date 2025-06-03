using lilgobguides.Data;
using lilgobguides.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lilgobguides.Pages.Posts;

public abstract class CategoryPageModel(AppDbContext db) : PageModel
{
    protected readonly AppDbContext _db = db;

    public List<Post> Posts { get; set; } = [];

    public abstract Task OnGet();
}