namespace innomiate_api.Services
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using global::innomiate_api.DTOs;
    using global::innomiate_api.Models;
    using global::INNOMIATE_API.Data;
    using Microsoft.AspNetCore.Hosting;

    namespace innomiate_api.Services
    {
        public class SubmittedInputService
        {
            private readonly ApplicationDbContext _context;
            private readonly string _uploadFolderPath;

            public SubmittedInputService(ApplicationDbContext context, IWebHostEnvironment env)
            {
                _context = context;
                _uploadFolderPath = Path.Combine(env.ContentRootPath, "uploads");
            }

            public async Task<SubmittedInputDto> CreateSubmittedInputAsync(SubmittedInputDto submittedInputDto)
            {
                var submittedInput = new SubmittedInput
                {
                    StepInputId = submittedInputDto.StepInputId,
                    TeamId = submittedInputDto.TeamId
                };

                if (submittedInputDto.Value != null)
                {
                    var filePath = Path.Combine(_uploadFolderPath, submittedInputDto.Value.FileName);
                    Directory.CreateDirectory(_uploadFolderPath);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await submittedInputDto.Value.CopyToAsync(stream);
                    }

                    submittedInput.Value = filePath;
                }

                _context.submittedInputs.Add(submittedInput);
                await _context.SaveChangesAsync();

                submittedInputDto.Id = submittedInput.Id;
                return submittedInputDto;
            }
        }
    }

}
