using innomiate_api.DTOs;

public class StepDto
{
    public int Id { get; set; }
    public int CompetitionId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string SecondTitle { get; set; }
    public bool StepOpen { get; set; }
    public bool DeadLineEnd { get; set; }
    public List<StepInputDto> ToComplete { get; set; }
}