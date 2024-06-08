using System;
using System.Linq;
using System.Threading.Tasks;
using innomiate_api.DTOs;
using innomiate_api.Models;
using INNOMIATE_API.Data;

namespace innomiate_api.Services
{
    public class CoachingManagingService
    {
        private readonly ApplicationDbContext _context;

        public CoachingManagingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CompetitionPendingCoachDto> CreatePendingCoach(CompetitionPendingCoachDto coachDto)
        {
            var coach = new CompetitionPendingCoach
            {
                CoachEmail = coachDto.CoachEmail,
                Comment = coachDto.Comment,
                CompetitionId = coachDto.CompetitionId
            };

            _context.CompetitionPendingCoaches.Add(coach);
            await _context.SaveChangesAsync();

            coachDto.Id = coach.Id; // Update the DTO with the generated ID
            return coachDto;
        }

        public async Task UpdatePendingCoach(int id, CompetitionPendingCoachDto coachDto)
        {
            var coachToUpdate = await _context.CompetitionPendingCoaches.FindAsync(id);

            if (coachToUpdate == null)
            {
                throw new ArgumentException("Coach not found");
            }

            coachToUpdate.CoachEmail = coachDto.CoachEmail;
            coachToUpdate.Comment = coachDto.Comment;

            await _context.SaveChangesAsync();
        }

        public async Task DeletePendingCoach(int id)
        {
            var coachToDelete = await _context.CompetitionPendingCoaches.FindAsync(id);

            if (coachToDelete == null)
            {
                throw new ArgumentException("Coach not found");
            }

            _context.CompetitionPendingCoaches.Remove(coachToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllPendingCoachesByCompetitionId(int competitionId)
        {
            var coachesToDelete = _context.CompetitionPendingCoaches.Where(coach => coach.CompetitionId == competitionId);
            _context.CompetitionPendingCoaches.RemoveRange(coachesToDelete);
            await _context.SaveChangesAsync();
        }

        public List<CompetitionPendingCoachDto> GetPendingCoachesByCompetitionId(int competitionId)
        {
            var coaches = _context.CompetitionPendingCoaches
                .Where(coach => coach.CompetitionId == competitionId)
                .Select(coach => new CompetitionPendingCoachDto
                {
                    Id = coach.Id,
                    CoachEmail = coach.CoachEmail,
                    Comment = coach.Comment,
                    CompetitionId = coach.CompetitionId
                })
                .ToList();

            return coaches;
        }

        // Announce managing
        public async Task UpdateAnnouncement(int id, CompetitionCoachingAnnounceDto announceDto)
        {
            var announcementToUpdate = await _context.CompetitionCoachingAnnounces.FindAsync(id);

            if (announcementToUpdate == null)
            {
                throw new ArgumentException("Announcement not found");
            }

            announcementToUpdate.Description = announceDto.Description;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAnnouncement(int id)
        {
            var announcementToDelete = await _context.CompetitionCoachingAnnounces.FindAsync(id);

            if (announcementToDelete == null)
            {
                throw new ArgumentException("Announcement not found");
            }

            _context.CompetitionCoachingAnnounces.Remove(announcementToDelete);
            await _context.SaveChangesAsync();
        }

        public CompetitionCoachingAnnounceDto GetAnnouncementByCompetitionId(int competitionId)
        {
            var announcement = _context.CompetitionCoachingAnnounces
                .SingleOrDefault(a => a.CompetitionId == competitionId);

            if (announcement == null)
            {
                throw new ArgumentException("Announcement not found");
            }

            return new CompetitionCoachingAnnounceDto
            {
                Id = announcement.Id,
                Description = announcement.Description,
                CompetitionId = announcement.CompetitionId
            };
        }

        public async Task<CompetitionCoachingAnnounceDto> CreateAnnouncement(CompetitionCoachingAnnounceDto announceDto)
        {
            var announcement = new CompetitionCoachingAnnounce
            {
                Description = announceDto.Description,
                CompetitionId = announceDto.CompetitionId
            };

            _context.CompetitionCoachingAnnounces.Add(announcement);
            await _context.SaveChangesAsync();

            announceDto.Id = announcement.Id; // Update the DTO with the generated ID
            return announceDto;
        }


        // Tags 
        public async Task<CompetitionCoachingTagDto> CreateTag(CompetitionCoachingTagDto tagDto)
        {
            var tag = new CompetitionCoachingTag
            {
                TagName = tagDto.TagName,
                CompetitionId = tagDto.CompetitionId
            };

            _context.CompetitionCoachingTags.Add(tag);
            await _context.SaveChangesAsync();

            tagDto.Id = tag.Id; // Update the DTO with the generated ID
            return tagDto;
        }

        public async Task UpdateTag(int id, CompetitionCoachingTagDto tagDto)
        {
            var tagToUpdate = await _context.CompetitionCoachingTags.FindAsync(id);

            if (tagToUpdate == null)
            {
                throw new ArgumentException("Tag not found");
            }

            tagToUpdate.TagName = tagDto.TagName;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTag(int id)
        {
            var tagToDelete = await _context.CompetitionCoachingTags.FindAsync(id);

            if (tagToDelete == null)
            {
                throw new ArgumentException("Tag not found");
            }

            _context.CompetitionCoachingTags.Remove(tagToDelete);
            await _context.SaveChangesAsync();
        }

        public List<CompetitionCoachingTagDto> GetTagsByCompetitionId(int competitionId)
        {
            var tags = _context.CompetitionCoachingTags
                .Where(tag => tag.CompetitionId == competitionId)
                .Select(tag => new CompetitionCoachingTagDto
                {
                    Id = tag.Id,
                    TagName = tag.TagName,
                    CompetitionId = tag.CompetitionId
                })
                .ToList();

            return tags;
        }

    }
}
