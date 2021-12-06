using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    public partial class AgregandomasentidadesenelmodelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "CiudadId",
                keyValue: 1,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "CiudadId",
                keyValue: 2,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "CiudadId",
                keyValue: 3,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "CiudadId",
                keyValue: 4,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "CiudadId",
                keyValue: 5,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "EmpresaId",
                keyValue: 1,
                columns: new[] { "Telefono", "UsuarioId" },
                values: new object[] { "(809)-290-8243", 1 });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "EmpresaId", "Duracion", "Nombre", "Puesto", "Telefono", "UsuarioId" },
                values: new object[] { 2, 3, "Ferreteria INCOROSA", "Vendedor", "(809)-725-0577", 1 });

            migrationBuilder.UpdateData(
                table: "Generos",
                keyColumn: "GeneroId",
                keyValue: 1,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Generos",
                keyColumn: "GeneroId",
                keyValue: 2,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "GeneroId", "Descripcion", "UsuarioId" },
                values: new object[] { 4, "Transexual", 1 });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "GeneroId", "Descripcion", "UsuarioId" },
                values: new object[] { 3, "Homosexual", 1 });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "GeneroId", "Descripcion", "UsuarioId" },
                values: new object[] { 5, "Bisexual", 1 });

            migrationBuilder.UpdateData(
                table: "Provincias",
                keyColumn: "ProvinciaId",
                keyValue: 1,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Provincias",
                keyColumn: "ProvinciaId",
                keyValue: 2,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Provincias",
                keyColumn: "ProvinciaId",
                keyValue: 3,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Provincias",
                keyColumn: "ProvinciaId",
                keyValue: 4,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Provincias",
                keyColumn: "ProvinciaId",
                keyValue: 5,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "SectorId",
                keyValue: 1,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "SectorId",
                keyValue: 2,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "SectorId",
                keyValue: 3,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "SectorId",
                keyValue: 4,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "SectorId",
                keyValue: 5,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 12, 6, 14, 4, 5, 369, DateTimeKind.Local).AddTicks(6582));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "EmpresaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "GeneroId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "GeneroId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "GeneroId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "CiudadId",
                keyValue: 1,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "CiudadId",
                keyValue: 2,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "CiudadId",
                keyValue: 3,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "CiudadId",
                keyValue: 4,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Ciudades",
                keyColumn: "CiudadId",
                keyValue: 5,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "EmpresaId",
                keyValue: 1,
                columns: new[] { "Telefono", "UsuarioId" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Generos",
                keyColumn: "GeneroId",
                keyValue: 1,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Generos",
                keyColumn: "GeneroId",
                keyValue: 2,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Provincias",
                keyColumn: "ProvinciaId",
                keyValue: 1,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Provincias",
                keyColumn: "ProvinciaId",
                keyValue: 2,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Provincias",
                keyColumn: "ProvinciaId",
                keyValue: 3,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Provincias",
                keyColumn: "ProvinciaId",
                keyValue: 4,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Provincias",
                keyColumn: "ProvinciaId",
                keyValue: 5,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "SectorId",
                keyValue: 1,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "SectorId",
                keyValue: 2,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "SectorId",
                keyValue: 3,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "SectorId",
                keyValue: 4,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sectores",
                keyColumn: "SectorId",
                keyValue: 5,
                column: "UsuarioId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 12, 6, 12, 36, 47, 263, DateTimeKind.Local).AddTicks(4689));
        }
    }
}
