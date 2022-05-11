using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using WUApiLib;

/*
V1.0.0
 - Aplicacion para configurar equipos de computo nuevos.

*/
namespace ConfigurarEq
{
    public partial class Form1 : Form
    {
        private String versiontext = "1.0.0";
        private String version = "fb598a3878e263d369925b9ceb4f4ee8044ececd";
        public Form1()
        {
            InitializeComponent();
        }

        public static String path_log_errores = Application.StartupPath + @"\ConfEq_Errores.log";
        public static String path_log = Application.StartupPath + @"\ConfEq.log";
        public static String Carpeta_Instalar = Application.StartupPath + "\\Instalar";
        static Rutas Rutas = new Rutas();
        private static Boolean permitir_cerrar = true;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            if(File.Exists(path_log_errores))
            {
                File.Delete(path_log_errores);
            }
            if(File.Exists(path_log))
            {
                File.Delete(path_log);
            }
            if (!Directory.Exists(Carpeta_Instalar))
            {
                MessageBox.Show("No se puede ejecutar esta aplicacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            //this.TopMost = true;
            #region inicio
            richTextBox1.Visible = false;
            txt_instalando.Text = "";
            txt_instalando.Visible = false;
            img_cargando.Visible = false;
            this.Enabled = false;
            if (inicio.IsBusy != true)
            {
                inicio.RunWorkerAsync();
            }
            #endregion
        }

        private void administrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrar administracion = new Administrar();
            administracion.ShowDialog();
            Recargar_Lista_Programas();
        }

        void AutoCompletar_Empleado()
        {
            if (Datos.Empleados.Any())
            {
                AutoCompleteStringCollection lista_puesto = new AutoCompleteStringCollection();
                foreach (String[] n in Datos.Empleados)
                {
                    lista_puesto.Add(n[3]);
                }
                usuario.AutoCompleteCustomSource = lista_puesto;
            }

            if (Datos.Correos.Any())
            {
                AutoCompleteStringCollection lista_correo_collection = new AutoCompleteStringCollection();
                foreach (String[] n in Datos.Correos)
                {
                    lista_correo_collection.Add(n[2]);
                }
                correo.AutoCompleteCustomSource = lista_correo_collection;
            }

        }
        
        private void Verificar_version_programa()
        {
            try
            {
                using (SqlConnection conexion2 = new SqlConnection(Datos.conexionsql_infeq))
                {
                    conexion2.Open();
                    String sql2 = "SELECT (SELECT valor FROM Configuracion WHERE nombre='ConfEq_Version') as version,valor FROM Configuracion WHERE nombre='ConfEq_hash'";
                    SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                    SqlDataReader nwReader2 = comm2.ExecuteReader();
                    if (nwReader2.Read())
                    {
                        if (nwReader2["valor"].ToString() != version)
                        {
                            MessageBox.Show("No se puede inciar sesion porque hay una nueva version.\n\nNueva Version: " + nwReader2["version"].ToString() + "\nVersion actual: " + versiontext + "\n\nEl programa se cerrara.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            System.Windows.Forms.Application.Exit();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puedo verificar la version del programa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Windows.Forms.Application.Exit();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en validar la version del programa\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
                return;
            }
        }
        
        private void inicio_DoWork(object sender, DoWorkEventArgs e)
        {
            Verificar_version_programa();
            InfEq InfEq_iniciar = new InfEq();
            Datos Datos = new Datos();
        }

        private void inicio_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AutoCompletar_Empleado();
            Recargar_Lista_Programas();
            this.Enabled = true;
            usuario.Focus();
        }
        
        private void Recargar_Lista_Programas()
        {
            dataGridView1.Rows.Clear();
            if (Datos.Programas.Any())
            {
                int contarceldas = 0;
                int fila = 0;
                foreach (String[] programs in Datos.Programas)
                {
                    int existe = (Convert.ToInt32(programs[3]) == 0) ? 0 : 1;
                    int activo = (Convert.ToInt32(programs[3]) == 0) ? 0 : Convert.ToInt32(programs[2]);

                    dataGridView1.Rows.Add(fila, activo, programs[0], programs[1], existe);
                    if (Convert.ToInt32(programs[3]) == 0)
                    {
                        dataGridView1.Rows[contarceldas].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                    contarceldas++;
                    fila++;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                if(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["existe"].Value) == 1)
                {
                    dataGridView1.Rows[e.RowIndex].Cells["activo"].Value = (Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["activo"].Value) == 1) ? 0 : 1;
                }
            }
        }
        
        private void iniciar_Click(object sender, EventArgs e)
        {

            if (File.Exists(path_log_errores))
            {
                File.Delete(path_log_errores);
            }
            if (File.Exists(path_log))
            {
                File.Delete(path_log);
            }
            if (!Directory.Exists(Carpeta_Instalar))
            {
                MessageBox.Show("No se puede ejecutar porque ya no existen los programas ni archivos de configuracion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(check_cambiarnombreequipo.Checked == true && String.IsNullOrEmpty(nombrepc.Text))
            {
                MessageBox.Show("Para cambiar el nombre del equipo no puede estar vacio el campo Nombre PC.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(check_infeq.Checked == true && String.IsNullOrEmpty(usuario.Text))
            {
                MessageBox.Show("Para guardar informacion en InfEq no puede estar vacio el campo Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            permitir_cerrar = false;
            if (configurando.IsBusy != true)
            {
                menuStrip1.Enabled = false;
                usuario.Enabled = false;
                panel_checks.Enabled = false;
                panel_txtbox.Enabled = false;
                txt_instalando.Visible = true;
                dataGridView1.Visible = false;
                img_cargando.Visible = true;

                configurando.RunWorkerAsync();
            }
        }
        
        private void Instalando(int fila)
        {
            Process process = new Process();
            process.StartInfo.FileName = Application.StartupPath + "\\Instalar\\" + Datos.Programas[fila][0];

            //REMPLAZA $PATH POR RUTA DEL PROGRAMA
            String argumentos = Datos.Programas[fila][4].Replace("$path", Application.StartupPath);


            if (Datos.Programas[fila][4].ToString().ToUpper() == "OFFICE")
            {
                txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Montando " + Datos.Programas[fila][0]; }));
                Office office = new Office("\\Instalar\\"+Datos.Programas[fila][0]);
                process.StartInfo.FileName = Office.letra + ":\\setup.exe";
                argumentos = "";
            }
            txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Instalando " + Datos.Programas[fila][0]; }));

            process.StartInfo.Arguments = argumentos;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();

            if (Datos.Programas[fila][4].ToString().ToUpper() == "OFFICE")
            {
                Office.Desmontar();
            }
            txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = ""; }));

        }

        private void configurando_DoWork(object sender, DoWorkEventArgs e)
        {
            CopiarArchivos copiar_archivo = new CopiarArchivos();

            #region INSTALANDO PROGRAMAS
            foreach (DataGridViewRow programas in dataGridView1.Rows)
            {
                if (Convert.ToInt32(programas.Cells["activo"].Value.ToString()) == 1)
                {
                    try
                    {
                        Instalando(Convert.ToInt32(programas.Cells["fila"].Value));
                        log(programas.Cells["programa"].Value.ToString() + " instalado correctamente.");
                    }
                    catch (Exception error)
                    {
                        log("Error al instalar " + programas.Cells["programa"].Value.ToString()+": "+error.Message, true);
                        MessageBox.Show("Error al instalar " + programas.Cells["programa"].Value.ToString() + "\n\nERROR: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            #endregion

            #region CAMBIAR NOMBRE DEL EQUIPO
            if (check_cambiarnombreequipo.Checked == true)
            {
                try
                {
                    txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Cambiando Nombre del Equipo"; }));
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");
                    foreach (System.Management.ManagementObject queryObj in searcher.Get())
                    {
                        queryObj["Description"] = usuario.Text;
                        queryObj.Put();
                    }
                    InfEq.SetMachineName(nombrepc.Text);
                    log("Nombre del equipo cambiado correctamente.");
                }
                catch (Exception error)
                {
                    log("Error al cambiar el nombre del equipo: "+error.Message, true);
                    txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Error al cambiar nombre del equipo"; }));
                }
            }
            #endregion

            #region GUARDAR INFEQ
            if (check_infeq.Checked == true)
            {
                // 1 = Correctivo, 2 = Preventivo, 3= Nuevo, 4 = cambio
                int mantto = 0;
                if (radio_correctivo.Checked == true)
                {
                    mantto = 1;
                }
                if (radio_preventivo.Checked == true)
                {
                    mantto = 2;
                }
                if (radio_equiponuevo.Checked == true)
                {
                    mantto = 3;
                }
                if (radio_cambiarequipo.Checked == true)
                {
                    mantto = 4;
                }
                String observaciones = (String.IsNullOrEmpty(txt_observaciones.Text)) ? "Sin Observaciones" : txt_observaciones.Text;
                InfEq.Insertar_InfEq(nombrepc.Text, txt_empresa.Text, txt_departamento.Text, txt_base.Text, usuario.Text, observaciones, mantto);
            }
            #endregion

            #region INSTALAR CERTIFICADO
            if (check_certificado.Checked == true)
            {
                try
                {
                    txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Instalando certificado"; }));
                    Process p_certificado = new Process();
                    p_certificado.StartInfo.RedirectStandardOutput = true;
                    p_certificado.StartInfo.RedirectStandardError = true;
                    p_certificado.StartInfo.UseShellExecute = false;

                    p_certificado.StartInfo.FileName = "powershell";
                    p_certificado.StartInfo.Arguments = "import-Certificate -FilePath '" + Rutas.Certificado + "' -CertStoreLocation Cert:\\LocalMachine\\Root";
                    p_certificado.Start();

                    //string stdoutx = p_certificado.StandardOutput.ReadToEnd();
                    string stderrx = p_certificado.StandardError.ReadToEnd();
                    p_certificado.WaitForExit();
                    if (p_certificado.ExitCode == 1)
                    {
                        //MessageBox.Show("error: " + stderrx);
                        log("Error al cargar certificado: " + stderrx, true);
                    }
                    else
                    {
                        log("Certificado Instalado");
                    }
                }
                catch (Exception error)
                {
                    log("Error al instalar certificado: " + error.Message, true);
                }
            }
            #endregion

            #region PONER FONDO DE PANTALLA
            if (check_fondodepantalla.Checked == true)
            {
                txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Estableciendo fondo de pantalla"; }));
                String PonerFondo = copiar_archivo.Establecer_Fondo();
                if (!String.IsNullOrEmpty(PonerFondo))
                {

                    log("Error al establecer fondo: " + PonerFondo, true);
                    //this.Invoke((Func<DialogResult>)(() => MessageBox.Show("Error al establecer fondo de pantalla\nERROR:" + PonerFondo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                }
                else
                {
                    log("Fondo de pantalla cambiado.");
                }
            }
            #endregion

            #region COPIAR BOOKMARKS
            if (check_marcadores.Checked == true)
            {
                txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Copiando Marcadores de Edge"; }));
                String CopiarBooks = copiar_archivo.Copiar_Bookmarks();
                if (!String.IsNullOrEmpty(CopiarBooks))
                {
                    log("Error al copiar BookMarks: " + CopiarBooks, true);
                    //this.Invoke((Func<DialogResult>)(() => MessageBox.Show("Error al copiar Bookmarks de Edge\nERROR:" + CopiarBooks, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                }
                else
                {
                    log("BookMarks agregados a EDGE");
                }
            }
            #endregion

            #region COPIAR ACCESOS DE OFFICES
            if (check_accesosoffice.Checked == true)
            {
                txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Copiando Accesos de Office"; }));
                String CopiarOffice = copiar_archivo.Copiar_Office();
                if (!String.IsNullOrEmpty(CopiarOffice))
                {
                    log("Error al copiar accesos directos de Office: " + CopiarOffice, true);
                    //this.Invoke((Func<DialogResult>)(() => MessageBox.Show("Error al copiar accesos directos de office\nERROR:" + CopiarOffice, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                }
                else
                {
                    log("Accesos directos de office copiados");
                }
            }
            #endregion

            #region HABILITANDO USUARIO ADMINISTRADOR
            if (check_usuarioadmin.Checked == true)
            {
                try
                {
                    txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Habilitando usuario Administrador"; }));
                    CMD("net user Administrador /active:yes");
                    CMD("net user Administrador Corpame*2013");
                    log("Usuario Administrador habilitado.");
                }
                catch(Exception ex)
                {
                    log("Error al habilitar usuario Administrador: "+ex.Message, true);
                }
            }
            #endregion

            #region CREAR PUNTO DE RESTAURACION
            if (check_puntoderestauracion.Checked == true)
            {
                try
                {
                    txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Creando punto de restauracion"; }));


                    Process p_habilitarpunto = new Process();
                    p_habilitarpunto.StartInfo.RedirectStandardOutput = true;
                    p_habilitarpunto.StartInfo.RedirectStandardError = true;
                    p_habilitarpunto.StartInfo.UseShellExecute = false;

                    p_habilitarpunto.StartInfo.FileName = "powershell";
                    p_habilitarpunto.StartInfo.Arguments = @"enable-computerrestore -drive C:\";
                    p_habilitarpunto.Start();

                    //string stdoutx = p_habilitarpunto.StandardOutput.ReadToEnd();
                    string error_habilitarp = p_habilitarpunto.StandardError.ReadToEnd();
                    p_habilitarpunto.WaitForExit();

                    if (p_habilitarpunto.ExitCode == 1)
                    {
                        log("Error al habilitar proteccion al sistema: " + error_habilitarp, true);
                        //MessageBox.Show("error: " + error_habilitarp);
                    }
                    else
                    {
                        log("Proteccion a sistema habilitada.");
                    }

                    Process p_punto_restauracion = new Process();
                    p_punto_restauracion.StartInfo.RedirectStandardOutput = true;
                    p_punto_restauracion.StartInfo.RedirectStandardError = true;
                    p_punto_restauracion.StartInfo.UseShellExecute = false;

                    p_punto_restauracion.StartInfo.FileName = "powershell";
                    p_punto_restauracion.StartInfo.Arguments = "Checkpoint-Computer -Description 'INICIAL'";
                    p_punto_restauracion.Start();

                    //string stdoutx = p_punto_restauracion.StandardOutput.ReadToEnd();
                    string error_presturacion = p_punto_restauracion.StandardError.ReadToEnd();
                    p_punto_restauracion.WaitForExit();

                    if (p_punto_restauracion.ExitCode == 1)
                    {
                        log("Error al crear punto 'INICIAL': " + error_presturacion, true);
                        //MessageBox.Show("error: " + error_presturacion);
                    }
                    else
                    {
                        log("Punto de restauracion 'INICIAL' creado.");
                    }
                }
                catch (Exception ex)
                {
                    log("Error al crear punto de restauracion: " + ex.Message, true);
                }
            }
            #endregion

            #region CONFIGURANDO KASPERSKY
            if (check_importarkaspersky.Checked == true)
            {
                try
                {
                    txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Configurando Kaspersky"; }));
                    Process p_configkaspersky = new Process();
                    p_configkaspersky.StartInfo.RedirectStandardOutput = true;
                    p_configkaspersky.StartInfo.RedirectStandardError = true;
                    p_configkaspersky.StartInfo.UseShellExecute = false;

                    p_configkaspersky.StartInfo.FileName = @"C:\Program Files (x86)\Kaspersky Lab\Kaspersky Endpoint Security for Windows\avp.com";
                    p_configkaspersky.StartInfo.Arguments = "IMPORT \"" + Rutas.Kaspersky_Config + "\" /login=UNNE /password=Unne*1234";
                    p_configkaspersky.Start();

                    //string stdoutx = p_configkaspersky.StandardOutput.ReadToEnd();
                    string error_configkaspersky = p_configkaspersky.StandardError.ReadToEnd();
                    p_configkaspersky.WaitForExit();

                    if (p_configkaspersky.ExitCode == 1)
                    {
                        log("Error al importar configuracion de Kaspersky: " + error_configkaspersky, true);
                        //MessageBox.Show("error: " + error_configkaspersky);
                    }
                    else
                    {
                        log("Kaspersky, configuracion importanda.");
                    }
                }
                catch (Exception ex)
                {
                    log("Error al importar configuracion de Kaspersky: " + ex.Message, true);
                }
            }
            #endregion

            #region LICENCIA KASPERSKY
            if (check_activarkaspersky.Checked == true)
            {
                try
                {
                    txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Activando Kaspersky"; }));
                    Process p_licenciakaspersky = new Process();
                    p_licenciakaspersky.StartInfo.RedirectStandardOutput = true;
                    p_licenciakaspersky.StartInfo.RedirectStandardError = true;
                    p_licenciakaspersky.StartInfo.UseShellExecute = false;

                    p_licenciakaspersky.StartInfo.FileName = @"C:\Program Files (x86)\Kaspersky Lab\Kaspersky Endpoint Security for Windows\avp.com";
                    p_licenciakaspersky.StartInfo.Arguments = "license /ADD \"" + Rutas.Kaspersky_Licencia + "\"";
                    p_licenciakaspersky.Start();

                    //string stdoutx = p_licenciakaspersky.StandardOutput.ReadToEnd();
                    string error_licenciakaspersky = p_licenciakaspersky.StandardError.ReadToEnd();
                    p_licenciakaspersky.WaitForExit();

                    if (p_licenciakaspersky.ExitCode == 1)
                    {
                        log("Error al insertar licencia de Kaspersky: " + error_licenciakaspersky, true);
                    }
                    else
                    {
                        log("Kaspersky, licencia activada.");
                    }
                }
                catch(Exception ex)
                {
                    log("Error al insertar licencia de Kaspersky: " + ex.Message, true);
                }
            }
            #endregion

            #region ACTUALIZANDO KASPERSKY
            if (check_actualizarkaspersky.Checked == true)
            {
                try
                {
                    txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Actualizando Kaspersky"; }));
                    richTextBox1.BeginInvoke(new System.Action(() => { richTextBox1.Visible = true; }));
                    CMD("\"C:\\Program Files (x86)\\Kaspersky Lab\\Kaspersky Endpoint Security for Windows\\avp.com\" UPDATE");
                    richTextBox1.BeginInvoke(new System.Action(() => { richTextBox1.Visible = false; }));
                    log("Kaspersky, actualizado correctamente.");
                }
                catch (Exception ex)
                {
                    log("Error al actualizar Kaspersky: "+ex.Message, true);
                }
            }
            #endregion

            #region ACTUALIZANDO TASKBAND
            if (check_actualizartaskband.Checked == true)
            {
                try
                {
                    txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Modificando TaskBand"; }));

                    List<string> strFiles = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar", "*", SearchOption.AllDirectories).ToList();
                    foreach (string fichero in strFiles)
                    {
                        File.Delete(fichero);
                    }
                    Registry.CurrentUser.DeleteSubKeyTree(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Taskband");

                    RegistryKey key1 = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Search");
                    key1.SetValue("SearchboxTaskbarMode", 0);
                    key1.Close();
                    RegistryKey key2 = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced");
                    key2.SetValue("ShowCortanaButton", 0);
                    key2.Close();

                    String CopiarTaskBand = copiar_archivo.CopiarTaskBand();
                    if (!String.IsNullOrEmpty(CopiarTaskBand))
                    {
                        log("Error al copiar accesos de TaskBand: " + CopiarTaskBand, true);
                        //this.Invoke((Func<DialogResult>)(() => MessageBox.Show("Error al copiar accesos directos de TaskBand\nERROR:" + CopiarTaskBand, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                    }


                    Process regeditProcess = Process.Start("regedit.exe", "/s \"" + Rutas.TaskBand + "\"");
                    regeditProcess.WaitForExit();

                    CMD("taskkill /f /im explorer.exe");
                    string explorer = string.Format("{0}\\{1}", Environment.GetEnvironmentVariable("WINDIR"), "explorer.exe");
                    Process process3 = new Process();
                    process3.StartInfo.FileName = explorer;
                    process3.StartInfo.UseShellExecute = true;
                    process3.Start();
                    log("TaskBand actualizado.");
                }
                catch (Exception ex)
                {
                    log("Error al actualizar TaskBand: "+ex.Message, true);
                }
            }
            #endregion

            #region ACTIVANDO OFFICE
            if (check_activaroffice.Checked == true)
            {
                try
                {
                    txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Activando Office"; }));
                    //CMD("cscript \"C:\\Program Files\\Microsoft Office\\Office16\\ospp.vbs\" /inpkey:" + Rutas.Office_Licencia + "");

                    Process p_activaroffice = new Process();
                    p_activaroffice.StartInfo.RedirectStandardOutput = true;
                    p_activaroffice.StartInfo.RedirectStandardError = true;
                    p_activaroffice.StartInfo.UseShellExecute = false;

                    p_activaroffice.StartInfo.FileName = "cscript";
                    p_activaroffice.StartInfo.Arguments = "\"C:\\Program Files\\Microsoft Office\\Office16\\ospp.vbs\" /inpkey:" + Rutas.Office_Licencia;
                    p_activaroffice.Start();

                    //string stdoutx = p_configkaspersky.StandardOutput.ReadToEnd();
                    string error_activaroffice = p_activaroffice.StandardError.ReadToEnd();
                    p_activaroffice.WaitForExit();

                    if (p_activaroffice.ExitCode == 1)
                    {
                        log("Error al activar office: " + error_activaroffice, true);
                        //MessageBox.Show("error: " + error_configkaspersky);
                    }
                    else
                    {
                        log("Office Activado");
                    }
                }
                catch(Exception ex)
                {
                    log("Error al activar Office: " + ex.Message, true);
                }
            }
            #endregion

            #region WINDOWS UPDATE
            if (check_windowsupdate.Checked == true)
            {
                try
                {
                    this.Invoke(new Action(() => { richTextBox1.Text = "Iniciando Windows Update"; }));
                    txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Actualizando Sistema"; }));
                    richTextBox1.BeginInvoke(new System.Action(() => { richTextBox1.Visible = true; }));
                    UpdatesAvailable();
                    if (NeedsUpdate())
                    {
                        EnableUpdateServices();
                        InstallUpdates(DownloadUpdates());
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            richTextBox1.Text += "\nNo hay actualizaciones para su equipo en este momento.";
                        }));
                        Console.WriteLine("\nThere are no updates for your computer at this time.");
                    }
                    log("Windows Update ejecutado correctamente.");
                }
                catch(Exception ex)
                {
                    log("Error al ejecutar Windows Update: " + ex.Message, true);
                    richTextBox1.Text += "\nERROR AL EJECUTAR WINDOWS UPDATE: "+ex.Message;
                }
            }
            #endregion

            #region ELIMINAR CARPETA AL TERMINAR
            if (check_eliminarcarpeta.Checked == true)
            {
                try
                {
                    if (Directory.Exists(Application.StartupPath + "\\Instalar"))
                    {
                        Directory.Delete(Application.StartupPath + "\\Instalar", true);
                        log("Carpeta de instalacion eliminada.");
                    }
                }
                catch (Exception ex)
                {
                    log("Error al eliminar carpeta de instalacion: "+ex.Message, true);
                }
            }
            #endregion

            #region OCULTAR ACCESOS RAPIDOS
            try
            {
                txt_instalando.BeginInvoke(new System.Action(() => { txt_instalando.Text = "Ocultando accesos rapidos"; }));
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer");
                key.SetValue("ShowFrequent", 0);
                key.SetValue("ShowRecent", 0);
                key.Close();
                //log("Accesos rapidos de carpetas Ocultos");
            }
            catch(Exception ex)
            {
                log("Error al ocultar accesos rapidos de carpeta: "+ex.Message,true);
            }
            #endregion

        }

        private void configurando_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(File.Exists(path_log_errores))
            {
                LogErrores Log_Errores = new LogErrores();
                Log_Errores.ShowDialog();
            }
            if (File.Exists(path_log))
            {
                DialogResult msj = MessageBox.Show("Proceso finalizado.\n¿Quieres ver el Log de instalacion?", "ConfEq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msj == DialogResult.Yes)
                {
                    Log log_instalacion = new Log();
                    log_instalacion.ShowDialog();
                }
            }
            richTextBox1.Visible = false;
            dataGridView1.Visible = true;
            txt_instalando.Text = "Proceso finalizado";
            txt_instalando.Visible = false;

            menuStrip1.Enabled = true;
            usuario.Enabled = true;
            img_cargando.Visible = false;
            panel_checks.Enabled = true;
            panel_txtbox.Enabled = true;

            permitir_cerrar = true;
        }
        
        private void CMD(String command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe")
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            startInfo.Arguments = @"/C " + command;
            Process process = Process.Start(startInfo);
            process.OutputDataReceived += new DataReceivedEventHandler((_sender, _e) =>
            {
                if (!String.IsNullOrEmpty(_e.Data))
                {
                    Console.WriteLine(_e.Data);
                    this.Invoke(new Action(() =>
                    {
                        richTextBox1.Text += _e.Data + "\n\n";
                    }));
                }
            });
            process.BeginOutputReadLine();
            process.WaitForExit();
        }

        //Auto scroll en richtext
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (permitir_cerrar == false)
            {
                switch (e.CloseReason)
                {
                    case CloseReason.UserClosing:
                        e.Cancel = true;
                        MessageBox.Show("No se puede cerrar la aplicacion mientras este configurando.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            if (File.Exists(path_log))
            {
                File.Delete(path_log);
            }
            if (File.Exists(path_log_errores))
            {
                File.Delete(path_log_errores);
            }
        }

        private void soloActualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check_usuarioadmin.Checked = false;
            check_puntoderestauracion.Checked = false;
            check_marcadores.Checked = false;
            check_importarkaspersky.Checked = false;
            check_fondodepantalla.Checked = false;
            check_certificado.Checked = false;
            check_actualizartaskband.Checked = false;
            check_actualizarkaspersky.Checked = false;
            check_activaroffice.Checked = false;
            check_activarkaspersky.Checked = false;
            check_accesosoffice.Checked = false;
            check_eliminarcarpeta.Checked = false;
            check_cambiarnombreequipo.Checked = false;
            check_infeq.Checked = false;   

            int celda = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.Rows[celda].Cells["activo"].Value = 0;
                celda++;
            }
        }

        private void usuario_Leave(object sender, EventArgs e)
        {
            if(Datos.Empleados.Any())
            {
                foreach(String[] empleado in Datos.Empleados)
                {
                    if (usuario.Text == empleado[3].ToUpper())
                    {
                        nombrepc.Text = empleado[4];
                        txt_departamento.Text = empleado[8];
                        txt_base.Text = empleado[7];
                        txt_empresa.Text = empleado[9];
                    }
                }
            }
        }
                
        public static void log(String texto, Boolean Error=false)
        {
            if (!String.IsNullOrEmpty(texto))
            {
                String path = (Error == true) ? path_log_errores : path_log;
                if (!File.Exists(path))
                {
                    using (StreamWriter escribir = File.CreateText(path))
                    {
                        escribir.WriteLine("*****"+texto);
                    }
                }
                else
                {
                    using (StreamWriter agregar = new StreamWriter(path, true))
                    {
                        agregar.WriteLine("*****" + texto);
                    }
                }
            }
        }
        
        #region FUNCIONES DE WINDOWS UPDATE
        public void UpdatesAvailable()
        {
            UpdateSession UpdateSession = new UpdateSession();
            IUpdateSearcher UpdateSearchResult = UpdateSession.CreateUpdateSearcher();
            UpdateSearchResult.Online = true;//checks for updates online
            ISearchResult SearchResults = UpdateSearchResult.Search("IsInstalled=0 AND IsPresent=0");
            //for the above search criteria refer to 
            //http://msdn.microsoft.com/en-us/library/windows/desktop/aa386526(v=VS.85).aspx
            //Check the remakrs section

            foreach (IUpdate x in SearchResults.Updates)
            {
                this.Invoke(new Action(() =>
                {
                    richTextBox1.Text += "\n" + x.Title;
                }));
                Console.WriteLine(x.Title);
            }
        }
        public static bool NeedsUpdate()
        {
            UpdateSession UpdateSession = new UpdateSession();
            IUpdateSearcher UpdateSearchResult = UpdateSession.CreateUpdateSearcher();
            UpdateSearchResult.Online = true;//checks for updates online
            ISearchResult SearchResults = UpdateSearchResult.Search("IsInstalled=0 AND IsPresent=0");
            //for the above search criteria refer to 
            //http://msdn.microsoft.com/en-us/library/windows/desktop/aa386526(v=VS.85).aspx
            //Check the remakrs section
            if (SearchResults.Updates.Count > 0)
                return true;
            else return false;
        }
        public void EnableUpdateServices()
        {
            IAutomaticUpdates updates = new AutomaticUpdates();
            if (!updates.ServiceEnabled)
            {
                this.Invoke(new Action(() =>
                {
                    richTextBox1.Text += "\nNo todos los servicios de actualizaciones estaban habilitados.Habilitar ahora " + updates.ServiceEnabled;
                }));
                Console.WriteLine("No todos los servicios de actualizaciones estaban habilitados. Habilitar ahora " + updates.ServiceEnabled);
                updates.EnableService();
                this.Invoke(new Action(() => { richTextBox1.Text += "\nServicio habilitado."; }));
                Console.WriteLine("Service enable success");
            }


        }
        public UpdateCollection DownloadUpdates()
        {
            UpdateSession UpdateSession = new UpdateSession();
            IUpdateSearcher SearchUpdates = UpdateSession.CreateUpdateSearcher();
            ISearchResult UpdateSearchResult = SearchUpdates.Search("IsInstalled=0 and IsPresent=0");
            UpdateCollection UpdateCollection = new UpdateCollection();
            //Accept Eula code for each update
            for (int i = 0; i < UpdateSearchResult.Updates.Count; i++)
            {
                IUpdate Updates = UpdateSearchResult.Updates[i];
                if (Updates.EulaAccepted == false)
                {
                    Updates.AcceptEula();
                }
                UpdateCollection.Add(Updates);
            }
            //Accept Eula ends here
            //if it is zero i am not sure if it will trow an exception -- I havent tested it.
            if (UpdateSearchResult.Updates.Count > 0)
            {
                UpdateCollection DownloadCollection = new UpdateCollection();
                UpdateDownloader Downloader = UpdateSession.CreateUpdateDownloader();

                for (int i = 0; i < UpdateCollection.Count; i++)
                {
                    DownloadCollection.Add(UpdateCollection[i]);
                }

                Downloader.Updates = DownloadCollection;
                this.Invoke(new Action(() => { richTextBox1.Text += "\nDescargando actualizaciones... Esto puede tardar varios minutos."; }));
                Console.WriteLine("Downloading Updates... This may take several minutes.");



                IDownloadResult DownloadResult = Downloader.Download();
                UpdateCollection InstallCollection = new UpdateCollection();
                for (int i = 0; i < UpdateCollection.Count; i++)
                {
                    if (DownloadCollection[i].IsDownloaded)
                    {
                        InstallCollection.Add(DownloadCollection[i]);
                    }
                }
                this.Invoke(new Action(() => { richTextBox1.Text += "\nDescarga finalizada."; }));
                Console.WriteLine("Download Finished");
                return InstallCollection;
            }
            else
                return UpdateCollection;
        }
        public void InstallUpdates(UpdateCollection DownloadedUpdates)
        {
            this.Invoke(new Action(() => { richTextBox1.Text += "\nInstalando actualizaciones..."; }));
            Console.WriteLine("Installing updates now...");
            UpdateSession UpdateSession = new UpdateSession();
            UpdateInstaller InstallAgent = UpdateSession.CreateUpdateInstaller() as UpdateInstaller;
            InstallAgent.Updates = DownloadedUpdates;

            //Starts a synchronous installation of the updates.
            // http://msdn.microsoft.com/en-us/library/windows/desktop/aa386491(v=VS.85).aspx#methods
            if (DownloadedUpdates.Count > 0)
            {
                IInstallationResult InstallResult = InstallAgent.Install();
                if (InstallResult.ResultCode == OperationResultCode.orcSucceeded)
                {
                    this.Invoke(new Action(() => { richTextBox1.Text += "\nActualizaciones instaladas correctamente.."; }));
                    Console.WriteLine("Updates installed succesfully");
                    if (InstallResult.RebootRequired == true)
                    {
                        this.Invoke(new Action(() => { richTextBox1.Text += "\nActualizaciones instaladas correctamente.."; }));
                        Console.WriteLine("Se requiere reiniciar para una o más actualizaciones.");
                    }
                }
                else
                {
                    this.Invoke(new Action(() => { richTextBox1.Text += "\nLas actualizaciones no se pudieron instalar, hágalo manualmente"; }));
                    Console.WriteLine("Updates failed to install do it manually");
                }
            }
            else
            {
                this.Invoke(new Action(() => { richTextBox1.Text += "\nLa computadora en la que se ejecutó este script está actualizada"; }));
                Console.WriteLine("The computer that this script was executed is up to date");
            }

        }

        #endregion

    }
}
