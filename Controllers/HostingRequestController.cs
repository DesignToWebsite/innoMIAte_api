using innomiate_api.DTOs;
using innomiate_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace innomiate_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HostingRequestController : ControllerBase
    {
        private readonly HostingRequestService _hostingRequestService;

        public HostingRequestController(HostingRequestService hostingRequestService)
        {
            _hostingRequestService = hostingRequestService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHostingRequest(HostingRequestDto requestDto)
        {
            var result = await _hostingRequestService.CreateHostingRequest(requestDto);
            return Ok(result);
        }
    }
}
