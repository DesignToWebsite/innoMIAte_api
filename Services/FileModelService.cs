using innomiate_api.DTOs.Submission;
using innomiate_api.Models.Submission;
using INNOMIATE_API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace innomiate_api.Services
{/*
    public class FileModelService
    {
        private readonly ApplicationDbContext _context;

        public FileModelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public FileModelDto CreateFileModel(FileModelDto fileModelDto)
        {
            try
            {
                var fileModel = new FileModel
                {
                    Type = fileModelDto.Type,
                    Title = fileModelDto.Title,
                    Description = fileModelDto.Description,
                    SubmissionModelId = fileModelDto.SubmissionModelId
                };

                _context.FileModels.Add(fileModel);
                _context.SaveChanges();

                fileModelDto.FileModelId = fileModel.FileModelId;
                return fileModelDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create file model", ex);
            }
        }

        public void DeleteFileModel(int fileModelId)
        {
            try
            {
                var fileModel = _context.FileModels.Find(fileModelId);
                if (fileModel == null)
                {
                    throw new ArgumentException("File model not found");
                }

                _context.FileModels.Remove(fileModel);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete file model", ex);
            }
        }

        public IEnumerable<FileModelDto> GetFileModelsBySubmissionModelId(int submissionModelId)
        {
            try
            {
                var fileModels = _context.FileModels
                    .Where(fm => fm.SubmissionModelId == submissionModelId)
                    .Select(fm => new FileModelDto
                    {
                        FileModelId = fm.FileModelId,
                        Type = fm.Type,
                        Title = fm.Title,
                        Description = fm.Description,
                        SubmissionModelId = fm.SubmissionModelId
                    })
                    .ToList();

                return fileModels;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve file models by submission model id", ex);
            }
        }
    }
    */
}
