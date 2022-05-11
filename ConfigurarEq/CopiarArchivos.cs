using Microsoft.Win32;
using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ConfigurarEq
{
    class CopiarArchivos
    {
        private String Escritorio { get; set; }
        private String Carpeta_Copiar { get; set; }
        private String Start_Menu { get; set; }
        private String Imagenes { get; set; }
        private String Bookmarks { get; set; }
        private String appdata { get; set; }

        public CopiarArchivos()
        {
            Environment.ExpandEnvironmentVariables("%AppData%");
            Escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            Imagenes = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\";
            Carpeta_Copiar = Application.StartupPath + "\\Instalar\\Copiar\\";
            Start_Menu = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu)+ "\\Programs\\";
            Bookmarks = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Microsoft\\Edge\\User Data\\Default\\";
            appdata = Environment.ExpandEnvironmentVariables("%AppData%\\Microsoft\\Internet Explorer\\Quick Launch\\User Pinned\\TaskBar\\");
        }

        public String CopiarTaskBand()
        {
            String[] office = { "Microsoft Edge.lnk", "Outlook 2016.lnk" };
            try
            {
                foreach (String off in office)
                {
                    System.IO.File.Copy(Start_Menu + off, appdata + off, true);
                }
                System.IO.File.Copy(Carpeta_Copiar+ "Taskband.lnk", appdata+ "File Explorer.lnk", true);
                return null;
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }
        
        public String Copiar_Office()
        {
            String[] office = { "Word 2016.lnk", "Excel 2016.lnk", "PowerPoint 2016.lnk", "Outlook 2016.lnk" };
            try
            {
                foreach (String off in office)
                {
                    System.IO.File.Copy(Start_Menu + off, Escritorio + off, true);
                }
                return null;
            }
            catch(Exception error)
            {
                return error.Message;
            }
        }

        public String Copiar_Bookmarks()
        {
            String[] books = { "Bookmarks", "Bookmarks.bak", "Bookmarks.msbak" };
            try
            {
                foreach (String book in books)
                {
                    System.IO.File.Copy(Carpeta_Copiar + book, Bookmarks + book, true);
                }
                return null;
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Establecer_Fondo()
        {
            try
            {
                System.IO.File.Copy(Carpeta_Copiar + "FONDO DE PANTALLA.jpg", Imagenes + "FONDO DE PANTALLA.jpg", true);
                SetWallpaper(Imagenes + "FONDO DE PANTALLA.jpg");
                System.IO.File.Copy(Carpeta_Copiar + "NAV.rdp", Escritorio + "NAV.rdp", true);
                System.IO.File.Copy(Carpeta_Copiar + "VerIP.exe", Imagenes + "VerIP.exe", true);

                return null;
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(
        UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);
        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;
        static public void SetWallpaper(String path)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            key.SetValue(@"WallpaperStyle", 2.ToString()); // 2 is stretched
            key.SetValue(@"TileWallpaper", 0.ToString());

            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
    }
}
