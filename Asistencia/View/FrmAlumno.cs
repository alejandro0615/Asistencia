using Asistencia.Controller;
using Asistencia.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asistencia.View
{
    public partial class FrmAlumno : Form
    {
        List<Grado> lstGrado = new List<Grado>();
        GradoController controllerGrados = new GradoController();
        public FrmAlumno()
        {
            InitializeComponent();
            CargarGrados();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarAlumno();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarAlumno();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarAlumno();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarAlumno();
        }
        private void guardarAlumno()
        {
            Alumno nuevoAlumno = new Alumno();
            nuevoAlumno.Nombre = txtNombre.Text;
            nuevoAlumno.Apellido = txtApellido.Text;

            if (cbxTipo_Documento.SelectedItem != null)
            {
                nuevoAlumno.Tipo_Documento = cbxTipo_Documento.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Por favor selecciona un Tipo de Documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            nuevoAlumno.Documento = txtDocumento.Text;
            nuevoAlumno.Fecha_nacimiento = dtpFecha_nacimiento.Value;
            nuevoAlumno.Telefono = txtTelefono.Text;
            nuevoAlumno.GradoId = ((Grado)cbxGrado.SelectedItem).GradoId;

            var context = new ValidationContext(nuevoAlumno, null, null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(nuevoAlumno, context, results, true))
            {
                // Si no pasa la validación mostramos los errores y salimos
                string errores = string.Join("\n", results.Select(r => r.ErrorMessage));
                MessageBox.Show(errores, "Errores de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si pasa la validación, lo mandamos a la base de datos
            AlumnoController controller = new AlumnoController();
            string resultado = controller.agregarAlumno(nuevoAlumno);
            MessageBox.Show(resultado, "GUARDAR ALUMNO");
            Limpiar();
        }

        private void BuscarAlumno()
        {
            AlumnoController controller = new AlumnoController();
            Alumno alumno = controller.ObtenerAlumnoPorDocumento(txtDocumento.Text);

            if (alumno == null)
            {
                MessageBox.Show("Alumno no registrado");
                Limpiar();
            }
            else
            {
                txtID.Text = alumno.AlumnoId.ToString();
                txtDocumento.Text = alumno.Documento;
                cbxTipo_Documento.Text = alumno.Tipo_Documento;
                txtNombre.Text = alumno.Nombre;
                txtApellido.Text = alumno.Apellido;
                txtTelefono.Text = alumno.Telefono;
                dtpFecha_nacimiento.Value = alumno.Fecha_nacimiento;
                cbxGrado.SelectedValue = alumno.GradoId;

                // 👉 Calcular asistencias totales
                using (var context = new AsistenciaContext())
                {
                    var asistenciasAlumno = context.Presencia
                        .Where(p => p.AlumnoId == alumno.AlumnoId)
                        .ToList();

                    int totalAsistencias = asistenciasAlumno.Count(p => p.estado_alumno);
                    int totalInasistencias = asistenciasAlumno.Count(p => !p.estado_alumno);
                    
                    txtAsistencia.Text = totalAsistencias.ToString();
                    txtInasistencia.Text = totalInasistencias.ToString();
                    
                }
            }
        }

        public void ModificarAlumno()
        {
            Alumno nuevoAlumno = new Alumno
            {
                AlumnoId = int.Parse(txtID.Text),
                Documento = txtDocumento.Text,
                Tipo_Documento = cbxTipo_Documento.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Fecha_nacimiento = dtpFecha_nacimiento.Value,
                GradoId = Convert.ToInt32(cbxGrado.SelectedValue)
            };
            var context = new ValidationContext(nuevoAlumno, null, null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(nuevoAlumno, context, results, true))
            {
                // Si no pasa la validación mostramos los errores y salimos
                string errores = string.Join("\n", results.Select(r => r.ErrorMessage));
                MessageBox.Show(errores, "Errores de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AlumnoController controller = new AlumnoController();
            string resultado = controller.ActualizarAlumno(nuevoAlumno);
            MessageBox.Show(resultado, "ALUMNO ACTUALIZADO");
            Limpiar();
        }
        public void EliminarAlumno()
        {
            AlumnoController controller = new AlumnoController();

            DialogResult resultado = MessageBox.Show("¿Esta seguro de eliminar el registro?", "Confirma eliminiacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultado == DialogResult.OK)
            {
                string resul = controller.EliminarAlumno(int.Parse(txtID.Text));
                MessageBox.Show(resul, "ELIMINAR ALUMNO");
            }
            Limpiar();
        }

        private void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDocumento.Clear();
            txtTelefono.Clear();
            cbxTipo_Documento.SelectedItem = null;
            cbxGrado.SelectedItem = null;
            dtpFecha_nacimiento.Value = DateTime.Now;
        }
        private void CargarGrados()
        {
            lstGrado = controllerGrados.ObtenerTodoslosGrados();

            cbxGrado.DataSource = lstGrado;
            cbxGrado.DisplayMember = "Nombre";   
            cbxGrado.ValueMember = "GradoId";    
            cbxGrado.SelectedIndex = -1;         
        }

        private void cbxGrado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAsistencia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
