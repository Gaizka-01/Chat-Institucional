using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Grupos
    {
        string nombre;
        static List<Grupos> listaGrupos = new List<Grupos>();
        List<Profesores> profesGrupo = new List<Profesores>();
        List<Alumnos> alumnosGrupo = new List<Alumnos>();
        List<Alumnos> alumnosEspera = new List<Alumnos>();

        
       public Grupos()
        {

        }

        public Grupos(string nombre,List<Profesores> listaP, List<Alumnos> listaA)
        {
            this.nombre = nombre;
            this.alumnosGrupo = listaA;
            this.profesGrupo = listaP;
        }

        public List<Alumnos> getAlumnos()
        {
            return alumnosGrupo;
        }

        public List<Profesores> GetProfesores()
        {
            return profesGrupo;
        }

        public static List<Grupos> GetGrupos()
        {
            return listaGrupos;
        }

        public static void agregarGrupo(Grupos g)
        {
            listaGrupos.Add(g);
        }

        public static void agregarAlumno(Alumnos a, string nGrupo)
        {
            foreach(Grupos g in listaGrupos)
            {
                if(nGrupo == g.nombre)
                {
                    g.alumnosGrupo.Add(a);
                }
            }

        }

        public static void agregarProfesor(Profesores p, string nGrupo)
        {
            foreach(Grupos g in listaGrupos)
            {
                g.profesGrupo.Add(p);
            }
        }


        public static Grupos getGrupoXNombre(string nombre)
        {
            Grupos retorno = new Grupos();

            foreach(Grupos g in listaGrupos)
            {
                if(nombre == g.nombre)
                {
                    retorno = g;
                }
            }
            return retorno;

        }
        public string getNombre { get; set; }
    }
}
