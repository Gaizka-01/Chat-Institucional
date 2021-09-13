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
    public partial class ventanaProfesor : Form
    {
        Profesores p = new Profesores();
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

        public ventanaProfesor(Profesores p, Grupos g)
        {
            InitializeComponent();
            IntPtr handle = CreateRoundRectRgn(0, 0, Width, Height, 25, 25);
            if (handle == IntPtr.Zero)
                ; // error with CreateRoundRectRgn
            Region = System.Drawing.Region.FromHrgn(handle);
            DeleteObject(handle);
            this.p = p;
            this.g = g;
        }

        private void ventanaProfesor_Load(object sender, EventArgs e)
        {
            pOpicones.Visible = false;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tbBuscarP_Enter(object sender, EventArgs e)
        {
            if(tbBuscarP.Text == "Buscar Chat")
            {
                tbBuscarP.Text = "";
                tbBuscarP.ForeColor = Color.LightGray;
            }
        }

        private void tbBuscarP_Leave(object sender, EventArgs e)
        {
            if(tbBuscarP.Text == "")
            {
                tbBuscarP.Text = "Buscar Chat";
                tbBuscarP.ForeColor = Color.DimGray;
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
