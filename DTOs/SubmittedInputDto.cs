namespace innomiate_api.DTOs
{
    public class SubmittedInputDto
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int StepInputId { get; set; }
        public IFormFile? Value { get; set; }
    }
}
