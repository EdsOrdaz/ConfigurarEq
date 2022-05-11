
namespace ConfigurarEq
{
    partial class Administrar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administrar));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.argumentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_certificado = new System.Windows.Forms.TextBox();
            this.txt_fondodepantalla = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_taskband = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_kasconfig = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_kaslicencia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_licenciaoffice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.boton_certificado = new System.Windows.Forms.Button();
            this.boton_fondopantalla = new System.Windows.Forms.Button();
            this.boton_taskband = new System.Windows.Forms.Button();
            this.boton_configkaspersky = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pass = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pid,
            this.programass,
            this.argumentos,
            this.activo,
            this.editar});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(751, 280);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // pid
            // 
            this.pid.HeaderText = "ID";
            this.pid.Name = "pid";
            this.pid.ReadOnly = true;
            this.pid.Width = 30;
            // 
            // programass
            // 
            this.programass.HeaderText = "Programa";
            this.programass.Name = "programass";
            this.programass.ReadOnly = true;
            this.programass.Width = 200;
            // 
            // argumentos
            // 
            this.argumentos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.argumentos.HeaderText = "Comandos";
            this.argumentos.Name = "argumentos";
            this.argumentos.ReadOnly = true;
            // 
            // activo
            // 
            this.activo.HeaderText = "Activo";
            this.activo.Name = "activo";
            this.activo.ReadOnly = true;
            this.activo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.activo.Width = 50;
            // 
            // editar
            // 
            this.editar.HeaderText = "Editar";
            this.editar.Name = "editar";
            this.editar.ReadOnly = true;
            this.editar.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Certificado:";
            // 
            // txt_certificado
            // 
            this.txt_certificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_certificado.Location = new System.Drawing.Point(83, 7);
            this.txt_certificado.Name = "txt_certificado";
            this.txt_certificado.ReadOnly = true;
            this.txt_certificado.Size = new System.Drawing.Size(556, 22);
            this.txt_certificado.TabIndex = 10;
            // 
            // txt_fondodepantalla
            // 
            this.txt_fondodepantalla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fondodepantalla.Location = new System.Drawing.Point(126, 40);
            this.txt_fondodepantalla.Name = "txt_fondodepantalla";
            this.txt_fondodepantalla.ReadOnly = true;
            this.txt_fondodepantalla.Size = new System.Drawing.Size(513, 22);
            this.txt_fondodepantalla.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Fondo de Pantalla:";
            // 
            // txt_taskband
            // 
            this.txt_taskband.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_taskband.Location = new System.Drawing.Point(83, 72);
            this.txt_taskband.Name = "txt_taskband";
            this.txt_taskband.ReadOnly = true;
            this.txt_taskband.Size = new System.Drawing.Size(556, 22);
            this.txt_taskband.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "TaskBand:";
            // 
            // txt_kasconfig
            // 
            this.txt_kasconfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_kasconfig.Location = new System.Drawing.Point(162, 101);
            this.txt_kasconfig.Name = "txt_kasconfig";
            this.txt_kasconfig.ReadOnly = true;
            this.txt_kasconfig.Size = new System.Drawing.Size(477, 22);
            this.txt_kasconfig.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Configuracion Kaspersky:";
            // 
            // txt_kaslicencia
            // 
            this.txt_kaslicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_kaslicencia.Location = new System.Drawing.Point(139, 132);
            this.txt_kaslicencia.Name = "txt_kaslicencia";
            this.txt_kaslicencia.Size = new System.Drawing.Size(601, 22);
            this.txt_kaslicencia.TabIndex = 18;
            this.txt_kaslicencia.Leave += new System.EventHandler(this.txt_kaslicencia_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Licencia Kaspersky: ";
            // 
            // txt_licenciaoffice
            // 
            this.txt_licenciaoffice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_licenciaoffice.Location = new System.Drawing.Point(106, 164);
            this.txt_licenciaoffice.Name = "txt_licenciaoffice";
            this.txt_licenciaoffice.Size = new System.Drawing.Size(634, 22);
            this.txt_licenciaoffice.TabIndex = 20;
            this.txt_licenciaoffice.Leave += new System.EventHandler(this.txt_licenciaoffice_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Licencia Office:";
            // 
            // boton_certificado
            // 
            this.boton_certificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_certificado.Location = new System.Drawing.Point(645, 6);
            this.boton_certificado.Name = "boton_certificado";
            this.boton_certificado.Size = new System.Drawing.Size(95, 25);
            this.boton_certificado.TabIndex = 21;
            this.boton_certificado.Text = "Seleccionar";
            this.boton_certificado.UseVisualStyleBackColor = true;
            this.boton_certificado.Click += new System.EventHandler(this.boton_certificado_Click);
            // 
            // boton_fondopantalla
            // 
            this.boton_fondopantalla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_fondopantalla.Location = new System.Drawing.Point(645, 39);
            this.boton_fondopantalla.Name = "boton_fondopantalla";
            this.boton_fondopantalla.Size = new System.Drawing.Size(95, 25);
            this.boton_fondopantalla.TabIndex = 22;
            this.boton_fondopantalla.Text = "Seleccionar";
            this.boton_fondopantalla.UseVisualStyleBackColor = true;
            this.boton_fondopantalla.Click += new System.EventHandler(this.boton_fondopantalla_Click);
            // 
            // boton_taskband
            // 
            this.boton_taskband.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_taskband.Location = new System.Drawing.Point(645, 69);
            this.boton_taskband.Name = "boton_taskband";
            this.boton_taskband.Size = new System.Drawing.Size(95, 25);
            this.boton_taskband.TabIndex = 23;
            this.boton_taskband.Text = "Seleccionar";
            this.boton_taskband.UseVisualStyleBackColor = true;
            this.boton_taskband.Click += new System.EventHandler(this.boton_taskband_Click);
            // 
            // boton_configkaspersky
            // 
            this.boton_configkaspersky.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_configkaspersky.Location = new System.Drawing.Point(645, 98);
            this.boton_configkaspersky.Name = "boton_configkaspersky";
            this.boton_configkaspersky.Size = new System.Drawing.Size(95, 25);
            this.boton_configkaspersky.TabIndex = 24;
            this.boton_configkaspersky.Text = "Seleccionar";
            this.boton_configkaspersky.UseVisualStyleBackColor = true;
            this.boton_configkaspersky.Click += new System.EventHandler(this.boton_configkaspersky_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.boton_configkaspersky);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.boton_taskband);
            this.panel1.Controls.Add(this.txt_certificado);
            this.panel1.Controls.Add(this.boton_fondopantalla);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.boton_certificado);
            this.panel1.Controls.Add(this.txt_fondodepantalla);
            this.panel1.Controls.Add(this.txt_licenciaoffice);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt_taskband);
            this.panel1.Controls.Add(this.txt_kaslicencia);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_kasconfig);
            this.panel1.Location = new System.Drawing.Point(3, 289);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 193);
            this.panel1.TabIndex = 25;
            // 
            // pass
            // 
            this.pass.Location = new System.Drawing.Point(239, 153);
            this.pass.Name = "pass";
            this.pass.PasswordChar = '*';
            this.pass.Size = new System.Drawing.Size(278, 20);
            this.pass.TabIndex = 25;
            this.pass.UseSystemPasswordChar = true;
            this.pass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pass_KeyUp);
            // 
            // Administrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 485);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Administrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar";
            this.Load += new System.EventHandler(this.Administrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn programass;
        private System.Windows.Forms.DataGridViewTextBoxColumn argumentos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activo;
        private System.Windows.Forms.DataGridViewButtonColumn editar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_certificado;
        private System.Windows.Forms.TextBox txt_fondodepantalla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_taskband;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_kasconfig;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_kaslicencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_licenciaoffice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button boton_certificado;
        private System.Windows.Forms.Button boton_fondopantalla;
        private System.Windows.Forms.Button boton_taskband;
        private System.Windows.Forms.Button boton_configkaspersky;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox pass;
    }
}