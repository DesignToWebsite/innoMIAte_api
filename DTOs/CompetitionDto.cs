using System;
using System.Collections.Generic;
using innomiate_api.DTOs;
using innomiate_api.DTOs.Badging;
using innomiate_api.DTOs.Prizing;
using innomiate_api.DTOs.Submission;
using innomiate_api.Models;
using innomiate_api.Models.ValidationSteps;


namespace INNOMIATE_API.DTOs
{
    public class CompetitionDto
    {
        public int CompetitionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public  string DescriptionTop {get; set;} 
        public string ResponsibleEmail { get; set; }
        public DateTime Date { get; set; }
        // public TimeSpan Timing { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Theme { get; set; }
        public string? Rules { get; set; }
        public List<NameImageMapping>? Organizers {get; set;}
        public List<NameImageMapping>? Partnerships {get; set;}
        public List<NameImageMapping>? Sponsors {get; set;}
        public string Location { get; set; }
        public string TargetAudience { get; set; }
        public string URL { get; set; }
        public string Photo { get; set; }
        public string CoverPhoto { get; set; }
        public string? PdfRules {get; set;}
        public string? Resource {get; set;}
        public List<string>? Gallery {get; set;}
        
        public  DateTime StartDate {get; set;}
        public  DateTime DeadLine {get; set;}
    }
}
