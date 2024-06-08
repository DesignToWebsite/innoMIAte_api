using Microsoft.AspNetCore.Mvc;
using innomiate_api.Services;
using innomiate_api.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace innomiate_api.Controllers
{
    [ApiController]
    [Route("api/groups")]
    public class GroupController : ControllerBase
    {
        private readonly GroupService _groupService;

        public GroupController(GroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("{groupId}")]
        public async Task<ActionResult<GroupDTO>> GetGroupById(int groupId)
        {
            var group = await _groupService.GetGroupByIdAsync(groupId);
            if (group == null)
                return NotFound();

            return group;
        }

        [HttpPut("{groupId}/participants/{participantId}")]
        public async Task<ActionResult<GroupDTO>> UpdateParticipantGroup(int groupId, int participantId)
        {
            var group = await _groupService.UpdateParticipantGroupAsync(groupId, participantId);
            if (group == null)
                return NotFound();

            return Ok(group);
        }


        [HttpGet("competition/{competitionId}")]
        public async Task<ActionResult<List<GroupDTO>>> GetGroupsByCompetitionId(int competitionId)
        {
            var groups = await _groupService.GetGroupsByCompetitionIdAsync(competitionId);
            if (groups == null || groups.Count == 0)
                return NotFound();

            return groups;
        }

        [HttpPost("create")]
        public async Task<ActionResult<GroupDTO>> CreateGroup([FromBody] CreateGroupRequest request)
        {
            var group = await _groupService.CreateGroupAsync(request.ParticipantId, request.GroupName);
            if (group == null)
                return BadRequest("Participant not found or group creation failed.");

            return Ok(group);
        }


    }
}
