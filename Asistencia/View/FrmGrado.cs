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
    public partial class FrmGrado : Form
    {
        List<Alumno> lstAlumno = new List<Alumno>();
        AlumnoController controllerAlumno = new AlumnoController();
        public FrmGrado()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarGrado();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarGrado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarGrado();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarGrado();
        }
        private void guardarGrado()
        {

            Grado nuevoGrado = new Grado();
            nuevoGrado.Nombre = txtNombre.Text;
            //aca enviamos el objeto a la base de datos
            GradoController controller = new GradoController();
            string resultado = controller.agregarGrado(nuevoGrado);
            MessageBox.Show(resultado, "GUARDAR GRADO");
            Limpiar();
        }
        private void BuscarGrado()
        {
            GradoController controller = new GradoController();
            Grado grado = controller.ObtenerGradoPorNombre(txtNombre.Text);

            if (grado != null)
            {
                txtID.Text = grado.GradoId.ToString();
                txtNombre.Text = grado.Nombre;
                if (grado.Alumno != null && grado.Alumno.Count > 0)
                {
                    cbxCantidad.DataSource = null;
                    cbxCantidad.DataSource = grado.Alumno.ToList();
                    cbxCantidad.DisplayMember = "Nombre";
                    cbxCantidad.ValueMember = "AlumnoId";
                }
                else
                {
                    cbxCantidad.DataSource = null;
                    MessageBox.Show("Este grado no tiene alumnos vinculados.");
                }
            }
            else
            {
                MessageBox.Show("Grado no registrado");
            }
        }


        public void ModificarGrado()
        {
            Grado nuevoGrado = new Grado
            {
                GradoId = int.Parse(txtID.Text),
                Nombre = txtNombre.Text,
            };
            GradoController controller = new GradoController();
            string resultado = controller.ActualizarGrado(nuevoGrado);
            MessageBox.Show(resultado, "GRADO ACTUALIZADO");
            Limpiar();
        }
        public void EliminarGrado()
        {
            GradoController controller = new GradoController();

            DialogResult resultado = MessageBox.Show("¿Esta seguro de eliminar el registro?", "Confirma eliminiacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultado == DialogResult.OK)
            {
                string resul = controller.EliminarGrado(int.Parse(txtID.Text));
                MessageBox.Show(resul, "ELIMINAR GRADO");
            }
            Limpiar();
        }

        private void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            cbxCantidad.SelectedItem = null;

        }
    }
}
