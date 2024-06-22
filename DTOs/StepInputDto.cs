/*

using innomiate_api.Models;

namespace innomiate_api.DTOs
{
    public class StepInputDto
    {
        public string Type { get; set; }
        public string Tag { get; set; }
        public string Label { get; set; }
        public string Placeholder { get; set; }
        public string IdName { get; set; }
        public int? MaxCaracter { get; set; }
        public string Description { get; set; }
    }
}
*/

namespace innomiate_api.DTOs
{
    public class StepInputDto
    {
        public int Id { get; set; }
        public int StepId { get; set; }
        public string Type { get; set; }
        public string Tag { get; set; }
        public string Label { get; set; }
        public string Placeholder { get; set; }
        public string IdName { get; set; }
        public int? MaxCaracter { get; set; }
        public string Description { get; set; }
    }
}
