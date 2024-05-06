using innomiate_api.DTOs;
using innomiate_api.Models;
using INNOMIATE_API.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace innomiate_api.Services
{
    public class TeamService
    {
        private readonly ApplicationDbContext _context;

        public TeamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public TeamDto CreateTeam(TeamDto teamDto)
        {
            try
            {
                var team = new Team
                {
                    Name = teamDto.Name,
                    Slogan = teamDto.Slogan,
                    TeamLeaderUserId = teamDto.TeamLeaderUserId,
                    TeamLeaderCompetitionId = teamDto.TeamLeaderCompetitionId,
                    CompetitionId = teamDto.CompetitionId,
                };

                _context.Teams.Add(team);
                _context.SaveChanges();

                var createdTeamDto = new TeamDto
                {
                    TeamId = team.TeamId,
                    Name = team.Name,
                    Slogan = team.Slogan,
                    TeamLeaderUserId = team.TeamLeaderUserId,
                    TeamLeaderCompetitionId = team.TeamLeaderCompetitionId,
                    CompetitionId = team.CompetitionId,
                    // Map other properties accordingly
                };

                return createdTeamDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create team", ex);
            }
        }

        public TeamDto UpdateTeam(int teamId, TeamDto teamDto)
        {
            try
            {
                var team = _context.Teams.Find(teamId);

                if (team == null)
                {
                    throw new ArgumentException("Team not found");
                }

                team.Name = teamDto.Name;
                team.Slogan = teamDto.Slogan;
                team.TeamLeaderUserId = teamDto.TeamLeaderUserId;
                team.TeamLeaderCompetitionId = teamDto.TeamLeaderCompetitionId;
                team.CompetitionId = teamDto.CompetitionId;

                _context.SaveChanges();

                var updatedTeamDto = new TeamDto
                {
                    TeamId = team.TeamId,
                    Name = team.Name,
                    Slogan = team.Slogan,
                    TeamLeaderUserId = team.TeamLeaderUserId,
                    TeamLeaderCompetitionId = team.TeamLeaderCompetitionId,
                    CompetitionId = team.CompetitionId,
                };

                return updatedTeamDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update team", ex);
            }
        }

        public void DeleteTeam(int teamId)
        {
            try
            {
                var team = _context.Teams.Find(teamId);

                if (team == null)
                {
                    throw new ArgumentException("Team not found");
                }

                _context.Teams.Remove(team);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log exception or handle as needed
                throw new Exception("Failed to delete team", ex);
            }
        }

        public List<TeamDto> GetTeamsByCompetitionId(int competitionId)
        {
            try
            {
                var teams = _context.Teams
                    .Where(t => t.CompetitionId == competitionId)
                    .Select(t => new TeamDto
                    {
                        TeamId = t.TeamId,
                        Name = t.Name,
                        Slogan = t.Slogan,
                        TeamLeaderUserId = t.TeamLeaderUserId,
                        TeamLeaderCompetitionId = t.TeamLeaderCompetitionId,
                        CompetitionId = t.CompetitionId,
                        // Map other properties accordingly
                    })
                    .ToList();

                return teams;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve teams by competition ID", ex);
            }
        }
    }
}
