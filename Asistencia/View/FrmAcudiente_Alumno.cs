using Asistencia.Controller;
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
    public partial class FrmAcudiente_Alumno : Form
    {
        public FrmAcudiente_Alumno()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarAcudiente();
        }
        private void BuscarAcudiente()
        {
            string documento = txtDocumento.Text.Trim();

            if (string.IsNullOrEmpty(documento))
            {
                MessageBox.Show("Ingrese el documento del alumno");
                return;
            }

            string mensaje;
            AcudienteController controller = new AcudienteController();
            var acudiente = controller.ObtenerAcudientePorDocumentoAlumno(documento, out mensaje);

            if (acudiente != null)
            {
                txtAcudiente.Text = $"{acudiente.Nombre} {acudiente.Apellido} - Tel: {acudiente.telefono}";
            }
            else
            {
                txtAcudiente.Text = "No se encontró acudiente para este alumno";
            }

            MessageBox.Show(mensaje);
        }



    }
}
