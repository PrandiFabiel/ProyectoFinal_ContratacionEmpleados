using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    public partial class Agregando_Restricciones_a_Registros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolesDetalle_Permisos_PermisoId",
                table: "RolesDetalle");

            migrationBuilder.DropIndex(
                name: "IX_RolesDetalle_PermisoId",
                table: "RolesDetalle");

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "EmpresaId", "Duracion", "Nombre", "Puesto", "Telefono", "UsuarioId" },
                values: new object[] { 3, 8, "Guarina", "Vendedor", "(809)-200-6222", 1 });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "EmpresaId", "Duracion", "Nombre", "Puesto", "Telefono", "UsuarioId" },
                values: new object[] { 4, 8, "Aviva", "Vendedor", "(809)-372-1744", 1 });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "EmpresaId", "Duracion", "Nombre", "Puesto", "Telefono", "UsuarioId" },
                values: new object[] { 5, 8, "Effective", "Vendedor", "(502)-327-3700", 1 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 12, 6, 17, 51, 10, 483, DateTimeKind.Local).AddTicks(4078));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "EmpresaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "EmpresaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "EmpresaId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 12, 6, 17, 5, 6, 813, DateTimeKind.Local).AddTicks(1065));

            migrationBuilder.CreateIndex(
                name: "IX_RolesDetalle_PermisoId",
                table: "RolesDetalle",
                column: "PermisoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolesDetalle_Permisos_PermisoId",
                table: "RolesDetalle",
                column: "PermisoId",
                principalTable: "Permisos",
                principalColumn: "PermisoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
