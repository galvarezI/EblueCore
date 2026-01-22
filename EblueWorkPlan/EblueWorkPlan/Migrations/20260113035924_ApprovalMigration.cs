using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EblueWorkPlan.Migrations
{
    /// <inheritdoc />
    public partial class ApprovalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectApprovalHistories",
                columns: table => new
                {
                    ProjectApprovalHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectStatusId = table.Column<int>(type: "int", nullable: false),
                    RosterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectApprovalHistories", x => x.ProjectApprovalHistoryId);
                    table.ForeignKey(
                        name: "FK_ProjectApprovalHistories_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectApprovalHistories_roster_RosterId",
                        column: x => x.RosterId,
                        principalTable: "roster",
                        principalColumn: "RosterID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectApprovalHistories_ProjectId",
                table: "ProjectApprovalHistories",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectApprovalHistories_RosterId",
                table: "ProjectApprovalHistories",
                column: "RosterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectApprovalHistories");
        }
    }
}
