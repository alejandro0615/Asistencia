using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Model
{
    public class Profesor
    {
        public int ProfesorId { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo puede tener letras")]
        public string Nombres { get; set; }

        
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El Apellido solo puede tener letras")]
        public string Apellidos { get; set; }


        [Required]
        [StringLength(10)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El documento debe tener 10 dígitos")]
        public string Documento { get; set; }


        [Required]
        [StringLength(30)]
        public string Tipo_Documento { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener 10 dígitos")]
        public string Telefono { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Correo no válido")]
        public string Correo { get; set; }

        public ICollection<Asignatura>Asignatura { get; set; }
        public string NombreCompleto
        {
            get { return $"{Nombres} {Apellidos}"; }
        }

    }
}
