using Asistencia.Model;
using System;

public class Presencia
{
    public int PresenciaId { get; set; }
    public DateTime Fecha_Asistencia { get; set; }
    public bool estado_alumno { get; set; }  
    public int AlumnoId { get; set; }
    public int AsignaturaId { get; set; }
    public int GradoId { get; set; }

    public virtual Alumno Alumnos { get; set; }
    public virtual Asignatura Asignaturas { get; set; }
    public virtual Grado Grados { get; set; } 
}
