using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Windows.Forms;

namespace ConfigurarEq
{
    class Office
    {
        public static String letra { get; set; }
        private static String iso { get; set; }
        public Office(String ruta)
        {
            Montar(ruta);
            iso = Application.StartupPath+"\\"+ruta;
        }

        private void Montar(String iso)
        {
            string isoPath = Application.StartupPath + "\\"+iso;
            //string isoPath = Application.StartupPath + "\\Instalar\\Office 2016 STD.iso";
            using (var ps = PowerShell.Create())
            {
                //Mount ISO Image
                var command = ps.AddCommand("Mount-DiskImage");
                command.AddParameter("ImagePath", isoPath);
                command.Invoke();
                ps.Commands.Clear();

                //Get Drive Letter ISO Image Was Mounted To
                var runSpace = ps.Runspace;
                var pipeLine = runSpace.CreatePipeline();
                var getImageCommand = new Command("Get-DiskImage");
                getImageCommand.Parameters.Add("ImagePath", isoPath);
                pipeLine.Commands.Add(getImageCommand);
                pipeLine.Commands.Add("Get-Volume");

                string driveLetter = null;
                foreach (PSObject psObject in pipeLine.Invoke())
                {
                    driveLetter = psObject.Members["DriveLetter"].Value.ToString();
                    //Console.WriteLine("Mounted On Drive: " + driveLetter);
                }
                pipeLine.Commands.Clear();
                letra = driveLetter;
                /*

                //Alternate Unmount Via Drive Letter
                ps.AddScript("$ShellApplication = New-Object -ComObject Shell.Application;" +
                    "$ShellApplication.Namespace(17).ParseName(\"" + driveLetter + ":\").InvokeVerb(\"Eject\")");
                ps.Invoke();
                ps.Commands.Clear();
                */
            }
        }

        public static void Desmontar()
        {
            using (var ps = PowerShell.Create())
            {
                var command = ps.AddCommand("Dismount-DiskImage");
                command.AddParameter("ImagePath", iso);
                ps.Invoke();
                ps.Commands.Clear();
            }
        }
    }
}
