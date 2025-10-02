using Asistencia.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Controller
{
    public class AcudienteController
    {
        private readonly AsistenciaContext _context;
        public AcudienteController()
        {
            _context = new AsistenciaContext();
        }

        public Acudiente ObtenerAcudientePorId(int id)
        {
            return _context.Acudiente.Find(id);
        }
        public Acudiente ObtenerAcudientePorNombreAp(String nombre, string apellido)
        {
            return _context.Acudiente.FirstOrDefault(a => a.Nombre == nombre && a.Apellido == apellido);
        }
        public List<Acudiente> ObtenerTodoslosAcudientes()
        {
            return _context.Acudiente.ToList();
        }

        public Acudiente ObtenerAcudientePorDocumento(string doc)
        {
            return _context.Acudiente.FirstOrDefault(a => a.Documento == doc);
        }

        public string agregarAcudiente(Acudiente acudiente)
        {
            try
            {
                _context.Acudiente.Add(acudiente);
                _context.SaveChanges();
                return "el acudiente a sido agregado con exito";

            }
            catch (SqlException ex)
            {
                return $"Error en la base de datos: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Ocurrio un error inesperado: {ex.Message}";
            }
        }
        public string ActualizarAcudiente(Acudiente acudiente)
        {
            var AcudienteExistente = _context.Acudiente.Find(acudiente.AcudienteId);
            if (AcudienteExistente != null)
            {
                try
                {
                    AcudienteExistente.Nombre = acudiente.Nombre;
                    AcudienteExistente.Apellido = acudiente.Apellido;
                    AcudienteExistente.Correo = acudiente.Correo;
                    AcudienteExistente.Documento = acudiente.Documento;
                    AcudienteExistente.Tipo_Documento = acudiente.Tipo_Documento;
                    AcudienteExistente.telefono = acudiente.telefono;
                    AcudienteExistente.parentesco = acudiente.parentesco;
                    AcudienteExistente.AlumnoId = acudiente.AlumnoId;

                    _context.SaveChanges();
                    return "El Acudiente ha sido Actualizado....";
                }
                catch (SqlException ex)
                {
                    return $"Error en la base de datos: {ex.Message}";
                }
                catch (Exception ex)
                {
                    return $"Ocurrio un error inesperado: {(ex.InnerException != null ? ex.InnerException.Message : ex.Message)}";
                }

            }
            return "el acudiente no ha sido registrado...";
        }
        public string EliminarAcudiente(int id)
        {
            var acudiente = _context.Acudiente.Find(id);
            if (acudiente != null)
            {
                try
                {
                    _context.Acudiente.Remove(acudiente);
                    _context.SaveChanges();
                    return "el Acudiente a sido eliminado correctamente";
                }
                catch (SqlException ex)
                {
                    return $"Error en la base de datos: {ex.Message}";
                }
                catch (Exception ex)
                {
                    return $"Ocurrio un error inesperado: {ex.Message}";
                }
            }
            return "Error el Acudiente no ha sido registrado...";
        }
        public Acudiente ObtenerAcudientePorDocumentoAlumno(string documentoAlumno, out string mensaje)
        {
            // Buscar el alumno por documento
            var alumno = _context.Alumno.FirstOrDefault(a => a.Documento == documentoAlumno);
            if (alumno == null)
            {
                mensaje = "No se encontró un alumno con ese documento";
                return null;
            }

            // Buscar el acudiente que está relacionado con ese alumno
            var acudiente = _context.Acudiente.FirstOrDefault(a => a.AlumnoId == alumno.AlumnoId);
            if (acudiente != null)
            {
                mensaje = "Acudiente encontrado";
                return acudiente;
            }
            else
            {
                mensaje = "No se encontró acudiente para este alumno";
                return null;
            }
        }

    }
}
