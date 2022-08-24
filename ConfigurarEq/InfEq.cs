using Microsoft.Win32;
using System;
using System.Collections;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ConfigurarEq
{
    internal class InfEq
    {
        public static String Marca;
        public static String Modelo;
        public static String Arquitectura;
        public static String SistemaOperativo;
        public static String Licencia_SistemaOperativo;
        public static String MemoriaRAM;
        public static String DDTotal;
        public static String DDLibre;
        public static String Procesador;
        public static String NumeroDeSerie;
        public static String Tipo;
        public static String Activo;

        public InfEq()
        {
            Marca = get_Marca();
            Modelo = get_Modelo();
            Arquitectura = get_Arquitectura();
            SistemaOperativo = get_SistemaOperativo();
            Licencia_SistemaOperativo = WinProdKeyFind.KeyDecoder.GetWindowsProductKeyFromRegistry();
            MemoriaRAM = Get_RamTotal().ToString();
            DDTotal = get_DiscoDuro(1);
            DDLibre = get_DiscoDuro(2);
            
            Procesador = get_Procesador();
            NumeroDeSerie = get_NumSerie();
            Tipo = get_Tipo();
            Activo = get_Activo();
            
        }

        public static string funcion_wmi(String database, String dato)
        {
            ConnectionOptions options = new ConnectionOptions();
            options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

            ManagementScope scope = new ManagementScope("\\\\" + Environment.MachineName.ToString() + "\\root\\cimv2", options);
            scope.Connect();

            ObjectQuery query = new ObjectQuery("SELECT * FROM " + database);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            String cadena = "";
            ManagementObjectCollection queryCollection = searcher.Get();
            foreach (System.Management.ManagementObject m in queryCollection)
            {
                cadena = m[dato].ToString();
            }
            dato = null;
            database = null;
            if (cadena.Equals(null))
            {
                return "Error";
            }
            return cadena;
        }

        private static String get_Activo()
        {
            try
            {
                using (SqlConnection conexion2 = new SqlConnection(Datos.conexion_sirac))
                {
                    conexion2.Open();
                    String sql2 = "SELECT * FROM [bd_SiRAc].[dbo].[LNJ_Equipos_Gilberto] where [No. Serie]='" + NumeroDeSerie + "'";
                    SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                    SqlDataReader nwReader2 = comm2.ExecuteReader();
                    while (nwReader2.Read())
                    {
                        return nwReader2["No. Activo"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return "S/N";
            }
            return "S/N";
        }

        private static String get_Marca()
        {
            String[] data = new string[] {
                    "Win32_ComputerSystem",
                    "Manufacturer",
                    "Sin Resultado"
                };
            return (funcion_wmi(data[0], data[1]) == "") ? data[2] : funcion_wmi(data[0], data[1]);
        }

        private static String get_Modelo()
        {
            String[] data = new string[] {
                    "Win32_ComputerSystem",
                    "Model",
                    "Sin Resultado"
                };
            return (funcion_wmi(data[0], data[1]) == "") ? data[2] : funcion_wmi(data[0], data[1]);
        }

        private static String get_Arquitectura()
        {
            String[] data = new string[] {
                    "Win32_OperatingSystem",
                    "OSArchitecture",
                    "Sin Resultado"
                };
            return (funcion_wmi(data[0], data[1]) == "") ? data[2] : funcion_wmi(data[0], data[1]);
        }

        private static String get_SistemaOperativo()
        {
            String[] data = new string[] {
                    "Win32_OperatingSystem",
                    "caption",
                    "Sin SO"
                };
            return (funcion_wmi(data[0], data[1]) == "") ? data[2] : funcion_wmi(data[0], data[1]);
        }

        private static Int64 Get_RamTotal()
        {
            InformacionRendimiento pi = new InformacionRendimiento();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
            {
                return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }

        }
        
        #region DATOS PARA RAM
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPerformanceInfo([Out] out InformacionRendimiento PerformanceInformation, [In] int Size);

        /// Estructura que nos sera regresada por el metodo GetPerformanceInfo
        [StructLayout(LayoutKind.Sequential)]
        public struct InformacionRendimiento
        {
            public int Size;
            public IntPtr CommitTotal;
            public IntPtr CommitLimit;
            public IntPtr CommitPeak;
            public IntPtr PhysicalTotal;
            public IntPtr PhysicalAvailable;
            public IntPtr SystemCache;
            public IntPtr KernelTotal;
            public IntPtr KernelPaged;
            public IntPtr KernelNonPaged;
            public IntPtr PageSize;
            public int HandlesCount;
            public int ProcessCount;
            public int ThreadCount;
        }
        #endregion

        private static String get_DiscoDuro(int n = 1)
        {
            long EspacioTotal = 0, EspacioDisponible = 0;
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == "C:\\")
                {
                    EspacioDisponible = ((drive.AvailableFreeSpace / 1024) / 1024) / 1024;
                    EspacioTotal = ((drive.TotalSize / 1024) / 1024) / 1024;
                }
            }
            if (n == 1)
            {
                return EspacioTotal.ToString();
            }
            else
            {
                return EspacioDisponible.ToString();
            }
        }

        private static String get_Procesador()
        {
            String[] data = new string[] {
                    "Win32_Processor",
                    "Name",
                    "Sin Resultado"
                };
            return (funcion_wmi(data[0], data[1]) == "") ? data[2] : funcion_wmi(data[0], data[1]);
        }

        private static String get_NumSerie()
        {
            String[] data = new string[] {
                   "Win32_BIOS",
                    "SerialNumber",
                    "Sin Resultado"
                };
            return (funcion_wmi(data[0], data[1]) == "") ? data[2] : funcion_wmi(data[0], data[1]);
        }

        private static String get_Tipo()
        {
            return (SystemInformation.PowerStatus.BatteryChargeStatus == BatteryChargeStatus.NoSystemBattery) ? "CPU" : "LAPTOP";
        }
        
        private static String get_Usuario()
        {
            String[] data = new string[] {
                   "Win32_ComputerSystem",
                    "UserName",
                    "Sin Resultado"
                };
            return (funcion_wmi(data[0], data[1]) == "") ? data[2] : funcion_wmi(data[0], data[1]);
        }

        public static bool SetMachineName(string newName)
        {
            RegistryKey key = Registry.LocalMachine;

            string activeComputerName = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName";
            RegistryKey activeCmpName = key.CreateSubKey(activeComputerName);
            activeCmpName.SetValue("ComputerName", newName);
            activeCmpName.Close();
            string computerName = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName";
            RegistryKey cmpName = key.CreateSubKey(computerName);
            cmpName.SetValue("ComputerName", newName);
            cmpName.Close();
            string _hostName = "SYSTEM\\CurrentControlSet\\services\\Tcpip\\Parameters\\";
            RegistryKey hostName = key.CreateSubKey(_hostName);
            hostName.SetValue("Hostname", newName);
            hostName.SetValue("NV Hostname", newName);
            hostName.Close();
            return true;
        }

        private static void Entrega_Equipos_Nuevos(String usuario)
        {
            try
            {
                using (SqlConnection conexion2 = new SqlConnection(Datos.conexionsql_infeq))
                {
                    conexion2.Open();
                    SqlCommand comm2 = new SqlCommand("SELECT * FROM [InfEq].[dbo].[ComprasEqComputo] where economico='" + Activo + "' AND entregada='0'", conexion2);
                    SqlDataReader nwReader2 = comm2.ExecuteReader();
                    while (nwReader2.Read())
                    {
                        String insert = "UPDATE ComprasEqComputo SET stock_disponible=@stock_disponible, entregada=@entregada, nombre_entrega=@nombre_entrega " +
                        "WHERE cid='" + nwReader2["cid"].ToString() + "'";

                        SqlCommand cmdIns_update = new SqlCommand(insert, conexion2);

                        cmdIns_update.Parameters.AddWithValue("@stock_disponible", "0");
                        cmdIns_update.Parameters.AddWithValue("@entregada", "1");
                        cmdIns_update.Parameters.AddWithValue("@nombre_entrega", usuario);

                        cmdIns_update.ExecuteNonQuery();
                        cmdIns_update.Parameters.Clear();

                        cmdIns_update.Dispose();
                        cmdIns_update = null;
                        break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("No hay entregas");
            }
        }

        private static void Insertar_Macs(int xid, SqlConnection conexion)
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nics)
            {
                String mac = string.Join(":", (from z in adapter.GetPhysicalAddress().GetAddressBytes() select z.ToString("X2")).ToArray());
                mac = string.IsNullOrEmpty(mac) ? "Sin Datos" : mac;

                string sqlInsMac = "INSERT INTO MacAddress (xid, Nombre, Address) VALUES (@xid, @nombremac, @macinterfas)";
                SqlCommand cmdInsMac = new SqlCommand(sqlInsMac, conexion);
                cmdInsMac.Parameters.Add("@xid", xid);
                cmdInsMac.Parameters.Add("@nombremac", adapter.Description.ToString());
                cmdInsMac.Parameters.Add("@macinterfas", mac);
                cmdInsMac.ExecuteNonQuery();

                cmdInsMac.Parameters.Clear();
                cmdInsMac.CommandText = "SELECT @@IDENTITY";
                cmdInsMac.Dispose();
                cmdInsMac = null;
            }
        }

        public static void Insertar_InfEq(String NombrePC, String empresa, String departamento, String localidad, String usuario, String Observaciones,
            int mantenimiento)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(Datos.conexionsql_infeq))
                {
                    String usernameequipo = get_Usuario();
                    String[] usuario_word = usernameequipo.Split('\\');

                    conexion.Open();
                    string sqlIns = "INSERT INTO equipos (uid, nombreequipo, marca, modelo, usuario, tipo, ram, ddtotal, ddlibre, so, licenciaso, procesador, " +
                                "arquitectura, numeroserie, empresa, departamento, base, nombre, fechainicio, fechatermino, horainicio, horatermino, fecha, hora, mes, year, observaciones, noactivo, mantenimiento)" +
                                " VALUES (@uid, @name, @marca, @modelo, @usuario, @tipo, @ram, @ddtotal, @ddlibre, @so, @licenciaso, @procesador, @arquitectura, @numeroserie, @empresa, " +
                                "@departamento, @base, @nombre, @fechainicio, @fechatermino, @horainicio, @horatermino, @fecha, @hora, @mes, @year, @observaciones, @noactivo, @tipomantenimiento)";

                    SqlCommand insertar = new SqlCommand(sqlIns, conexion);
                    insertar.Parameters.Add("@uid", 1); // Usuario Edson Ordaz
                    insertar.Parameters.Add("@name", NombrePC); 
                    insertar.Parameters.Add("@marca", Marca);
                    insertar.Parameters.Add("@modelo", Modelo);
                    insertar.Parameters.Add("@usuario", NombrePC + "\\" + usuario_word[1]);
                    insertar.Parameters.Add("@tipo", Tipo);
                    insertar.Parameters.Add("@ram", MemoriaRAM);
                    insertar.Parameters.Add("@so", SistemaOperativo);
                    insertar.Parameters.Add("@licenciaso", Licencia_SistemaOperativo);
                    insertar.Parameters.Add("@procesador", Procesador);
                    insertar.Parameters.Add("@arquitectura", Arquitectura);
                    insertar.Parameters.Add("@numeroserie", NumeroDeSerie);
                    insertar.Parameters.Add("@empresa", empresa);
                    insertar.Parameters.Add("@fecha", DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                    insertar.Parameters.Add("@hora", DateTime.Now.ToString("hh:mm tt", CultureInfo.InvariantCulture));
                    insertar.Parameters.Add("@ddtotal", DDTotal);
                    insertar.Parameters.Add("@ddlibre", DDLibre);
                    insertar.Parameters.Add("@departamento", departamento);
                    insertar.Parameters.Add("@base", localidad);
                    insertar.Parameters.Add("@nombre", usuario);

                    String fechainicio = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    insertar.Parameters.Add("@fechainicio", fechainicio);

                    double min;
                    // 1 = Correctivo, 2 = Preventivo, 3= Nuevo, 4 = cambio
                    switch(mantenimiento)
                    {
                        case 1:
                            min = -90;
                            break;
                        case 2:
                            min = -15;
                            break;
                        case 3:
                            min = -90;
                            break;
                        case 4:
                            min = -120;
                            break;

                        default:
                            min = -120;
                            break;
                    }
                    insertar.Parameters.Add("@horainicio", DateTime.Now.AddMinutes(min).ToString("hh:mm tt", CultureInfo.InvariantCulture));
                    insertar.Parameters.Add("@fechatermino", DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                    insertar.Parameters.Add("@horatermino", DateTime.Now.ToString("hh:mm tt", CultureInfo.InvariantCulture));
                    insertar.Parameters.Add("@observaciones", Observaciones);
                    insertar.Parameters.Add("@tipomantenimiento", mantenimiento);

                    insertar.Parameters.Add("@noactivo", Activo);

                    string[] words = fechainicio.Split('/');

                    insertar.Parameters.Add("@mes", DateTime.Now.ToString(words[1], CultureInfo.InvariantCulture));
                    insertar.Parameters.Add("@year", DateTime.Now.ToString(words[2], CultureInfo.InvariantCulture));

                    Entrega_Equipos_Nuevos(usuario);

                    insertar.ExecuteNonQuery();
                    insertar.Parameters.Clear();
                    insertar.CommandText = "SELECT @@IDENTITY";
                    int insertID = Convert.ToInt32(insertar.ExecuteScalar());

                    Insertar_Macs(insertID, conexion);

                    insertar.Dispose();
                    insertar = null;
                    Form1.log("InfEq guardado correctamente.");
                }
            }
            catch (Exception ex)
            {
                Form1.log("Error al guardar InfEq: " + ex.Message, true);
            }
        }

    }
}





namespace WinProdKeyFind
{
    /// <summary>
    /// Enumeration that specifies DigitalProductId version
    /// </summary>
    public enum DigitalProductIdVersion
    {
        /// <summary>
        /// All systems up to Windows 7 (Windows 7 and older versions)
        /// </summary>
        UpToWindows7,
        /// <summary>
        /// Windows 8 and up (Windows 8 and newer versions)
        /// </summary>
        Windows8AndUp
    }

    /// <summary>
    /// Provides methods to decode Windows Product Key from registry or from DigitalProductId.
    /// This class is static.
    /// </summary>
    public static class KeyDecoder
    {
        public static string GetWindowsProductKeyFromRegistry()
        {
            var localKey =
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem
                    ? RegistryView.Registry64
                    : RegistryView.Registry32);

            var registryKeyValue = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion")?.GetValue("DigitalProductId");
            if (registryKeyValue == null)
                return "Failed to get DigitalProductId from registry";
            var digitalProductId = (byte[])registryKeyValue;
            localKey.Close();
            var isWin8OrUp =
                Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor >= 2
                ||
                Environment.OSVersion.Version.Major > 6;
            return GetWindowsProductKeyFromDigitalProductId(digitalProductId,
                isWin8OrUp ? DigitalProductIdVersion.Windows8AndUp : DigitalProductIdVersion.UpToWindows7);
        }

        /// <summary>
        /// Decodes Windows Product Key from DigitalProductId with specified DigitalProductId version.
        /// </summary>
        /// <param name="digitalProductId"></param>
        /// <param name="digitalProductIdVersion"></param>
        /// <returns></returns>
        public static string GetWindowsProductKeyFromDigitalProductId(byte[] digitalProductId, DigitalProductIdVersion digitalProductIdVersion)
        {

            var productKey = digitalProductIdVersion == DigitalProductIdVersion.Windows8AndUp
                ? DecodeProductKeyWin8AndUp(digitalProductId)
                : DecodeProductKey(digitalProductId);
            return productKey;
        }

        /// <summary>
        /// Decodes Windows Product Key from the DigitalProductId. 
        /// This method applies to DigitalProductId from Windows 7 or lower versions of Windows.
        /// </summary>
        /// <param name="digitalProductId">DigitalProductId to decode</param>
        /// <returns>Decoded Windows Product Key as a string</returns>
        private static string DecodeProductKey(byte[] digitalProductId)
        {
            const int keyStartIndex = 52;
            const int keyEndIndex = keyStartIndex + 15;
            var digits = new[]
            {
                'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'M', 'P', 'Q', 'R',
                'T', 'V', 'W', 'X', 'Y', '2', '3', '4', '6', '7', '8', '9',
            };
            const int decodeLength = 29;
            const int decodeStringLength = 15;
            var decodedChars = new char[decodeLength];
            var hexPid = new ArrayList();
            for (var i = keyStartIndex; i <= keyEndIndex; i++)
            {
                hexPid.Add(digitalProductId[i]);
            }
            for (var i = decodeLength - 1; i >= 0; i--)
            {
                if ((i + 1) % 6 == 0)
                {
                    decodedChars[i] = '-';
                }
                else
                {
                    var digitMapIndex = 0;
                    for (var j = decodeStringLength - 1; j >= 0; j--)
                    {
                        var byteValue = (digitMapIndex << 8) | (byte)hexPid[j];
                        hexPid[j] = (byte)(byteValue / 24);
                        digitMapIndex = byteValue % 24;
                        decodedChars[i] = digits[digitMapIndex];
                    }
                }
            }
            return new string(decodedChars);
        }

        /// <summary>
        /// Decodes Windows Product Key from the DigitalProductId. 
        /// This method applies to DigitalProductId from Windows 8 or newer versions of Windows.
        /// </summary>
        /// <param name="digitalProductId">DigitalProductId to decode</param>
        /// <returns>Decoded Windows Product Key as a string</returns>
        public static string DecodeProductKeyWin8AndUp(byte[] digitalProductId)
        {
            var key = String.Empty;
            const int keyOffset = 52;
            var isWin8 = (byte)((digitalProductId[66] / 6) & 1);
            digitalProductId[66] = (byte)((digitalProductId[66] & 0xf7) | (isWin8 & 2) * 4);

            const string digits = "BCDFGHJKMPQRTVWXY2346789";
            var last = 0;
            for (var i = 24; i >= 0; i--)
            {
                var current = 0;
                for (var j = 14; j >= 0; j--)
                {
                    current = current * 256;
                    current = digitalProductId[j + keyOffset] + current;
                    digitalProductId[j + keyOffset] = (byte)(current / 24);
                    current = current % 24;
                    last = current;
                }
                key = digits[current] + key;
            }

            var keypart1 = key.Substring(1, last);
            var keypart2 = key.Substring(last + 1, key.Length - (last + 1));
            key = keypart1 + "N" + keypart2;

            for (var i = 5; i < key.Length; i += 6)
            {
                key = key.Insert(i, "-");
            }

            return key;
        }
    }
}

