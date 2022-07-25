using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KrasnodarAirport.Data.Migrations
{
    public partial class EditStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Direction",
                table: "Flights",
                newName: "Country");

            migrationBuilder.AddColumn<int>(
                name: "AirportId",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportId",
                table: "Flights",
                column: "AirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airport_AirportId",
                table: "Flights",
                column: "AirportId",
                principalTable: "Airport",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airport_AirportId",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AirportId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AirportId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Flights",
                newName: "Direction");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
