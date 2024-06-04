using INNOMIATE_API.DTOs;

namespace innomiate_api.DTOs
{
    public class StepWithInputsDto
    {
        public StepCompetitionDto Step { get; set; }
        public List<StepInputDto> Inputs { get; set; }
    }
}
