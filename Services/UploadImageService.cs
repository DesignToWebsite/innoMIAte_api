
using INNOMIATE_API.Data;
using Microsoft.AspNetCore.Mvc;

namespace INNOMIATE_API.Services;


public class UploadImageService(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IActionResult> UploadProfilePicture(IFormFile file)
{
    if (file == null || file.Length == 0)
    {
        return BadRequest("Invalid file.");
    }

    byte[] imageData;
    using (var memoryStream = new MemoryStream())
    {
        await file.CopyToAsync(memoryStream);
        imageData = memoryStream.ToArray();
    }
    return Ok(imageData);
}
}