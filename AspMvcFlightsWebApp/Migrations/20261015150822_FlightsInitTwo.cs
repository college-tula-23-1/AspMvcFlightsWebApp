using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspMvcFlightsWebApp.Migrations
{
    /// <inheritdoc />
    public partial class FlightsInitTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airlines_AirlineId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_DepartureId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_DepartureId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureId",
                table: "Flights");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DapartueId",
                table: "Flights",
                column: "DapartueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airlines_AirlineId",
                table: "Flights",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_DapartueId",
                table: "Flights",
                column: "DapartueId",
                principalTable: "Airports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airlines_AirlineId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_DapartueId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_DapartueId",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "DepartureId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DepartureId",
                table: "Flights",
                column: "DepartureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airlines_AirlineId",
                table: "Flights",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_DepartureId",
                table: "Flights",
                column: "DepartureId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
