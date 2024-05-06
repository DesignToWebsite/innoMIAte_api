using System;
using System.Threading.Tasks;
using innomiate_api.DTOs;
using innomiate_api.Services;
using INNOMIATE_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace innomiate_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionJudgeController : ControllerBase
    {
        private readonly CompetitionJudgeService _judgeService;

        public CompetitionJudgeController(CompetitionJudgeService judgeService)
        {
            _judgeService = judgeService;
        }

        [HttpPost]
        public async Task<ActionResult<CompetitionJudgeDto>> CreateJudge(CompetitionJudgeDto judgeDto)
        {
            try
            {
                var createdJudge = await _judgeService.CreateJudge(judgeDto);
                return CreatedAtAction(nameof(CreateJudge), createdJudge);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJudge(int id, CompetitionJudgeDto judgeDto)
        {
            try
            {
                await _judgeService.UpdateJudge(id, judgeDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJudge(int id)
        {
            try
            {
                await _judgeService.DeleteJudge(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CompetitionJudgeDto> GetJudgeById(int id)
        {
            try
            {
                var judge = _judgeService.GetJudgeById(id);
                return judge;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
