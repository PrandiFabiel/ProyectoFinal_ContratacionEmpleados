using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    public partial class Añadiendoentidadesalmodelcreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "EmpresaId", "Duracion", "Nombre", "Puesto", "Telefono", "UsuarioId" },
                values: new object[] { 1, 9, "Ferreteria Jordan", "Vendedor", null, 0 });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "GeneroId", "Descripcion", "UsuarioId" },
                values: new object[] { 1, "Masculino", 0 });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "GeneroId", "Descripcion", "UsuarioId" },
                values: new object[] { 2, "Femenino", 0 });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombre", "UsuarioId" },
                values: new object[] { 1, "Duarte", 0 });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombre", "UsuarioId" },
                values: new object[] { 2, "Santo Domingo", 0 });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombre", "UsuarioId" },
                values: new object[] { 3, "La Vega", 0 });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombre", "UsuarioId" },
                values: new object[] { 4, "Santiago de los Caballeros", 0 });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombre", "UsuarioId" },
                values: new object[] { 5, "Hermanas Mirabal", 0 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 11, 29, 20, 19, 17, 463, DateTimeKind.Local).AddTicks(5206));

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "CiudadId", "Nombre", "ProvinciaId", "UsuarioId" },
                values: new object[] { 1, "San Francisco de Macoris", 1, 0 });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "CiudadId", "Nombre", "ProvinciaId", "UsuarioId" },
                values: new object[] { 2, "Santo Domingo Este", 2, 0 });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "CiudadId", "Nombre", "ProvinciaId", "UsuarioId" },
                values: new object[] { 3, "La Vega", 3, 0 });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "CiudadId", "Nombre", "ProvinciaId", "UsuarioId" },
                values: new object[] { 4, "Santiago", 4, 0 });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "CiudadId", "Nombre", "ProvinciaId", "UsuarioId" },
                values: new object[] { 5, "Salcedo", 5, 0 });

            migrationBuilder.InsertData(
                table: "Sectores",
                columns: new[] { "SectorId", "CiudadId", "Nombre", "UsuarioId" },
                values: new object[] { 1, 1, "Cenovi", 0 });

            migrationBuilder.InsertData(
                table: "Sectores",
                columns: new[] { "SectorId", "CiudadId", "Nombre", "UsuarioId" },
                values: new object[] { 2, 2, "Valle del Este", 0 });

            migrationBuilder.InsertData(
                table: "Sectores",
                columns: new[] { "SectorId", "CiudadId", "Nombre", "UsuarioId" },
                values: new object[] { 3, 3, "El Ranchito", 0 });

            migrationBuilder.InsertData(
                table: "Sectores",
                columns: new[] { "SectorId", "CiudadId", "Nombre", "UsuarioId" },
                values: new object[] { 4, 4, "Bella Vista", 0 });

            migrationBuilder.InsertData(
                table: "Sectores",
                columns: new[] { "SectorId", "CiudadId", "Nombre", "UsuarioId" },
                values: new object[] { 5, 5, "Ojo de agua", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "EmpresaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "GeneroId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "GeneroId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sectores",
                keyColumn: "SectorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sectores",
                keyColumn: "SectorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sectores",
                keyColumn: "SectorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sectores",
                keyColumn: "SectorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sectores",
                keyColumn: "SectorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "CiudadId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "CiudadId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "CiudadId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "CiudadId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "CiudadId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "ProvinciaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "ProvinciaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "ProvinciaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "ProvinciaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "ProvinciaId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaRegistroUsuario",
                value: new DateTime(2021, 11, 28, 18, 8, 15, 391, DateTimeKind.Local).AddTicks(312));
        }
    }
}
