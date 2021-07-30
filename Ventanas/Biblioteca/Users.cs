using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
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
        static List<Alumnos> listaAlumnosE = new List<Alumnos>();
        List<Chat> listaChats = new List<Chat>();
        

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
        public static string NombreGrupo(Alumnos a)
        {
            return Grupos.Nombre(a.grupoAlumno);
        }
        public static string Contraseña(Alumnos a)
        {
            return a.contraseña;
        }
        public static Grupos getGrupoObj(Alumnos a)
        {
            return a.grupoAlumno;
        } 
        public static string Usuario(Alumnos a)
        {
            return a.usuario;
        }
        public static Alumnos getAlumnoObj(int cedula)
        {
            Alumnos retorno = new Alumnos();
            foreach (Alumnos a in listaAlumnos)
            {
                if (a.cedula == cedula)
                {
                    retorno = a;
                }
            }
            return retorno;
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
        List<string> mensajes = new List<string>();
        Grupos grupoProfesor = new Grupos();
        private string usuario;
        static List<Profesores> listaProfesores = new List<Profesores>();
        public Profesores()
        {

        }
        public Profesores(string nombre, string apellido, int cedula, string contraseña, Grupos grupo, string materia, string usuario)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.contraseña = contraseña;
            grupoProfesor = grupo;
            this.materia = materia;
            this.usuario = usuario;
            listaProfesores = Profesores.GetProfesores();

        }
        

        public static void CrearProfesor(string nombre, string apellido,int cedula, string contraseña, Grupos grupo, string materia)
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
        public static void Recibir(Profesores p, string mensaje)
        {
            p.mensajes.Add(mensaje);
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
        public static Profesores getProfesorC(string cedula)
        {
            Profesores prof = new Profesores();
            foreach (Profesores p in listaProfesores)
            {
                if (p.cedula == usuario )
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
        public static string NombreGrupo(Profesores p)
        {
            return Grupos.Nombre(p.grupoProfesor);
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
        List<Profesores> profesGrupo = new List<Profesores>();
        List<Alumnos> alumnosGrupo = new List<Alumnos>();
        List<string> listaMaterias = new List<string>();
        public Grupos()
        {

        }
        public Grupos(string nombre, List<Profesores> profesGrupo0, List<Alumnos> alumnosGrupo0, List<string> listaMaterias0)
        {
            this.nombre = nombre;
            profesGrupo = profesGrupo0;
            alumnosGrupo = alumnosGrupo0;
            listaMaterias = listaMaterias0;
            
        }

        public static string Nombre(Grupos g)
        {
            return g.nombre;
        }

        public static List<Profesores> GetProfesGrupo(Grupos g)
        {
            return g.profesGrupo;
        }

        public static Grupos GetGrupo(string nombreGrupo)
        {
            Grupos retorno = new Grupos();
            foreach (Grupos g in listaGrupos)
            {
                if (g.nombre == nombreGrupo)
                {
                    
                    retorno = g;
                }
            }
            return retorno;
        }

        public static List<string> getMaterias(Grupos g)
        {
            return g.listaMaterias;
        }

        public static List<Grupos> GetGrupos()
        {
            return listaGrupos;
        }

        public static void IngresarGrupo(Grupos g)
        {
            listaGrupos.Add(g);
        }
    }


    public class Chat
    {
        private string materia;
        
        List<string> mensajes = new List<string>();
        public Chat()
        {

        }
        public Chat(List<string> mensajes0, string materia)
        {
            this.materia = materia;
            mensajes = mensajes0;

        }




    }
    public class Mensaje
    {
        private string emisor;
        private string contenido;
        private int estado;
        private string destinatario;
        public Mensaje()
        {

        }
        public Mensaje(string contenido, string emisor, int estado, string destinatario)
        {
            this.estado = estado;
            this.contenido = contenido;
            this.emisor = emisor;
            this.destinatario = destinatario;

        }

        public static string Contenido(Mensaje m)
        {
            return m.contenido;
        }
        public static string Emisor(Mensaje m)
        {
            return m.emisor;
        }
        public static int Estado(Mensaje m)
        {
            return m.estado;
        }

        





    }
}
