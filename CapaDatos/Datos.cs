using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace CapaDatos
{
    public class Datos
    {
        public Datos()
        {

        }

        public static void crearConexion()
        {
            MySqlConnection conexion = new MySqlConnection("Server = localhost ; uid = root ;pwd = ; database = bdmessages");
            conexion.Open();

            MySqlCommand agregar = new MySqlCommand("INSERT INTO alumno (CI, Nickname) VALUES (pedro, pedro12)");
        }


        public void RegistrarAlumno()
        {

        }

    }
}
