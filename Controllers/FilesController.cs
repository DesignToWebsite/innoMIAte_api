using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INNOMIATE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public FilesController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("upload")]
        public IActionResult Upload(IFormFile file)
        {
            try
            {
                // Get the directory path where you want to save the file
                var uploadsDirectory = Path.Combine(_environment.ContentRootPath, "uploads");

                // Create the directory if it doesn't exist
                if (!Directory.Exists(uploadsDirectory))
                {
                    Directory.CreateDirectory(uploadsDirectory);
                }

                // Generate a unique file name to prevent overwriting
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                
                // Combine the directory path and file name
                var filePath = Path.Combine("uploads", fileName);

                // Save the file to the server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // Return the file path or any other response
                return Ok(new { FilePath = filePath });
            }
            catch (Exception ex)
            {
                // Return an error response
                return StatusCode(500, $"Error uploading file: {ex.Message}");
            }
        }
    }
}
