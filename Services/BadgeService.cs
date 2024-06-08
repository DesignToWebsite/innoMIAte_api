using System.Linq;
using innomiate_api.DTOs.Badging;
using innomiate_api.Models.Badging;
using Microsoft.EntityFrameworkCore;
using INNOMIATE_API.Data;

namespace innomiate_api.Services
{
    public class BadgeService
    {
        private readonly ApplicationDbContext _context;

        public BadgeService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Badge Methods

        public BadgeDto GetBadge(int badgeId)
        {
            var badge = _context.Badges
                .FirstOrDefault(b => b.BadgeId == badgeId);

            if (badge == null)
            {
                return null;
            }

            var badgeDto = new BadgeDto
            {
                BadgeId = badge.BadgeId,
                BadgeType = badge.BadgeType,
                Description = badge.Description,
                Image = badge.Image,
                Criteria = badge.Criteria,
                ExpirationDate = badge.ExpirationDate
            };

            return badgeDto;
        }

        public Badge CreateBadge(BadgeDto badgeDto)
        {
            var badge = new Badge
            {
                BadgeType = badgeDto.BadgeType,
                Description = badgeDto.Description,
                Image = badgeDto.Image,
                Criteria = badgeDto.Criteria,
                ExpirationDate = badgeDto.ExpirationDate
            };

            _context.Badges.Add(badge);
            _context.SaveChanges();
            return badge;
        }

        public void UpdateBadge(BadgeDto badgeDto)
        {
            var badge = _context.Badges.Find(badgeDto.BadgeId);
            if (badge != null)
            {
                badge.BadgeType = badgeDto.BadgeType;
                badge.Description = badgeDto.Description;
                badge.Image = badgeDto.Image;
                badge.Criteria = badgeDto.Criteria;
                badge.ExpirationDate = badgeDto.ExpirationDate;
                _context.SaveChanges();
            }
        }

        public Badge DeleteBadge(int badgeId)
        {
            var badge = _context.Badges.Find(badgeId);
            if (badge != null)
            {
                _context.Badges.Remove(badge);
                _context.SaveChanges();
            }
            return badge;
        }

        // Badging Methods

        public BadgingDto GetBadging(int competitionId)
        {
            var badging = _context.Badgings
                .Include(b => b.Badges)
                .FirstOrDefault(b => b.CompetitionId == competitionId);

            if (badging == null)
            {
                return null;
            }

            var badgingDto = new BadgingDto
            {
                BadgingId = badging.BadgingId,
                CompetitionId = badging.CompetitionId,
                Badges = badging.Badges.Select(b => new BadgeDto
                {
                    BadgeId = b.BadgeId,
                    BadgeType = b.BadgeType,
                    Description = b.Description,
                    Image = b.Image,
                    Criteria = b.Criteria,
                    ExpirationDate = b.ExpirationDate
                }).ToList()
            };

            return badgingDto;
        }

        public Badging CreateBadging(BadgingDto badgingDto)
        {
            var badging = new Badging
            {
                CompetitionId = badgingDto.CompetitionId
            };

            _context.Badgings.Add(badging);
            _context.SaveChanges();
            return badging;
        }

        public void UpdateBadging(BadgingDto badgingDto)
        {
            var badging = _context.Badgings.Find(badgingDto.BadgingId);
            if (badging != null)
            {
                badging.CompetitionId = badgingDto.CompetitionId;
                _context.SaveChanges();
            }
        }

        public Badging DeleteBadging(int competitionId)
        {
            var badging = _context.Badgings.Find(competitionId);
            if (badging != null)
            {
                _context.Badgings.Remove(badging);
                _context.SaveChanges();
            }
            return badging;
        }
    }
}
