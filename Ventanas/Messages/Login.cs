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
        
        public Login()
        {
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
            Registro nueva = new Registro();
            nueva.Visible = true;
            Visible = false;
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            string tipo;
            tipo = lblTipo.Text;
            if (tbUsuario.Text == "Usuario" || tbContraseña.Text == "Contraseña" ) 
            {
                MessageBox.Show("Por favor completa todos los campos");
                
            }
            else
            {
                switch (tipo)
                {
                    case "| Alumnos":
                        try
                        {
                            Alumnos.LoginAlumno(tbUsuario.Text, tbContraseña.Text);
                            Alumnos nuevo = new Alumnos();
                            nuevo = Alumnos.getAlumnmo(tbUsuario.Text, tbContraseña.Text);
                            intAlumno nueva = new intAlumno(Alumnos.Nombre(nuevo), Alumnos.Apelido(nuevo), Alumnos.Grupo(nuevo));
                            nueva.Visible = true;
                            Visible = false;
                        }
                        catch
                        {
                            MessageBox.Show("No se encontro un alumno con ese usuario y contraseña");
                        }
                        break;
                    case "| Profesores":
                        try
                        {
                            Profesores.LoginProfesor(tbUsuario.Text, tbContraseña.Text);
                            Profesores nuevo = new Profesores();
                            nuevo = Profesores.getProfesor(tbUsuario.Text, tbContraseña.Text);
                            intProfesor nueva = new intProfesor();
                            nueva.Visible = true;
                            Visible = false;

                        }
                        catch
                        {
                            MessageBox.Show("No se encontro un profesor con ese usuario y contraseña");
                        }

                        break;
                    case "| Administradores":
                        try
                        {
                            Administradores.LoginAdministrador(tbUsuario.Text, tbContraseña.Text);
                            intAdmin nueva = new intAdmin();
                            nueva.Visible = true;
                            Visible = false;
                        }
                        catch
                        {
                            MessageBox.Show("No se encontro un administrador con es usuario y contraseña");
                        }
                        break;
                }
            }
        }
    }
}
