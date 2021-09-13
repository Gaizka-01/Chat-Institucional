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
    public partial class Registro : Form
    {

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

        public Registro()
        {
            InitializeComponent();
            IntPtr handle = CreateRoundRectRgn(0, 0, Width, Height, 20, 20);
            if (handle == IntPtr.Zero)
                ; // error with CreateRoundRectRgn
            Region = System.Drawing.Region.FromHrgn(handle);
            DeleteObject(handle);
        }

private void Registro_Load(object sender, EventArgs e)
        {
            lbMateria.Visible = false;
            lblMateria.Visible = false;
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbAlumno_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAlumno.Checked == true)
            {
                cbProfesor.Checked = false;
                lbMateria.Visible = false;
                lblMateria.Visible = false;
            }
        }

        private void cbProfesor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProfesor.Checked == true)
            {
                cbAlumno.Checked = false;
                lblMateria.Visible = true;
                lbMateria.Visible = true;
            }
        }

        private void lblNombre_Enter(object sender, EventArgs e)
        {
            if(tbNombre.Text == "Nombre")
            {
                tbNombre.Text = "";
                tbNombre.ForeColor = Color.LightGray;
            }
        }

        private void tbNombre_Leave(object sender, EventArgs e)
        {
            if(tbNombre.Text == "")
            {
                tbNombre.Text = "Nombre";
                tbNombre.ForeColor = Color.DimGray;
            }
        }

        private void tbApellido_Enter(object sender, EventArgs e)
        {
            if(tbApellido.Text == "Apellido")
            {
                tbApellido.Text = "";
                tbApellido.ForeColor = Color.LightGray;
            }
        }

        private void tbApellido_Leave(object sender, EventArgs e)
        {
            if(tbApellido.Text == "")
            {
                tbApellido.Text = "Apellido";
                tbApellido.ForeColor = Color.DimGray;
            }
        }

        private void tbCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void tbCedula_Enter(object sender, EventArgs e)
        {
            if (tbCedula.Text == "Cedula")
            {
                tbCedula.Text = "";
                tbCedula.ForeColor = Color.LightGray;
            }
        }

        private void tbCedula_Leave(object sender, EventArgs e)
        {
            if (tbCedula.Text == "")
            {
                tbCedula.Text = "Cedula";
                tbCedula.ForeColor = Color.DimGray;
            }
        }

        private void tbContra_Enter(object sender, EventArgs e)
        {
            if (tbContra.Text == "Contraseña")
            {
                tbContra.Text = "";
                tbContra.ForeColor = Color.LightGray;
                tbContra.UseSystemPasswordChar = true;
            }
        }

        private void tbContra_Leave(object sender, EventArgs e)
        {
            if (tbContra.Text == "")
            {
                tbContra.Text = "Contraseña";
                tbContra.ForeColor = Color.DimGray;
                tbContra.UseSystemPasswordChar = false;
            }
        }

        private void tbContra2_Enter(object sender, EventArgs e)
        {
            if(tbContra2.Text == "Repetir Contraseña")
            {
                tbContra2.Text = "";
                tbContra2.ForeColor = Color.LightGray;
                tbContra2.UseSystemPasswordChar = true;
            }
        }

        private void tbContra2_Leave(object sender, EventArgs e)
        {
            if(tbContra2.Text == "")
            {
                tbContra2.Text = "Repetir Contraseña";
                tbContra2.ForeColor = Color.DimGray;
                tbContra2.UseSystemPasswordChar = false;
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if(tbContra.Text == "Contraseña")
            {

            }
            else
            {
                if (tbContra.UseSystemPasswordChar == true)
                {
                    tbContra.UseSystemPasswordChar = false;
                }
                else tbContra.UseSystemPasswordChar = true;
             }
            
        }

        private void btnMostrar2_Click(object sender, EventArgs e)
        {
            if(tbContra2.Text == "Repetir Contraseña")
            {
                
            }
            else
            {
                if (tbContra2.UseSystemPasswordChar == true)
                {
                    tbContra2.UseSystemPasswordChar = false;
                }
                else tbContra2.UseSystemPasswordChar = true;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cbAlumno.Checked == true)
            {
                try
                {
                    Alumnos.CrearUsuario(tbNombre.Text, tbApellido.Text, Convert.ToInt32(tbCedula.Text), tbContra.Text,lbGrupos.SelectedItem.ToString());
                    string usuario = tbNombre.Text.Substring(0, 1) + tbApellido.Text;
                    MessageBox.Show($"Cuenta creada correctamente, tu usuario es {usuario} ");
                    Alumnos nuevo = new Alumnos(tbNombre.Text, tbApellido.Text, Convert.ToInt32(tbCedula.Text), tbContra.Text,usuario , lbGrupos.SelectedItem.ToString());
                    Grupos.agregarAlumno(nuevo, lbGrupos.SelectedItem.ToString());
                    this.Close();
                    Program.Principal.Visible = true;
                }
                catch
                {
                    MessageBox.Show("Ya existe un alumno con la cedula ingresada");
                }
            }
            else if (cbProfesor.Checked == true)
            {
                Profesores.CrearProfesor(tbNombre.Text, tbApellido.Text, Convert.ToInt32(tbCedula.Text), tbContra.Text, lbGrupos.SelectedItem.ToString(), lbMateria.SelectedItem.ToString());
                string usuario = tbNombre.Text.Substring(0, 1) + tbApellido.Text;
                Profesores nuevo = new Profesores(tbNombre.Text, tbApellido.Text, Convert.ToInt32(tbCedula.Text), tbContra.Text, usuario,lbGrupos.SelectedItem.ToString(), lbMateria.SelectedItem.ToString());
                Grupos.agregarProfesor(nuevo, lbGrupos.SelectedItem.ToString());
                this.Close();
                Program.Principal.Visible = true;

            }else {MessageBox.Show("Por favor seleccione tipo de usuario"); }
            
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.Principal.Visible = true;
        }

        public static void llenarGrupos()
        {
            List<Grupos> lg = new List<Grupos>();
            lg = Grupos.GetGrupos();

            foreach(Grupos g in lg)
            {
            }
        }

    }
}
