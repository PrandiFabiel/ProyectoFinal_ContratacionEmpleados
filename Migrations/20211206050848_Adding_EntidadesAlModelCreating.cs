using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    public partial class Adding_EntidadesAlModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsusarioId",
                table: "Vacantes",
                newName: "UsuarioId");

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "DepartamentoId", "Nombre", "UsuarioId" },
                values: new object[] { 1, "Ventas", 1 });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "DepartamentoId", "Nombre", "UsuarioId" },
                values: new object[] { 2, "Compras", 1 });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "DepartamentoId", "Nombre", "UsuarioId" },
                values: new object[] { 3, "TI", 1 });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "DepartamentoId", "Nombre", "UsuarioId" },
                values: new object[] { 4, "Recursos Humanos", 1 });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "DepartamentoId", "Nombre", "UsuarioId" },
                values: new object[] { 5, "Mantenimiento", 1 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "HabilidadId", "Descripcion", "UsuarioId", "VecesAsignada" },
                values: new object[] { 1, "Liderazgo", 1, 0 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "HabilidadId", "Descripcion", "UsuarioId", "VecesAsignada" },
                values: new object[] { 2, "Actitud positiva", 1, 0 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "HabilidadId", "Descripcion", "UsuarioId", "VecesAsignada" },
                values: new object[] { 3, "Adaptabilidad y flexibilidad", 1, 0 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "HabilidadId", "Descripcion", "UsuarioId", "VecesAsignada" },
                values: new object[] { 4, "Comunicación", 1, 0 });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "HabilidadId", "Descripcion", "UsuarioId", "VecesAsignada" },
                values: new object[] { 5, "Trabajo en equipo", 1, 0 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 12, 6, 1, 8, 44, 344, DateTimeKind.Local).AddTicks(5439));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "DepartamentoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Habilidades",
                keyColumn: "HabilidadId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Habilidades",
                keyColumn: "HabilidadId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Habilidades",
                keyColumn: "HabilidadId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Habilidades",
                keyColumn: "HabilidadId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Habilidades",
                keyColumn: "HabilidadId",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Vacantes",
                newName: "UsusarioId");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 11, 29, 20, 19, 17, 463, DateTimeKind.Local).AddTicks(5206));
        }
    }
}
