﻿using Microsoft.AspNetCore.Mvc;
using innomiate_api.Services;
using innomiate_api.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using INNOMIATE_API.DTOs;

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
        /*
        [HttpPost("create")]
        public async Task<ActionResult<GroupDTO>> CreateGroup([FromBody] CreateGroupRequest request)
        {
            var group = await _groupService.CreateGroupAsync(request.ParticipantId, request.GroupName);
            if (group == null)
                return BadRequest("Participant not found or group creation failed.");

            return Ok(group);
        }
        */
        [HttpPost("create")]
        public async Task<ActionResult<GroupDTO>> CreateGroup([FromBody] CreateGroupRequest request)
        {
            var group = await _groupService.CreateGroupAsync(request.ParticipantId, request.GroupName);
            if (group == null)
                return BadRequest("Participant not found or group creation failed.");

            return Ok(group);
        }
        [HttpPost("leaderCreateGroup")]
        public async Task<ActionResult<GroupDTO>> LeaderCreateGroup([FromQuery] int participantId, [FromBody] GroupDTO groupDto)
    {
        if (groupDto == null)
        {
            return BadRequest("Group data is required.");
        }

        var result = await _groupService.LeaderCreateGroup(participantId, groupDto);

        if (result == null)
        {
            return NotFound("Participant not found.");
        }

        return Ok(result);
    }
        [HttpDelete("delete/{groupId}")]
        public async Task<IActionResult> DeleteGroup(int groupId)
        {
            var result = await _groupService.DeleteGroupAsync(groupId);
            if (!result)
            {
                return NotFound("Group not found");
            }

            return Ok("Group deleted successfully");
        }

        [HttpPatch("remove-participant-from-group/{participantId}")]
        public async Task<IActionResult> RemoveParticipantFromGroup(int participantId)
        {
            var result = await _groupService.RemoveParticipantFromGroupAsync(participantId);
            if (!result)
            {
                return NotFound("Participant not found or already not in a group");
            }

            return Ok("Participant removed from group successfully");
        }

        [HttpGet("{groupId}/participants")]
        public async Task<ActionResult<List<CompetitionParticipantsPerTeamDto>>> GetParticipantsByGroupId(int groupId)
        {
            var participants = await _groupService.GetParticipantsByGroupIdAsync(groupId);
            if (participants == null || participants.Count == 0)
                return NotFound();

            return participants;
        }

        [HttpGet]
        public async Task<ActionResult<List<GroupListDto>>> GetAllGroups()
        {
            var groups = await _groupService.GetAllGroupsAsync();
            if (groups == null || groups.Count == 0)
                return NotFound();

            return groups;
        }

    }
}
