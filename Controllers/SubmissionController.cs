using Microsoft.AspNetCore.Mvc;
using innomiate_api.DTOs.Submission;
using innomiate_api.Services;
using System;

namespace innomiate_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly SubmissionModelService _submissionModelService;
        private readonly FileModelService _fileModelService;
        private readonly TeamSubmissionService _teamSubmissionService;
        private readonly TeamSubmissionFileService _teamSubmissionFileService;

        public SubmissionController(
            SubmissionModelService submissionModelService,
            FileModelService fileModelService,
            TeamSubmissionService teamSubmissionService,
            TeamSubmissionFileService teamSubmissionFileService)
        {
            _submissionModelService = submissionModelService;
            _fileModelService = fileModelService;
            _teamSubmissionService = teamSubmissionService;
            _teamSubmissionFileService = teamSubmissionFileService;
        }

        // Submission Model EndPoints

        [HttpPost("CreateSubmissionModel")]
        public IActionResult CreateSubmissionModel([FromBody] SubmissionModelDto submissionModelDto)
        {
            var createdSubmissionModel = _submissionModelService.CreateSubmissionModel(submissionModelDto);
            return Ok(createdSubmissionModel);
        }

        [HttpGet("submission/{id}")]
        public IActionResult GetSubmissionModelById(int id)
        {
            var submissionModel = _submissionModelService.GetSubmissionModelById(id);
            return Ok(submissionModel);
        }

        [HttpPut("submission/{id}")]
        public IActionResult UpdateSubmissionModel(int id, [FromBody] SubmissionModelDto submissionModelDto)
        {
            var updatedSubmissionModel = _submissionModelService.UpdateSubmissionModel(id, submissionModelDto);
            return Ok(updatedSubmissionModel);
        }

        [HttpDelete("submission/{id}")]
        public IActionResult DeleteSubmissionModel(int id)
        {
            _submissionModelService.DeleteSubmissionModel(id);
            return Ok();
        }

        [HttpGet("competition/{competitionId}")]
        public IActionResult GetSubmissionModelsByCompetitionId(int competitionId)
        {
            var submissionModels = _submissionModelService.GetSubmissionModelsByCompetitionId(competitionId);
            return Ok(submissionModels);
        }

        // File Model Endpoints 

        [HttpPost("CreateFileModel")]
        public IActionResult CreateFileModel([FromBody] FileModelDto fileModelDto)
        {
            var createdFileModel = _fileModelService.CreateFileModel(fileModelDto);
            return Ok(createdFileModel);
        }

        [HttpDelete("file/{id}")]
        public IActionResult DeleteFileModel(int id)
        {
            try
            {
                _fileModelService.DeleteFileModel(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("submission/{submissionModelId}/files")]
        public IActionResult GetFileModelsBySubmissionModelId(int submissionModelId)
        {
            try
            {
                var fileModels = _fileModelService.GetFileModelsBySubmissionModelId(submissionModelId);
                return Ok(fileModels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Team Submission 

        [HttpPost("CreateTeamSubmission")]
        public IActionResult CreateTeamSubmission([FromBody] TeamSubmissionDto teamSubmissionDto)
        {
            var createdTeamSubmission = _teamSubmissionService.CreateTeamSubmission(teamSubmissionDto);
            return Ok(createdTeamSubmission);
        }
        [HttpDelete("team/{id}")]
        public IActionResult DeleteTeamSubmission(int id)
        {
            try
            {
                _teamSubmissionService.DeleteTeamSubmission(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("team/{id}")]
        public IActionResult GetTeamSubmissionById(int id)
        {
            try
            {
                var teamSubmission = _teamSubmissionService.GetTeamSubmissionById(id);
                return Ok(teamSubmission);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("competition/{competitionId}/teamsubmissions")]
        public IActionResult GetTeamSubmissionsByCompetition(int competitionId)
        {
            try
            {
                var teamSubmissions = _teamSubmissionService.GetTeamSubmissionsByCompetition(competitionId);
                return Ok(teamSubmissions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("team/{id}")]
        public IActionResult UpdateTeamSubmission(int id, [FromBody] TeamSubmissionDto teamSubmissionDto)
        {
            try
            {
                _teamSubmissionService.UpdateTeamSubmission(id, teamSubmissionDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Team Submission File

        [HttpPost("CreateTeamSubmissionFile")]
        public IActionResult CreateTeamSubmissionFile([FromBody] TeamSubmissionFileDto teamSubmissionFileDto)
        {
            var createdTeamSubmissionFile = _teamSubmissionFileService.CreateTeamSubmissionFile(teamSubmissionFileDto);
            return Ok(createdTeamSubmissionFile);
        }
        [HttpDelete("teamfile/{id}")]
        public IActionResult DeleteTeamSubmissionFile(int id)
        {
            try
            {
                _teamSubmissionFileService.DeleteTeamSubmissionFile(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("teamfile/{id}")]
        public IActionResult UpdateTeamSubmissionFile(int id, [FromBody] TeamSubmissionFileDto teamSubmissionFileDto)
        {
            try
            {
                _teamSubmissionFileService.UpdateTeamSubmissionFile(id, teamSubmissionFileDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("teamsubmission/{teamSubmissionId}/files")]
        public IActionResult GetSubmissionFilesByTeamSubmission(int teamSubmissionId)
        {
            try
            {
                var submissionFiles = _teamSubmissionFileService.GetSubmissionFilesByTeamSubmission(teamSubmissionId);
                return Ok(submissionFiles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
