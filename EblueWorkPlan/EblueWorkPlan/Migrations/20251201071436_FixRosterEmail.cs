using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EblueWorkPlan.Migrations
{
    /// <inheritdoc />
    public partial class FixRosterEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<int>(
                name: "RosterId",
                table: "Locationn",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RosterId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locationn_RosterId",
                table: "Locationn",
                column: "RosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_RosterId",
                table: "Departments",
                column: "RosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_roster_RosterId",
                table: "Departments",
                column: "RosterId",
                principalTable: "roster",
                principalColumn: "RosterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locationn_roster_RosterId",
                table: "Locationn",
                column: "RosterId",
                principalTable: "roster",
                principalColumn: "RosterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_roster_RosterId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Locationn_roster_RosterId",
                table: "Locationn");

            migrationBuilder.DropIndex(
                name: "IX_Locationn_RosterId",
                table: "Locationn");

            migrationBuilder.DropIndex(
                name: "IX_Departments_RosterId",
                table: "Departments");

           

            migrationBuilder.DropColumn(
                name: "RosterId",
                table: "Locationn");

            migrationBuilder.DropColumn(
                name: "RosterId",
                table: "Departments");
        }
    }
}
