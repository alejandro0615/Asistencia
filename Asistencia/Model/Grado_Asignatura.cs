using Asistencia.Model;

public class Grado_Asignatura
{
    public int Grado_AsignaturaId { get; set; }

    public int GradoId { get; set; }

    public int AsignaturaId { get; set; }
    
    public virtual Asignatura Asignatura { get; set; }
    
    public virtual Grado Grado { get; set; }
}
