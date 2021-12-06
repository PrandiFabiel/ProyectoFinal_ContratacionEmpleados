using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    public partial class Agregando_Entidades_ModelCreatingPrandi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 1,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisoId", "Descripcion", "UsuarioId", "VecesAsignado" },
                values: new object[] { 2, "Permiso2", 1, 0 });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisoId", "Descripcion", "UsuarioId", "VecesAsignado" },
                values: new object[] { 3, "Permiso3", 1, 0 });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisoId", "Descripcion", "UsuarioId", "VecesAsignado" },
                values: new object[] { 4, "Permiso4", 1, 0 });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisoId", "Descripcion", "UsuarioId", "VecesAsignado" },
                values: new object[] { 5, "Permiso5", 1, 0 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolId",
                keyValue: 1,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolId", "Descripcion", "UsuarioId" },
                values: new object[] { 2, "Empleado", 1 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolId", "Descripcion", "UsuarioId" },
                values: new object[] { 3, "Tester", 1 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolId", "Descripcion", "UsuarioId" },
                values: new object[] { 4, "Programador", 1 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolId", "Descripcion", "UsuarioId" },
                values: new object[] { 5, "Jefe", 1 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 12, 6, 12, 34, 50, 924, DateTimeKind.Local).AddTicks(5225));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "PermisoId",
                keyValue: 1,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolId",
                keyValue: 1,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 12, 6, 1, 35, 9, 427, DateTimeKind.Local).AddTicks(3565));
        }
    }
}
