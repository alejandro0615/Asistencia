using Asistencia.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Controller
{
    public class GradoController
    {
        private readonly AsistenciaContext _context;
        public GradoController()
        {
            _context = new AsistenciaContext();
        }

        public Grado ObtenerGradoPorId(int id)
        {
            return _context.Grado.Find(id);
        }
        public Grado ObtenerGradoPorNombre(String nombre)
        {
            return _context.Grado
            .Include(g => g.Alumno) 
            .FirstOrDefault(g => g.Nombre == nombre);
        }
        public List<Grado> ObtenerTodoslosGrados()
        {
            return _context.Grado.ToList();
        }

        public string agregarGrado(Grado grado)
        {
            try
            {
                _context.Grado.Add(grado);
                _context.SaveChanges();
                return "el Grado a sido agregado con exito";

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
        public string ActualizarGrado(Grado grado)
        {
            var GradoExistente = _context.Grado.Find(grado.GradoId);
            if (GradoExistente != null)
            {
                try
                {
                    GradoExistente.Nombre = grado.Nombre;
                    _context.SaveChanges();
                    return "El Grado ha sido ACtualizado....";
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
            return "el Grado no ha sido registrado...";
        }
        public string EliminarGrado(int id)
        {
            var grado = _context.Grado
                         .Include(a => a.Alumno)
                         .FirstOrDefault(a => a.GradoId == id);
            if (grado != null)
            {
                try
                {
                    if (grado.Alumno != null && grado.Alumno.Any())
                    {
                        return " No se puede eliminar el Alumno porque tiene un Alumnos vinculado.";
                    }
                    _context.Grado.Remove(grado);
                    _context.SaveChanges();
                    return "el Grado a sido eliminado correctamente";
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
            return "Error el Grado no ha sido registrado...";
        }
    }
}
