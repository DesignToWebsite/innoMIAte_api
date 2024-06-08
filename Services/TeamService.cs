using INNOMIATE_API.Data;
using innomiate_api.Models;
using Microsoft.EntityFrameworkCore;
using innomiate_api.DTOs;

namespace INNOMIATE_API.Services
{/*
    public class TeamService
    {
        private readonly ApplicationDbContext _context;

        public TeamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TeamDto> CreateTeamAsync(TeamDto teamDto)
        {
            var team = new Team
            {
                Name = teamDto.Name,
                Slogan = teamDto.Slogan,
                CompetitionId = teamDto.CompetitionId ,
                ProjectName = teamDto.ProjectName,
                ProjectDescription = teamDto.ProjectDescription,
                ProjectImage = teamDto.ProjectDescription  
            };

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return new TeamDto
            {
                TeamId = team.TeamId,
                Name = team.Name,
                Slogan = team.Slogan,
                CompetitionId = team.CompetitionId,
                ProjectName = teamDto.ProjectName,
                ProjectDescription = teamDto.ProjectDescription,
                ProjectImage = teamDto.ProjectDescription  
            };
        }

        public async Task<bool> DeleteTeamAsync(int teamId)
        {
            var team = await _context.Teams.FindAsync(teamId);
            if (team == null)
            {
                return false;
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TeamDto> UpdateTeamAsync(UpdateTeamDto updateTeamDto)
        {
            var existingTeam = await _context.Teams.FindAsync(updateTeamDto.TeamId);
            if (existingTeam == null)
            {
                return null;
            }

            existingTeam.Name = updateTeamDto.Name;
            existingTeam.Slogan = updateTeamDto.Slogan;
            existingTeam.CompetitionId = updateTeamDto.CompetitionId;

            _context.Teams.Update(existingTeam);
            await _context.SaveChangesAsync();

            return new TeamDto
            {
                TeamId = existingTeam.TeamId,
                Name = existingTeam.Name,
                Slogan = existingTeam.Slogan,
                CompetitionId = existingTeam.CompetitionId
            };
        }

        public async Task<TeamDto> GetTeamByIdAsync(int teamId)
        {
            var team = await _context.Teams
                .Include(t => t.Participants)
                .ThenInclude(p => p.User)
                .Include(t => t.SubmittedInputs)
                .FirstOrDefaultAsync(t => t.TeamId == teamId);

            if (team == null)
            {
                return null;
            }

            return new TeamDto
            {
                TeamId = team.TeamId,
                Name = team.Name,
                Slogan = team.Slogan,
                CompetitionId = team.CompetitionId
            };
        }
    }
    */
}
