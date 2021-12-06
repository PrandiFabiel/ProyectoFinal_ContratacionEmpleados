using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    public partial class Modificando_ModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 1,
                column: "VecesAsignado",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 2,
                column: "VecesAsignado",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 3,
                column: "VecesAsignado",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 4,
                column: "VecesAsignado",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 5,
                column: "VecesAsignado",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 12, 6, 12, 36, 47, 263, DateTimeKind.Local).AddTicks(4689));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 1,
                column: "VecesAsignado",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 2,
                column: "VecesAsignado",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 3,
                column: "VecesAsignado",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 4,
                column: "VecesAsignado",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 5,
                column: "VecesAsignado",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 12, 6, 12, 34, 50, 924, DateTimeKind.Local).AddTicks(5225));
        }
    }
}
