using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lilgobguides.Controllers;

[ApiController, Route("uploads")]
public class UploadsController(IWebHostEnvironment env) : ControllerBase
{
    private readonly IWebHostEnvironment _env = env;

    [Authorize, HttpDelete("trix")]
    public IActionResult DeleteImage([FromQuery] string url)
    {
        string fileName = Path.GetFileName(url);
        string path = Path.Combine(_env.WebRootPath, "uploads", fileName);

        if (System.IO.File.Exists(path))
            System.IO.File.Delete(path);

        return Ok();
    }

    [Authorize, HttpPost("trix")]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        string uploadsPath = Path.Combine(_env.WebRootPath, "uploads");
        Directory.CreateDirectory(uploadsPath);

        string fileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
        string filePath = Path.Combine(uploadsPath, fileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        string fileUrl = Url.Content($"~/uploads/{fileName}");
        return Ok(new { url = fileUrl });
    }
}