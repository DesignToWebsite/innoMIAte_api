using INNOMIATE_API.Models;

namespace innomiate_api.Models
{
    public class SubmittedInput
    {
        public int Id { get; set; }
        public int StepInputId { get; set; }
        public StepInput StepInput { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public string? Value { get; set; }
        
    }
}
