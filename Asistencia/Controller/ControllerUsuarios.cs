using Asistencia.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tienda2998601.Model;

namespace tienda2998601.Controller
{
    public class ControllerUsuarios
    {
        private readonly AsistenciaContext _context;

        public ControllerUsuarios()
        {
            _context = new AsistenciaContext();
        }

        public bool ValidarIngreso(string usuario, string pass)
        {
            try
            {
                Usuario usu = _context.Usuarios
                    .FirstOrDefault(u => u.usuario == usuario && u.pass == pass);

                return usu != null; 
            }
            catch
            {
                return false;
            }
        }

    }
}
