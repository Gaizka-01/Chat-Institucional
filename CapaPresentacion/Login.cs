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
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        //Modificar Bordes

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
        [DllImport("Gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern bool DeleteObject(IntPtr hObject);

        public Login()
        {
            InitializeComponent();
            IntPtr handle = CreateRoundRectRgn(0, 0, Width, Height, 20, 20);
            if (handle == IntPtr.Zero)
                ; // error with CreateRoundRectRgn
            Region = System.Drawing.Region.FromHrgn(handle);
            DeleteObject(handle);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            tbUsuario.Visible = false;
            btnVolver.Visible = false;
            tbContraseña.Visible = false;
            btnMostrar.Visible = false;
            btnAcceder.Visible = false;
            btnRecuperar.Visible = false;
            lblUsuario.Visible = false;
        }

        //Eventos de los Botones 

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            lblUsuario.Text = "Alumno";
            lblUsuario.Visible = true;
            lblIngresa.Visible = false;
            tbUsuario.Visible = true;
            tbContraseña.Visible = true;
            btnAcceder.Visible = true;
            btnVolver.Visible = true;
            btnMostrar.Visible = true;
            btnAlumnos.Visible = false;
            btnAdministrador.Visible = false;
            btnProfesor.Visible = false;
        }

        private void btnProfesor_Click(object sender, EventArgs e)
        {
            lblUsuario.Text = "Profesor";
            lblUsuario.Visible = true;
            lblIngresa.Visible = false;
            tbUsuario.Visible = true;
            tbContraseña.Visible = true;
            btnAcceder.Visible = true;
            btnVolver.Visible = true;
            btnMostrar.Visible = true;
            btnAlumnos.Visible = false;
            btnAdministrador.Visible = false;
            btnProfesor.Visible = false;
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            lblUsuario.Text = "Administrador";
            lblUsuario.Visible = true;
            lblIngresa.Visible = false;
            tbUsuario.Visible = true;
            tbContraseña.Visible = true;
            btnAcceder.Visible = true;
            btnVolver.Visible = true;
            btnMostrar.Visible = true;
            btnAlumnos.Visible = false;
            btnAdministrador.Visible = false;
            btnProfesor.Visible = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            lblUsuario.Visible = false;
            lblIngresa.Visible = true;
            tbUsuario.Visible = false;
            tbContraseña.Visible = false;
            btnAcceder.Visible = false;
            btnMostrar.Visible = false;
            btnAlumnos.Visible = true;
            btnAdministrador.Visible = true;
            btnProfesor.Visible = true;
            btnVolver.Visible = false;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            

            string tipo = lblUsuario.Text;
            if(tbUsuario.Text == "Usuario"  ||  tbContraseña.Text == "Contraseña" )
            {
                MessageBox.Show("Por favor completa todos los campos");
            }
            else
            {
                switch (tipo)
                {
                    case "Alumno":
                        Alumnos ingreso = new Alumnos();
                        ingreso = Alumnos.getAlumnoXUsuario(tbUsuario.Text, tbContraseña.Text);
                        Grupos gingreso = new Grupos();
                        gingreso = Grupos.getGrupoXNombre(ingreso.GetGrupo);
                        ventanaAlumno nuevaA = new ventanaAlumno(ingreso, gingreso);
                        nuevaA.Show();
                        this.Hide();
                        break;
                    case "Profesor":
                        Profesores ingresoP = new Profesores();
                        ingresoP = Profesores.getProfesorXUsuario(tbUsuario.Text, tbContraseña.Text);
                        Grupos gingresoP = new Grupos();
                        gingresoP = Grupos.getGrupoXNombre(ingresoP.GetGrupo);
                        ventanaProfesor nuevaP = new ventanaProfesor(ingresoP,gingresoP);
                        nuevaP.Show();
                        this.Hide();
                        break;
                    case "Administrador":
                        
                        break;
                    case "Usuario":
                        MessageBox.Show("Por favor seleccione tipo de usuario");
                        break;
                }

            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registro nueva = new Registro();
            nueva.Show();
            this.Hide();
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {

        }

        //Eventos de los TextBox

        private void tbusuario_Enter(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "Usuario")
            {
                tbUsuario.Text = "";
                tbUsuario.ForeColor = Color.LightGray;
            }
        }

        private void tbusuario_Leave(object sender, EventArgs e)
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
                tbContraseña.ForeColor = Color.DimGray;
                tbContraseña.UseSystemPasswordChar = false;
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (tbContraseña.Text == "Contraseña")
            {

            }
            else
            {
                if (tbContraseña.UseSystemPasswordChar == true)
                {
                    tbContraseña.UseSystemPasswordChar = false;
                }
                else tbContraseña.UseSystemPasswordChar = true;
            }
        }

        
    }
}
