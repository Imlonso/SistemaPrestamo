using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class _3rdmigrtion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_Prestamo_PrestamoIdPrestamo",
                table: "Equipo");

            migrationBuilder.DropIndex(
                name: "IX_Equipo_PrestamoIdPrestamo",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "PrestamoIdPrestamo",
                table: "Equipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrestamoIdPrestamo",
                table: "Equipo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_PrestamoIdPrestamo",
                table: "Equipo",
                column: "PrestamoIdPrestamo");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_Prestamo_PrestamoIdPrestamo",
                table: "Equipo",
                column: "PrestamoIdPrestamo",
                principalTable: "Prestamo",
                principalColumn: "IdPrestamo");
        }
    }
}
