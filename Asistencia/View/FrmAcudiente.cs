using Asistencia.Controller;
using Asistencia.Model;
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
    public partial class FrmAcudiente : Form
    {
        List<Alumno> lstAlumno = new List<Alumno>();
        AlumnoController controllerAlumnos = new AlumnoController();
        public FrmAcudiente()
        {
            InitializeComponent();
            CargarAlumnos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarAcudiente();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarAcudiente();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ModificarAcudiente();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarAcudiente();
        }
        private void guardarAcudiente()
        {

            Acudiente nuevoAcudiente = new Acudiente();
            nuevoAcudiente.Nombre = txtNombre.Text;
            nuevoAcudiente.Apellido = txtApellidos.Text;
            if (cbxTipo_Documento.SelectedItem != null)
            {
                nuevoAcudiente.Tipo_Documento = cbxTipo_Documento.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Por favor selecciona un Tipo de Documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            nuevoAcudiente.Documento = txtDocumento.Text;
            nuevoAcudiente.Correo = txtCorreo.Text;
            nuevoAcudiente.telefono = txtTelefono.Text;
            nuevoAcudiente.parentesco = txtParentesco.Text;
            nuevoAcudiente.AlumnoId = ((Alumno)cbxAlumno.SelectedItem).AlumnoId;

            //lo mandamos a la base de datos  
            AcudienteController controller = new AcudienteController();
            string resultado = controller.agregarAcudiente(nuevoAcudiente);
            MessageBox.Show(resultado, "GUARDAR ACUDIENTE");
            Limpiar();
           

        }
        private void BuscarAcudiente()
        {
            AcudienteController controller = new AcudienteController();
            Acudiente acudiente = controller.ObtenerAcudientePorDocumento(txtDocumento.Text);

            if (acudiente == null)
            {
                MessageBox.Show("Acudiente no registrado");
            }
            else
            {
                txtID.Text = acudiente.AcudienteId.ToString();
                txtDocumento.Text = acudiente.Documento;
                cbxTipo_Documento.Text = acudiente.Tipo_Documento;
                txtNombre.Text = acudiente.Nombre;
                txtApellidos.Text = acudiente.Apellido;
                txtCorreo.Text = acudiente.Correo;
                txtTelefono.Text = acudiente.telefono;
                txtParentesco.Text = acudiente.parentesco;
                cbxAlumno.SelectedValue = acudiente.AlumnoId;
            }
        }
        public void ModificarAcudiente()
        {
            Acudiente nuevoAcudiente = new Acudiente
            {
                AcudienteId = int.Parse(txtID.Text),
                Documento = txtDocumento.Text,
                Tipo_Documento = cbxTipo_Documento.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellidos.Text,
                Correo = txtCorreo.Text,
                telefono = txtTelefono.Text,
                parentesco = txtParentesco.Text,
                AlumnoId = Convert.ToInt32(cbxAlumno.SelectedValue)
            };
            AcudienteController controller = new AcudienteController();
            string resultado = controller.ActualizarAcudiente(nuevoAcudiente);
            MessageBox.Show(resultado, "ACUDIENTE ACTUAALIZADO");
            Limpiar();
        }
        public void EliminarAcudiente()
        {
            AcudienteController controller = new AcudienteController();

            DialogResult resultado = MessageBox.Show("¿Esta seguro de eliminar el registro?", "Confirma eliminiacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultado == DialogResult.OK)
            {
                string resul = controller.EliminarAcudiente(int.Parse(txtID.Text));
                MessageBox.Show(resul, "ELIMINAR ACUDIENTE");
            }
            Limpiar();
        }

        private void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtDocumento.Clear();
            txtTelefono.Clear();
            cbxTipo_Documento.SelectedItem = null;  
            txtCorreo.Clear();
            txtParentesco.Clear();

        }
        private void CargarAlumnos()
        {
            lstAlumno = controllerAlumnos.ObtenerTodoslosAlumnos();

            cbxAlumno.DataSource = lstAlumno;
            cbxAlumno.ValueMember = "AlumnoId";
            cbxAlumno.DisplayMember = "Nombre";
            cbxAlumno.Format += (s, e) =>
            {
                if (e.ListItem is Alumno alumno)
                {
                    string nombreGrado = alumno.Grado != null ? alumno.Grado.Nombre : "Sin grado";
                    e.Value = $"{alumno.Nombre} {alumno.Apellido} - {nombreGrado}";
                }
            };
            cbxAlumno.SelectedIndex = -1;
        }


        private void cbxAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
