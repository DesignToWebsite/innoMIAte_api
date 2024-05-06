using Microsoft.EntityFrameworkCore;
using INNOMIATE_API.Models;
using innomiate_api.Models;
using innomiate_api.Models.ValidationSteps;
using innomiate_api.Models.Submission;
using innomiate_api.Models.Prizing;
using innomiate_api.Models.Badging;

namespace INNOMIATE_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Competition> Competitions { get; set; }
        public DbSet<CompetitionCoach> Coaches { get; set; }
        public DbSet<CompetitionCoachingAnnounce> CompetitionCoachingAnnounces { get; set; }
        public DbSet<CompetitionPendingCoach> CompetitionPendingCoaches { get; set; }
        public DbSet<CompetitionCoachingTag> CompetitionCoachingTags { get; set; }

        public DbSet<CompetitionJudge> Judges { get; set; }
        public DbSet<CompetitionCreator> Creators { get; set; }
        public DbSet<CompetitionParticipant> Participants { get; set; }
        public DbSet<CompetitionContributor> Contributors { get; set; }
        public DbSet<CompetitionSponsor> Sponsors { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamSubmissionFile> TeamSubmissionFiles { get; set; }
        public DbSet<TeamSubmission> TeamSubmissions { get; set; }


        public DbSet<SubmissionModel> SubmissionModels { get; set; } 
        public DbSet<FileModel> FileModels { get; set; }

        ///Step Models <summary>
        /// Step Models
        /// </summary>
        /// 
        public DbSet<StepModel> StepModels { get; set; }
        public DbSet<TeamStepSubmission> TeamStepSubmissions { get; set; }
        public DbSet<StepTemplateModel> StepTemplateModels { get; set; }



        public DbSet<Prizing> Prizings { get; set; }
        public DbSet<Prize> Prizes { get; set; }
        public DbSet<PrizeType> PrizeTypes { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Badging> Badgings { get; set; } 
        public DbSet<PlatformAdmin> PlateformAdmins { get; set; }
        public DbSet<HostingRequest> HostingRequests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship between User and CompetitionCoach
            modelBuilder.Entity<CompetitionCoach>()
                .HasKey(cc => new { cc.UserId, cc.CompetitionId });

            modelBuilder.Entity<CompetitionCoach>()
                .HasOne(cc => cc.User)
                .WithMany(u => u.CoachedCompetitions)
                .HasForeignKey(cc => cc.UserId);

            modelBuilder.Entity<CompetitionCoach>()
                .HasOne(cc => cc.Competition)
                .WithMany(c => c.Coaches)
                .HasForeignKey(cc => cc.CompetitionId);

            // Configure many-to-many relationship between User and CompetitionJudge
            modelBuilder.Entity<CompetitionJudge>()
                .HasKey(cj => new { cj.UserId, cj.CompetitionId });

            modelBuilder.Entity<CompetitionJudge>()
                .HasOne(cj => cj.User)
                .WithMany(u => u.JudgedCompetitions)
                .HasForeignKey(cj => cj.UserId);

            modelBuilder.Entity<CompetitionJudge>()
                .HasOne(cj => cj.Competition)
                .WithMany(c => c.Judges)
                .HasForeignKey(cj => cj.CompetitionId);
            // Configure many-to-many relationship between User and CompetitionParticipant
            modelBuilder.Entity<CompetitionParticipant>()
                .HasKey(cp => new { cp.UserId, cp.CompetitionId });

            modelBuilder.Entity<CompetitionParticipant>()
                .HasOne(cp => cp.User)
                .WithMany(u => u.ParticipatedCompetitions)
                .HasForeignKey(cp => cp.UserId);

            modelBuilder.Entity<CompetitionParticipant>()
                .HasOne(cp => cp.Competition)
                .WithMany(c => c.Participants)
                .HasForeignKey(cp => cp.CompetitionId);

            // Configure one-to-many relationship between User and CompetitionCreator
            modelBuilder.Entity<CompetitionCreator>()
                .HasKey(cc => new { cc.UserId, cc.CompetitionId });

            modelBuilder.Entity<CompetitionCreator>()
                .HasOne(cc => cc.User)
                .WithMany(u => u.CreatedCompetitions)
                .HasForeignKey(cc => cc.UserId);

            modelBuilder.Entity<CompetitionCreator>()
                .HasOne(cc => cc.Competition)
                .WithOne(c => c.Creator)
                .HasForeignKey<CompetitionCreator>(cc => cc.CompetitionId);
            // Team relations 
            modelBuilder.Entity<CompetitionParticipant>()
    .HasOne(cp => cp.Team)
    .WithMany(t => t.Participants)
    .HasForeignKey(cp => cp.TeamId);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Competition)
                .WithMany(c => c.Teams)
                .HasForeignKey(t => t.CompetitionId);

        

            // Steps Relations 
            modelBuilder.Entity<TeamStepSubmission>()
    .HasKey(tss => tss.TeamStepSubmissionId);

            modelBuilder.Entity<TeamStepSubmission>()
                .HasOne(tss => tss.Team)
                .WithMany(t => t.TeamStepsSubmissions)
                .HasForeignKey(tss => tss.TeamId);

            modelBuilder.Entity<TeamStepSubmission>()
                .HasOne(tss => tss.Step)
                .WithMany(s => s.TeamStepSubmissions)
                .HasForeignKey(tss => tss.StepId);

            modelBuilder.Entity<Team>()
    .HasOne(t => t.TeamLeader)
    .WithMany()
    .HasForeignKey(t => new { t.TeamLeaderUserId, t.TeamLeaderCompetitionId })
    .IsRequired(false) 
    .OnDelete(DeleteBehavior.SetNull);

            // Configure one-to-many relationship between SubmissionModel and Competition
            modelBuilder.Entity<SubmissionModel>()
                .HasOne(sm => sm.Competition)
                .WithOne(c => c.SubmissionModel)
                .HasForeignKey<SubmissionModel>(sm => sm.CompetitionId);

            // Configure one-to-many relationship between FileModel and SubmissionModel
            modelBuilder.Entity<FileModel>()
                .HasOne(fm => fm.SubmissionModel)
                .WithMany(sm => sm.FileModels)
                .HasForeignKey(fm => fm.SubmissionModelId);

            // Configure the relationship between TeamSubmission, TeamSubmissionFile, and FileModel
            modelBuilder.Entity<TeamSubmissionFile>()
                .HasKey(tsf => tsf.TeamSubmissionFileId);

            modelBuilder.Entity<TeamSubmissionFile>()
                .HasOne(tsf => tsf.TeamSubmission)
                .WithMany(ts => ts.TeamSubmissionFiles)
                .HasForeignKey(tsf => tsf.TeamSubmissionFileId);

            modelBuilder.Entity<TeamSubmissionFile>()
                .HasOne(tsf => tsf.FileModel)
                .WithMany()
                .HasForeignKey(tsf => tsf.FileModelId);

            // Configure Prizing relationships
            modelBuilder.Entity<Prizing>()
                .HasOne(p => p.Competition)
                .WithOne(c => c.Prizing)
                .HasForeignKey<Prizing>(p => p.CompetitionId);

            modelBuilder.Entity<Prize>()
                .HasOne(p => p.PrizeType)
                .WithMany()
                .HasForeignKey(p => p.PrizeTypeId);

            modelBuilder.Entity<Prize>()
                .HasOne(p => p.Prizing)
                .WithMany(pr => pr.Prizes)
                .HasForeignKey(p => p.PrizingId);


           

            // Configure one-to-many relationship between Badge and Badging
            modelBuilder.Entity<Badge>()
                .HasOne(b => b.Badging)
                .WithMany(ba => ba.Badges)
                .HasForeignKey(b => b.BadgingId);

            // Configure HostingRequest relationships
            modelBuilder.Entity<HostingRequest>()
                .HasOne(hr => hr.User)
                .WithMany(u => u.HostingRequests)
                .HasForeignKey(hr => hr.UserId);


        }





    }
}
