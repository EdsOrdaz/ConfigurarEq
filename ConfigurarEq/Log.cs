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
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void Log_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Form1.path_log))
            {
                MessageBox.Show("No existe un log de errores.");
                Close();
            }
            String[] lines = File.ReadAllLines(Form1.path_log);
            String log = "";
            int i = 0;
            foreach (string line in lines)
            {
                log = log.Replace("*****", "");
                if (line.Contains("*****"))
                {
                    if (i != 0)
                    {
                        dataGridView1.Rows.Add("\n" + log + "\n");
                    }
                    log = line;
                }
                else
                {
                    log += line;
                }
                i++;
            }
            log = log.Replace("*****", "");
            dataGridView1.Rows.Add("\n" + log + "\n");
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
    }
}
