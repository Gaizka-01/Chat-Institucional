using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ventanas1
{
    public partial class intAlumno : Form
    {
        public intAlumno(string nombre, string apellido, string grupo)
        {
            
            
            InitializeComponent();
            lblNombre.Text = nombre + " " + apellido + "| " + grupo;

        }

    
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
