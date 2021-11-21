using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    public partial class Añadiendoentidadpersonas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    NombreReferenciaFamiliar = table.Column<string>(type: "TEXT", nullable: true),
                    TelefonoReferenciaFamiliar = table.Column<string>(type: "TEXT", nullable: true),
                    NombreReferenciaPersonal = table.Column<string>(type: "TEXT", nullable: true),
                    TelefonoReferenciaPersonal = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    GeneroId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProvinciaId = table.Column<int>(type: "INTEGER", nullable: false),
                    VacanteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaId);
                    table.ForeignKey(
                        name: "FK_Personas_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "ProvinciaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_Vacantes_VacanteId",
                        column: x => x.VacanteId,
                        principalTable: "Vacantes",
                        principalColumn: "VacanteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonasDetalle",
                columns: table => new
                {
                    PersonasDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonasDetalle", x => x.PersonasDetalleId);
                    table.ForeignKey(
                        name: "FK_PersonasDetalle_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonasDetalle_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_GeneroId",
                table: "Personas",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_ProvinciaId",
                table: "Personas",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_VacanteId",
                table: "Personas",
                column: "VacanteId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonasDetalle_EmpresaId",
                table: "PersonasDetalle",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonasDetalle_PersonaId",
                table: "PersonasDetalle",
                column: "PersonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonasDetalle");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
