using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class PlanEstudio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanEstudio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VigenciaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VigenciaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false),
                    TurnoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanEstudio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanEstudio_Especialidad_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanEstudio_Turno_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turno",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanEstudio_EspecialidadId",
                table: "PlanEstudio",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanEstudio_TurnoId",
                table: "PlanEstudio",
                column: "TurnoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanEstudio");
        }
    }
}
