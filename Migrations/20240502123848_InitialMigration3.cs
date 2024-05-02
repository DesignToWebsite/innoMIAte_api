using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace innomiate_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompetitions_Users_UserId1",
                table: "UserCompetitions");

            migrationBuilder.DropIndex(
                name: "IX_UserCompetitions_UserId1",
                table: "UserCompetitions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserCompetitions");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserCompetitions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompetitions_Users_UserId",
                table: "UserCompetitions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompetitions_Users_UserId",
                table: "UserCompetitions");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserCompetitions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserCompetitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserCompetitions_UserId1",
                table: "UserCompetitions",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompetitions_Users_UserId1",
                table: "UserCompetitions",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
