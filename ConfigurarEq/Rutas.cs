using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigurarEq
{
    internal class Rutas
    {
        public static String TaskBand { get; set; }
        public static String Certificado { get; set; }
        public static String FondoDePantalla { get; set; }
        public static String Kaspersky_Config { get; set; }
        public static String Kaspersky_Licencia { get; set; }
        public static String Office_Licencia { get; set; }

        public Rutas()
        {
            using (SqlConnection conexion2 = new SqlConnection(Datos.conexionsql_infeq))
            {
                conexion2.Open();
                String sql2 = "SELECT * FROM ConfEq_rutas";
                SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                SqlDataReader nwReader2 = comm2.ExecuteReader();


                while (nwReader2.Read())
                {
                    String ruta = nwReader2["ruta"].ToString().Replace("$path", Application.StartupPath);

                    switch (nwReader2["comentario"].ToString().ToUpper())
                    {
                        case "CERTIFICADO":
                            Certificado = ruta;
                            break;
                        case "FONDO DE PANTALLA":
                            FondoDePantalla = ruta;
                            break;
                        case "TASKBAND":
                            TaskBand = ruta;
                            break;
                        case "KASPERSKY CONFIG":
                            Kaspersky_Config = ruta;
                            break;
                        case "KASPERSKY LICENCIA":
                            Kaspersky_Licencia = ruta;
                            break;
                        case "OFFICE LICENCIA":
                            Office_Licencia = ruta;
                            break;
                    }
                }
            }
        }
    }
}
