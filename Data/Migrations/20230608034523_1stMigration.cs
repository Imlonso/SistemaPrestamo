using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class _1stMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Exactitud = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.IdMarca);
                });

            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePersona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoPrestamo = table.Column<bool>(type: "bit", nullable: false),
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.IdPrestamo);
                    table.ForeignKey(
                        name: "FK_Prestamo_Marcas_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "Marcas",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    IdEquipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroSerie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    PrestamoIdPrestamo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.IdEquipo);
                    table.ForeignKey(
                        name: "FK_Equipo_Marcas_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "Marcas",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipo_Prestamo_PrestamoIdPrestamo",
                        column: x => x.PrestamoIdPrestamo,
                        principalTable: "Prestamo",
                        principalColumn: "IdPrestamo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_IdMarca",
                table: "Equipo",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_PrestamoIdPrestamo",
                table: "Equipo",
                column: "PrestamoIdPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_IdMarca",
                table: "Prestamo",
                column: "IdMarca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "Prestamo");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
