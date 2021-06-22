using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ProyectoFinal
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

        //Movimiento Ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessagge(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //Apariciones de paneles segun la necesidad
        public Login()
        {
            
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pAlumnos.Visible = true;
            pProfesores.Visible = false;
            pAdministrador.Visible = false;
            btnAtras.Visible = false;
        }
        

        private void btnProfesor_Click(object sender, EventArgs e)
        {
            btnAtras.Visible = true;
            pAlumnos.Visible = false;
            pProfesores.Visible = true;
            btnProfesor.Visible = false;
            btnAdministrador.Visible = false;
        }

       

        private void btnAtras_Click(object sender, EventArgs e)
        {
            btnAtras.Visible = false;
            pAdministrador.Visible = false;
            pProfesores.Visible = false;
            pAlumnos.Visible = true;
            btnProfesor.Visible = true;
            btnAdministrador.Visible = true;
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            btnAtras.Visible = true;
            pAlumnos.Visible = false;
            pAdministrador.Visible = true;
            btnProfesor.Visible = false;
            btnAdministrador.Visible = false;
        }

        private void lblRegistrar_Click(object sender, EventArgs e)
        {

        }
        //Configuraciones de text box
        private void tbUsuario_Enter(object sender, EventArgs e)
        {
            if(tbUsuario.Text == "Usuario")
            {
                tbUsuario.Text = "";
                tbUsuario.ForeColor = Color.LightGray;
            }
        }

        private void tbUsuario_Leave(object sender, EventArgs e)
        {
            if(tbUsuario.Text == "")
            {
                tbUsuario.Text = "Usuario";
                tbUsuario.ForeColor = Color.DimGray;
            }
        }

        private void tbContraseña_Enter(object sender, EventArgs e)
        {
            if(tbContraseña.Text == "Contraseña")
            {
                tbContraseña.Text = "";
                tbContraseña.ForeColor = Color.LightGray;
                tbContraseña.UseSystemPasswordChar = true;
            }
        }

        private void tbContraseña_Leave(object sender, EventArgs e)
        {
            if(tbContraseña.Text == "")
            {
                tbContraseña.Text = "Contraseña";
                tbContraseña.ForeColor = Color.LightGray;
                tbContraseña.UseSystemPasswordChar = false;
            }
        }

        private void lblRecuperar_Click(object sender, EventArgs e)
        {
            lblRecuperar.ForeColor = Color.Blue;
        }
        //Eventos para los botones cerrar y minimizar

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Eventos para movimiento de ventana
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessagge(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessagge(this.Handle, 0x112, 0xf012, 0);
        }

        private void pAlumnos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessagge(this.Handle, 0x112, 0xf012, 0);
        }

        private void pProfesores_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessagge(this.Handle, 0x112, 0xf012, 0);
        }

        private void pAdministrador_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessagge(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
