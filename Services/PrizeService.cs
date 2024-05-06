using System.Linq;
using innomiate_api.DTOs.Prizing;
using innomiate_api.Models.Prizing;
using Microsoft.EntityFrameworkCore;
using INNOMIATE_API.Data;

namespace innomiate_api.Services
{
    public class PrizeService
    {
        private readonly ApplicationDbContext _context;

        public PrizeService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Prize Methods

        public PrizeDto GetPrize(int prizeId)
        {
            var prize = _context.Prizes
                .Include(p => p.PrizeType)
                .FirstOrDefault(p => p.PrizeId == prizeId);

            if (prize == null)
            {
                return null;
            }

            var prizeDto = new PrizeDto
            {
                PrizeId = prize.PrizeId,
                BeginningRank = prize.BeginningRank,
                EndingRank = prize.EndingRank,
                PrizeTypeId = prize.PrizeTypeId,
                PrizeType = new PrizeTypeDto
                {
                    PrizeTypeId = prize.PrizeType.PrizeTypeId,
                    Name = prize.PrizeType.Name,
                    Amount = prize.PrizeType.Amount,
                    Currency = prize.PrizeType.Currency,
                    Description = prize.PrizeType.Description
                }
            };

            return prizeDto;
        }

        public Prize CreatePrize(PrizeDto prizeDto)
        {
            var prize = new Prize
            {
                BeginningRank = prizeDto.BeginningRank,
                EndingRank = prizeDto.EndingRank,
                PrizeTypeId = prizeDto.PrizeTypeId
            };

            _context.Prizes.Add(prize);
            _context.SaveChanges();
            return prize;
        }

        public void UpdatePrize(PrizeDto prizeDto)
        {
            var prize = _context.Prizes.Find(prizeDto.PrizeId);
            if (prize != null)
            {
                prize.BeginningRank = prizeDto.BeginningRank;
                prize.EndingRank = prizeDto.EndingRank;
                prize.PrizeTypeId = prizeDto.PrizeTypeId;
                _context.SaveChanges();
            }
        }

        public Prize DeletePrize(int prizeId)
        {
            var prize = _context.Prizes.Find(prizeId);
            if (prize != null)
            {
                _context.Prizes.Remove(prize);
                _context.SaveChanges();
            }
            return prize;
        }

        // Prizing Methods

        public PrizingDto GetPrizing(int competitionId)
        {
            var prizing = _context.Prizings
                .Include(p => p.Prizes)
                    .ThenInclude(p => p.PrizeType)
                .FirstOrDefault(p => p.CompetitionId == competitionId);

            if (prizing == null)
            {
                return null;
            }

            var prizingDto = new PrizingDto
            {
                PrizingId = prizing.PrizingId,
                CompetitionId = prizing.CompetitionId,
                Prizes = prizing.Prizes.Select(p => new PrizeDto
                {
                    PrizeId = p.PrizeId,
                    BeginningRank = p.BeginningRank,
                    EndingRank = p.EndingRank,
                    PrizeTypeId = p.PrizeTypeId,
                    PrizeType = new PrizeTypeDto
                    {
                        PrizeTypeId = p.PrizeType.PrizeTypeId,
                        Name = p.PrizeType.Name,
                        Amount = p.PrizeType.Amount,
                        Currency = p.PrizeType.Currency,
                        Description = p.PrizeType.Description
                    }
                }).ToList()
            };

            return prizingDto;
        }

        public Prizing CreatePrizing(PrizingDto prizingDto)
        {
            var prizing = new Prizing
            {
                CompetitionId = prizingDto.CompetitionId
            };

            _context.Prizings.Add(prizing);
            _context.SaveChanges();
            return prizing;
        }

        public void UpdatePrizing(PrizingDto prizingDto)
        {
            var prizing = _context.Prizings.Find(prizingDto.PrizingId);
            if (prizing != null)
            {
                prizing.CompetitionId = prizingDto.CompetitionId;
                _context.SaveChanges();
            }
        }

        public Prizing DeletePrizing(int competitionId)
        {
            var prizing = _context.Prizings.Find(competitionId);
            if (prizing != null)
            {
                _context.Prizings.Remove(prizing);
                _context.SaveChanges();
            }
            return prizing;
        }
    }
}
