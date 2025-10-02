using Asistencia.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Controller
{
    public class AlumnoController
    {
        private readonly AsistenciaContext _context;
        public AlumnoController()
        {
            _context = new AsistenciaContext();
        }

        public Alumno ObtenerAlumnoPorId(int id)
        {
            return _context.Alumno.Find(id);
        }
        public Alumno ObtenerAlumnoPorNombreAp(String nombre, string apellido)
        {
            return _context.Alumno.FirstOrDefault(a => a.Nombre == nombre && a.Apellido == apellido);
        }

        public List<Alumno> ObtenerTodoslosAlumnos()
        {
            return _context.Alumno
                           .Include(a => a.Grado)
                           .ToList();
        }

        public Alumno ObtenerAlumnoPorDocumento(string doc)
        {
            return _context.Alumno.FirstOrDefault(a => a.Documento == doc);
        }

        public string agregarAlumno(Alumno alumno)
        {
            try
            {
                _context.Alumno.Add(alumno);
                _context.SaveChanges();
                return "el alumno a sido agregado con exito";

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
        public string ActualizarAlumno(Alumno alumno)
        {
            var AlumnoExistente = _context.Alumno.Find(alumno.AlumnoId);
            if (AlumnoExistente != null)
            {
                try
                {
                    AlumnoExistente.Nombre = alumno.Nombre;
                    AlumnoExistente.Apellido = alumno.Apellido;
                    AlumnoExistente.Documento = alumno.Documento;
                    AlumnoExistente.Tipo_Documento = alumno.Tipo_Documento;
                    AlumnoExistente.Fecha_nacimiento = alumno.Fecha_nacimiento;
                    AlumnoExistente.Telefono = alumno.Telefono;
                    AlumnoExistente.GradoId = alumno.GradoId;
                    _context.SaveChanges();
                    return "El Alumno ha sido Actualizado....";
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
            return "el alumno no ha sido registrado...";
        }
        public string EliminarAlumno(int id)
        {
            var alumno = _context.Alumno
                          .Include(a => a.Acudientes) 
                          .FirstOrDefault(a => a.AlumnoId == id);
            if (alumno != null)
            {
                try
                {
                    if (alumno.Acudientes != null && alumno.Acudientes.Any())
                    {
                        return " No se puede eliminar el Alumno porque tiene un Acudiente vinculado.";
                    }
                    _context.Alumno.Remove(alumno);
                    _context.SaveChanges();
                    return "el Alumno a sido eliminado correctamente";
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
            return "Error el Alumno no ha sido registrado...";
        }
    }
}
