using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace innomiate_api.Migrations
{
    /// <inheritdoc />
    public partial class stepcom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StepCompetitions_Teams_IdTeam",
                table: "StepCompetitions");

            migrationBuilder.DropIndex(
                name: "IX_StepCompetitions_IdTeam",
                table: "StepCompetitions");

            migrationBuilder.DropColumn(
                name: "IdTeam",
                table: "StepCompetitions");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "StepCompetitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StepCompetitions_TeamId",
                table: "StepCompetitions",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_StepCompetitions_Teams_TeamId",
                table: "StepCompetitions",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StepCompetitions_Teams_TeamId",
                table: "StepCompetitions");

            migrationBuilder.DropIndex(
                name: "IX_StepCompetitions_TeamId",
                table: "StepCompetitions");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "StepCompetitions");

            migrationBuilder.AddColumn<int>(
                name: "IdTeam",
                table: "StepCompetitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StepCompetitions_IdTeam",
                table: "StepCompetitions",
                column: "IdTeam");

            migrationBuilder.AddForeignKey(
                name: "FK_StepCompetitions_Teams_IdTeam",
                table: "StepCompetitions",
                column: "IdTeam",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
