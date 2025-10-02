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
    public partial class FrmAsignatura : Form
    {

        List<Profesor> lstProfesor = new List<Profesor>();
        ProfesorController controllerProfesor = new ProfesorController();
        public FrmAsignatura()
        {
            InitializeComponent();
            CargarProfesores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardarAsignatura(); 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarAsignatura();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarAsignatura();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarAsignatura();
        }
        private void guardarAsignatura()
        {

            Asignatura nuevaAsignatura = new Asignatura();
            nuevaAsignatura.Nombre = txtNombre.Text;
            nuevaAsignatura.ProfesorId = ((Profesor)cbxProfesor.SelectedItem).ProfesorId;

            var context = new ValidationContext(nuevaAsignatura, null, null);
            var results = new List<ValidationResult>();

            //aca validamos el objeto que este cumpliendo con las especificaciones que le pusimos en el modelo con las expresiones regulares
            if (!Validator.TryValidateObject(nuevaAsignatura, context, results, true))
            {
                // Si no pasa la validación mostramos los errores y salimos
                string errores = string.Join("\n", results.Select(r => r.ErrorMessage));
                MessageBox.Show(errores, "Errores de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //lo mandamos a la base de datos  
            AsignaturaController controller = new AsignaturaController();
            string resultado = controller.agregarAsignatura(nuevaAsignatura);
            MessageBox.Show(resultado, "GUARDAR ASIGNATURA");
            Limpiar();
        }
        private void BuscarAsignatura()
        {
            AsignaturaController controller = new AsignaturaController();
            Asignatura asignatura = controller.ObtenerAsignaturaPorNombre(txtNombre.Text);

            if (asignatura == null)
            {
                MessageBox.Show("Asignatura no registrado");
            }
            else
            {
                txtID.Text = asignatura.AsignaturaId.ToString();
                txtNombre.Text = asignatura.Nombre;
                cbxProfesor.SelectedValue = asignatura.ProfesorId;
            }
        }
        public void ModificarAsignatura()
        {
            Asignatura nuevaAsignatura = new Asignatura
            {
                AsignaturaId = int.Parse(txtID.Text),
                Nombre = txtNombre.Text,
                ProfesorId = Convert.ToInt32(cbxProfesor.SelectedValue)
            };
            var context = new ValidationContext(nuevaAsignatura, null, null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(nuevaAsignatura, context, results, true))
            {
                // Si no pasa la validación mostramos los errores y salimos
                string errores = string.Join("\n", results.Select(r => r.ErrorMessage));
                MessageBox.Show(errores, "Errores de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AsignaturaController controller = new AsignaturaController();
            string resultado = controller.ActualizarAsignatura(nuevaAsignatura);
            MessageBox.Show(resultado, "ASIGNATURA ACTUALIZADO");
            Limpiar();
        }
        public void EliminarAsignatura()
        {
            AsignaturaController controller = new AsignaturaController();

            DialogResult resultado = MessageBox.Show("¿Esta seguro de eliminar el registro?", "Confirma eliminiacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultado == DialogResult.OK)
            {
                string resul = controller.EliminarAsignatura(int.Parse(txtID.Text));
                MessageBox.Show(resul, "ELIMINAR ASIGNATURA");
            }
            Limpiar();
        }

        private void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            cbxProfesor.SelectedItem = null;
            
        }
        private void CargarProfesores()
        {
            lstProfesor = controllerProfesor.ObtenerTodoslosProfesores();
            cbxProfesor.DataSource = lstProfesor;
            cbxProfesor.DisplayMember = "NombreCompleto";
            cbxProfesor.ValueMember = "ProfesorId";
            cbxProfesor.SelectedIndex = -1;
        }
        private void cbxProfesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
