using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asistencia.Model
{
    public class Asignatura
    {
        public int AsignaturaId { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo puede tener letras")]
        public string Nombre { get; set; }


        [Required]
        public int ? ProfesorId { get; set; }

        public virtual Profesor Profesor { get; set; }

        public virtual ICollection<Grado_Asignatura> Grado_Asignaturas { get; set; }
    }
}
