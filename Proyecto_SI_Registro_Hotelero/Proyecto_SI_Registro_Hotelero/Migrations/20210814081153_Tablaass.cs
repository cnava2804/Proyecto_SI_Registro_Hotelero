using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_SI_Registro_Hotelero.Migrations
{
    public partial class Tablaass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHabitaciones_PagoReservas_PReservaId",
                table: "ReservaHabitaciones");

            migrationBuilder.DropIndex(
                name: "IX_ReservaHabitaciones_PReservaId",
                table: "ReservaHabitaciones");

            migrationBuilder.DropColumn(
                name: "PReservaId",
                table: "ReservaHabitaciones");

            migrationBuilder.AddColumn<int>(
                name: "ReservaHId",
                table: "PagoReservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PagoReservas_ReservaHId",
                table: "PagoReservas",
                column: "ReservaHId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagoReservas_ReservaHabitaciones_ReservaHId",
                table: "PagoReservas",
                column: "ReservaHId",
                principalTable: "ReservaHabitaciones",
                principalColumn: "ReservaHId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagoReservas_ReservaHabitaciones_ReservaHId",
                table: "PagoReservas");

            migrationBuilder.DropIndex(
                name: "IX_PagoReservas_ReservaHId",
                table: "PagoReservas");

            migrationBuilder.DropColumn(
                name: "ReservaHId",
                table: "PagoReservas");

            migrationBuilder.AddColumn<int>(
                name: "PReservaId",
                table: "ReservaHabitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitaciones_PReservaId",
                table: "ReservaHabitaciones",
                column: "PReservaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHabitaciones_PagoReservas_PReservaId",
                table: "ReservaHabitaciones",
                column: "PReservaId",
                principalTable: "PagoReservas",
                principalColumn: "PReservaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
