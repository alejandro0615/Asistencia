using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Model
{
    public class Grado
    {
        public int GradoId { get; set; }


        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }


        [Required]
        public int Cantidad_alumnos { get; set; }

    }
}
