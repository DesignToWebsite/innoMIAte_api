﻿using System.ComponentModel.DataAnnotations.Schema;

namespace INNOMIATE_API.Models
{
    public class Requirement
    {
        public int RequirementId { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public string BackgroundConstraints { get; set; }
        public string GeographicConstraints { get; set; }
        public string LocalCountry { get; set; }
        public string LocalCity { get; set; }
        public List<string> RestrictedMaterials { get; set; }
        public List<string> RequiredMaterials { get; set; }

        public string InclusionSpecifications { get; set; }
        
        public Competition competition { get; set; }
    }
}