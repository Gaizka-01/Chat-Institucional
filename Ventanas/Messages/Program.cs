using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;
using Ventanas1;

namespace Messages
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<Profesores> profes3BA = new List<Profesores>();
            List<Alumnos> alumnos3BA = new List<Alumnos>();
            List<string> materias3BA = new List<string>();            
            materias3BA.Add("Matematica");
            materias3BA.Add("Programacion");
            Grupos nuevo = new Grupos("3ºBA", profes3BA, alumnos3BA, materias3BA);
            Profesores profenuevo = new Profesores("Julio", "Profe", 5435, "contraseña", nuevo, "Matematica", "JProfe");
            profes3BA.Add(profenuevo);
            List<Profesores> profes3BB = new List<Profesores>();
            List<Alumnos> alumnos3BB = new List<Alumnos>();
            List<string> materias3BB = new List<string>();
            Grupos nuevo2 = new Grupos("3ºBB", profes3BB, alumnos3BB, materias3BB);
            List<Profesores> profes3BC = new List<Profesores>();
            List<Alumnos> alumnos3BC = new List<Alumnos>();
            List<string> materias3BC = new List<string>();
            Grupos nuevo3 = new Grupos("3ºBC", profes3BC, alumnos3BC, materias3BC);
            Grupos.IngresarGrupo(nuevo);
            Grupos.IngresarGrupo(nuevo2);
            Grupos.IngresarGrupo(nuevo3);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
