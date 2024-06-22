namespace innomiate_api.DTOs
{
    public class SubmittedInputCreateDto
    {
        public int StepId { get; set; }
        public int GroupId { get; set; }
        public List<IFormFile> Values { get; set; }
    }
}
