using Microsoft.EntityFrameworkCore;
using INNOMIATE_API.Models;
using innomiate_api.Models;
using innomiate_api.Models.Submission;
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

        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
 

        public DbSet<SubmissionModel> SubmissionModels { get; set; }
        public DbSet<FileModel> FileModels { get; set; }
 

        ///Step Models <summary>
        /// Step Models
        /// </summary>
        /// 


        public DbSet<StepCompetition> stepCompetitions { get; set; }
        public DbSet<StepInput> stepInputs { get; set; }
        public DbSet<SubmittedInput> submittedInputs { get; set; }
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


            modelBuilder.Entity<CompetitionCreator>()
                .HasKey(cc => cc.CreatorId);

            modelBuilder.Entity<CompetitionCreator>()
                .HasOne(cc => cc.User)
                .WithMany(u => u.CreatedCompetitions)
                .HasForeignKey(cc => cc.UserId);


            // Team relations 

            modelBuilder.Entity<CompetitionParticipant>()
                .HasOne(cp => cp.Team)
                .WithMany(t => t.Participants)
                .HasForeignKey(cp => cp.TeamId);

                   //  Group
            modelBuilder.Entity<CompetitionParticipant>()
      .HasOne(cp => cp.Group)                    
      .WithMany(g => g.Participants)            
      .HasForeignKey(cp => cp.GroupId);         

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Competition)
                .WithMany(c => c.Teams)
                .HasForeignKey(t => t.CompetitionId);


            



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
            // Configure Competition's relationship with Organizers
            modelBuilder.Entity<Competition>().OwnsMany(c => c.Organizers, organizers =>
            {
                organizers.WithOwner().HasForeignKey("CompetitionId");
                organizers.Property(mapping => mapping.Name).IsRequired();
                organizers.Property(mapping => mapping.ImageUrl).IsRequired();
                organizers.ToTable("CompetitionOrganizers");
            });

            // Configure Competition's relationship with Partnerships
            modelBuilder.Entity<Competition>().OwnsMany(c => c.Partnerships, partnerships =>
            {
                partnerships.WithOwner().HasForeignKey("CompetitionId");
                partnerships.Property(mapping => mapping.Name).IsRequired();
                partnerships.Property(mapping => mapping.ImageUrl).IsRequired();
                partnerships.ToTable("CompetitionPartnerships");
            });

            // Configure Competition's relationship with Sponsors
            modelBuilder.Entity<Competition>().OwnsMany(c => c.Sponsors, sponsors =>
            {
                sponsors.WithOwner().HasForeignKey("CompetitionId");
                sponsors.Property(mapping => mapping.Name).IsRequired();
                sponsors.Property(mapping => mapping.ImageUrl).IsRequired();
                sponsors.ToTable("CompetitionSponsors");
            });

            // Configure Competition's relationship with prizes
            modelBuilder.Entity<Competition>().OwnsMany(c => c.Prizes, prize =>
            {
                prize.WithOwner().HasForeignKey("CompetitionId");
                prize.Property(mapping => mapping.Amount).IsRequired();
                prize.Property(mapping => mapping.BeginningRank).IsRequired();
                prize.Property(mapping => mapping.Currency).IsRequired();
                prize.Property(mapping => mapping.Description).IsRequired();
                prize.Property(mapping => mapping.EndingRank).IsRequired();
                prize.ToTable("CompetitionPrizes");
            });
           
           modelBuilder.Entity<StepCompetition>()
            .HasKey(sc=>sc.IdSteps);


            modelBuilder.Entity<StepCompetition>()
              .HasOne(sc=>sc.Competition)
              .WithMany(c=>c.Steps)
              .HasForeignKey(sc => sc.IdCompetition)
              .OnDelete(DeleteBehavior.Cascade);

         

            modelBuilder.Entity<SubmittedInput>()
            .HasOne(si => si.Team)
            .WithMany(t => t.SubmittedInputs)
            .HasForeignKey(si => si.TeamId);
            
            modelBuilder.Entity<SubmittedInput>()
            .HasOne(si => si.StepInput)
            .WithMany(i => i.InputValues)
            .HasForeignKey(si=>si.StepInputId);
            modelBuilder.Entity<StepCompetition>()
    .HasKey(sc => sc.IdSteps);

            modelBuilder.Entity<StepInput>()
                .HasKey(si => si.Id);

            modelBuilder.Entity<StepInput>()
                .HasOne(si => si.StepCompetition)  
                .WithMany(sc => sc.ToComplete)      
                .HasForeignKey(si => si.StepCompetitionId) 
                .OnDelete(DeleteBehavior.Cascade);

        }






    }
}