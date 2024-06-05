using innomiate_api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace INNOMIATE_API.Models
{
    public class StepCompetition
    {
        public int IdSteps { get; set; }
        [ForeignKey("Competition")]
        public int IdCompetition { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? SecondTitle { get; set; }
        public required bool StepOpen { get; set; }
        public required bool DeadLineEnd { get; set; }
        public List<StepInput>? ToComplete { get; set; }
        public Competition Competition { get; set; }


    }
}