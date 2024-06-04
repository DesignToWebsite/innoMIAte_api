﻿using innomiate_api.Models.ValidationSteps;
using INNOMIATE_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace innomiate_api.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Slogan { get; set; }
        public int CompetitionId { get; set; }
        [ForeignKey("CompetitionId")]
        public Competition Competition { get; set; }

        public ICollection<CompetitionParticipant> Participants { get; set; } = new List<CompetitionParticipant>();
        public ICollection<SubmittedInput>? SubmittedInputs { get; set; }

    }
}