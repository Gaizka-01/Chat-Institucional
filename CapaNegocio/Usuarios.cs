using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public abstract class Usuarios
    {
        private string nombre;
        private string apellido;
        private int cedula;
        private string contraseña;
        private string usuario;

        public Usuarios()
        {

        }

        public Usuarios(string nombre, string apellido, int cedula, string contraseña, string usuario)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.contraseña = contraseña;
            this.usuario = usuario;

        }

        public void CrearUsuario(string nombre, string apellido, int cedula, string contraseña)
        {
            string usuario = nombre.Substring(1, 0) + apellido;

        }

        

        public void CambiarUsuario(string usuarioNuevo)
        {
            this.usuario = usuarioNuevo;
        }

        public void CambiarFoto()
        {

        }





        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Cedula { get; set; }
        public string Contraseña { get; set; }
        public string Usuario { get; set; }

    }
}
