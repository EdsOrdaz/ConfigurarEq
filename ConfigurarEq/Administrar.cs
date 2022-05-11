using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ConfigurarEq
{
    public partial class Administrar : Form
    {
        public Administrar()
        {
            InitializeComponent();
        }

        private void Recargar_Lista_Programas()
        {
            Datos.Recargar_Programas();
            dataGridView1.Rows.Clear();
            int contarceldas = 0;
            int fila = 0;
            foreach (String[] programs in Datos.Programas)
            {
                int existe = (Convert.ToInt32(programs[3]) == 0) ? 0 : 1;
                int activo = (Convert.ToInt32(programs[3]) == 0) ? 0 : Convert.ToInt32(programs[2]);

                dataGridView1.Rows.Add(programs[5], programs[0], programs[4], activo, "Editar");
                if (Convert.ToInt32(programs[3]) == 0)
                {
                    dataGridView1.Rows[contarceldas].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
                contarceldas++;
                fila++;
            }

            using (SqlConnection conexion2 = new SqlConnection(Datos.conexionsql_infeq))
            {
                conexion2.Open();
                String sql2 = "SELECT * FROM ConfEq_rutas";
                SqlCommand comm = new SqlCommand(sql2, conexion2);
                SqlDataReader query = comm.ExecuteReader();
                while (query.Read())
                {
                    if (query["comentario"].ToString() == "Certificado")
                    {
                        txt_certificado.Text = query["ruta"].ToString();
                    }
                    if (query["comentario"].ToString() == "Fondo de pantalla")
                    {
                        txt_fondodepantalla.Text = query["ruta"].ToString();
                    }
                    if (query["comentario"].ToString() == "TaskBand")
                    {
                        txt_taskband.Text = query["ruta"].ToString();
                    }
                    if (query["comentario"].ToString() == "Kaspersky Config")
                    {
                        txt_kasconfig.Text = query["ruta"].ToString();
                    }
                    if (query["comentario"].ToString() == "Kaspersky Licencia")
                    {
                        txt_kaslicencia.Text = query["ruta"].ToString();
                    }
                    if (query["comentario"].ToString() == "Office Licencia")
                    {
                        txt_licenciaoffice.Text = query["ruta"].ToString();
                    }
                }
            }
        }
        
        private void Administrar_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = false;
            Recargar_Lista_Programas();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1 && e.ColumnIndex == 4)
            {
                EditarPrograma.pid = dataGridView1.Rows[e.RowIndex].Cells["pid"].Value.ToString();
                EditarPrograma.programa = dataGridView1.Rows[e.RowIndex].Cells["programass"].Value.ToString();
                EditarPrograma.comando = dataGridView1.Rows[e.RowIndex].Cells["argumentos"].Value.ToString();
                EditarPrograma.activo = dataGridView1.Rows[e.RowIndex].Cells["activo"].Value.ToString();
                EditarPrograma editar_programa = new EditarPrograma();
                editar_programa.ShowDialog();
                Recargar_Lista_Programas();
            }
        }

        private void boton_certificado_Click(object sender, EventArgs e)
        {
            OpenFileDialog certificado = new OpenFileDialog();
            certificado.InitialDirectory = Application.StartupPath;
            certificado.CheckFileExists = true;
            certificado.CheckPathExists = true;
            certificado.ReadOnlyChecked = true;
            certificado.Filter = "Certificado (crt)|*.crt";
            if (certificado.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String cert = txt_certificado.Text;
                    String path = cert.Replace("$path", Application.StartupPath);
                    if(File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    File.Copy(certificado.FileName, Application.StartupPath + "\\Instalar\\Copiar\\" + Path.GetFileName(certificado.FileName));
                    using (SqlConnection conexion2 = new SqlConnection(Datos.conexionsql_infeq))
                    {
                        conexion2.Open();
                        String sql2 = "UPDATE ConfEq_rutas SET ruta=@ruta where rid=1";
                        SqlCommand cmdIns = new SqlCommand(sql2, conexion2);

                        cmdIns.Parameters.AddWithValue("@ruta", @"$path\Instalar\Copiar\"+ Path.GetFileName(certificado.FileName));

                        cmdIns.ExecuteNonQuery();
                        cmdIns.Parameters.Clear();
                        cmdIns.Dispose();
                        cmdIns = null;

                        Recargar_Lista_Programas();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("ERROR: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void boton_fondopantalla_Click(object sender, EventArgs e)
        {
            OpenFileDialog fondo_de_pantalla = new OpenFileDialog();
            fondo_de_pantalla.InitialDirectory = Application.StartupPath;
            fondo_de_pantalla.CheckFileExists = true;
            fondo_de_pantalla.CheckPathExists = true;
            fondo_de_pantalla.ReadOnlyChecked = true;
            fondo_de_pantalla.Filter = "Imagen (JPG, JPEG, PNG)|*.jpg;*.jpeg;*.png";
            if (fondo_de_pantalla.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String fondo_txt = txt_fondodepantalla.Text;
                    String path = fondo_txt.Replace("$path", Application.StartupPath);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    File.Copy(fondo_de_pantalla.FileName, Application.StartupPath + "\\Instalar\\Copiar\\" + Path.GetFileName(fondo_de_pantalla.FileName));

                    using (SqlConnection conexion2 = new SqlConnection(Datos.conexionsql_infeq))
                    {
                        conexion2.Open();
                        String sql2 = "UPDATE ConfEq_rutas SET ruta=@ruta where rid=4";
                        SqlCommand cmdIns = new SqlCommand(sql2, conexion2);

                        cmdIns.Parameters.AddWithValue("@ruta", @"$path\Instalar\Copiar\" + Path.GetFileName(fondo_de_pantalla.FileName));

                        cmdIns.ExecuteNonQuery();
                        cmdIns.Parameters.Clear();
                        cmdIns.Dispose();
                        cmdIns = null;

                        Recargar_Lista_Programas();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("ERROR: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void boton_taskband_Click(object sender, EventArgs e)
        {
            OpenFileDialog task_band = new OpenFileDialog();
            task_band.InitialDirectory = Application.StartupPath;
            task_band.CheckFileExists = true;
            task_band.CheckPathExists = true;
            task_band.ReadOnlyChecked = true;
            task_band.Filter = "Registro (Reg)|*.reg";
            if (task_band.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String task_txt = txt_taskband.Text;
                    String path = task_txt.Replace("$path", Application.StartupPath);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    File.Copy(task_band.FileName, Application.StartupPath + "\\Instalar\\Copiar\\" + Path.GetFileName(task_band.FileName));

                    using (SqlConnection conexion2 = new SqlConnection(Datos.conexionsql_infeq))
                    {
                        conexion2.Open();
                        String sql2 = "UPDATE ConfEq_rutas SET ruta=@ruta where rid=5";
                        SqlCommand cmdIns = new SqlCommand(sql2, conexion2);

                        cmdIns.Parameters.AddWithValue("@ruta", @"$path\Instalar\Copiar\" + Path.GetFileName(task_band.FileName));

                        cmdIns.ExecuteNonQuery();
                        cmdIns.Parameters.Clear();
                        cmdIns.Dispose();
                        cmdIns = null;

                        Recargar_Lista_Programas();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("ERROR: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void boton_configkaspersky_Click(object sender, EventArgs e)
        {
            OpenFileDialog kas_config = new OpenFileDialog();
            kas_config.InitialDirectory = Application.StartupPath;
            kas_config.CheckFileExists = true;
            kas_config.CheckPathExists = true;
            kas_config.ReadOnlyChecked = true;
            kas_config.Filter = "Kaspersky Config (cfg)|*.cfg";
            if (kas_config.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String kas_config_txt = txt_kasconfig.Text;
                    String path = kas_config_txt.Replace("$path", Application.StartupPath);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    File.Copy(kas_config.FileName, Application.StartupPath + "\\Instalar\\Copiar\\" + Path.GetFileName(kas_config.FileName));

                    using (SqlConnection conexion2 = new SqlConnection(Datos.conexionsql_infeq))
                    {
                        conexion2.Open();
                        String sql2 = "UPDATE ConfEq_rutas SET ruta=@ruta where rid=6";
                        SqlCommand cmdIns = new SqlCommand(sql2, conexion2);

                        cmdIns.Parameters.AddWithValue("@ruta", @"$path\Instalar\Copiar\" + Path.GetFileName(kas_config.FileName));

                        cmdIns.ExecuteNonQuery();
                        cmdIns.Parameters.Clear();
                        cmdIns.Dispose();
                        cmdIns = null;

                        Recargar_Lista_Programas();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("ERROR: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txt_kaslicencia_Leave(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion2 = new SqlConnection(Datos.conexionsql_infeq))
                {
                    conexion2.Open();
                    String sql2 = "UPDATE ConfEq_rutas SET ruta=@ruta where rid=7";
                    SqlCommand cmdIns = new SqlCommand(sql2, conexion2);

                    cmdIns.Parameters.AddWithValue("@ruta", txt_kaslicencia.Text);

                    cmdIns.ExecuteNonQuery();
                    cmdIns.Parameters.Clear();
                    cmdIns.Dispose();
                    cmdIns = null;

                    Recargar_Lista_Programas();
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("ERROR: "+error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_licenciaoffice_Leave(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion2 = new SqlConnection(Datos.conexionsql_infeq))
                {
                    conexion2.Open();
                    String sql2 = "UPDATE ConfEq_rutas SET ruta=@ruta where rid=8";
                    SqlCommand cmdIns = new SqlCommand(sql2, conexion2);

                    cmdIns.Parameters.AddWithValue("@ruta", txt_licenciaoffice.Text);

                    cmdIns.ExecuteNonQuery();
                    cmdIns.Parameters.Clear();
                    cmdIns.Dispose();
                    cmdIns = null;

                    Recargar_Lista_Programas();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pass_KeyUp(object sender, KeyEventArgs e)
        {
            if(pass.Text=="edunne")
            {
                dataGridView1.Visible = true;
                panel1.Visible = true;
                pass.Visible = false;
                dataGridView1.Focus();
            }
        }
    }
}
