using innomiate_api.Models;

namespace innomiate_api.DTOs
{
    public class StepInputDto
    {
        public int Id { get; set; }
        public required string Type { get; set; }
        public required string Tag { get; set; }
        public required string Label { get; set; }
        public string? Placeholder { get; set; }
        public required string IdName { get; set; }
        public int? MaxCaracter { get; set; }
        public string? Description { get; set; }
        public IFormFile? File { get; set; }
        public List<SubmittedInput>? InputValues { get; set; }

    }
}
