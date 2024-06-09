﻿// <auto-generated />
using System;
using INNOMIATE_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace innomiate_api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240608234311_aa")]
    partial class aa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("INNOMIATE_API.Models.Competition", b =>
                {
                    b.Property<int>("CompetitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CompetitionId"));

                    b.Property<string>("CoverPhoto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DescriptionTop")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Gallery")
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PdfRules")
                        .HasColumnType("longtext");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Resource")
                        .HasColumnType("longtext");

                    b.Property<string>("ResponsibleEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rules")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TargetAudience")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CompetitionId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.CompetitionCoach", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CompetitionId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.CompetitionContributor", b =>
                {
                    b.Property<int>("ContributorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ContributorId"));

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<string>("ContributorName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("logo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ContributorId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("CompetitionContributor");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.CompetitionCreator", b =>
                {
                    b.Property<int>("CreatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CreatorId"));

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CreatorId");

                    b.HasIndex("CompetitionId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.CompetitionJudge", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CompetitionId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Judges");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.CompetitionParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsLeader")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectImage")
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectName")
                        .HasColumnType("longtext");

                    b.Property<string>("Slogan")
                        .HasColumnType("longtext");

                    b.HasKey("GroupId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.Requirement", b =>
                {
                    b.Property<int>("RequirementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RequirementId"));

                    b.Property<string>("BackgroundConstraints")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<string>("GeographicConstraints")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("InclusionSpecifications")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LocalCity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LocalCountry")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MaxAge")
                        .HasColumnType("int");

                    b.Property<int>("MinAge")
                        .HasColumnType("int");

                    b.Property<string>("RequiredMaterials")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RestrictedMaterials")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RequirementId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Requirements");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Followers")
                        .HasColumnType("longtext");

                    b.Property<string>("Following")
                        .HasColumnType("longtext");

                    b.Property<string>("Github")
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Interests")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAcceuil")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Likes")
                        .HasColumnType("longtext");

                    b.Property<string>("Linkedin")
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Skills")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Website")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("innomiate_api.Models.Badging.Badge", b =>
                {
                    b.Property<int>("BadgeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BadgeId"));

                    b.Property<string>("BadgeType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("BadgingId")
                        .HasColumnType("int");

                    b.Property<string>("Criteria")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("BadgeId");

                    b.HasIndex("BadgingId");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("innomiate_api.Models.Badging.Badging", b =>
                {
                    b.Property<int>("BadgingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BadgingId"));

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.HasKey("BadgingId");

                    b.HasIndex("CompetitionId")
                        .IsUnique();

                    b.ToTable("Badgings");
                });

            modelBuilder.Entity("innomiate_api.Models.CompetitionCoachingAnnounce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.ToTable("CompetitionCoachingAnnounces");
                });

            modelBuilder.Entity("innomiate_api.Models.CompetitionCoachingTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.ToTable("CompetitionCoachingTags");
                });

            modelBuilder.Entity("innomiate_api.Models.CompetitionPendingCoach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoachEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.ToTable("CompetitionPendingCoaches");
                });

            modelBuilder.Entity("innomiate_api.Models.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Operation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OperationDate")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("History");
                });

            modelBuilder.Entity("innomiate_api.Models.HostingRequest", b =>
                {
                    b.Property<int>("HostingRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("HostingRequestId"));

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Request")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("HostingRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("HostingRequests");
                });

            modelBuilder.Entity("innomiate_api.Models.PlatformAdmin", b =>
                {
                    b.Property<int>("PlatformAdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PlatformAdminId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PlatformAdminId");

                    b.ToTable("PlateformAdmins");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.Competition", b =>
                {
                    b.OwnsMany("innomiate_api.Models.NameImageMapping", "Organizers", b1 =>
                        {
                            b1.Property<int>("CompetitionId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("ImageUrl")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("CompetitionId", "Id");

                            b1.ToTable("CompetitionOrganizers", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CompetitionId");
                        });

                    b.OwnsMany("innomiate_api.Models.NameImageMapping", "Partnerships", b1 =>
                        {
                            b1.Property<int>("CompetitionId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("ImageUrl")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("CompetitionId", "Id");

                            b1.ToTable("CompetitionPartnerships", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CompetitionId");
                        });

                    b.OwnsMany("innomiate_api.Models.NameImageMapping", "Sponsors", b1 =>
                        {
                            b1.Property<int>("CompetitionId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("ImageUrl")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("CompetitionId", "Id");

                            b1.ToTable("CompetitionSponsors", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CompetitionId");
                        });

                    b.OwnsMany("innomiate_api.Models.CompetitionPrize", "Prizes", b1 =>
                        {
                            b1.Property<int>("CompetitionId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<int>("BeginningRank")
                                .HasColumnType("int");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<int>("EndingRank")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("CompetitionId", "Id");

                            b1.ToTable("CompetitionPrizes", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CompetitionId");
                        });

                    b.Navigation("Organizers");

                    b.Navigation("Partnerships");

                    b.Navigation("Prizes");

                    b.Navigation("Sponsors");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.CompetitionCoach", b =>
                {
                    b.HasOne("INNOMIATE_API.Models.Competition", "Competition")
                        .WithMany("Coaches")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("INNOMIATE_API.Models.User", "User")
                        .WithMany("CoachedCompetitions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");

                    b.Navigation("User");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.CompetitionContributor", b =>
                {
                    b.HasOne("INNOMIATE_API.Models.Competition", "Competition")
                        .WithMany("Contributors")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.CompetitionCreator", b =>
                {
                    b.HasOne("INNOMIATE_API.Models.Competition", "Competition")
                        .WithOne("Creator")
                        .HasForeignKey("INNOMIATE_API.Models.CompetitionCreator", "CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("INNOMIATE_API.Models.User", "User")
                        .WithMany("CreatedCompetitions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");

                    b.Navigation("User");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.CompetitionJudge", b =>
                {
                    b.HasOne("INNOMIATE_API.Models.Competition", "Competition")
                        .WithMany("Judges")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("INNOMIATE_API.Models.User", "User")
                        .WithMany("JudgedCompetitions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");

                    b.Navigation("User");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.CompetitionParticipant", b =>
                {
                    b.HasOne("INNOMIATE_API.Models.Competition", "Competition")
                        .WithMany("Participants")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("INNOMIATE_API.Models.Group", "Group")
                        .WithMany("Participants")
                        .HasForeignKey("GroupId");

                    b.HasOne("INNOMIATE_API.Models.User", "User")
                        .WithMany("ParticipatedCompetitions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.Group", b =>
                {
                    b.HasOne("INNOMIATE_API.Models.Competition", "Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.Requirement", b =>
                {
                    b.HasOne("INNOMIATE_API.Models.Competition", "competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("competition");
                });

            modelBuilder.Entity("innomiate_api.Models.Badging.Badge", b =>
                {
                    b.HasOne("innomiate_api.Models.Badging.Badging", "Badging")
                        .WithMany("Badges")
                        .HasForeignKey("BadgingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Badging");
                });

            modelBuilder.Entity("innomiate_api.Models.Badging.Badging", b =>
                {
                    b.HasOne("INNOMIATE_API.Models.Competition", "Competition")
                        .WithOne("Badging")
                        .HasForeignKey("innomiate_api.Models.Badging.Badging", "CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("innomiate_api.Models.CompetitionCoachingAnnounce", b =>
                {
                    b.HasOne("INNOMIATE_API.Models.Competition", "Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("innomiate_api.Models.CompetitionCoachingTag", b =>
                {
                    b.HasOne("INNOMIATE_API.Models.Competition", "Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("innomiate_api.Models.CompetitionPendingCoach", b =>
                {
                    b.HasOne("INNOMIATE_API.Models.Competition", "Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("innomiate_api.Models.HostingRequest", b =>
                {
                    b.HasOne("INNOMIATE_API.Models.User", "User")
                        .WithMany("HostingRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.Competition", b =>
                {
                    b.Navigation("Badging")
                        .IsRequired();

                    b.Navigation("Coaches");

                    b.Navigation("Contributors");

                    b.Navigation("Creator")
                        .IsRequired();

                    b.Navigation("Judges");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.Group", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("INNOMIATE_API.Models.User", b =>
                {
                    b.Navigation("CoachedCompetitions");

                    b.Navigation("CreatedCompetitions");

                    b.Navigation("HostingRequests");

                    b.Navigation("JudgedCompetitions");

                    b.Navigation("ParticipatedCompetitions");
                });

            modelBuilder.Entity("innomiate_api.Models.Badging.Badging", b =>
                {
                    b.Navigation("Badges");
                });
#pragma warning restore 612, 618
        }
    }
}
