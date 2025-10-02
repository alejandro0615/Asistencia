using Asistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tienda2998601.Controller;

namespace tienda2998601.VIew
{
    public partial class FrmLogin : Form
    {
         private bool passwordVisible=false;
        public FrmLogin()
        {
            InitializeComponent();
            txtpass.UseSystemPasswordChar = true; 
            passwordVisible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar() 
        {
            txtusu.Clear();
            txtpass.Clear();
        }
        private void Ingresar() 
        {
            ControllerUsuarios obj= new ControllerUsuarios();
            bool valido = obj.ValidarIngreso(txtusu.Text, txtpass.Text);
            if (valido)
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Error de credenciales... valide porfavor usuario y contraseña 🚨🚨 ");
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            txtpass.UseSystemPasswordChar = !passwordVisible;
        }
    }
}
