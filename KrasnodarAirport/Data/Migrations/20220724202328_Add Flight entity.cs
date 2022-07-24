using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KrasnodarAirport.Data.Migrations
{
    public partial class AddFlightentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Flights_FlightId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "Tickets",
                newName: "FlightRealId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_FlightId",
                table: "Tickets",
                newName: "IX_Tickets_FlightRealId");

            migrationBuilder.RenameColumn(
                name: "FlightTime",
                table: "Flights",
                newName: "PublishDate");

            migrationBuilder.RenameColumn(
                name: "DepartureTime",
                table: "Flights",
                newName: "FirstFlight");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FlightReal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightReal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightReal_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightReal_FlightId",
                table: "FlightReal",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_FlightReal_FlightRealId",
                table: "Tickets",
                column: "FlightRealId",
                principalTable: "FlightReal",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_FlightReal_FlightRealId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "FlightReal");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "FlightRealId",
                table: "Tickets",
                newName: "FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_FlightRealId",
                table: "Tickets",
                newName: "IX_Tickets_FlightId");

            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "Flights",
                newName: "FlightTime");

            migrationBuilder.RenameColumn(
                name: "FirstFlight",
                table: "Flights",
                newName: "DepartureTime");

            migrationBuilder.AddColumn<string>(
                name: "FlightNumber",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Flights_FlightId",
                table: "Tickets",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id");
        }
    }
}
