using Asistencia.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Controller
{
    public class ProfesorController
    {
        private readonly AsistenciaContext _context;
        public ProfesorController()
        {
            _context = new AsistenciaContext();
        }

        public Profesor ObtenerProfesorPorId(int id)
        {
            return _context.Profesor.Find(id);
        }
        public Profesor ObtenerProfesorPorNombre(String nombre)
        {
            return _context.Profesor.FirstOrDefault(a => a.Nombres == nombre);
        }
        public List<Profesor> ObtenerTodoslosProfesores()
        {
            return _context.Profesor.ToList();
        }
        public Profesor ObtenerProfesorPorDocumento(string doc)
        {
            return _context.Profesor.FirstOrDefault(a => a.Documento == doc);
        }

        public string agregarProfesor(Profesor profesor)
        {
            try
            {
                _context.Profesor.Add(profesor);
                _context.SaveChanges();
                return "El profesor a sido agregado con exito";

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
        public string ActualizarProfesor(Profesor profesor)
        {
            var ProfesorExistente = _context.Profesor.Find(profesor.ProfesorId);
            if (ProfesorExistente != null)
            {
                try
                {
                    ProfesorExistente.Nombres = profesor.Nombres;
                    ProfesorExistente.Apellidos = profesor.Apellidos;
                    ProfesorExistente.Documento = profesor.Documento;
                    ProfesorExistente.Tipo_Documento = profesor.Tipo_Documento;
                    ProfesorExistente.Correo = profesor.Correo;
                    _context.SaveChanges();
                    return "El profesor ha sido Actualizado....";
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
            return "Erro el Profesor no ha sido registrado...";
        }
        public string EliminarProfesor(int id)
        {
            var profesor = _context.Profesor.Find(id);
            if (profesor != null)
            {
                try
                {
                    _context.Profesor.Remove(profesor);
                    _context.SaveChanges();
                    return "El profesor a sido eliminado correctamente";
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
            return "Error el profesor no ha sido registrado...";
        }
    }
}
