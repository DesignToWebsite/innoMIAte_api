using innomiate_api.DTOs.Submission;
using innomiate_api.Models.Submission;
using INNOMIATE_API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace innomiate_api.Services
{
    public class TeamSubmissionService
    {
        private readonly ApplicationDbContext _context;

        public TeamSubmissionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public TeamSubmissionDto CreateTeamSubmission(TeamSubmissionDto teamSubmissionDto)
        {
            try
            {
                var teamSubmission = new TeamSubmission
                {
                    TeamId = teamSubmissionDto.TeamId,
                    SubmissionModelId = teamSubmissionDto.SubmissionModelId
                };

                _context.TeamSubmissions.Add(teamSubmission);
                _context.SaveChanges();

                teamSubmissionDto.TeamSubmissionId = teamSubmission.TeamSubmissionId;
                return teamSubmissionDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create team submission", ex);
            }
        }

        public void DeleteTeamSubmission(int teamSubmissionId)
        {
            try
            {
                var teamSubmission = _context.TeamSubmissions.Find(teamSubmissionId);
                if (teamSubmission == null)
                {
                    throw new ArgumentException("Team submission not found");
                }

                _context.TeamSubmissions.Remove(teamSubmission);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete team submission", ex);
            }
        }

        public TeamSubmissionDto GetTeamSubmissionById(int teamSubmissionId)
        {
            try
            {
                var teamSubmission = _context.TeamSubmissions.Find(teamSubmissionId);
                if (teamSubmission == null)
                {
                    throw new ArgumentException("Team submission not found");
                }

                var teamSubmissionDto = new TeamSubmissionDto
                {
                    TeamSubmissionId = teamSubmission.TeamSubmissionId,
                    TeamId = teamSubmission.TeamId,
                    SubmissionModelId = teamSubmission.SubmissionModelId
                };

                return teamSubmissionDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get team submission", ex);
            }
        }

        public IEnumerable<TeamSubmissionDto> GetTeamSubmissionsByCompetition(int competitionId)
        {
            try
            {
                var teamSubmissions = _context.TeamSubmissions
                    .Where(ts => ts.Team.CompetitionId == competitionId)
                    .Select(ts => new TeamSubmissionDto
                    {
                        TeamSubmissionId = ts.TeamSubmissionId,
                        TeamId = ts.TeamId,
                        SubmissionModelId = ts.SubmissionModelId
                    })
                    .ToList();

                return teamSubmissions;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get team submissions", ex);
            }
        }

        public void UpdateTeamSubmission(int teamSubmissionId, TeamSubmissionDto teamSubmissionDto)
        {
            try
            {
                var teamSubmission = _context.TeamSubmissions.Find(teamSubmissionId);
                if (teamSubmission == null)
                {
                    throw new ArgumentException("Team submission not found");
                }

                teamSubmission.TeamId = teamSubmissionDto.TeamId;
                teamSubmission.SubmissionModelId = teamSubmissionDto.SubmissionModelId;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update team submission", ex);
            }
        }
    }
}
