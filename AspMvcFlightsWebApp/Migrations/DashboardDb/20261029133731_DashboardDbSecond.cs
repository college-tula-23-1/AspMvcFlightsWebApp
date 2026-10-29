using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspMvcFlightsWebApp.Migrations.DashboardDb
{
    /// <inheritdoc />
    public partial class DashboardDbSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Action",
                table: "MainMenuItems",
                newName: "Controller");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Controller",
                table: "MainMenuItems",
                newName: "Action");
        }
    }
}
