using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Biblioteca;
using Messages;

namespace Ventanas1
{
    public partial class Registro : Form
    {
        public Registro()
        {          
            InitializeComponent(); 
            
        }
        private void Registro_Load(object sender, EventArgs e)
        {
            lbMateria.Visible = false;
            pMateria.Visible = false;
            lblMateria.Visible = false; 
            List<Grupos> cargar = new List<Grupos>();
            cargar = Grupos.GetGrupos();

            foreach (Grupos g in cargar)
            {
                lbGrupo.Items.Add(Grupos.Nombre(g));
            }
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

        private void tbNombre_Enter(object sender, EventArgs e)
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
                tbContraseña.ForeColor = Color.DimGray;
                tbContraseña.UseSystemPasswordChar = false;
            }
        }

        private void tbContraseña2_Enter(object sender, EventArgs e)
        {
            if(tbContraseña2.Text == "Repetir Contraseña")
            {
                tbContraseña2.Text = "";
                tbContraseña2.ForeColor = Color.LightGray;
                tbContraseña2.UseSystemPasswordChar = true;
            }
        }

        private void tbContraseña2_Leave(object sender, EventArgs e)
        {
            if(tbContraseña.Text == "")
            {
                tbContraseña.Text = "Repetir Contraseña";
                tbContraseña.ForeColor = Color.DimGray;
                tbContraseña.UseSystemPasswordChar = false;
            }
        }

        private void tbCedula_Enter(object sender, EventArgs e)
        {
            if(tbCedula.Text == "Cedula")
            {
                tbCedula.Text = "";
                tbCedula.ForeColor = Color.LightGray;
            }
        }

        private void tbCedula_Leave(object sender, EventArgs e)
        {
            if(tbCedula.Text == "")
            {
                tbCedula.Text = "Cedula";
                tbCedula.ForeColor = Color.DimGray;
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
        private void rbAlumno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAlumno.Checked == true)
            {
                rbProfesor.Checked = false;
                lblMateria.Visible = false;
                lbMateria.Visible = false;
                pMateria.Visible = false;
            }
            
        }

        private void rbProfesor_CheckedChanged(object sender, EventArgs e)
        {
            if(rbProfesor.Checked == true)
            {
                rbAlumno.Checked = false;
                lblMateria.Visible = true;
                lbMateria.Visible = true;
                pMateria.Visible = true;
            }
            
        }

        private void lbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grupos g = new Grupos();
            g = Grupos.GetGrupo(Convert.ToString(lbGrupo.SelectedItem));
            List<string> materias = new List<string>();
            materias = Grupos.getMaterias(g);
            foreach (string m in materias)
            {
                lbMateria.Items.Add(m);
            }
        }



        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool tipo = rbAlumno.Checked;
            switch (tipo)
            {
                case true:

                    if (tbNombre.Text == "Nombre" || tbApellido.Text == "Apellido" || tbCedula.Text == "Cedula" || tbContraseña.Text == "Contraseña" || tbContraseña2.Text == "Repetir Contraseña" || lbGrupo.SelectedItem == null)
                    {
                        MessageBox.Show("Por Favor Completa Todos Los Campos");
                    }
                    else if (tbContraseña.Text != tbContraseña2.Text)
                    {
                        MessageBox.Show("Las contraseñas no coinciden");

                    }
                    else
                    {
                        try
                        {
                            Alumnos.CrearAlummo(tbNombre.Text, tbApellido.Text, Convert.ToInt32(tbCedula.Text), tbContraseña.Text, Grupos.GetGrupo(Convert.ToString(lbGrupo.SelectedItem)));
                            MessageBox.Show("Usuario Creado Correctamente");
                            Login nueva = new Login();
                            nueva.Show();
                            this.Close();                            
                        }
                        catch
                        {
                            MessageBox.Show("Ya existe un usuario con la cedula ingresada");
                        }
                    }
                    break;
                case false:
                    if (tbNombre.Text == "Nombre" || tbApellido.Text == "Apellido" || tbCedula.Text == "Cedula" || tbContraseña.Text == "Contraseña" || tbContraseña2.Text == "Repetir Contraseña" || lbGrupo.SelectedItem == null ||lbMateria.SelectedItem == null)
                    {
                        MessageBox.Show("Por Favor Completa Todos Los Campos");
                    }
                    else if (tbContraseña.Text != tbContraseña2.Text)
                    {
                        MessageBox.Show("Las contraseñas no coinciden");
                    }
                    else
                    {
                        try
                        {
                            Profesores.CrearProfesor(tbNombre.Text, tbApellido.Text, Convert.ToInt32(tbCedula.Text), tbContraseña.Text, Grupos.GetGrupo(Convert.ToString(lbGrupo.SelectedItem)), Convert.ToString(lbMateria.SelectedItem));
                            MessageBox.Show("Usuario Creado Correctamente");
                            Login nueva = new Login();
                            nueva.Show();
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Ya existe un usuario con la cedula ingresada");
                        }
                    }

                    break;

                    
            }

            
        }

        
    }
}
