using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ConfigurarEq
{
    class Datos
    {
        public Datos()
        {
            Cargar_Empleados();
            Cargar_Correos();
            Cargar_Programas();
        }

        public static List<String[]> Correos = new List<String[]>();
        public static List<String[]> Empleados = new List<String[]>();
        public static List<String[]> Programas = new List<String[]>();
        public static List<String[]> NombrePC = new List<String[]>();

        public static void Recargar_Programas()
        {
            Cargar_Programas();
        }
        
        private static void Cargar_Programas()
        {
            Programas.Clear();
            try
            {
                using (SqlConnection conexion2 = new SqlConnection(conexionsql_infeq))
                {

                    int contarceldas = 0;
                    conexion2.Open();
                    String sql2 = "SELECT * FROM ConfEq";
                    SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                    SqlDataReader nwReader2 = comm2.ExecuteReader();
                    while (nwReader2.Read())
                    {
                        String[] n = new String[6];

                        /*
                         * 1 = NOMBRE PROGRAMA
                         * 2 = FECHA DE CARGA
                         * 3 = ACTIVO
                         * 4 = SI SE ENCUENTRA EN RUTA
                         */
                        int activo = (Convert.ToInt32(nwReader2["activo"]) == 1) ? 1 : 0;
                        n[0] = nwReader2["programa"].ToString();
                        n[1] = nwReader2["fechacarga"].ToString();
                        n[2] = nwReader2["activo"].ToString();
                        if (!File.Exists(Application.StartupPath+"\\Instalar\\"+nwReader2["programa"].ToString()))
                        {
                            n[3] = "0";
                        }
                        else
                        {
                            n[3] = "1";
                        }
                        n[4] = nwReader2["comandos"].ToString();
                        n[5] = nwReader2["pid"].ToString();
                        Programas.Add(n);
                        contarceldas++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener tipos de compras.\n\nMensaje: " + ex.Message, "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cargar_Empleados()
        {
            Empleados.Clear();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionsqlnomina))
                {
                    conexion.Open();
                    SqlCommand comm = new SqlCommand(select_empleados, conexion);
                    SqlDataReader nwReader = comm.ExecuteReader();
                    while (nwReader.Read())
                    {
                        //String[] nombre_pc = new String[2];
                        String[] n = new String[10];
                        n[0] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nwReader["nombre"].ToString().ToLower());
                        n[1] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nwReader["paterno"].ToString().ToLower());
                        n[2] = (string.IsNullOrEmpty(nwReader["materno"].ToString())) ? "" : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nwReader["materno"].ToString().ToLower());
                        n[3] = n[0] + " " + n[1] + " " + n[2];
                        char nom = n[0][0];
                        String id;
                        if (string.IsNullOrEmpty(nwReader["materno"].ToString()))
                        {
                            id = nom.ToString() + n[1];
                        }
                        else
                        {
                            char a = n[2][0];
                            id = nom.ToString() + n[1] + a.ToString();
                        }
                        n[4] = id.ToLower();
                        n[5] = n[3].ToUpper();
                        n[6] = nwReader["email"].ToString();
                        n[7] = nwReader["ubicacion"].ToString();
                        n[8] = nwReader["cc"].ToString();
                        n[9] = nwReader["empresa"].ToString();
                        Empleados.Add(n);

                        /*
                        nombre_pc[0] = n[3];
                        nombre_pc[1] = n[4];
                        NombrePC.Add(nombre_pc);
                        */
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error en la busqueda en nomina\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cargar_Correos()
        {
            Correos.Clear();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionsql_infeq))
                {
                    conexion.Open();
                    SqlCommand comm = new SqlCommand("SELECT * FROM [InfEq].[dbo].[GetName] ORDER BY id DESC", conexion);
                    SqlDataReader nwReader = comm.ExecuteReader();
                    while (nwReader.Read())
                    {
                        String[] n = new String[6];
                        n[0] = nwReader["nombre"].ToString();
                        n[1] = nwReader["usuario"].ToString();
                        n[2] = nwReader["correo"].ToString();
                        n[3] = Desencriptar(nwReader["password"].ToString());
                        n[4] = nwReader["fecha"].ToString();
                        n[5] = nwReader["id"].ToString();
                        Correos.Add(n);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error en la busqueda\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Desencriptar(String textToDecrypt)
        {
            try
            {
                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "87654321";
                byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }



        //DATOS DE CONEXION A BD
        public static string conexion_sirac= "server=148.223.153.43\\MSSQLSERVER1; database=bd_SiRAc;User ID=sa;Password=At3n4; integrated security = false ; MultipleActiveResultSets=True";
        public static String conexionsql_infeq = "server=148.223.153.37,5314; database=InfEq;User ID=eordazs;Password=Corpame*2013; integrated security = false ; MultipleActiveResultSets=True";
        private String conexionsqlnomina = "server=40.76.105.1,5055; database=Nom2001;User ID=reportesUNNE;Password=8rt=h!RdP9gVy; integrated security = false ; MultipleActiveResultSets=True";
        private String select_empleados = "SELECT Ltrim(Rtrim(nombre))       AS nombre,        Ltrim(Rtrim(apepat))       AS paterno,        Ltrim(Rtrim(apemat))       AS materno,        Isnull(nompais.despai, '') AS [ubicacion],        Isnull(CC.desubi, '')      AS [cc],        Ltrim(Rtrim(nomtrab.email)) AS email,        Ltrim(Rtrim(nomcias.descor)) AS empresa " +
            "FROM   nomtrab        LEFT JOIN nomubic CC               ON nomtrab.cvepa2 = CC.cvepai                  AND nomtrab.cveci2 = CC.cveciu                  AND nomtrab.cvecia = CC.cvecia                  AND nomtrab.cveubi = CC.cveubi 	   LEFT JOIN nomcias               ON nomtrab.cvecia = nomcias.cvecia        " +
            "LEFT JOIN nompais                ON nomtrab.cvepa2 = nompais.cvepai                  AND nomtrab.cvecia = nompais.cvecia " +
            "WHERE  nomtrab.status = 'A' ";
    }
}
