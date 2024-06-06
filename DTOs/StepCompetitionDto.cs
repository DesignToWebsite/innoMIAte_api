namespace INNOMIATE_API.DTOs
{
    public class StepCompetitionDto
    {
        public int IdSteps { get; set; }
        public int IdCompetition { get; set; }
        public bool StepOpen { get; set; }
        public bool DeadLineEnd { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SecondTitle { get; set; }
    }
}
