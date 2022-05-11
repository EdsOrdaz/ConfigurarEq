using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigurarEq
{
    public partial class EditarPrograma : Form
    {
        public EditarPrograma()
        {
            InitializeComponent();
        }

        public static String pid;
        public static String programa;
        public static String programa_nuevo;
        public static String comando;
        public static String activo;
        private void EditarPrograma_Load(object sender, EventArgs e)
        {
            if(activo=="1")
            {
                instalar.Checked = true;
            }
            nombreprograma.Text = programa;
            comandos.Text = comando;
        }

        private static String ruta_copiar;
        private static String ruta_nueva;
        private void boton_buscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog();
            archivo.InitialDirectory = Application.StartupPath;
            archivo.CheckFileExists = true;
            archivo.CheckPathExists = true;
            archivo.ReadOnlyChecked = true;
            archivo.Filter = "Programas (exe, msi, iso)|*.exe;*.msi;*.iso";
            panel1.Visible = false;

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                programa_nuevo = System.IO.Path.GetFileName(archivo.FileName);
                if (antivirus.Checked)
                {
                    FileInfo file = new FileInfo(Application.StartupPath + "\\Instalar\\Kaspersky\\" + programa_nuevo);
                    if (!file.Directory.Exists)
                    {
                        file.Directory.Create();
                    }
                    programa_nuevo = "Kaspersky\\" + programa_nuevo;
                }
                try
                {
                    ruta_copiar = archivo.FileName;
                    ruta_nueva = Application.StartupPath + "\\Instalar\\" + programa_nuevo;

                    nombreprograma.Text = programa_nuevo;
                    comandos.Focus();
                }
                catch (Exception error)
                {
                    panel1.Visible = true;
                    MessageBox.Show("ERROR: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            panel1.Visible = true;
        }

        private void boton_cargar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion2 = new SqlConnection(Datos.conexionsql_infeq))
                {
                    conexion2.Open();
                    String sql2 = "UPDATE ConfEq SET programa=@programa, comandos=@comandos, fechacarga=@fechacarga, activo=@activo where pid=@pid";
                    SqlCommand cmdIns = new SqlCommand(sql2, conexion2);

                    int instalarsiempre = (instalar.Checked == true) ? 1 : 0;
                    cmdIns.Parameters.AddWithValue("@programa", nombreprograma.Text);
                    cmdIns.Parameters.AddWithValue("@comandos", comandos.Text);
                    cmdIns.Parameters.AddWithValue("@fechacarga", DateTime.Now);
                    cmdIns.Parameters.AddWithValue("@activo", instalarsiempre);
                    cmdIns.Parameters.AddWithValue("@pid", pid);

                    cmdIns.ExecuteNonQuery();
                    cmdIns.Parameters.Clear();
                    cmdIns.Dispose();
                    cmdIns = null;
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al cargar la informacion a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(Application.StartupPath + "\\Instalar\\" + programa))
            {
                File.Delete(Application.StartupPath + "\\Instalar\\" + programa);
            }
            if (File.Exists(ruta_copiar))
            {
                File.Copy(ruta_copiar, ruta_nueva, true);
            }
            MessageBox.Show("Programa Actualizado", "Cargar Programa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
