using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventanas1;
using Biblioteca;

namespace Messages
{
    public partial class Login : Form
    {
        //Bordes Redondeados
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect, // x-coordinate of upper-left corner
        int nTopRect, // y-coordinate of upper-left corner
        int nRightRect, // x-coordinate of lower-right corner
        int nBottomRect, // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
        );
        public Login()
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            InitializeComponent();

        }
        //eleccion de tipo de usuario
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            lblTipo.Text = "| Profesores";
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            lblTipo.Text = "| Alumnos";
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            lblTipo.Text = "| Administradores";
        }
        //botones cerrar y minimizar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //configuraciones textbox
        private void tbUsuario_Enter(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "Usuario")
            {
                tbUsuario.Text = "";
                tbUsuario.ForeColor = Color.LightGray;
            }
        }

        private void tbUsuario_Leave(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "")
            {
                tbUsuario.Text = "Usuario";
                tbUsuario.ForeColor = Color.DimGray;
            }
        }

        private void tbContraseña_Enter(object sender, EventArgs e)
        {
            if (tbContraseña.Text == "Contraseña")
            {
                tbContraseña.Text = "";
                tbContraseña.ForeColor = Color.LightGray;
                tbContraseña.UseSystemPasswordChar = true;
            }
        }

        private void tbContraseña_Leave(object sender, EventArgs e)
        {
            if (tbContraseña.Text == "")
            {
                tbContraseña.Text = "Contraseña";
                tbContraseña.ForeColor = Color.LightGray;
                tbContraseña.UseSystemPasswordChar = false;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registro.abrir();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                Alumnos.LoginAlumno(tbUsuario.Text,tbContraseña.Text);
                intAlumno nueva = new intAlumno();
                nueva.Show();
                Registro.cerrar();
            }
            catch
            {
                MessageBox.Show("No se encontro un usuario con ese nombre y contraseña");
            }
        }
    }
}
