
namespace ConfigurarEq
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.programa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ultimamod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.existe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.check_certificado = new System.Windows.Forms.CheckBox();
            this.check_fondodepantalla = new System.Windows.Forms.CheckBox();
            this.check_usuarioadmin = new System.Windows.Forms.CheckBox();
            this.check_puntoderestauracion = new System.Windows.Forms.CheckBox();
            this.check_actualizarkaspersky = new System.Windows.Forms.CheckBox();
            this.check_accesosoffice = new System.Windows.Forms.CheckBox();
            this.usuario = new System.Windows.Forms.TextBox();
            this.inicio = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soloActualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciar = new System.Windows.Forms.Button();
            this.configurando = new System.ComponentModel.BackgroundWorker();
            this.txt_instalando = new System.Windows.Forms.Label();
            this.panel_checks = new System.Windows.Forms.Panel();
            this.check_infeq = new System.Windows.Forms.CheckBox();
            this.check_cambiarnombreequipo = new System.Windows.Forms.CheckBox();
            this.check_eliminarcarpeta = new System.Windows.Forms.CheckBox();
            this.check_windowsupdate = new System.Windows.Forms.CheckBox();
            this.check_activaroffice = new System.Windows.Forms.CheckBox();
            this.check_actualizartaskband = new System.Windows.Forms.CheckBox();
            this.check_activarkaspersky = new System.Windows.Forms.CheckBox();
            this.check_importarkaspersky = new System.Windows.Forms.CheckBox();
            this.check_marcadores = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.correo = new System.Windows.Forms.TextBox();
            this.nombrepc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_departamento = new System.Windows.Forms.TextBox();
            this.txt_base = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_empresa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_txtbox = new System.Windows.Forms.Panel();
            this.txt_observaciones = new System.Windows.Forms.TextBox();
            this.radio_cambiarequipo = new System.Windows.Forms.RadioButton();
            this.radio_equiponuevo = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.img_cargando = new System.Windows.Forms.PictureBox();
            this.radio_correctivo = new System.Windows.Forms.RadioButton();
            this.radio_preventivo = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel_checks.SuspendLayout();
            this.panel_txtbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_cargando)).BeginInit();
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
            this.fila,
            this.activo,
            this.programa,
            this.ultimamod,
            this.existe});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(3, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(561, 280);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // fila
            // 
            this.fila.HeaderText = "fila";
            this.fila.Name = "fila";
            this.fila.ReadOnly = true;
            this.fila.Visible = false;
            // 
            // activo
            // 
            this.activo.HeaderText = "Instalar";
            this.activo.Name = "activo";
            this.activo.ReadOnly = true;
            this.activo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.activo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.activo.Width = 50;
            // 
            // programa
            // 
            this.programa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.programa.HeaderText = "Programa";
            this.programa.Name = "programa";
            this.programa.ReadOnly = true;
            // 
            // ultimamod
            // 
            this.ultimamod.HeaderText = "Ultima Modificacion";
            this.ultimamod.Name = "ultimamod";
            this.ultimamod.ReadOnly = true;
            this.ultimamod.Width = 150;
            // 
            // existe
            // 
            this.existe.HeaderText = "existe";
            this.existe.Name = "existe";
            this.existe.ReadOnly = true;
            this.existe.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario:";
            // 
            // check_certificado
            // 
            this.check_certificado.AutoSize = true;
            this.check_certificado.Checked = true;
            this.check_certificado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_certificado.Location = new System.Drawing.Point(9, 54);
            this.check_certificado.Name = "check_certificado";
            this.check_certificado.Size = new System.Drawing.Size(113, 17);
            this.check_certificado.TabIndex = 100;
            this.check_certificado.Text = "Instalar Certificado";
            this.check_certificado.UseVisualStyleBackColor = true;
            // 
            // check_fondodepantalla
            // 
            this.check_fondodepantalla.AutoSize = true;
            this.check_fondodepantalla.Checked = true;
            this.check_fondodepantalla.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_fondodepantalla.Location = new System.Drawing.Point(9, 77);
            this.check_fondodepantalla.Name = "check_fondodepantalla";
            this.check_fondodepantalla.Size = new System.Drawing.Size(161, 17);
            this.check_fondodepantalla.TabIndex = 101;
            this.check_fondodepantalla.Text = "Establecer fondo de pantalla";
            this.check_fondodepantalla.UseVisualStyleBackColor = true;
            // 
            // check_usuarioadmin
            // 
            this.check_usuarioadmin.AutoSize = true;
            this.check_usuarioadmin.Checked = true;
            this.check_usuarioadmin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_usuarioadmin.Location = new System.Drawing.Point(205, 31);
            this.check_usuarioadmin.Name = "check_usuarioadmin";
            this.check_usuarioadmin.Size = new System.Drawing.Size(135, 17);
            this.check_usuarioadmin.TabIndex = 102;
            this.check_usuarioadmin.Text = "Habilitar Usuario Admin";
            this.check_usuarioadmin.UseVisualStyleBackColor = true;
            // 
            // check_puntoderestauracion
            // 
            this.check_puntoderestauracion.AutoSize = true;
            this.check_puntoderestauracion.Checked = true;
            this.check_puntoderestauracion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_puntoderestauracion.Location = new System.Drawing.Point(205, 54);
            this.check_puntoderestauracion.Name = "check_puntoderestauracion";
            this.check_puntoderestauracion.Size = new System.Drawing.Size(157, 17);
            this.check_puntoderestauracion.TabIndex = 103;
            this.check_puntoderestauracion.Text = "Crear punto de restauracion";
            this.check_puntoderestauracion.UseVisualStyleBackColor = true;
            // 
            // check_actualizarkaspersky
            // 
            this.check_actualizarkaspersky.AutoSize = true;
            this.check_actualizarkaspersky.Checked = true;
            this.check_actualizarkaspersky.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_actualizarkaspersky.Location = new System.Drawing.Point(388, 8);
            this.check_actualizarkaspersky.Name = "check_actualizarkaspersky";
            this.check_actualizarkaspersky.Size = new System.Drawing.Size(124, 17);
            this.check_actualizarkaspersky.TabIndex = 104;
            this.check_actualizarkaspersky.Text = "Actualizar Kaspersky";
            this.check_actualizarkaspersky.UseVisualStyleBackColor = true;
            // 
            // check_accesosoffice
            // 
            this.check_accesosoffice.AutoSize = true;
            this.check_accesosoffice.Checked = true;
            this.check_accesosoffice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_accesosoffice.Location = new System.Drawing.Point(205, 8);
            this.check_accesosoffice.Name = "check_accesosoffice";
            this.check_accesosoffice.Size = new System.Drawing.Size(153, 17);
            this.check_accesosoffice.TabIndex = 110;
            this.check_accesosoffice.Text = "Accesos directos de Office";
            this.check_accesosoffice.UseVisualStyleBackColor = true;
            // 
            // usuario
            // 
            this.usuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.usuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.usuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuario.Location = new System.Drawing.Point(66, 5);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(255, 22);
            this.usuario.TabIndex = 1;
            this.usuario.Leave += new System.EventHandler(this.usuario_Leave);
            // 
            // inicio
            // 
            this.inicio.DoWork += new System.ComponentModel.DoWorkEventHandler(this.inicio_DoWork);
            this.inicio.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.inicio_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarToolStripMenuItem,
            this.masToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(573, 24);
            this.menuStrip1.TabIndex = 112;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administrarToolStripMenuItem
            // 
            this.administrarToolStripMenuItem.Name = "administrarToolStripMenuItem";
            this.administrarToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.administrarToolStripMenuItem.Text = "Administrar";
            this.administrarToolStripMenuItem.Click += new System.EventHandler(this.administrarToolStripMenuItem_Click);
            // 
            // masToolStripMenuItem
            // 
            this.masToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soloActualizarToolStripMenuItem});
            this.masToolStripMenuItem.Name = "masToolStripMenuItem";
            this.masToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.masToolStripMenuItem.Text = "Mas";
            // 
            // soloActualizarToolStripMenuItem
            // 
            this.soloActualizarToolStripMenuItem.Name = "soloActualizarToolStripMenuItem";
            this.soloActualizarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.soloActualizarToolStripMenuItem.Text = "Solo Actualizar";
            this.soloActualizarToolStripMenuItem.Click += new System.EventHandler(this.soloActualizarToolStripMenuItem_Click);
            // 
            // iniciar
            // 
            this.iniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iniciar.Location = new System.Drawing.Point(205, 123);
            this.iniciar.Name = "iniciar";
            this.iniciar.Size = new System.Drawing.Size(143, 37);
            this.iniciar.TabIndex = 113;
            this.iniciar.Text = "Iniciar Configuracion";
            this.iniciar.UseVisualStyleBackColor = true;
            this.iniciar.Click += new System.EventHandler(this.iniciar_Click);
            // 
            // configurando
            // 
            this.configurando.DoWork += new System.ComponentModel.DoWorkEventHandler(this.configurando_DoWork);
            this.configurando.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.configurando_RunWorkerCompleted);
            // 
            // txt_instalando
            // 
            this.txt_instalando.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_instalando.Location = new System.Drawing.Point(3, 159);
            this.txt_instalando.Name = "txt_instalando";
            this.txt_instalando.Size = new System.Drawing.Size(561, 23);
            this.txt_instalando.TabIndex = 114;
            this.txt_instalando.Text = "label2";
            this.txt_instalando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_checks
            // 
            this.panel_checks.Controls.Add(this.check_infeq);
            this.panel_checks.Controls.Add(this.check_cambiarnombreequipo);
            this.panel_checks.Controls.Add(this.check_eliminarcarpeta);
            this.panel_checks.Controls.Add(this.check_windowsupdate);
            this.panel_checks.Controls.Add(this.check_activaroffice);
            this.panel_checks.Controls.Add(this.check_actualizartaskband);
            this.panel_checks.Controls.Add(this.check_activarkaspersky);
            this.panel_checks.Controls.Add(this.check_importarkaspersky);
            this.panel_checks.Controls.Add(this.check_marcadores);
            this.panel_checks.Controls.Add(this.iniciar);
            this.panel_checks.Controls.Add(this.check_certificado);
            this.panel_checks.Controls.Add(this.check_usuarioadmin);
            this.panel_checks.Controls.Add(this.check_actualizarkaspersky);
            this.panel_checks.Controls.Add(this.check_accesosoffice);
            this.panel_checks.Controls.Add(this.check_fondodepantalla);
            this.panel_checks.Controls.Add(this.check_puntoderestauracion);
            this.panel_checks.Location = new System.Drawing.Point(3, 427);
            this.panel_checks.Name = "panel_checks";
            this.panel_checks.Size = new System.Drawing.Size(556, 169);
            this.panel_checks.TabIndex = 116;
            // 
            // check_infeq
            // 
            this.check_infeq.AutoSize = true;
            this.check_infeq.Checked = true;
            this.check_infeq.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_infeq.Location = new System.Drawing.Point(9, 31);
            this.check_infeq.Name = "check_infeq";
            this.check_infeq.Size = new System.Drawing.Size(92, 17);
            this.check_infeq.TabIndex = 123;
            this.check_infeq.Text = "Guardar InfEq";
            this.check_infeq.UseVisualStyleBackColor = true;
            // 
            // check_cambiarnombreequipo
            // 
            this.check_cambiarnombreequipo.AutoSize = true;
            this.check_cambiarnombreequipo.Checked = true;
            this.check_cambiarnombreequipo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_cambiarnombreequipo.Location = new System.Drawing.Point(9, 8);
            this.check_cambiarnombreequipo.Name = "check_cambiarnombreequipo";
            this.check_cambiarnombreequipo.Size = new System.Drawing.Size(159, 17);
            this.check_cambiarnombreequipo.TabIndex = 122;
            this.check_cambiarnombreequipo.Text = "Cambiar Nombre Del Equipo";
            this.check_cambiarnombreequipo.UseVisualStyleBackColor = true;
            // 
            // check_eliminarcarpeta
            // 
            this.check_eliminarcarpeta.AutoSize = true;
            this.check_eliminarcarpeta.Checked = true;
            this.check_eliminarcarpeta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_eliminarcarpeta.Location = new System.Drawing.Point(388, 100);
            this.check_eliminarcarpeta.Name = "check_eliminarcarpeta";
            this.check_eliminarcarpeta.Size = new System.Drawing.Size(157, 17);
            this.check_eliminarcarpeta.TabIndex = 121;
            this.check_eliminarcarpeta.Text = "Eliminar Carpeta al Terminar";
            this.check_eliminarcarpeta.UseVisualStyleBackColor = true;
            // 
            // check_windowsupdate
            // 
            this.check_windowsupdate.AutoSize = true;
            this.check_windowsupdate.Checked = true;
            this.check_windowsupdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_windowsupdate.Location = new System.Drawing.Point(388, 77);
            this.check_windowsupdate.Name = "check_windowsupdate";
            this.check_windowsupdate.Size = new System.Drawing.Size(150, 17);
            this.check_windowsupdate.TabIndex = 120;
            this.check_windowsupdate.Text = "Ejecutar Windows Update";
            this.check_windowsupdate.UseVisualStyleBackColor = true;
            // 
            // check_activaroffice
            // 
            this.check_activaroffice.AutoSize = true;
            this.check_activaroffice.Checked = true;
            this.check_activaroffice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_activaroffice.Location = new System.Drawing.Point(388, 54);
            this.check_activaroffice.Name = "check_activaroffice";
            this.check_activaroffice.Size = new System.Drawing.Size(90, 17);
            this.check_activaroffice.TabIndex = 119;
            this.check_activaroffice.Text = "Activar Office";
            this.check_activaroffice.UseVisualStyleBackColor = true;
            // 
            // check_actualizartaskband
            // 
            this.check_actualizartaskband.AutoSize = true;
            this.check_actualizartaskband.Checked = true;
            this.check_actualizartaskband.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_actualizartaskband.Location = new System.Drawing.Point(388, 31);
            this.check_actualizartaskband.Name = "check_actualizartaskband";
            this.check_actualizartaskband.Size = new System.Drawing.Size(151, 17);
            this.check_actualizartaskband.TabIndex = 118;
            this.check_actualizartaskband.Text = "Actualizar Barra de Tareas";
            this.check_actualizartaskband.UseVisualStyleBackColor = true;
            // 
            // check_activarkaspersky
            // 
            this.check_activarkaspersky.AutoSize = true;
            this.check_activarkaspersky.Checked = true;
            this.check_activarkaspersky.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_activarkaspersky.Location = new System.Drawing.Point(205, 100);
            this.check_activarkaspersky.Name = "check_activarkaspersky";
            this.check_activarkaspersky.Size = new System.Drawing.Size(111, 17);
            this.check_activarkaspersky.TabIndex = 117;
            this.check_activarkaspersky.Text = "Activar Kaspersky";
            this.check_activarkaspersky.UseVisualStyleBackColor = true;
            // 
            // check_importarkaspersky
            // 
            this.check_importarkaspersky.AutoSize = true;
            this.check_importarkaspersky.Checked = true;
            this.check_importarkaspersky.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_importarkaspersky.Location = new System.Drawing.Point(205, 77);
            this.check_importarkaspersky.Name = "check_importarkaspersky";
            this.check_importarkaspersky.Size = new System.Drawing.Size(151, 17);
            this.check_importarkaspersky.TabIndex = 116;
            this.check_importarkaspersky.Text = "Importar config. Kaspersky";
            this.check_importarkaspersky.UseVisualStyleBackColor = true;
            // 
            // check_marcadores
            // 
            this.check_marcadores.AutoSize = true;
            this.check_marcadores.Checked = true;
            this.check_marcadores.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_marcadores.Location = new System.Drawing.Point(9, 100);
            this.check_marcadores.Name = "check_marcadores";
            this.check_marcadores.Size = new System.Drawing.Size(128, 17);
            this.check_marcadores.TabIndex = 114;
            this.check_marcadores.Text = "BookMarks en EDGE";
            this.check_marcadores.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(10, 185);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(537, 236);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // correo
            // 
            this.correo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.correo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.correo.Location = new System.Drawing.Point(579, 257);
            this.correo.Name = "correo";
            this.correo.Size = new System.Drawing.Size(100, 20);
            this.correo.TabIndex = 115;
            // 
            // nombrepc
            // 
            this.nombrepc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nombrepc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombrepc.Location = new System.Drawing.Point(407, 5);
            this.nombrepc.Name = "nombrepc";
            this.nombrepc.Size = new System.Drawing.Size(154, 22);
            this.nombrepc.TabIndex = 200;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(321, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 119;
            this.label2.Text = "Nombre PC:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 120;
            this.label3.Text = "Departamento:";
            // 
            // txt_departamento
            // 
            this.txt_departamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_departamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_departamento.Location = new System.Drawing.Point(101, 35);
            this.txt_departamento.Name = "txt_departamento";
            this.txt_departamento.Size = new System.Drawing.Size(118, 22);
            this.txt_departamento.TabIndex = 201;
            // 
            // txt_base
            // 
            this.txt_base.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_base.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_base.Location = new System.Drawing.Point(271, 35);
            this.txt_base.Name = "txt_base";
            this.txt_base.Size = new System.Drawing.Size(105, 22);
            this.txt_base.TabIndex = 202;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(223, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 122;
            this.label4.Text = "Base:";
            // 
            // txt_empresa
            // 
            this.txt_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_empresa.Location = new System.Drawing.Point(457, 35);
            this.txt_empresa.Name = "txt_empresa";
            this.txt_empresa.Size = new System.Drawing.Size(105, 22);
            this.txt_empresa.TabIndex = 125;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(382, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 124;
            this.label5.Text = "Empresa:";
            // 
            // panel_txtbox
            // 
            this.panel_txtbox.Controls.Add(this.radio_correctivo);
            this.panel_txtbox.Controls.Add(this.txt_observaciones);
            this.panel_txtbox.Controls.Add(this.radio_preventivo);
            this.panel_txtbox.Controls.Add(this.radio_cambiarequipo);
            this.panel_txtbox.Controls.Add(this.radio_equiponuevo);
            this.panel_txtbox.Controls.Add(this.label6);
            this.panel_txtbox.Controls.Add(this.label1);
            this.panel_txtbox.Controls.Add(this.txt_empresa);
            this.panel_txtbox.Controls.Add(this.usuario);
            this.panel_txtbox.Controls.Add(this.label5);
            this.panel_txtbox.Controls.Add(this.nombrepc);
            this.panel_txtbox.Controls.Add(this.txt_base);
            this.panel_txtbox.Controls.Add(this.label2);
            this.panel_txtbox.Controls.Add(this.label4);
            this.panel_txtbox.Controls.Add(this.label3);
            this.panel_txtbox.Controls.Add(this.txt_departamento);
            this.panel_txtbox.Location = new System.Drawing.Point(3, 27);
            this.panel_txtbox.Name = "panel_txtbox";
            this.panel_txtbox.Size = new System.Drawing.Size(567, 114);
            this.panel_txtbox.TabIndex = 126;
            // 
            // txt_observaciones
            // 
            this.txt_observaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_observaciones.Location = new System.Drawing.Point(111, 64);
            this.txt_observaciones.Multiline = true;
            this.txt_observaciones.Name = "txt_observaciones";
            this.txt_observaciones.Size = new System.Drawing.Size(290, 41);
            this.txt_observaciones.TabIndex = 203;
            // 
            // radio_cambiarequipo
            // 
            this.radio_cambiarequipo.AutoSize = true;
            this.radio_cambiarequipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_cambiarequipo.Location = new System.Drawing.Point(419, 85);
            this.radio_cambiarequipo.Name = "radio_cambiarequipo";
            this.radio_cambiarequipo.Size = new System.Drawing.Size(57, 20);
            this.radio_cambiarequipo.TabIndex = 129;
            this.radio_cambiarequipo.Text = "C. Eq";
            this.radio_cambiarequipo.UseVisualStyleBackColor = true;
            // 
            // radio_equiponuevo
            // 
            this.radio_equiponuevo.AutoSize = true;
            this.radio_equiponuevo.Checked = true;
            this.radio_equiponuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_equiponuevo.Location = new System.Drawing.Point(419, 66);
            this.radio_equiponuevo.Name = "radio_equiponuevo";
            this.radio_equiponuevo.Size = new System.Drawing.Size(70, 20);
            this.radio_equiponuevo.TabIndex = 128;
            this.radio_equiponuevo.TabStop = true;
            this.radio_equiponuevo.Text = "Eq Nvo";
            this.radio_equiponuevo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 16);
            this.label6.TabIndex = 126;
            this.label6.Text = "Observaciones:";
            // 
            // img_cargando
            // 
            this.img_cargando.Image = global::ConfigurarEq.Properties.Resources.gears;
            this.img_cargando.Location = new System.Drawing.Point(185, 201);
            this.img_cargando.Name = "img_cargando";
            this.img_cargando.Size = new System.Drawing.Size(183, 183);
            this.img_cargando.TabIndex = 115;
            this.img_cargando.TabStop = false;
            // 
            // radio_correctivo
            // 
            this.radio_correctivo.AutoSize = true;
            this.radio_correctivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_correctivo.Location = new System.Drawing.Point(491, 85);
            this.radio_correctivo.Name = "radio_correctivo";
            this.radio_correctivo.Size = new System.Drawing.Size(64, 20);
            this.radio_correctivo.TabIndex = 128;
            this.radio_correctivo.TabStop = true;
            this.radio_correctivo.Text = "M.Corr";
            this.radio_correctivo.UseVisualStyleBackColor = true;
            // 
            // radio_preventivo
            // 
            this.radio_preventivo.AutoSize = true;
            this.radio_preventivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_preventivo.Location = new System.Drawing.Point(491, 67);
            this.radio_preventivo.Name = "radio_preventivo";
            this.radio_preventivo.Size = new System.Drawing.Size(70, 20);
            this.radio_preventivo.TabIndex = 127;
            this.radio_preventivo.TabStop = true;
            this.radio_preventivo.Text = "M. Prev";
            this.radio_preventivo.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 592);
            this.Controls.Add(this.panel_txtbox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel_checks);
            this.Controls.Add(this.txt_instalando);
            this.Controls.Add(this.img_cargando);
            this.Controls.Add(this.correo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Equipo de Computo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_checks.ResumeLayout(false);
            this.panel_checks.PerformLayout();
            this.panel_txtbox.ResumeLayout(false);
            this.panel_txtbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_cargando)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox check_certificado;
        private System.Windows.Forms.CheckBox check_fondodepantalla;
        private System.Windows.Forms.CheckBox check_usuarioadmin;
        private System.Windows.Forms.CheckBox check_puntoderestauracion;
        private System.Windows.Forms.CheckBox check_actualizarkaspersky;
        private System.Windows.Forms.CheckBox check_accesosoffice;
        private System.Windows.Forms.TextBox usuario;
        private System.ComponentModel.BackgroundWorker inicio;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.Button iniciar;
        private System.ComponentModel.BackgroundWorker configurando;
        private System.Windows.Forms.Label txt_instalando;
        private System.Windows.Forms.PictureBox img_cargando;
        private System.Windows.Forms.Panel panel_checks;
        private System.Windows.Forms.DataGridViewTextBoxColumn fila;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activo;
        private System.Windows.Forms.DataGridViewTextBoxColumn programa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimamod;
        private System.Windows.Forms.DataGridViewTextBoxColumn existe;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox check_marcadores;
        private System.Windows.Forms.TextBox correo;
        private System.Windows.Forms.CheckBox check_importarkaspersky;
        private System.Windows.Forms.CheckBox check_activarkaspersky;
        private System.Windows.Forms.CheckBox check_actualizartaskband;
        private System.Windows.Forms.CheckBox check_activaroffice;
        private System.Windows.Forms.CheckBox check_windowsupdate;
        private System.Windows.Forms.ToolStripMenuItem masToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soloActualizarToolStripMenuItem;
        private System.Windows.Forms.CheckBox check_eliminarcarpeta;
        private System.Windows.Forms.TextBox nombrepc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox check_cambiarnombreequipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_departamento;
        private System.Windows.Forms.TextBox txt_base;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_empresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel_txtbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radio_cambiarequipo;
        private System.Windows.Forms.RadioButton radio_equiponuevo;
        private System.Windows.Forms.CheckBox check_infeq;
        private System.Windows.Forms.TextBox txt_observaciones;
        private System.Windows.Forms.RadioButton radio_correctivo;
        private System.Windows.Forms.RadioButton radio_preventivo;
    }
}

