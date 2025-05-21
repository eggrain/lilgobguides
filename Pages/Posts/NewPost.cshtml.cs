using lilgobguides.Data;
using lilgobguides.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lilgobguides.Pages.Posts;

[Authorize]
public class NewPostModel(AppDbContext db) : PageModel
{
    private readonly AppDbContext _db = db;

    [BindProperty]
    public Post Post { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("It was not valid");
            return Page();
        }

        _db.Posts.Add(Post);
        await _db.SaveChangesAsync();

        return RedirectToPage("/Index"); 
    }
}
