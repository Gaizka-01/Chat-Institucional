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
        private string usuario;
        Grupos grupoAlumno = new Grupos();
        static List<Alumnos> listaAlumnos = new List<Alumnos>();
        

        public Alumnos()
        {

        }
        public Alumnos(string nombre, string apellido, int cedula, string contraseña,string usuario, Grupos grupo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.contraseña = contraseña;
            this.usuario = usuario;
            grupoAlumno = grupo;
            
        }
        
        public static void CrearAlummo(string nombre, string apellido, int cedula, string contraseña, Grupos grupo)
        {
            string usuario = nombre.Substring(0,1) + apellido;
            Alumnos nuevo = new Alumnos(nombre, apellido, cedula, contraseña, usuario, grupo);
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

        public static Alumnos getAlumnmo(string usuario, string constraseña)
        {
            Alumnos alu = new Alumnos();
            foreach(Alumnos a in listaAlumnos)
            {
                if (a.usuario == usuario & a.contraseña == constraseña)
                {
                    
                    alu = a;
                    break;
                }
            }


            return alu;
            
        }
        public static string Nombre(Alumnos a)
        {
            return a.nombre;
        }
        public static string Apelido(Alumnos a)
        {
            return a.apellido;
        }
        public static Grupos Grupo(Alumnos a)
        {
            return Grupos.Nombre(a.grupoAlumno);
        }
        public static string Contraseña(Alumnos a)
        {
            return a.contraseña;
        }
        public static string Usuario(Alumnos a)
        {
            return a.usuario;
        }
        public static int Cedula(Alumnos a)
        {
            return a.cedula;
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
        private string usuario;
        static List<Profesores> listaProfesores = new List<Profesores>();
        public Profesores()
        {

        }
        public Profesores(string nombre, string apellido, int cedula, string contraseña, string grupo, string materia, string usuario)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.contraseña = contraseña;
            this.grupo = grupo;
            this.materia = materia;
            this.usuario = usuario;
            listaProfesores = Profesores.GetProfesores();

        }
        

        public static void CrearProfesor(string nombre, string apellido,int cedula, string contraseña, string grupo, string materia)
        {
            string usuario = nombre.Substring(0, 1) + apellido;
            Profesores nuevo = new Profesores(nombre, apellido, cedula, contraseña, grupo, materia, usuario);
            foreach(Profesores p in listaProfesores)
            {
                if(p.cedula == cedula)
                {
                    throw new Exception();
                }
                else
                {

                }
                listaProfesores.Add(nuevo);
            }

        }

        public static void LoginProfesor(string usuario, string contraseña)
        {
            foreach (Profesores p in listaProfesores)
            {
                if(p.usuario == usuario & p.contraseña == contraseña)
                {

                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public static List<Profesores> GetProfesores()
        {
            return listaProfesores;
        }
        public static Profesores getProfesor(string usuario, string constraseña)
        {
            Profesores prof = new Profesores();
            foreach (Profesores p in listaProfesores)
            {
                if (p.usuario == usuario & p.contraseña == constraseña)
                {
                    prof = p;
                    break;
                }
            }
            return prof;
        }



        public static string Nombre(Profesores p)
        {
            return p.nombre;
        }
        public static string Apellido(Profesores p)
        {
            return p.apellido;
        }
        public static string Contraseña(Profesores p)
        {
            return p.contraseña;
        }
        public static int Cedula(Profesores p)
        {
            return p.cedula;
        }
        public static string Materia(Profesores p)
        {
            return p.materia;
        }
        public static string Grupo(Profesores p)
        {
            return p.grupo;
        }
        public static string Usuario(Profesores p)
        {
            return p.usuario;
        }
        
       


    }

    public class Administradores
    {
        private string usuario;
        private string contraseña;
        static List<Administradores> listaAdministradores = new List<Administradores>();
        


        public Administradores()
        {

        }

        public Administradores(string usuario, string contraseña)
        {
            this.usuario = usuario;
            this.contraseña = contraseña;
        }

        public static void LoginAdministrador(string usuario, string contaseña) 
        { 
            foreach (Administradores a in listaAdministradores)
            {
                if(a.usuario == usuario & a.contraseña == contaseña)
                {

                }
                else
                {
                    throw new Exception();
                }
            }
            
        }


        public static string Usuario(Administradores a)
        {
            return a.usuario;
        }
        public static string Contraseña(Administradores a)
        {
            return a.contraseña;
        }
    }

    public class Grupos
    {
        private string nombre;
        static List<Grupos> listaGrupos = new List<Grupos>();
        static List<Profesores> profesGrupo = new List<Profesores>();
        static List<Alumnos> alumnosGrupo = new List<Alumnos>();
        public Grupos()
        {

        }
        public Grupos(string nombre, List<Profesores> profesGrupo0, List<Alumnos> alumnosGrupo0)
        {
            this.nombre = nombre;
            profesGrupo = profesGrupo0;
            alumnosGrupo = alumnosGrupo0;
        }

        public static string Nombre(Grupos g)
        {
            return g.nombre;
        }

    }
}
