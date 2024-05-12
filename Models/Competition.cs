﻿using innomiate_api.Models;
using innomiate_api.Models.Badging;
using innomiate_api.Models.Submission;
using innomiate_api.Models.ValidationSteps;

namespace INNOMIATE_API.Models
{
    public class Competition
    {
        public int CompetitionId { get; set; }
        public string Name { get; set; }
        public  string DescriptionTop {get; set;} 
        public string Description { get; set; }
        public string ResponsibleEmail { get; set; }
        public DateTime Date { get; set; }
        public List<String> Tags { get; set; }
        public List<string> Theme { get; set; }
        public string? Rules { get; set; }
        public List<NameImageMapping>? Organizers {get; set;}
        public List<NameImageMapping>? Partnerships {get; set;}
        public List<NameImageMapping>? Sponsors {get; set;}
        public List<CompetitionPrize>? Prizes {get; set;}
        public string TargetAudience { get; set; }
        public string URL { get; set; }
        public string Location { get; set; }
        public string Photo { get; set; }
        public string CoverPhoto { get; set; }
        public  DateTime StartDate {get; set;}
        public  DateTime DeadLine {get; set;}
        public string? PdfRules {get; set;}
        public string? Resource {get; set;}
        public List<string>? Gallery {get; set;}
        // Navigation references 
        public virtual ICollection<CompetitionParticipant> Participants { get; set; }
        public virtual ICollection<CompetitionCoach> Coaches { get; set; }
        public virtual ICollection<CompetitionJudge> Judges { get; set; }
        public virtual ICollection<CompetitionContributor> Contributors { get; set; }
        // public ICollection<CompetitionSponsor> Sponsors { get; set; }
        public virtual List<StepModel> StepModels { get; set; }
        public virtual List<StepCompetition> StepCompetitions {get; set;}
        public virtual List<Team> Teams { get; set; }
        public virtual SubmissionModel SubmissionModel { get; set; }
        // public Prizing Prizing { get; set; }
        public virtual Badging Badging { get; set; }

        public virtual ICollection<StepCompetition> Steps { get; set; }

        public CompetitionCreator Creator { get; set; }


    }
}
