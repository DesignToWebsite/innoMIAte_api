using innomiate_api.Models;
using innomiate_api.Models.Badging;
using innomiate_api.Models.Submission;
using innomiate_api.Models.ValidationSteps;

namespace INNOMIATE_API.DTOs
{
    public class StepCompetitionDto
    {
       public int IdSteps {get; set;}
    //    public int IdTeam {get; set;}
       public int IdCompetition {get; set;}
       public required bool StepOpen { get; set; }
       public required bool DeadLineEnd { get; set; }
       public string Title {get; set;}
       public string Description {get; set;}
       public string? SecondTitle {get; set;}
       public List<StepInput> ToComplete {get; set;}
   

    }
}