using System;
using System.Collections.Generic;
using innomiate_api.DTOs;
using innomiate_api.DTOs.Badging;
using innomiate_api.DTOs.Prizing;
using innomiate_api.DTOs.Submission;
using innomiate_api.Models.ValidationSteps;


namespace INNOMIATE_API.DTOs
{
    public class CompetitionDto
    {
        public int CompetitionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ResponsibleEmail { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Timing { get; set; }
        public List<string> Tags { get; set; }
        public string TargetAudience { get; set; }
        public string URL { get; set; }
        public string Photo { get; set; }
        public string CoverPhoto { get; set; }
    }
}
