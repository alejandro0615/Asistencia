using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda2998601.Model
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        public string usuario { get; set; }

        [Required]
        public string pass { get; set; }
    }
}
