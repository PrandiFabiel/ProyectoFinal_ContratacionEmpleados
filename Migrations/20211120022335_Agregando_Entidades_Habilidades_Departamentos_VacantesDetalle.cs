using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    public partial class Agregando_Entidades_Habilidades_Departamentos_VacantesDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequisitosVacante",
                table: "Vacantes",
                newName: "Requisitos");

            migrationBuilder.RenameColumn(
                name: "NombreDeVacante",
                table: "Vacantes",
                newName: "NombreVacante");

            migrationBuilder.RenameColumn(
                name: "FechaDeRegistroVacante",
                table: "Vacantes",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "DescripcionVacante",
                table: "Vacantes",
                newName: "Descripcion");

            migrationBuilder.AddColumn<int>(
                name: "Disponible",
                table: "Vacantes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsusarioId",
                table: "Vacantes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    HabilidadId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    VecesAsignada = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.HabilidadId);
                });

            migrationBuilder.CreateTable(
                name: "VacantesDetalle",
                columns: table => new
                {
                    VacanteDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VacanteId = table.Column<int>(type: "INTEGER", nullable: false),
                    HabilidadId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacantesDetalle", x => x.VacanteDetalleId);
                    table.ForeignKey(
                        name: "FK_VacantesDetalle_Habilidades_HabilidadId",
                        column: x => x.HabilidadId,
                        principalTable: "Habilidades",
                        principalColumn: "HabilidadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacantesDetalle_Vacantes_VacanteId",
                        column: x => x.VacanteId,
                        principalTable: "Vacantes",
                        principalColumn: "VacanteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacantes_DepartamentoId",
                table: "Vacantes",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_VacantesDetalle_HabilidadId",
                table: "VacantesDetalle",
                column: "HabilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_VacantesDetalle_VacanteId",
                table: "VacantesDetalle",
                column: "VacanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacantes_Departamentos_DepartamentoId",
                table: "Vacantes",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacantes_Departamentos_DepartamentoId",
                table: "Vacantes");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "VacantesDetalle");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropIndex(
                name: "IX_Vacantes_DepartamentoId",
                table: "Vacantes");

            migrationBuilder.DropColumn(
                name: "Disponible",
                table: "Vacantes");

            migrationBuilder.DropColumn(
                name: "UsusarioId",
                table: "Vacantes");

            migrationBuilder.RenameColumn(
                name: "Requisitos",
                table: "Vacantes",
                newName: "RequisitosVacante");

            migrationBuilder.RenameColumn(
                name: "NombreVacante",
                table: "Vacantes",
                newName: "NombreDeVacante");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Vacantes",
                newName: "FechaDeRegistroVacante");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Vacantes",
                newName: "DescripcionVacante");
        }
    }
}
