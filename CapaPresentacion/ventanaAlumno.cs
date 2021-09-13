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
    public partial class ventanaAlumno : Form
    {
        Alumnos a = new Alumnos();
        Grupos g = new Grupos();

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

        public ventanaAlumno(Alumnos a, Grupos g)
        {
            InitializeComponent();
            a = this.a;
            g = this.g;
            IntPtr handle = CreateRoundRectRgn(0, 0, Width, Height, 25, 25);
            if (handle == IntPtr.Zero)
                ; // error with CreateRoundRectRgn
            Region = System.Drawing.Region.FromHrgn(handle);
            DeleteObject(handle);
        }

        private void ventanaAlumno_Load(object sender, EventArgs e)
        {
            pNuevo.Visible = false;
            pOpicones.Visible = false;

            lblNombre.Text = a.Nombre + " " + a.Apellido;
            lblNombreConfig.Text = a.Nombre + " " + a.Apellido;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            pInicio.Visible = false;
            pNuevo.Visible = true;


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            pNuevo.Visible = false;
            pInicio.Visible = true;
        }

        private void tbBuscar_Enter(object sender, EventArgs e)
        {
            if(tbBuscar.Text == "Buscar Chat")
            {
                tbBuscar.Text = "";
                tbBuscar.ForeColor = Color.LightGray;
            }
        }

        private void tbBuscar_Leave(object sender, EventArgs e)
        {
            if(tbBuscar.Text == "")
            {
                tbBuscar.Text = "Buscar Chat";
                tbBuscar.ForeColor = Color.DimGray;
            }
        }

        private void tbMensaje_Enter(object sender, EventArgs e)
        {
            if(tbMensaje.Text == "Type your message")
            {
                tbMensaje.Text = "";
            }
        }

        private void tbMensaje_Leave(object sender, EventArgs e)
        {
            if(tbMensaje.Text == "")
            {
                tbMensaje.Text = "Type your message";
            }
        }

        

        private void btncerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea Cerrar Sesion?", "Cerrar Sesion",
               MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                this.Close();
                Program.Principal.Visible = true;

            }
        }
        
        //metodos pintar

        private void pintarMensaje()
        {
            Control mensaje = new TextBox();
            mensaje.Parent = pMensajes;
            mensaje.Dock = DockStyle.Bottom;
            mensaje.Text = tbMensaje.Text;

        }

        private void pintarChat()
        {
            Control panel = new Panel();
            panel.Parent = pChats;
            panel.Dock = DockStyle.Top;

        }

        

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            pintarMensaje();
        }

        private void chNuevoChat_CheckedChanged(object sender, EventArgs e)
        {
            if (chNuevoChat.Checked == true)
            {
                cbNuevaConsulta.Checked = false;
                cbUnirse.Checked = false;

            }
        }

        private void cbNuevaConsulta_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNuevaConsulta.Checked == true)
            {
                chNuevoChat.Checked = false;
                cbUnirse.Checked = false;
            }
        }

        private void cbUnirse_CheckedChanged(object sender, EventArgs e)
        {
            if(cbUnirse.Checked == true)
            {
                chNuevoChat.Checked = false;
                cbNuevaConsulta.Checked = false;
                
            }
        }

        private void btnEnlace_Click(object sender, EventArgs e)
        {
            try
            {
            Alumnos.abrir();

            }
            catch
            {
                throw new Exception();
            }

        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            if (pOpicones.Visible == false)
            {
                pOpicones.Visible = true;
            }
            else pOpicones.Visible = false;
        }
    }
}
