using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Model
{
    public class Alumno
    {
        public int AlumnoId { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo puede tener letras")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El apellido solo puede tener letras")]
        public string Apellido { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El documento debe tener 10 dígitos")]

        public string Documento{ get; set; }

        [Required]
        [StringLength(20)]
        public string Tipo_Documento { get; set; }


        [Required]
        public DateTime Fecha_nacimiento { get; set; }

        [Required]
        [StringLength(12)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener 10 dígitos")]
        public string Telefono { get; set; }


        public int GradoId { get; set; }


        public List<Acudiente> Acudientes { get; set; }


        public virtual ICollection<Presencia> Presencia { get; set; }

        public virtual Grado Grado { get; set; }
    }
}
