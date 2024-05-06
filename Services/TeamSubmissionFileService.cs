using innomiate_api.DTOs.Submission;
using innomiate_api.Models.Submission;
using INNOMIATE_API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace innomiate_api.Services
{
    public class TeamSubmissionFileService
    {
        private readonly ApplicationDbContext _context;

        public TeamSubmissionFileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public TeamSubmissionFileDto CreateTeamSubmissionFile(TeamSubmissionFileDto teamSubmissionFileDto)
        {
            try
            {
                var teamSubmissionFile = new TeamSubmissionFile
                {
                    File = teamSubmissionFileDto.File,
                    FileName = teamSubmissionFileDto.FileName,
                    ContentType = teamSubmissionFileDto.ContentType,
                    TeamSubmissionId = teamSubmissionFileDto.TeamSubmissionId,
                    FileModelId = teamSubmissionFileDto.FileModelId
                };

                _context.TeamSubmissionFiles.Add(teamSubmissionFile);
                _context.SaveChanges();

                teamSubmissionFileDto.TeamSubmissionFileId = teamSubmissionFile.TeamSubmissionFileId;
                return teamSubmissionFileDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create team submission file", ex);
            }
        }

        public void DeleteTeamSubmissionFile(int teamSubmissionFileId)
        {
            try
            {
                var teamSubmissionFile = _context.TeamSubmissionFiles.Find(teamSubmissionFileId);
                if (teamSubmissionFile == null)
                {
                    throw new ArgumentException("Team submission file not found");
                }

                _context.TeamSubmissionFiles.Remove(teamSubmissionFile);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete team submission file", ex);
            }
        }

        public void UpdateTeamSubmissionFile(int teamSubmissionFileId, TeamSubmissionFileDto teamSubmissionFileDto)
        {
            try
            {
                var teamSubmissionFile = _context.TeamSubmissionFiles.Find(teamSubmissionFileId);
                if (teamSubmissionFile == null)
                {
                    throw new ArgumentException("Team submission file not found");
                }

                teamSubmissionFile.File = teamSubmissionFileDto.File;
                teamSubmissionFile.FileName = teamSubmissionFileDto.FileName;
                teamSubmissionFile.ContentType = teamSubmissionFileDto.ContentType;
                teamSubmissionFile.TeamSubmissionId = teamSubmissionFileDto.TeamSubmissionId;
                teamSubmissionFile.FileModelId = teamSubmissionFileDto.FileModelId;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update team submission file", ex);
            }
        }

        public IEnumerable<TeamSubmissionFileDto> GetSubmissionFilesByTeamSubmission(int teamSubmissionId)
        {
            try
            {
                var teamSubmissionFiles = _context.TeamSubmissionFiles
                    .Where(tsf => tsf.TeamSubmissionId == teamSubmissionId)
                    .Select(tsf => new TeamSubmissionFileDto
                    {
                        TeamSubmissionFileId = tsf.TeamSubmissionFileId,
                        File = tsf.File,
                        FileName = tsf.FileName,
                        ContentType = tsf.ContentType,
                        TeamSubmissionId = tsf.TeamSubmissionId,
                        FileModelId = tsf.FileModelId
                    })
                    .ToList();

                return teamSubmissionFiles;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get team submission files", ex);
            }
        }
    }
}
