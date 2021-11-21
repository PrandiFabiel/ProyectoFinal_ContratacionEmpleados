using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    public partial class Login_Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Clave", "Email", "FechaRegistroUsuario", "NombreUsuario", "RolId" },
                values: new object[] { 1, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", "profe098@gmail.com", new DateTime(2021, 11, 21, 17, 3, 56, 346, DateTimeKind.Local).AddTicks(7047), "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1);
        }
    }
}
