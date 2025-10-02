using Asistencia.Controller;
using Asistencia.Model;
using Microsoft.EntityFrameworkCore;
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
using tienda2998601.Model;

namespace Asistencia.View
{
    public partial class FrmProfesor : Form
    {
        List<AsignaturaController> lstAsignatura = new List<AsignaturaController>();
        List<AsignaturaSeleccionado> lstAsignaturaSeleccionada = new List<AsignaturaSeleccionado>();


        public FrmProfesor()
        {
            InitializeComponent();
            CargarAsignaturas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardarProfesores();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuscarProfesor();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModificarProfesor();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EliminarProfesor();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AsignarAsignatura();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }
        private void guardarProfesores()
        {

            Profesor nuevoProfesor = new Profesor
            {
                Nombres = txtNombre.Text,
                Apellidos = txtApellido.Text,
                Documento = txtDocumento.Text,
                Tipo_Documento = cbxTipo_documento.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text
            };

            ProfesorController controller = new ProfesorController();
            string resultado = controller.agregarProfesor(nuevoProfesor);

            if (resultado.Contains("correctamente"))
            {
                
                var asignaturaController = new AsignaturaController();

                foreach (var a in lstAsignaturaSeleccionada)
                {
                    var asignatura = new Asignatura
                    {
                        AsignaturaId = a.AsignaturaId, 
                        ProfesorId = nuevoProfesor.ProfesorId
                    };

                    asignaturaController.AsignarProfesor(asignatura.AsignaturaId, nuevoProfesor.ProfesorId);
                }
            }
            var context = new ValidationContext(nuevoProfesor, null, null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(nuevoProfesor, context, results, true))
            {
                // Si no pasa la validación mostramos los errores y salimos
                string errores = string.Join("\n", results.Select(r => r.ErrorMessage));
                MessageBox.Show(errores, "Errores de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Profesor y asignaturas guardados correctamente");
            Limpiar();
        }
        private void BuscarProfesor()
        {
            ProfesorController controller = new ProfesorController();
            Profesor profesor = controller.ObtenerProfesorPorDocumento(txtDocumento.Text);

            if (profesor != null)
            {
                txtID.Text = profesor.ProfesorId.ToString();
                txtNombre.Text = profesor.Nombres;
                txtApellido.Text = profesor.Apellidos;
                txtDocumento.Text = profesor.Documento;
                txtCorreo.Text = profesor.Correo;
                txtTelefono.Text = profesor.Telefono;
                cbxTipo_documento.Text = profesor.Tipo_Documento;

                var asignaturaController = new AsignaturaController();
                var asignaturasProfesor = asignaturaController.ObtenerAsignaturasPorProfesor(profesor.ProfesorId);

                lstAsignaturaSeleccionada = asignaturasProfesor
                    .Select(a => new AsignaturaSeleccionado
                    {
                        AsignaturaId = a.AsignaturaId,
                        Nombre = a.Nombre
                    })
                    .ToList();

                dtgAsignatura.DataSource = null;
                dtgAsignatura.DataSource = lstAsignaturaSeleccionada;
                dtgAsignatura.Columns["ProfesorId"].Visible = false;
                dtgAsignatura.Columns["GradoId"].Visible = false;
            }
            else
            {
                MessageBox.Show("Profesor no registrado");
            }
        }

        public void ModificarProfesor()
        {
            int profesorId = int.Parse(txtID.Text);
            using (var context = new AsistenciaContext())
            {
                var profesor = context.Profesor
                                      .Include(p => p.Asignatura)
                                      .FirstOrDefault(p => p.ProfesorId == profesorId);

                if (profesor == null)
                {
                    MessageBox.Show("Profesor no encontrado.");
                    return;
                }

                // Modificar datos personales
                profesor.Nombres = txtNombre.Text;
                profesor.Apellidos = txtApellido.Text;
                profesor.Documento = txtDocumento.Text;
                profesor.Tipo_Documento = cbxTipo_documento.Text;
                profesor.Correo = txtCorreo.Text;
                profesor.Telefono = txtTelefono.Text;

                profesor.Asignatura.Clear();

                foreach (var a in lstAsignaturaSeleccionada)
                {
                    var asignatura = context.Asignatura.FirstOrDefault(x => x.AsignaturaId == a.AsignaturaId);
                    if (asignatura != null)
                    {
                        profesor.Asignatura.Add(asignatura);
                    }
                }

                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Profesor actualizado correctamente 👍");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el profesor: " + ex.InnerException?.Message ?? ex.Message);
                }
            }
        }
        public void EliminarProfesor()
        {
            ProfesorController controller = new ProfesorController();

            DialogResult resultado = MessageBox.Show("¿Esta seguro de eliminar el registro?", "Confirma eliminiacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultado == DialogResult.OK)
            {
                string resul = controller.EliminarProfesor(int.Parse(txtID.Text));
                MessageBox.Show(resul, "ELIMINAR PROFESOR");
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
            txtCorreo.Clear();
            cbxTipo_documento.SelectedItem = null;
            dtgAsignatura.DataSource = null;
            dtgAsignatura.Rows.Clear();

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
        private void AsignarAsignatura()
        {
            if (cbxAsignatura.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una asignatura");
                return;
            }
            var asignatura = (Asignatura)cbxAsignatura.SelectedItem;
            var existe = lstAsignaturaSeleccionada.FirstOrDefault(a => a.AsignaturaId == asignatura.AsignaturaId);

            if (existe != null)
            {
                MessageBox.Show("Esta asignatura ya está asignada al profesor");
                return;
            }

            lstAsignaturaSeleccionada.Add(new AsignaturaSeleccionado
            
            {
                AsignaturaId = asignatura.AsignaturaId,
                Nombre = asignatura.Nombre
            
            });
            
            dtgAsignatura.DataSource = null;
            dtgAsignatura.DataSource = lstAsignaturaSeleccionada;
        }


       

        private void cbxAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtgAsignatura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
