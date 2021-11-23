using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    public partial class Cambiando_nombre_variable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreVacante",
                table: "Vacantes",
                newName: "Nombre");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 11, 22, 18, 57, 52, 639, DateTimeKind.Local).AddTicks(8237));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Vacantes",
                newName: "NombreVacante");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 11, 21, 19, 35, 16, 861, DateTimeKind.Local).AddTicks(9345));
        }
    }
}
