﻿namespace innomiate_api.DTOs
{
    public class ParticipantUserDto
    {
        public int UserId { get; set; }
        public int CompetitionId { get; set; }
        public bool IsLeader { get; set; }
        public bool IsConfirmed { get; set; }
        public int? GroupId { get; set; }

        // User Information
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
