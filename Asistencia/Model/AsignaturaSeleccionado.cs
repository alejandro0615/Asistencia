using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda2998601.Model
{
    public class AsignaturaSeleccionado
    {
        public int AsignaturaId { get; set; }
        public string Nombre { get; set; }

        public int ProfesorId { get; set; }   
        public int GradoId { get; set; }      
    }
}
