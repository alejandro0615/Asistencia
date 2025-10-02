using Asistencia.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asistencia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gESTIONDEACUDIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gstionDeAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //creamos la instancia del formmulario llamandolo 
            FrmAlumno GUIAlumno = new FrmAlumno();

            //asignamos un padre al formulario
            GUIAlumno.MdiParent = this;

            //cargamos o mostramos el formulario  en la vista principal
            GUIAlumno.Show();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true; // <-- convierte Form1 en contenedor MDI
        }

        private void gestionDeAsignaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //creamos la instancia del formmulario llamandolo 
            FrmAsignatura GUIAsignatura = new FrmAsignatura();

            //asignamos un padre al formulario
            GUIAsignatura.MdiParent = this;

            //cargamos o mostramos el formulario  en la vista principal
            GUIAsignatura.Show();
        }

        private void gestionDeAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //creamos la instancia del formmulario llamandolo 
            FrmAsistencia GUIAsistencia = new FrmAsistencia();

            //asignamos un padre al formulario
            GUIAsistencia.MdiParent = this;

            //cargamos o mostramos el formulario  en la vista principal
            GUIAsistencia.Show();
        }

        private void aCUDIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //creamos la instancia del formmulario llamandolo 
            FrmAcudiente GUIAcudiente = new FrmAcudiente();

            //asignamos un padre al formulario
            GUIAcudiente.MdiParent = this;

            //cargamos o mostramos el formulario  en la vista principal
            GUIAcudiente.Show();
        }

        private void pROFESORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //creamos la instancia del formmulario llamandolo 
            FrmProfesor GUIProfesor = new FrmProfesor();

            //asignamos un padre al formulario
            GUIProfesor.MdiParent = this;

            //cargamos o mostramos el formulario  en la vista principal
            GUIProfesor.Show();
        }

        private void gRADOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //creamos la instancia del formmulario llamandolo 
            FrmGrado GUIGrado = new FrmGrado();

            //asignamos un padre al formulario
            GUIGrado.MdiParent = this;

            //cargamos o mostramos el formulario  en la vista principal
            GUIGrado.Show();
        }

        private void aSISTENCIAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hISTORIALASISTENCIASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //creamos la instancia del formmulario llamandolo 
            FrmHistorial GUIHistorial = new FrmHistorial();

            //asignamos un padre al formulario
            GUIHistorial.MdiParent = this;

            //cargamos o mostramos el formulario  en la vista principal
            GUIHistorial.Show();
        }

        private void buscarAcudienteDeAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //creamos la instancia del formmulario llamandolo 
            FrmAcudiente_Alumno GUIAcudiente = new FrmAcudiente_Alumno();

            //asignamos un padre al formulario
            GUIAcudiente.MdiParent = this;

            //cargamos o mostramos el formulario  en la vista principal
            GUIAcudiente.Show();
        }
    }
}
