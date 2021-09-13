using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        public static Form Principal;
        [STAThread]
        static void Main()
        {
            //Creo grupo 3BA
            List<Profesores> profes3BA = new List<Profesores>();
            List<Alumnos> alumnos3BA = new List<Alumnos>();
            Grupos TerceroBA = new Grupos("3BA", profes3BA, alumnos3BA);
            Grupos.agregarGrupo(TerceroBA);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);           
            Application.Run(Principal = new Login());
        }
    }
}
