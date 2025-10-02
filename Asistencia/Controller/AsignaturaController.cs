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
    public class AsignaturaController
    {
        private readonly AsistenciaContext _context;
        public AsignaturaController()
        {
            _context = new AsistenciaContext();
        }

        public Asignatura ObtenerAsignaturaPorId(int id)
        {
            return _context.Asignatura.Find(id);
        }
        
        public Asignatura ObtenerAsignaturaPorNombre(String nombre)
        {
            return _context.Asignatura.FirstOrDefault(a => a.Nombre == nombre);
        }
        public List<Asignatura> ObtenerTodaslasAsignatura()
        {
            return _context.Asignatura
               .Include(a => a.Profesor)
               .Include(a => a.Grado_Asignaturas)
               .ToList();

        }

        public string agregarAsignatura(Asignatura asignatura)
        {
            try
            {
                _context.Asignatura.Add(asignatura);
                _context.SaveChanges();
                return "La asignatura a sido agregado con exito";

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
        public string ActualizarAsignatura(Asignatura asignatura)
        {
            var AsignaturaExistente = _context.Asignatura.Find(asignatura.AsignaturaId);
            if (AsignaturaExistente != null)
            {
                try
                {
                    AsignaturaExistente.Nombre = asignatura.Nombre;
                    AsignaturaExistente.ProfesorId = asignatura.ProfesorId;
                    _context.SaveChanges();
                    return "La asignatura ha sido ACtualizado....";
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
            return "La asignatura no ha sido registrado...";
        }
        public string EliminarAsignatura(int id)
        {
            var asignatura = _context.Asignatura.Find(id);
            if (asignatura != null)
            {
                try
                {
                    _context.Asignatura.Remove(asignatura);
                    _context.SaveChanges();
                    return "La asignatura a sido eliminado correctamente";
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
            return "Error la Asignatura no ha sido registrado...";
        }
        public string AsignarProfesor(int asignaturaId, int profesorId)
        {
            var asignatura = _context.Asignatura.Find(asignaturaId);
            if (asignatura != null)
            {
                asignatura.ProfesorId = profesorId;
                _context.SaveChanges();
                return "Asignatura vinculada al profesor";
            }
            return "No se encontró la asignatura";
        }
        public List<Asignatura> ObtenerAsignaturasPorProfesor(int profesorId)
        {
            return _context.Asignatura
                           .Where(a => a.ProfesorId == profesorId)
                           .ToList();
        }
        public void EliminarAsignaturasPorProfesor(int profesorId)
        {
            var asignaturas = _context.Asignatura
                                      .Where(a => a.ProfesorId == profesorId)
                                      .ToList();

            foreach (var asignatura in asignaturas)
            {
                asignatura.ProfesorId = null; 
            }

            _context.SaveChanges();
        }



    }
}
