using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class Alumnos : Usuarios
    {
        private string nombre;
        private string apellido;
        private int cedula;
        private string contraseña;
        private string usuario;
        private string grupo;
        private static List<Alumnos> listaAlumnos = new List<Alumnos>();
        private static List<Alumnos> listaEspAlumnos = new List<Alumnos>();
        private List<Chat> listaChats = new List<Chat>();

        public Alumnos() : base()
        {

        }

        public Alumnos(string nombre, string apellido, int cedula, string contraseña, string usuario, string grupo) : base(nombre, apellido, cedula, contraseña, usuario)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.contraseña = contraseña;
            this.usuario = usuario;
            this.grupo = grupo;

        }

        public static void CrearUsuario(string nombre, string apellido, int cedula, string contraseña, string grupo)
        {
            foreach (Alumnos a in listaAlumnos)
            {
                if (a.Cedula == cedula)
                {
                    throw new Exception();
                }
            }
            foreach (Alumnos a in listaEspAlumnos)
            {
                if (a.Cedula == cedula)
                {
                    throw new Exception();
                }
                else
                {
                    string usuario;
                    usuario = nombre.Substring(0, 1) + apellido;
                    Alumnos nuevo = new Alumnos(nombre, apellido, cedula, contraseña, usuario,grupo);
                    nuevo.RegistrarUs(nuevo);
                }
            }


        }
        public  void RegistrarUs(Alumnos a)
        {
            listaAlumnos.Add(a);
        }

        

        public static List<Alumnos> GetListaAlumnos()
        {
            return listaAlumnos;
        }

        public static List<Alumnos> GetListaEspAlumnos()
        {
            return listaEspAlumnos;
        }

        public static Alumnos getAlumnoXUsuario(string usuario, string contraseña)
        {
            Alumnos retorno = new Alumnos();
            foreach (Alumnos a in listaAlumnos)
            {
                if(usuario == a.usuario && contraseña == a.contraseña)
                {
                    retorno = a;
                }
            }

            foreach (Alumnos a in listaEspAlumnos)
            {
                if (usuario == a.usuario && contraseña == a.contraseña)
                {
                    retorno = a;
                }
            }
            
            return retorno;
        }

        public static void abrir()
        {
            Datos.crearConexion();
        }

        public string GetGrupo { get; set; }

        
    }
}
