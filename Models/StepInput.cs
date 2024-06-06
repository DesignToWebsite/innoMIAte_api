using INNOMIATE_API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace innomiate_api.Models
{
    public class StepInput
    {
        public int Id { get; set; }
        [ForeignKey("StepCompetition")]
        public int StepCompetitionId {  get; set; }
        public StepCompetition StepCompetition { get; set; }
        public required string Type { get; set; }
        public required string Tag { get; set; }
        public required string Label { get; set; }
        public string? Placeholder { get; set; }
        public required string IdName { get; set; }
        public int? MaxCaracter { get; set; }
        public string? Description { get; set; }

        public List<SubmittedInput>? InputValues { get; set; }
    }
}