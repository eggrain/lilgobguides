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

    [BindProperty]
    public IFormFile? HeaderImageFile { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("Model validation failed");
            return Page();
        }

        if (HeaderImageFile != null && HeaderImageFile.Length > 0)
        {
            using var ms = new MemoryStream();
            await HeaderImageFile.CopyToAsync(ms);
            Post.HeaderImageData = ms.ToArray();
            Post.HeaderImageContentType = HeaderImageFile.ContentType;
        }

        _db.Posts.Add(Post);
        await _db.SaveChangesAsync();

        return RedirectToPage("/Index"); 
    }
}
