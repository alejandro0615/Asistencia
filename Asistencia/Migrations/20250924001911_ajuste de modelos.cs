using Microsoft.EntityFrameworkCore.Migrations;

namespace Asistencia.Migrations
{
    public partial class ajustedemodelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presencia_Alumno_AlumnoId",
                table: "Presencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Presencia_Asignatura_AsignaturaId",
                table: "Presencia");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo_Documento",
                table: "Profesor",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<bool>(
                name: "estado_alumno",
                table: "Presencia",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "AlumnoId1",
                table: "Presencia",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradoId",
                table: "Presencia",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Presencia_AlumnoId1",
                table: "Presencia",
                column: "AlumnoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Presencia_GradoId",
                table: "Presencia",
                column: "GradoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Presencia_Alumno_AlumnoId",
                table: "Presencia",
                column: "AlumnoId",
                principalTable: "Alumno",
                principalColumn: "AlumnoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Presencia_Alumno_AlumnoId1",
                table: "Presencia",
                column: "AlumnoId1",
                principalTable: "Alumno",
                principalColumn: "AlumnoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Presencia_Asignatura_AsignaturaId",
                table: "Presencia",
                column: "AsignaturaId",
                principalTable: "Asignatura",
                principalColumn: "AsignaturaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Presencia_Grado_GradoId",
                table: "Presencia",
                column: "GradoId",
                principalTable: "Grado",
                principalColumn: "GradoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presencia_Alumno_AlumnoId",
                table: "Presencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Presencia_Alumno_AlumnoId1",
                table: "Presencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Presencia_Asignatura_AsignaturaId",
                table: "Presencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Presencia_Grado_GradoId",
                table: "Presencia");

            migrationBuilder.DropIndex(
                name: "IX_Presencia_AlumnoId1",
                table: "Presencia");

            migrationBuilder.DropIndex(
                name: "IX_Presencia_GradoId",
                table: "Presencia");

            migrationBuilder.DropColumn(
                name: "AlumnoId1",
                table: "Presencia");

            migrationBuilder.DropColumn(
                name: "GradoId",
                table: "Presencia");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo_Documento",
                table: "Profesor",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "estado_alumno",
                table: "Presencia",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddForeignKey(
                name: "FK_Presencia_Alumno_AlumnoId",
                table: "Presencia",
                column: "AlumnoId",
                principalTable: "Alumno",
                principalColumn: "AlumnoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Presencia_Asignatura_AsignaturaId",
                table: "Presencia",
                column: "AsignaturaId",
                principalTable: "Asignatura",
                principalColumn: "AsignaturaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
