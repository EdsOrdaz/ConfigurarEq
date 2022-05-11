using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigurarEq
{
    public partial class LogErrores : Form
    {
        public LogErrores()
        {
            InitializeComponent();
        }

        private void LogErrores_Load(object sender, EventArgs e)
        {
            if(!File.Exists(Form1.path_log_errores))
            {
                MessageBox.Show("No existe un log de errores.");
                Close();
            }
            String[] lines = File.ReadAllLines(Form1.path_log_errores);
            String error = "";
            int i = 0;
            foreach (string line in lines)
            {
                error = error.Replace("*****", "");
                if (line.Contains("*****"))
                {
                    if (i != 0)
                    {
                        dataGridView1.Rows.Add("\n" + error + "\n");
                    }
                    error = line;
                }
                else
                {
                    error += line;
                }
                i++;
            }
            error = error.Replace("*****", "");
            dataGridView1.Rows.Add("\n" + error + "\n");
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
    }
}
