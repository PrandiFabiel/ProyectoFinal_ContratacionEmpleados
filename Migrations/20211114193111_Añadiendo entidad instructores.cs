using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    public partial class Añadiendoentidadinstructores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructores",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaInstructor = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NombreInstructor = table.Column<string>(type: "TEXT", nullable: true),
                    ApellidosInstructor = table.Column<string>(type: "TEXT", nullable: true),
                    TelefonoInstructor = table.Column<string>(type: "TEXT", nullable: true),
                    CantidadEmpleados = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructores", x => x.InstructorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructores");
        }
    }
}
