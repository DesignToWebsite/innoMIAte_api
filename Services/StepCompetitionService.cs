using Microsoft.EntityFrameworkCore;
using INNOMIATE_API.Data;
using INNOMIATE_API.Models;
using INNOMIATE_API.DTOs;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace INNOMIATE_API.Services
{
    public class StepCompetitionService(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<StepCompetition?> GetStepById(int id)
        {
            return await _context.StepCompetitions
                            .FirstOrDefaultAsync(c => c.IdSteps == id);
        }

        public async Task<StepCompetition?> GetStepByIdTeamIdCompIdStep(int idSteps, int idTeam, int idCompetition)
        {
            return await _context.StepCompetitions
                .Where(step => step.IdSteps == idSteps  && step.IdCompetition == idCompetition)
                .FirstOrDefaultAsync();
        }



        public async Task<IEnumerable<StepCompetition>> GetAllStepsCompetitions(int competitionId)
        {

            return await _context
                    .StepCompetitions
                    .ToListAsync();
        }

        // public async Task<bool> CreateStep(StepCompetitionDto stepCompetitionDto)
        // {
        //     var StepCompetition = new StepCompetition
        //     {
        //         IdSteps = stepCompetitionDto.IdSteps,
        //         IdTeam = stepCompetitionDto.IdTeam,
        //         IdCompetition = stepCompetitionDto.IdTeam,
        //         Title = stepCompetitionDto.Title,
        //         Description = stepCompetitionDto.Description,
        //         SecondTitle = stepCompetitionDto.SecondTitle,
        //         ToComplete = stepCompetitionDto.ToComplete,
        //         StepOpen = stepCompetitionDto.StepOpen,
        //         DeadLineEnd = stepCompetitionDto.DeadLineEnd
        //     };

        //     try
        //     {
        //         _context.StepCompetitions.Add(StepCompetition);
        //         await _context.SaveChangesAsync();
        //         return true;
        //     }
        //     catch
        //     {
        //         return false;
        //     }
        // }

        public async Task<StepCompetition> CreateStep(StepCompetitionDto stepCompetitionDto)
        {
            var StepCompetition = new StepCompetition
            {
                IdSteps = stepCompetitionDto.IdSteps,
                IdCompetition = stepCompetitionDto.IdCompetition,
                Title = stepCompetitionDto.Title,
                Description = stepCompetitionDto.Description,
                SecondTitle = stepCompetitionDto.SecondTitle,
                ToComplete = stepCompetitionDto.ToComplete,
                StepOpen = stepCompetitionDto.StepOpen,
                DeadLineEnd = stepCompetitionDto.DeadLineEnd
            };

            // try
            // {
            //     // foreach (var input in stepCompetitionDto.ToComplete)
            //     // {
            //     //     //check if the input value is a file
            //     //     if (input.Type == "file" && !string.IsNullOrEmpty(input.ValueInput))
            //     //     {
            //     //         var fileUploadResponse = await UploadFile(input.ValueInput);
            //     //         input.ValueInput = fileUploadResponse.FilePath;
            //     //     }
            //     // }
            //     _context.StepCompetitions.Add(StepCompetition);
            //     await _context.SaveChangesAsync();
            //     return _context;
            // }
            // catch
            // {
            //     return false;
            // }
            _context.StepCompetitions.Add(StepCompetition);
            await _context.SaveChangesAsync();
            return StepCompetition;

        }


        // public async Task<bool> UploadTeamStep(int idTeam, int idCompetition, int idStep, StepCompetitionDto stepCompetitionDto)
        // {
        //     var step = await _context.StepCompetitions.FindAsync(1);
        //     var StepCompetition = new StepCompetition
        //     {
        //         IdSteps = stepCompetitionDto.IdSteps,
        //         IdTeam = stepCompetitionDto.IdTeam,
        //         IdCompetition = stepCompetitionDto.IdTeam,
        //         Title = stepCompetitionDto.Title,
        //         Description = stepCompetitionDto.Description,
        //         SecondTitle = stepCompetitionDto.SecondTitle,
        //         // ToComplete = stepCompetitionDto.ToComplete,
        //         StepOpen = stepCompetitionDto.StepOpen,
        //         DeadLineEnd = stepCompetitionDto.DeadLineEnd
        //     };

        //     try
        //     {
        //         foreach (var input in stepCompetitionDto.ToComplete)
        //         {
        //             //check if the input value is a file
        //             if (input.Type == "file" && !string.IsNullOrEmpty(input.ValueInput))
        //             {
        //                 var fileUploadResponse = await UploadFile(input.ValueInput);
        //                 input.ValueInput = fileUploadResponse.FilePath;
        //             }

        //         }
        //         _context.StepCompetitions.Add(StepCompetition);
        //         await _context.SaveChangesAsync();
        //         return true;
        //     }
        //     catch
        //     {
        //         return false;
        //     }
        // }



        // private async Task UploadFile(string valueInput)
        // {
        //     throw new NotImplementedException();
        // }

        // private async Task UploadFile(string valueInput)
        // {
        //     throw new NotImplementedException();
        // }

        // private static async Task UploadFile(IFormFile file)
        // {
        //     using (var client = new HttpClient())
        //     {
        //         using (var formData = new MultipartFormDataContent())
        //         {
        //             formData.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);

        //             using (var response = await client.PostAsync("http://localhost:5299/api/files/upload", formData))
        //             {
        //                 if (response.IsSuccessStatusCode)
        //                 {
        //                     var content = await response.Content.ReadAsStringAsync();
        //                     var responseObject = JsonConvert.DeserializeObject<FileUploadResponse>(content);
        //                     return responseObject.FilePath;
        //                 }
        //                 else
        //                 {
        //                     throw new Exception($"Failed to upload file: {response.ReasonPhrase}");
        //                 }
        //             }
        //         }
        //     }
        // }

        private static async Task<FileUploadResponse> UploadFile(string filePath)
        {
            using (var client = new HttpClient())
            {
                using (var formData = new MultipartFormDataContent())
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        formData.Add(new StreamContent(fileStream), "file", Path.GetFileName(filePath));

                        using (var response = await client.PostAsync("http://localhost:5299/api/files/upload", formData))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var content = await response.Content.ReadAsStringAsync();
                                return JsonConvert.DeserializeObject<FileUploadResponse>(content);
                            }
                            else
                            {
                                throw new Exception($"Failed to upload file: {response.ReasonPhrase}");
                            }
                        }
                    }
                }
            }
        }

    }
}
