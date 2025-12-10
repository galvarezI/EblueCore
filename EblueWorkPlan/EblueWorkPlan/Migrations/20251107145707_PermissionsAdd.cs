using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EblueWorkPlan.Migrations
{
    /// <inheritdoc />
    public partial class PermissionsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PuedeCrear = table.Column<bool>(type: "bit", nullable: false),
                    PuedeEditar = table.Column<bool>(type: "bit", nullable: false),
                    PuedeEliminar = table.Column<bool>(type: "bit", nullable: false),
                    PuedeVer = table.Column<bool>(type: "bit", nullable: false),
                    PuedeAprobar = table.Column<bool>(type: "bit", nullable: false),
                    PuedeRechazar = table.Column<bool>(type: "bit", nullable: false),
                    PuedeComentar = table.Column<bool>(type: "bit", nullable: false),
                    PuedeAsignarRoles = table.Column<bool>(type: "bit", nullable: false),
                    PuedeAdministrarTodo = table.Column<bool>(type: "bit", nullable: false),
                    PuedeReenviar = table.Column<bool>(type: "bit", nullable: false),
                    PuedeModificarTrasRechazo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");
        }
    }
}
