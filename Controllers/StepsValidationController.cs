using innomiate_api.DTOs.ValidationSteps;
using innomiate_api.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace innomiate_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepsValidationController : ControllerBase
    {
        private readonly StepModelService _stepModelService;
        private readonly StepTemplateModelService _stepTemplateModelService;
        private readonly TeamStepSubmissionService _teamStepSubmissionService;

        public StepsValidationController(
            StepModelService stepModelService,
            StepTemplateModelService stepTemplateModelService,
            TeamStepSubmissionService teamStepSubmissionService)
        {
            _stepModelService = stepModelService;
            _stepTemplateModelService = stepTemplateModelService;
            _teamStepSubmissionService = teamStepSubmissionService;
        }

        // StepModel Endpoints
        [HttpPost("step-model")]
        public IActionResult CreateStepModel([FromBody] StepModelDto stepModelDto)
        {
            try
            {
                var createdStepModel = _stepModelService.CreateStepModel(stepModelDto);
                return Ok(createdStepModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("step-model/{id}")]
        public IActionResult UpdateStepModel(int id, [FromBody] StepModelDto stepModelDto)
        {
            try
            {
                var updatedStepModel = _stepModelService.UpdateStepModel(id, stepModelDto);
                return Ok(updatedStepModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("step-model/{id}")]
        public IActionResult DeleteStepModel(int id)
        {
            try
            {
                _stepModelService.DeleteStepModel(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("step-model/{id}")]
        public IActionResult GetStepModelById(int id)
        {
            try
            {
                var stepModel = _stepModelService.GetStepModelById(id);
                return Ok(stepModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("step-models/by-competition/{competitionId}")]
        public IActionResult GetStepModelsByCompetitionId(int competitionId)
        {
            try
            {
                var stepModels = _stepModelService.GetStepModelsByCompetitionId(competitionId);
                return Ok(stepModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // StepTemplateModel Endpoints
        [HttpPost("step-template")]
        public IActionResult CreateStepTemplateModel([FromBody] StepTemplateModelDto stepTemplateModelDto)
        {
            try
            {
                var createdStepTemplateModel = _stepTemplateModelService.CreateStepTemplateModel(stepTemplateModelDto);
                return Ok(createdStepTemplateModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("step-template/{id}")]
        public IActionResult UpdateStepTemplateModel(int id, [FromBody] StepTemplateModelDto stepTemplateModelDto)
        {
            try
            {
                var updatedStepTemplateModel = _stepTemplateModelService.UpdateStepTemplateModel(id, stepTemplateModelDto);
                return Ok(updatedStepTemplateModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("step-template/{id}")]
        public IActionResult DeleteStepTemplateModel(int id)
        {
            try
            {
                _stepTemplateModelService.DeleteStepTemplateModel(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // TeamStepSubmission Endpoints
        [HttpPost("team-step-submission")]
        public IActionResult CreateTeamStepSubmission([FromBody] TeamStepSubmissionDto teamStepSubmissionDto)
        {
            try
            {
                var createdTeamStepSubmission = _teamStepSubmissionService.CreateTeamStepSubmission(teamStepSubmissionDto);
                return Ok(createdTeamStepSubmission);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("team-step-submission/{id}")]
        public IActionResult UpdateTeamStepSubmission(int id, [FromBody] TeamStepSubmissionDto teamStepSubmissionDto)
        {
            try
            {
                var updatedTeamStepSubmission = _teamStepSubmissionService.UpdateTeamStepSubmission(id, teamStepSubmissionDto);
                return Ok(updatedTeamStepSubmission);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("team-step-submission/{id}")]
        public IActionResult DeleteTeamStepSubmission(int id)
        {
            try
            {
                _teamStepSubmissionService.DeleteTeamStepSubmission(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("team-step-submissions/by-competition/{competitionId}")]
        public IActionResult GetTeamStepSubmissionsByCompetitionId(int competitionId)
        {
            try
            {
                var teamStepSubmissions = _teamStepSubmissionService.GetTeamStepSubmissionsByCompetitionId(competitionId);
                return Ok(teamStepSubmissions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
