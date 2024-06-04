namespace innomiate_api.Models
{
    public class SubmittedInput
    {
        public int Id { get; set; }
        public int StepInputId { get; set; }
        public StepInput StepInput { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public string? Value { get; set; }
    }
}
