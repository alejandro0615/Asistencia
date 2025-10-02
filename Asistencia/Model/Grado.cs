using Asistencia.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Grado
{
    public int GradoId { get; set; }

    [Required]
    [StringLength(50)]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo puede tener letras")]
    public string Nombre { get; set; }


    public virtual ICollection<Alumno> Alumno { get; set; }

    // Muchos a muchos
    public virtual ICollection<Grado_Asignatura> Grado_Asignatura { get; set; }

    public int CantidadAlumnos
    {
        get { return Alumno != null ? Alumno.Count : 0; }
    }
}
