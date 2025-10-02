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
    public partial class FrmHistorial : Form
    {
        public FrmHistorial()
        {
            
            InitializeComponent();
            ConfigurarGrid();

        }
        private void ConfigurarGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Apellido", "Apellido");
            dataGridView1.Columns.Add("Fecha", "Fecha");
            dataGridView1.Columns.Add("Asignatura", "Asignatura");

            DataGridViewCheckBoxColumn colAsistio = new DataGridViewCheckBoxColumn();
            colAsistio.Name = "Asistio";
            colAsistio.HeaderText = "Asistió";
            dataGridView1.Columns.Add(colAsistio);

            DataGridViewCheckBoxColumn colNoAsistio = new DataGridViewCheckBoxColumn();
            colNoAsistio.Name = "NoAsistio";
            colNoAsistio.HeaderText = "No asistió";
            dataGridView1.Columns.Add(colNoAsistio);
        }
        private void BuscarHistorialPorDocumento(string documento)
        {
            using (var context = new AsistenciaContext())
            {
                var alumno = context.Alumno.FirstOrDefault(a => a.Documento == documento);
                if (alumno == null)
                {
                    MessageBox.Show("Alumno no encontrado");
                    return;
                }

                var historial = context.Presencia
                    .Include(p => p.Asignaturas)
                    .Where(p => p.AlumnoId == alumno.AlumnoId)
                    .OrderBy(p => p.Fecha_Asistencia)
                    .ToList();

                dataGridView1.Rows.Clear();

                foreach (var reg in historial)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowIndex].Cells["Nombre"].Value = alumno.Nombre;
                    dataGridView1.Rows[rowIndex].Cells["Apellido"].Value = alumno.Apellido;
                    dataGridView1.Rows[rowIndex].Cells["Fecha"].Value = reg.Fecha_Asistencia.ToShortDateString();
                    dataGridView1.Rows[rowIndex].Cells["Asignatura"].Value = reg.Asignaturas.Nombre;
                    dataGridView1.Rows[rowIndex].Cells["Asistio"].Value = reg.estado_alumno;
                    dataGridView1.Rows[rowIndex].Cells["NoAsistio"].Value = !reg.estado_alumno;
                }

                if (historial.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros de asistencia para este alumno.");
                }
            }
        }
        private void BuscarHistorial() 
        {
            string documento = txtDocumento.Text.Trim();
            if (string.IsNullOrEmpty(documento))
            {
                MessageBox.Show("Ingresa un documento válido");
                return;
            }

            BuscarHistorialPorDocumento(documento);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarHistorial();
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmHistorial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
                MessageBox.Show("Solo se permiten números en el documento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números en el documento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

}
