using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacantes",
                columns: table => new
                {
                    VacanteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreDeVacante = table.Column<string>(type: "TEXT", nullable: true),
                    DepartamentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaDeRegistroVacante = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RequisitosVacante = table.Column<string>(type: "TEXT", nullable: true),
                    DescripcionVacante = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacantes", x => x.VacanteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacantes");
        }
    }
}
