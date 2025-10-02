using Asistencia.Controller;
using Asistencia.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asistencia.View
{
    public partial class FrmAsistencia : Form
    {
        List<Grado> lstGrado = new List<Grado>();
        List<Profesor> lstProfesor = new List<Profesor>();
        ProfesorController controllerProfesor = new ProfesorController();
        GradoController controllerGrados = new GradoController();
        public FrmAsistencia()
        {
            InitializeComponent();
            ConfigurarGrid();
            CargarGrados();
            CargarProfesores();
            CargarAsignaturas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuscarAistencia();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ModificarAsistencia();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EliminarAsistencia();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            int gradoId = Convert.ToInt32(cbxGrado.SelectedValue);
            int asignaturaId = Convert.ToInt32(cbxAsignatura.SelectedValue);
            DateTime fecha = dateTimePicker1.Value;

            CargarEstudiantes(gradoId, asignaturaId, fecha);
        }
        private void Guardar() 
        {
            int gradoId = Convert.ToInt32(cbxGrado.SelectedValue);
            int asignaturaId = Convert.ToInt32(cbxAsignatura.SelectedValue);
            DateTime fecha = dateTimePicker1.Value;
            GuardarAsistencia(gradoId, asignaturaId, fecha);
        }
        



        private void GuardarAsistencia(int gradoId, int asignaturaId, DateTime fecha)
            {
                using (var context = new AsistenciaContext())
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Id"].Value == null) continue;

                        int estudianteId = (int)row.Cells["Id"].Value;
                        bool asistio = Convert.ToBoolean(row.Cells["Asistio"].Value);

                        var asistencia = new Presencia
                        {
                            AlumnoId = estudianteId,
                            AsignaturaId = asignaturaId,
                            GradoId = gradoId,
                            Fecha_Asistencia = fecha,
                            estado_alumno = asistio
                        };

                        context.Presencia.Add(asistencia);
                    }

                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Asistencia guardada correctamente ");
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"Error al guardar: {ex.InnerException?.Message}");
                }
            }

                MessageBox.Show("Asistencia guardada correctamente ");
            }
        private void BuscarAistencia()
        {
            int gradoId = Convert.ToInt32(cbxGrado.SelectedValue);
            int asignaturaId = Convert.ToInt32(cbxAsignatura.SelectedValue);
            DateTime fecha = dateTimePicker1.Value;

            using (var context = new AsistenciaContext())
            {
                var asistencias = context.Presencia
                    .Include(p => p.Alumnos)
                    .Where(p => p.GradoId == gradoId
                             && p.AsignaturaId == asignaturaId
                             && p.Fecha_Asistencia.Date == fecha.Date)
                    .ToList();

                dataGridView1.Rows.Clear();

                foreach (var a in asistencias)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowIndex].Cells["Id"].Value = a.PresenciaId;
                    dataGridView1.Rows[rowIndex].Cells["Nombre"].Value = a.Alumnos.Nombre;
                    dataGridView1.Rows[rowIndex].Cells["Apellido"].Value = a.Alumnos.Apellido;
                    dataGridView1.Rows[rowIndex].Cells["Asistio"].Value = a.estado_alumno;
                    dataGridView1.Rows[rowIndex].Cells["NoAsistio"].Value = !a.estado_alumno; 
                }
            }
        }
        private void ModificarAsistencia()
        {
            using (var context = new AsistenciaContext())
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Id"].Value == null) continue;

                    int presenciaId = Convert.ToInt32(row.Cells["Id"].Value);
                    bool asistio = Convert.ToBoolean(row.Cells["Asistio"].Value);

                    var asistencia = context.Presencia.Find(presenciaId);
                    if (asistencia != null)
                    {
                        asistencia.estado_alumno = asistio;
                    }
                }

                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Asistencias modificadas correctamente ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar: " + ex.Message);
                }
            }
        }
        private void EliminarAsistencia()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un registro para eliminar.");
                return;
            }

            int presenciaId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

            using (var context = new AsistenciaContext())
            {
                var asistencia = context.Presencia.Find(presenciaId);
                if (asistencia != null)
                {
                    context.Presencia.Remove(asistencia);
                    context.SaveChanges();
                    MessageBox.Show("Asistencia eliminada correctamente ");

                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
                else
                {
                    MessageBox.Show("No se encontró el registro seleccionado ❌");
                }
            }
        }

        private void CargarEstudiantes(int gradoId, int asignaturaId, DateTime fecha)
        {
            using (var context = new AsistenciaContext())
            {
                var alumnos = context.Alumno
                    .Where(a => a.GradoId == gradoId)
                    .OrderBy(a => a.Nombre)
                    .ToList();

                dataGridView1.Rows.Clear();

                foreach (var alum in alumnos)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowIndex].Cells["Id"].Value = alum.AlumnoId;
                    dataGridView1.Rows[rowIndex].Cells["Nombre"].Value = alum.Nombre;
                    dataGridView1.Rows[rowIndex].Cells["Apellido"].Value = alum.Apellido;

                    dataGridView1.Rows[rowIndex].Cells["Asistio"].Value = false; 
                }
            }

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show(" No hay alumnos registrados en este grado.");
            }
        }

        private void ConfigurarGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns["Id"].Visible = false;

            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Apellido", "Apellido");

            DataGridViewCheckBoxColumn colAsistencia = new DataGridViewCheckBoxColumn();
            colAsistencia.Name = "Asistio";
            colAsistencia.HeaderText = "Asistió";
            colAsistencia.TrueValue = true;
            colAsistencia.FalseValue = false;
            colAsistencia.ThreeState = false;
            dataGridView1.Columns.Add(colAsistencia);

            
            DataGridViewCheckBoxColumn colNoAsistio = new DataGridViewCheckBoxColumn();
            colNoAsistio.Name = "NoAsistio";
            colNoAsistio.HeaderText = "No asistió";
            colNoAsistio.TrueValue = true;
            colNoAsistio.FalseValue = false;
            colNoAsistio.ThreeState = false;
            dataGridView1.Columns.Add(colNoAsistio);


            dataGridView1.Columns["Id"].ReadOnly = true;
            dataGridView1.Columns["Nombre"].ReadOnly = true;
            dataGridView1.Columns["Asistio"].ReadOnly = false;
            dataGridView1.Columns["NoAsistio"].ReadOnly = false;


            
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        }
        private void CargarGrados()
        {
            lstGrado = controllerGrados.ObtenerTodoslosGrados();

            cbxGrado.DataSource = lstGrado;
            cbxGrado.DisplayMember = "Nombre";
            cbxGrado.ValueMember = "GradoId";
            cbxGrado.SelectedIndex = -1;
        }
        private void CargarProfesores()
        {
            lstProfesor = controllerProfesor.ObtenerTodoslosProfesores();
            cbxProfesor.DataSource = lstProfesor;
            cbxProfesor.DisplayMember = "NombreCompleto";
            cbxProfesor.ValueMember = "ProfesorId";
            cbxProfesor.SelectedIndex = -1;
        }
        private void CargarAsignaturas()
        {
            var asignaturaController = new AsignaturaController();  
            var asignaturas = asignaturaController.ObtenerTodaslasAsignatura();

            cbxAsignatura.DataSource = asignaturas;
            cbxAsignatura.DisplayMember = "Nombre";
            cbxAsignatura.ValueMember = "AsignaturaId";
            cbxAsignatura.SelectedIndex = -1;
        }

        private void cbxAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbxProfesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProfesor.SelectedValue != null && cbxProfesor.SelectedValue is int)
            {
                int maestroId = Convert.ToInt32(cbxProfesor.SelectedValue);

                using (var db = new AsistenciaContext())
                {
                    var asignaturas = db.Asignatura
                                        .Where(a => a.ProfesorId == maestroId)
                                        .ToList();

                    cbxAsignatura.DataSource = asignaturas;
                    cbxAsignatura.DisplayMember = "Nombre";
                    cbxAsignatura.ValueMember = "AsignaturaId";
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
