using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;

namespace CapaNegocio
{
    public class Profesores : Usuarios
    {
        private string nombre;
        private string apellido;
        private int cedula;
        private string contraseña;
        private string materia;
        private string usuario;
        private string grupo;
        List<string> mensajes = new List<string>();
        static List<Profesores> listaProfesores = new List<Profesores>();

        public Profesores() : base()
        {

        }

        public Profesores(string nombre, string apellido, int cedula, string contraseña, string usuario, string grupo, string materia) : base(nombre, apellido, cedula, contraseña, usuario)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.contraseña = contraseña;
            this.materia = materia;
            this.usuario = usuario;
            this.grupo = grupo;
        }

        public void RegistrarUs(Profesores p)
        {
            listaProfesores.Add(p);
        }

        public static void CrearProfesor(string nombre, string apellido, int cedula, string contraseña, string grupo, string materia)
        {
            foreach(Profesores p in listaProfesores)
            {
                if(cedula == p.cedula)
                {
                    throw new Exception();
                }
                else
                {
                    string usuario;
                    usuario = nombre.Substring(0, 1) + apellido;
                    Profesores nuevo = new Profesores(nombre, apellido, cedula, contraseña, usuario, grupo, materia);
                }
            }
        }

        public static Profesores getProfesorXUsuario(string usuario, string contraseña)
        {
            Profesores retorno = new Profesores();
            foreach(Profesores p in listaProfesores)
            {
                if(usuario == p.usuario && contraseña == p.contraseña)
                {
                    retorno = p;
                }
            }
            return retorno;
        }
        public string GetGrupo { get; set; }
        public string GetMateria { get; set; }
    }
}
