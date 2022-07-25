using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KrasnodarAirport.Data.Migrations
{
    public partial class EditDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightReal_Flights_FlightId",
                table: "FlightReal");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airport_AirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_FlightReal_FlightRealId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flights",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightReal",
                table: "FlightReal");

            migrationBuilder.RenameTable(
                name: "Flights",
                newName: "Flight");

            migrationBuilder.RenameTable(
                name: "FlightReal",
                newName: "FlightsReal");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_AirportId",
                table: "Flight",
                newName: "IX_Flight_AirportId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightReal_FlightId",
                table: "FlightsReal",
                newName: "IX_FlightsReal_FlightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight",
                table: "Flight",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightsReal",
                table: "FlightsReal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_AirportId",
                table: "Flight",
                column: "AirportId",
                principalTable: "Airport",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightsReal_Flight_FlightId",
                table: "FlightsReal",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_FlightsReal_FlightRealId",
                table: "Tickets",
                column: "FlightRealId",
                principalTable: "FlightsReal",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_AirportId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightsReal_Flight_FlightId",
                table: "FlightsReal");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_FlightsReal_FlightRealId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightsReal",
                table: "FlightsReal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight",
                table: "Flight");

            migrationBuilder.RenameTable(
                name: "FlightsReal",
                newName: "FlightReal");

            migrationBuilder.RenameTable(
                name: "Flight",
                newName: "Flights");

            migrationBuilder.RenameIndex(
                name: "IX_FlightsReal_FlightId",
                table: "FlightReal",
                newName: "IX_FlightReal_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_AirportId",
                table: "Flights",
                newName: "IX_Flights_AirportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightReal",
                table: "FlightReal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flights",
                table: "Flights",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightReal_Flights_FlightId",
                table: "FlightReal",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airport_AirportId",
                table: "Flights",
                column: "AirportId",
                principalTable: "Airport",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_FlightReal_FlightRealId",
                table: "Tickets",
                column: "FlightRealId",
                principalTable: "FlightReal",
                principalColumn: "Id");
        }
    }
}
