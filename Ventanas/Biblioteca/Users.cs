using System;
using System.Collections.Generic;
namespace Biblioteca
{
    



    public class Alumnos
    {
        
        private string nombre;
        private string apellido;
        private int cedula;
        private string contraseña;
        private string grupo;
        private string usuario;
        static List<Alumnos> listaAlumnos = new List<Alumnos>();
        

        public Alumnos()
        {

        }
        public Alumnos(string nombre, string apellido, int cedula, string contraseña, string grupo, string usuario)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.contraseña = contraseña;
            this.grupo = grupo;
            this.usuario = usuario;
        }
        
        public static void CrearAlummo(string nombre, string apellido, int cedula, string contraseña, string grupo)
        {
            string usuario = nombre.Substring(0,1) + apellido;
            Alumnos nuevo = new Alumnos(nombre, apellido, cedula, contraseña, grupo, usuario);
            foreach (Alumnos a in listaAlumnos)
            {
                if (a.cedula == cedula)
                {
                    throw new Exception();
                }
                

            }

            listaAlumnos.Add(nuevo);


        }
        public static void LoginAlumno(string usuario, string contraseña)
        {
            foreach (Alumnos a in listaAlumnos)
            {
                if(a.usuario == usuario & a.contraseña == contraseña)
                {
                    
                }
                else
                {
                    throw new Exception();
                }

            }
        }



    }
    

    public class Profesores
    {
        private string nombre;
        private string apellido;
        private int cedula;
        private string contraseña;
        private string materia;
        private string grupo;
        public Profesores()
        {

        }
        public Profesores(string nombre, string apellido, int cedula, string contraseña, string grupo, string materia)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.contraseña = contraseña;
            this.grupo = grupo;
            this.materia = materia;

            List<Profesores> listaProfesores









        }


    }

    public class Administradores
    {
        string usuario;
        string contraseña;


        public Administradores()
        {

        }

        public Administradores(string usuario, string contraseña)
        {
            this.usuario = usuario;
            this.contraseña = contraseña;
        }
    }
}
