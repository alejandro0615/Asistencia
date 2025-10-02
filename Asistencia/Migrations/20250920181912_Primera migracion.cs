using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asistencia.Migrations
{
    public partial class Primeramigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grado",
                columns: table => new
                {
                    GradoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grado", x => x.GradoId);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    ProfesorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 50, nullable: false),
                    Documento = table.Column<string>(maxLength: 10, nullable: false),
                    Tipo_Documento = table.Column<string>(maxLength: 12, nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Correo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.ProfesorId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario = table.Column<string>(nullable: false),
                    pass = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    AlumnoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(maxLength: 20, nullable: false),
                    Documento = table.Column<string>(maxLength: 10, nullable: false),
                    Tipo_Documento = table.Column<string>(maxLength: 20, nullable: false),
                    Fecha_nacimiento = table.Column<DateTime>(nullable: false),
                    Telefono = table.Column<string>(maxLength: 12, nullable: false),
                    GradoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.AlumnoId);
                    table.ForeignKey(
                        name: "FK_Alumno_Grado_GradoId",
                        column: x => x.GradoId,
                        principalTable: "Grado",
                        principalColumn: "GradoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    AsignaturaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    ProfesorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.AsignaturaId);
                    table.ForeignKey(
                        name: "FK_Asignatura_Profesor_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesor",
                        principalColumn: "ProfesorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acudiente",
                columns: table => new
                {
                    AcudienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(maxLength: 50, nullable: false),
                    Documento = table.Column<string>(maxLength: 50, nullable: false),
                    Tipo_Documento = table.Column<string>(maxLength: 50, nullable: false),
                    telefono = table.Column<string>(maxLength: 50, nullable: false),
                    Correo = table.Column<string>(maxLength: 50, nullable: false),
                    parentesco = table.Column<string>(maxLength: 50, nullable: false),
                    AlumnoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acudiente", x => x.AcudienteId);
                    table.ForeignKey(
                        name: "FK_Acudiente_Alumno_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumno",
                        principalColumn: "AlumnoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grado_Asignatura",
                columns: table => new
                {
                    Grado_AsignaturaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradoId = table.Column<int>(nullable: false),
                    AsignaturaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grado_Asignatura", x => x.Grado_AsignaturaId);
                    table.ForeignKey(
                        name: "FK_Grado_Asignatura_Asignatura_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalTable: "Asignatura",
                        principalColumn: "AsignaturaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grado_Asignatura_Grado_GradoId",
                        column: x => x.GradoId,
                        principalTable: "Grado",
                        principalColumn: "GradoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Presencia",
                columns: table => new
                {
                    PresenciaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Asistencia = table.Column<DateTime>(nullable: false),
                    estado_alumno = table.Column<string>(maxLength: 10, nullable: false),
                    AlumnoId = table.Column<int>(nullable: false),
                    AsignaturaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presencia", x => x.PresenciaId);
                    table.ForeignKey(
                        name: "FK_Presencia_Alumno_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumno",
                        principalColumn: "AlumnoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Presencia_Asignatura_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalTable: "Asignatura",
                        principalColumn: "AsignaturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acudiente_AlumnoId",
                table: "Acudiente",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Acudiente_Correo",
                table: "Acudiente",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acudiente_Documento",
                table: "Acudiente",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acudiente_telefono",
                table: "Acudiente",
                column: "telefono",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_Documento",
                table: "Alumno",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_GradoId",
                table: "Alumno",
                column: "GradoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_Telefono",
                table: "Alumno",
                column: "Telefono",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_ProfesorId",
                table: "Asignatura",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Grado_Nombre",
                table: "Grado",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grado_Asignatura_AsignaturaId",
                table: "Grado_Asignatura",
                column: "AsignaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Grado_Asignatura_GradoId",
                table: "Grado_Asignatura",
                column: "GradoId");

            migrationBuilder.CreateIndex(
                name: "IX_Presencia_AlumnoId",
                table: "Presencia",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Presencia_AsignaturaId",
                table: "Presencia",
                column: "AsignaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_Correo",
                table: "Profesor",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_Documento",
                table: "Profesor",
                column: "Documento",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acudiente");

            migrationBuilder.DropTable(
                name: "Grado_Asignatura");

            migrationBuilder.DropTable(
                name: "Presencia");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "Asignatura");

            migrationBuilder.DropTable(
                name: "Grado");

            migrationBuilder.DropTable(
                name: "Profesor");
        }
    }
}
