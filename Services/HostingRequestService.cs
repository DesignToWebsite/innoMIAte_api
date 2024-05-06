using innomiate_api.DTOs;
using innomiate_api.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using INNOMIATE_API.Data;

namespace innomiate_api.Services
{
    public class HostingRequestService
    {
        private readonly ApplicationDbContext _dbContext; 

        public HostingRequestService(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<HostingRequest> CreateHostingRequest(HostingRequestDto requestDto)
        {
            var hostingRequest = new HostingRequest
            {
                Name = requestDto.Name,
                Host = requestDto.Host,
                Request = requestDto.Request,
                UserId = requestDto.UserId
            };

            _dbContext.HostingRequests.Add(hostingRequest);
            await _dbContext.SaveChangesAsync(); 

            return hostingRequest;
        }
    }
}
