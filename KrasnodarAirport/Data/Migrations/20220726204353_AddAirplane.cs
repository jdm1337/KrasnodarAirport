using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KrasnodarAirport.Data.Migrations
{
    public partial class AddAirplane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AirplaneId",
                table: "Flight",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Airplane",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatsAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplane", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirplaneId",
                table: "Flight",
                column: "AirplaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airplane_AirplaneId",
                table: "Flight",
                column: "AirplaneId",
                principalTable: "Airplane",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airplane_AirplaneId",
                table: "Flight");

            migrationBuilder.DropTable(
                name: "Airplane");

            migrationBuilder.DropIndex(
                name: "IX_Flight_AirplaneId",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "AirplaneId",
                table: "Flight");
        }
    }
}
