using innomiate_api.DTOs.ValidationSteps;
using innomiate_api.Models.ValidationSteps;
using INNOMIATE_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace innomiate_api.Services
{
    public class TeamStepSubmissionService
    {
        private readonly ApplicationDbContext _context;

        public TeamStepSubmissionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public TeamStepSubmissionDto CreateTeamStepSubmission(TeamStepSubmissionDto teamStepSubmissionDto)
        {
            try
            {
                var teamStepSubmission = new TeamStepSubmission
                {
                    TeamId = teamStepSubmissionDto.TeamId,
                    StepId = teamStepSubmissionDto.StepId,
                    SubmissionFilePath = teamStepSubmissionDto.SubmissionFilePath,
                    SubmissionDate = teamStepSubmissionDto.SubmissionDate
                };

                _context.TeamStepSubmissions.Add(teamStepSubmission);
                _context.SaveChanges();

                teamStepSubmissionDto.TeamStepSubmissionId = teamStepSubmission.TeamStepSubmissionId; // Update ID in DTO
                return teamStepSubmissionDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create TeamStepSubmission", ex);
            }
        }

        public TeamStepSubmissionDto UpdateTeamStepSubmission(int id, TeamStepSubmissionDto teamStepSubmissionDto)
        {
            try
            {
                var teamStepSubmission = _context.TeamStepSubmissions.Find(id);

                if (teamStepSubmission == null)
                    throw new ArgumentException("TeamStepSubmission not found");

                teamStepSubmission.TeamId = teamStepSubmissionDto.TeamId;
                teamStepSubmission.StepId = teamStepSubmissionDto.StepId;
                teamStepSubmission.SubmissionFilePath = teamStepSubmissionDto.SubmissionFilePath;
                teamStepSubmission.SubmissionDate = teamStepSubmissionDto.SubmissionDate;

                _context.SaveChanges();

                return teamStepSubmissionDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update TeamStepSubmission", ex);
            }
        }

        public void DeleteTeamStepSubmission(int id)
        {
            try
            {
                var teamStepSubmission = _context.TeamStepSubmissions.Find(id);

                if (teamStepSubmission == null)
                    throw new ArgumentException("TeamStepSubmission not found");

                _context.TeamStepSubmissions.Remove(teamStepSubmission);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete TeamStepSubmission", ex);
            }
        }

        public List<TeamStepSubmissionDto> GetTeamStepSubmissionsByCompetitionId(int competitionId)
        {
            try
            {
                var teamStepSubmissions = _context.TeamStepSubmissions
                    .Where(t => t.Step.CompetitionId == competitionId)
                    .ToList();

                var teamStepSubmissionDtos = teamStepSubmissions.Select(ts => new TeamStepSubmissionDto
                {
                    TeamStepSubmissionId = ts.TeamStepSubmissionId,
                    TeamId = ts.TeamId,
                    StepId = ts.StepId,
                    SubmissionFilePath = ts.SubmissionFilePath,
                    SubmissionDate = ts.SubmissionDate
                }).ToList();

                return teamStepSubmissionDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get TeamStepSubmissions by competition ID", ex);
            }
        }
    }
}
