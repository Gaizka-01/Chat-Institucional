using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Biblioteca;

namespace Ventanas1
{
    public partial class intAlumno : Form
    {
        private string nombre;
        private string apellido;
        private string grupo;
        private int cedula;
        public intAlumno(string nombre, string apellido, string grupo, int cedula)
        {
            
            
            InitializeComponent();
            this.nombre = nombre;
            this.apellido = apellido;
            this.grupo = grupo;
            lblNombre.Text = nombre + " " + apellido + "| " + grupo;

        }

        private void intAlumno_Load(object sender, EventArgs e)
        {
            pNuevoMensaje.Visible = false;
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pNuevoMensaje.Visible = true;
            List<string> profes = new List<string>();
            Grupos nuevo = new Grupos();
            nuevo = Grupos.GetGrupo(grupo);
            profes = Grupos.getMaterias(nuevo);
            foreach (string s in profes)
            {
                lbNuevo.Items.Add(s);
            }
        }

       

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea Cerrar Sesion?", "Cerrar Sesion",
                MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                Messages.Login nueva = new Messages.Login();
                nueva.Visible = true;
                this.Close();
                
            }

        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            if (lbNuevo.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar un destinatario");
            }
            else
            {
                Alumnos a = new Alumnos();
                a = Alumnos.getAlumnoObj(cedula);
                Grupos g = new Grupos();
                g = Grupos.GetGrupo(grupo);
                List<Profesores> profes = new List<Profesores>();
                profes = Grupos.GetProfesGrupo(g);
                Profesores destinatario = new Profesores();
                foreach (Profesores p in profes)
                {
                    if (Profesores.Materia(p) == Convert.ToString(lbNuevo.SelectedItem))
                    {
                        destinatario = p;
                    }
                }
                lbldestinatario.Text = Profesores.Nombre(destinatario) + Profesores.Apellido(destinatario);
                lblMateria.Text = Convert.ToString(lbNuevo.SelectedItem);
                

                pNuevoMensaje.Visible = false;
            }
        } 
        private void ConsultaBasica(string mensaje)
        {
            Grupos g = new Grupos();
            g = Grupos.GetGrupo(grupo);
            List<Profesores> profes = new List<Profesores>();
            profes = Grupos.GetProfesGrupo(g);
            Profesores destinatario = new Profesores();
            foreach (Profesores p in profes)
            {
                if (Profesores.Materia(p) == Convert.ToString(lblMateria.Text))
                {
                    destinatario = p;
                }
            }
            try
            {
                Profesores.Recibir(destinatario, mensaje);
            }
            catch
            {
                MessageBox.Show("No se pudo enviar el mensaje");
            }

            
        }
        private void CrearConsultatb(string mensaje)
        {
            TextBox tb = new TextBox();
            this.Controls.Add(tb);
            tb.Location = pMensajes.Location;
            tb.Dock = DockStyle.Bottom;
            tb.Text = mensaje;

        }
        private void CrearConsulta(string contenido)
        {
            Panel nuevoMensaje = new Panel();
            this.Controls.Add(nuevoMensaje);
            nuevoMensaje.Visible = true;
            nuevoMensaje.Visible = true;
            nuevoMensaje.Location = pMensajes.Location;
            nuevoMensaje.BackColor = Color.AliceBlue;
            Label Contenido = new Label();
            Contenido.Text = contenido;
            
        }

        private void CrearDock(string materiaing)
        {
            Panel dock = new Panel();           
            dock.Location = pChats.Location;
            dock.Dock = DockStyle.Top;
            PictureBox foto = new PictureBox();
            foto.Location = dock.Location;
            foto.Dock = DockStyle.Left;
            dock.BackColor = Color.White;
            Label materia = new Label();
            materia.Location = dock.Location;
            materia.Text = materiaing;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(lblMateria.Text == "Materia")
            {
                MessageBox.Show("Debes seleccionar un destinatario");
            }
            else
            {
                CrearConsultatb(tbMensaje.Text);
            }
            
        }
    }
}
