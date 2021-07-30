using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ventanas1
{
    public partial class intProfesor : Form
    {
        private string nombre;
        private string apellido;
        private string grupo;
        private int cedula;
        private string materia;

        public intProfesor(string nombre, string apellido, string grupo, int cedula)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.apellido = apellido;
            this.grupo = grupo;
            lblNombre.Text = nombre + " " + apellido + "| " + grupo;
        }

        private void intProfesor_Load(object sender, EventArgs e)
        {
            pNuevoMensaje.Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pNuevoMensaje.Visible = true;

        }
    }
}
