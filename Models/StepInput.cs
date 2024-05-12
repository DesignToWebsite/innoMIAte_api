using INNOMIATE_API.Models;

namespace innomiate_api.Models
{
     public class StepInput
    {
        public required string Type { get; set; }
        public required string Tag { get; set; }
        public required string Label { get; set; }
        public string? Placeholder { get; set; }
        public required string IdName { get; set; }
        public int? MaxCaracter  { get; set; }
        
        public string? ValueInput { get; set; }
    }
}