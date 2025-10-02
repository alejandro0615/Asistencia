using Asistencia.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Controller
{
    public class AsistenciaController
    {
        private readonly AsistenciaContext _context;
        public AsistenciaController()
        {
            _context = new AsistenciaContext();
        }

        public Presencia ObtenerAsistenciaPorId(int id)
        {
            return _context.Presencia.Find(id);
        }
        public Presencia ObtenerAsistenciaPorAlumno(int AlumnoId)
        {
            return _context.Presencia.FirstOrDefault(a => a.AlumnoId == AlumnoId);
        }

        public string agregarAsistencia(Presencia presencia)
        {
            try
            {
                _context.Presencia.Add(presencia);
                _context.SaveChanges();
                return "La asistencia a sido registrada con exito";

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
        public string ActualizarAsistencia(Presencia presencia)
        {
            var AsistenciaExistente = _context.Presencia.Find(presencia.PresenciaId);
            if (AsistenciaExistente != null)
            {
                try
                {
                    AsistenciaExistente.Fecha_Asistencia = presencia.Fecha_Asistencia;
                    AsistenciaExistente.estado_alumno = presencia.estado_alumno;
                    AsistenciaExistente.AlumnoId = presencia.AlumnoId;
                    AsistenciaExistente.AsignaturaId = presencia.AsignaturaId;
                    _context.SaveChanges();
                    return "La asistencia ha sido Actualizado....";
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
            return "La asistencia no ha sido registrado...";
        }
        public string EliminarAsistencia(int id)
        {
            var asistencia = _context.Presencia.Find(id);
            if (asistencia != null)
            {
                try
                {
                    _context.Presencia.Remove(asistencia);
                    _context.SaveChanges();
                    return "La asistencia a sido eliminada correctamente";
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
            return "Error la Asistencia no ha sido registrado...";
        }
    }
}
