using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    public partial class Agregando_Campo_ACiudades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Provincias_ProvinciaId",
                table: "Ciudades");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinciaId",
                table: "Ciudades",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Provincias_ProvinciaId",
                table: "Ciudades",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "ProvinciaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Provincias_ProvinciaId",
                table: "Ciudades");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinciaId",
                table: "Ciudades",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Provincias_ProvinciaId",
                table: "Ciudades",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "ProvinciaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
