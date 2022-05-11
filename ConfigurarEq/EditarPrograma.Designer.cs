namespace ConfigurarEq
{
    partial class EditarPrograma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarPrograma));
            this.label1 = new System.Windows.Forms.Label();
            this.nombreprograma = new System.Windows.Forms.Label();
            this.comandos = new System.Windows.Forms.TextBox();
            this.boton_buscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.instalar = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.antivirus = new System.Windows.Forms.CheckBox();
            this.boton_cargar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Seleccionar Programa:";
            // 
            // nombreprograma
            // 
            this.nombreprograma.AutoSize = true;
            this.nombreprograma.Location = new System.Drawing.Point(207, 28);
            this.nombreprograma.Name = "nombreprograma";
            this.nombreprograma.Size = new System.Drawing.Size(35, 13);
            this.nombreprograma.TabIndex = 11;
            this.nombreprograma.Text = "label3";
            // 
            // comandos
            // 
            this.comandos.Location = new System.Drawing.Point(137, 50);
            this.comandos.Name = "comandos";
            this.comandos.Size = new System.Drawing.Size(356, 20);
            this.comandos.TabIndex = 9;
            // 
            // boton_buscar
            // 
            this.boton_buscar.Location = new System.Drawing.Point(123, 23);
            this.boton_buscar.Name = "boton_buscar";
            this.boton_buscar.Size = new System.Drawing.Size(83, 23);
            this.boton_buscar.TabIndex = 7;
            this.boton_buscar.Text = "Buscar";
            this.boton_buscar.UseVisualStyleBackColor = true;
            this.boton_buscar.Click += new System.EventHandler(this.boton_buscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Comandos de instalacion:";
            // 
            // instalar
            // 
            this.instalar.AutoSize = true;
            this.instalar.Location = new System.Drawing.Point(6, 76);
            this.instalar.Name = "instalar";
            this.instalar.Size = new System.Drawing.Size(156, 17);
            this.instalar.TabIndex = 12;
            this.instalar.Text = "Siempre activo para instalar";
            this.instalar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.boton_cargar);
            this.panel1.Controls.Add(this.antivirus);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.instalar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.boton_buscar);
            this.panel1.Controls.Add(this.nombreprograma);
            this.panel1.Controls.Add(this.comandos);
            this.panel1.Location = new System.Drawing.Point(2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 127);
            this.panel1.TabIndex = 13;
            // 
            // antivirus
            // 
            this.antivirus.AutoSize = true;
            this.antivirus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.antivirus.Location = new System.Drawing.Point(6, 6);
            this.antivirus.Name = "antivirus";
            this.antivirus.Size = new System.Drawing.Size(75, 17);
            this.antivirus.TabIndex = 14;
            this.antivirus.Text = "Kaspersky";
            this.antivirus.UseVisualStyleBackColor = true;
            // 
            // boton_cargar
            // 
            this.boton_cargar.Location = new System.Drawing.Point(185, 84);
            this.boton_cargar.Name = "boton_cargar";
            this.boton_cargar.Size = new System.Drawing.Size(144, 35);
            this.boton_cargar.TabIndex = 15;
            this.boton_cargar.Text = "Cargar Programa";
            this.boton_cargar.UseVisualStyleBackColor = true;
            this.boton_cargar.Click += new System.EventHandler(this.boton_cargar_Click);
            // 
            // EditarPrograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 134);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditarPrograma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Programa";
            this.Load += new System.EventHandler(this.EditarPrograma_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nombreprograma;
        private System.Windows.Forms.TextBox comandos;
        private System.Windows.Forms.Button boton_buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox instalar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox antivirus;
        private System.Windows.Forms.Button boton_cargar;
    }
}