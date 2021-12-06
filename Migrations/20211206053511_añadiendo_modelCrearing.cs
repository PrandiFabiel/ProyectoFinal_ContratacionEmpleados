using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    public partial class añadiendo_modelCrearing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 12, 6, 1, 35, 9, 427, DateTimeKind.Local).AddTicks(3565));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 12, 6, 1, 8, 44, 344, DateTimeKind.Local).AddTicks(5439));
        }
    }
}
