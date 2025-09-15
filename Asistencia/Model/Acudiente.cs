using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Model
{
    public class Acudiente
    {
        public int AcudienteId { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Documento { get; set; }

        public string Tipo_Documento { get; set; }

        public string telefono { get; set; }
        public string Correo { get; set; }

        public string parentesco { get; set; }

        public int Alumno_id { get; set; }

        //public virtual ICollection<Alumno> Alumnos { get; set; }
    }
}
