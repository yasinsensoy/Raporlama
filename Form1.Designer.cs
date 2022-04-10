namespace Raporlama
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (WorkTimer != null)
                WorkTimer.Dispose();
            if (IsiThread != null)
                IsiThread.Abort();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gösterGizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.sicakliklar = new CustomTabPage();
            this.veriler = new CustomTabPage();
            this.tableLayoutPanel1 = new CustomTableLayoutPanel();
            this.btnpartiayrinti = new System.Windows.Forms.Button();
            this.dataveriler = new CustomDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnbaslatdurdur = new System.Windows.Forms.Button();
            this.btnsirketayrinti = new System.Windows.Forms.Button();
            this.cbsirketler = new System.Windows.Forms.ComboBox();
            this.cboturumlar = new System.Windows.Forms.ComboBox();
            this.lblkayitsayi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new CustomTableLayoutPanel();
            this.nudfont = new System.Windows.Forms.NumericUpDown();
            this.btnrapor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.partiler = new CustomTabPage();
            this.datapartiler = new CustomDataGridView();
            this.o_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_bt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_bta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_sure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_sayi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_sid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnpartiraporal = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new CustomTableLayoutPanel();
            this.cbtariharalik = new System.Windows.Forms.CheckBox();
            this.txtara = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new CustomTableLayoutPanel();
            this.lblpartino = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblfirinno = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblyetkino = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new Raporlama.CustomFlowLayoutPanel();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.sicakliklar.SuspendLayout();
            this.veriler.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataveriler)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudfont)).BeginInit();
            this.partiler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datapartiler)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "EKS";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gösterGizleToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 48);
            // 
            // gösterGizleToolStripMenuItem
            // 
            this.gösterGizleToolStripMenuItem.Name = "gösterGizleToolStripMenuItem";
            this.gösterGizleToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.gösterGizleToolStripMenuItem.Text = "Göster/Gizle";
            this.gösterGizleToolStripMenuItem.Click += new System.EventHandler(this.gösterGizleToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel8,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 531);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(821, 30);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.DarkRed;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(22, 25);
            this.toolStripStatusLabel1.Text = "  ";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(185, 25);
            this.toolStripStatusLabel3.Text = "Kayıt İşlem Durumu:";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 25);
            this.toolStripStatusLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(188, 25);
            this.toolStripStatusLabel6.Text = "Otomatik Durdurma:";
            this.toolStripStatusLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(0, 25);
            this.toolStripStatusLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel8.ForeColor = System.Drawing.Color.OrangeRed;
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(411, 25);
            this.toolStripStatusLabel8.Spring = true;
            this.toolStripStatusLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 25);
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripStatusLabel2_MouseDown);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.sicakliklar);
            this.tabControl1.Controls.Add(this.veriler);
            this.tabControl1.Controls.Add(this.partiler);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(821, 500);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // sicakliklar
            // 
            this.sicakliklar.Controls.Add(this.flowLayoutPanel1);
            this.sicakliklar.Location = new System.Drawing.Point(4, 29);
            this.sicakliklar.Name = "sicakliklar";
            this.sicakliklar.Padding = new System.Windows.Forms.Padding(3);
            this.sicakliklar.Size = new System.Drawing.Size(813, 467);
            this.sicakliklar.TabIndex = 0;
            this.sicakliklar.Text = "Sıcaklıklar";
            this.sicakliklar.UseVisualStyleBackColor = true;
            // 
            // veriler
            // 
            this.veriler.Controls.Add(this.tableLayoutPanel1);
            this.veriler.Controls.Add(this.panel2);
            this.veriler.Location = new System.Drawing.Point(4, 29);
            this.veriler.Name = "veriler";
            this.veriler.Padding = new System.Windows.Forms.Padding(3);
            this.veriler.Size = new System.Drawing.Size(813, 467);
            this.veriler.TabIndex = 1;
            this.veriler.Text = "Veriler";
            this.veriler.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnpartiayrinti, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataveriler, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnbaslatdurdur, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnsirketayrinti, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbsirketler, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboturumlar, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblkayitsayi, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(807, 422);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // btnpartiayrinti
            // 
            this.btnpartiayrinti.AutoSize = true;
            this.btnpartiayrinti.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnpartiayrinti.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnpartiayrinti.Location = new System.Drawing.Point(622, 39);
            this.btnpartiayrinti.Name = "btnpartiayrinti";
            this.btnpartiayrinti.Size = new System.Drawing.Size(89, 30);
            this.btnpartiayrinti.TabIndex = 12;
            this.btnpartiayrinti.Text = "Ayrıntılar";
            this.btnpartiayrinti.UseVisualStyleBackColor = true;
            this.btnpartiayrinti.Click += new System.EventHandler(this.btnpartiayrinti_Click);
            // 
            // dataveriler
            // 
            this.dataveriler.AllowUserToAddRows = false;
            this.dataveriler.AllowUserToDeleteRows = false;
            this.dataveriler.AllowUserToResizeRows = false;
            this.dataveriler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataveriler.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataveriler.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dataveriler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataveriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataveriler, 5);
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.NullValue = null;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataveriler.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataveriler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataveriler.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataveriler.Location = new System.Drawing.Point(3, 101);
            this.dataveriler.Name = "dataveriler";
            this.dataveriler.ReadOnly = true;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dataveriler.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataveriler.RowHeadersVisible = false;
            this.dataveriler.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Aqua;
            this.dataveriler.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataveriler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataveriler.Size = new System.Drawing.Size(801, 318);
            this.dataveriler.TabIndex = 6;
            this.dataveriler.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataveriler_DataBindingComplete);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Açıklamalar";
            // 
            // btnbaslatdurdur
            // 
            this.btnbaslatdurdur.AutoSize = true;
            this.btnbaslatdurdur.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnbaslatdurdur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnbaslatdurdur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnbaslatdurdur.Location = new System.Drawing.Point(717, 3);
            this.btnbaslatdurdur.Name = "btnbaslatdurdur";
            this.tableLayoutPanel1.SetRowSpan(this.btnbaslatdurdur, 2);
            this.btnbaslatdurdur.Size = new System.Drawing.Size(87, 66);
            this.btnbaslatdurdur.TabIndex = 7;
            this.btnbaslatdurdur.Text = "BAŞLAT";
            this.btnbaslatdurdur.UseVisualStyleBackColor = true;
            this.btnbaslatdurdur.Click += new System.EventHandler(this.btnbaslatdurdur_Click);
            // 
            // btnsirketayrinti
            // 
            this.btnsirketayrinti.AutoSize = true;
            this.btnsirketayrinti.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnsirketayrinti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnsirketayrinti.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnsirketayrinti.Location = new System.Drawing.Point(622, 3);
            this.btnsirketayrinti.Name = "btnsirketayrinti";
            this.btnsirketayrinti.Size = new System.Drawing.Size(89, 30);
            this.btnsirketayrinti.TabIndex = 1;
            this.btnsirketayrinti.Text = "Ayrıntılar";
            this.btnsirketayrinti.UseVisualStyleBackColor = true;
            this.btnsirketayrinti.Click += new System.EventHandler(this.btnsirketayrinti_Click);
            // 
            // cbsirketler
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbsirketler, 2);
            this.cbsirketler.DisplayMember = "AD";
            this.cbsirketler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbsirketler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsirketler.FormattingEnabled = true;
            this.cbsirketler.Location = new System.Drawing.Point(110, 3);
            this.cbsirketler.Name = "cbsirketler";
            this.cbsirketler.Size = new System.Drawing.Size(506, 28);
            this.cbsirketler.TabIndex = 0;
            this.cbsirketler.ValueMember = "ID";
            this.cbsirketler.SelectedIndexChanged += new System.EventHandler(this.cbsirketler_SelectedIndexChanged);
            // 
            // cboturumlar
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboturumlar, 2);
            this.cboturumlar.DisplayMember = "AD";
            this.cboturumlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboturumlar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboturumlar.FormattingEnabled = true;
            this.cboturumlar.Location = new System.Drawing.Point(110, 39);
            this.cboturumlar.Name = "cboturumlar";
            this.cboturumlar.Size = new System.Drawing.Size(506, 28);
            this.cboturumlar.TabIndex = 3;
            this.cboturumlar.ValueMember = "ID";
            this.cboturumlar.SelectedIndexChanged += new System.EventHandler(this.cboturumlar_SelectedIndexChanged);
            // 
            // lblkayitsayi
            // 
            this.lblkayitsayi.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblkayitsayi, 5);
            this.lblkayitsayi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblkayitsayi.Location = new System.Drawing.Point(3, 75);
            this.lblkayitsayi.Margin = new System.Windows.Forms.Padding(3);
            this.lblkayitsayi.Name = "lblkayitsayi";
            this.lblkayitsayi.Size = new System.Drawing.Size(0, 20);
            this.lblkayitsayi.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Partiler";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.tableLayoutPanel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 425);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(807, 39);
            this.panel2.TabIndex = 9;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.nudfont, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnrapor, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(317, 36);
            this.tableLayoutPanel5.TabIndex = 20;
            // 
            // nudfont
            // 
            this.nudfont.AutoSize = true;
            this.nudfont.Location = new System.Drawing.Point(157, 3);
            this.nudfont.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nudfont.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudfont.Name = "nudfont";
            this.nudfont.Size = new System.Drawing.Size(43, 26);
            this.nudfont.TabIndex = 13;
            this.nudfont.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nudfont.ValueChanged += new System.EventHandler(this.nudfont_ValueChanged);
            // 
            // btnrapor
            // 
            this.btnrapor.AutoSize = true;
            this.btnrapor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnrapor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnrapor.Location = new System.Drawing.Point(206, 3);
            this.btnrapor.Name = "btnrapor";
            this.btnrapor.Size = new System.Drawing.Size(108, 30);
            this.btnrapor.TabIndex = 19;
            this.btnrapor.Text = "RAPOR AL";
            this.btnrapor.UseVisualStyleBackColor = true;
            this.btnrapor.Click += new System.EventHandler(this.btnrapor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tablo yazı boyutu";
            // 
            // partiler
            // 
            this.partiler.Controls.Add(this.datapartiler);
            this.partiler.Controls.Add(this.panel3);
            this.partiler.Location = new System.Drawing.Point(4, 29);
            this.partiler.Name = "partiler";
            this.partiler.Padding = new System.Windows.Forms.Padding(3);
            this.partiler.Size = new System.Drawing.Size(813, 467);
            this.partiler.TabIndex = 2;
            this.partiler.Text = "İşlem Geçmişi";
            this.partiler.UseVisualStyleBackColor = true;
            // 
            // datapartiler
            // 
            this.datapartiler.AllowUserToAddRows = false;
            this.datapartiler.AllowUserToDeleteRows = false;
            this.datapartiler.AllowUserToResizeRows = false;
            this.datapartiler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datapartiler.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.datapartiler.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.datapartiler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datapartiler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.o_id,
            this.o_bt,
            this.o_bta,
            this.o_sure,
            this.o_sayi,
            this.o_sid,
            this.o_ad});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.NullValue = null;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datapartiler.DefaultCellStyle = dataGridViewCellStyle12;
            this.datapartiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datapartiler.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.datapartiler.Location = new System.Drawing.Point(3, 3);
            this.datapartiler.Name = "datapartiler";
            this.datapartiler.ReadOnly = true;
            this.datapartiler.RowHeadersVisible = false;
            this.datapartiler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datapartiler.Size = new System.Drawing.Size(807, 395);
            this.datapartiler.TabIndex = 8;
            this.datapartiler.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.datapartiler_DataBindingComplete);
            this.datapartiler.SelectionChanged += new System.EventHandler(this.datapartiler_SelectionChanged);
            // 
            // o_id
            // 
            this.o_id.DataPropertyName = "ID";
            this.o_id.HeaderText = "Parti No";
            this.o_id.Name = "o_id";
            this.o_id.ReadOnly = true;
            this.o_id.Width = 90;
            // 
            // o_bt
            // 
            this.o_bt.DataPropertyName = "BASTARIH";
            dataGridViewCellStyle10.Format = "G";
            this.o_bt.DefaultCellStyle = dataGridViewCellStyle10;
            this.o_bt.HeaderText = "Başlama Tarihi";
            this.o_bt.Name = "o_bt";
            this.o_bt.ReadOnly = true;
            this.o_bt.Width = 138;
            // 
            // o_bta
            // 
            this.o_bta.DataPropertyName = "BITTARIH";
            dataGridViewCellStyle11.Format = "G";
            this.o_bta.DefaultCellStyle = dataGridViewCellStyle11;
            this.o_bta.HeaderText = "Bitiş Tarihi";
            this.o_bta.Name = "o_bta";
            this.o_bta.ReadOnly = true;
            this.o_bta.Width = 106;
            // 
            // o_sure
            // 
            this.o_sure.DataPropertyName = "SURE";
            this.o_sure.HeaderText = "Süre";
            this.o_sure.Name = "o_sure";
            this.o_sure.ReadOnly = true;
            this.o_sure.Width = 68;
            // 
            // o_sayi
            // 
            this.o_sayi.DataPropertyName = "ADET";
            this.o_sayi.HeaderText = "Kayıt Sayısı";
            this.o_sayi.Name = "o_sayi";
            this.o_sayi.ReadOnly = true;
            this.o_sayi.Width = 113;
            // 
            // o_sid
            // 
            this.o_sid.DataPropertyName = "SID";
            this.o_sid.HeaderText = "Şirket Id";
            this.o_sid.Name = "o_sid";
            this.o_sid.ReadOnly = true;
            this.o_sid.Visible = false;
            // 
            // o_ad
            // 
            this.o_ad.DataPropertyName = "AD";
            this.o_ad.HeaderText = "Şirket Ad";
            this.o_ad.Name = "o_ad";
            this.o_ad.ReadOnly = true;
            this.o_ad.Visible = false;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.btnpartiraporal);
            this.panel3.Controls.Add(this.tableLayoutPanel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 398);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(807, 66);
            this.panel3.TabIndex = 9;
            // 
            // btnpartiraporal
            // 
            this.btnpartiraporal.AutoSize = true;
            this.btnpartiraporal.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnpartiraporal.Enabled = false;
            this.btnpartiraporal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnpartiraporal.Location = new System.Drawing.Point(699, 0);
            this.btnpartiraporal.Name = "btnpartiraporal";
            this.btnpartiraporal.Size = new System.Drawing.Size(108, 66);
            this.btnpartiraporal.TabIndex = 20;
            this.btnpartiraporal.Text = "RAPOR AL";
            this.btnpartiraporal.UseVisualStyleBackColor = true;
            this.btnpartiraporal.Click += new System.EventHandler(this.btnpartiraporal_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.cbtariharalik, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtara, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.date1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.date2, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.label8, 1, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(453, 66);
            this.tableLayoutPanel4.TabIndex = 15;
            // 
            // cbtariharalik
            // 
            this.cbtariharalik.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.cbtariharalik, 3);
            this.cbtariharalik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbtariharalik.Location = new System.Drawing.Point(3, 3);
            this.cbtariharalik.Name = "cbtariharalik";
            this.cbtariharalik.Size = new System.Drawing.Size(163, 25);
            this.cbtariharalik.TabIndex = 17;
            this.cbtariharalik.Text = "Tarih aralığı seçin";
            this.cbtariharalik.UseVisualStyleBackColor = true;
            this.cbtariharalik.CheckedChanged += new System.EventHandler(this.cbtariharalik_CheckedChanged);
            // 
            // txtara
            // 
            this.txtara.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtara.Location = new System.Drawing.Point(284, 34);
            this.txtara.Name = "txtara";
            this.txtara.Size = new System.Drawing.Size(166, 26);
            this.txtara.TabIndex = 0;
            this.txtara.TextChanged += new System.EventHandler(this.Filtrele);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(284, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "İşlem Parti No";
            // 
            // date1
            // 
            this.date1.CustomFormat = "";
            this.date1.Enabled = false;
            this.date1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.date1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date1.Location = new System.Drawing.Point(3, 34);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(120, 29);
            this.date1.TabIndex = 8;
            this.date1.Value = new System.DateTime(2019, 3, 11, 2, 31, 34, 0);
            this.date1.ValueChanged += new System.EventHandler(this.Filtrele);
            // 
            // date2
            // 
            this.date2.CustomFormat = "";
            this.date2.Enabled = false;
            this.date2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.date2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date2.Location = new System.Drawing.Point(158, 34);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(120, 29);
            this.date2.TabIndex = 18;
            this.date2.Value = new System.DateTime(2019, 3, 11, 2, 31, 34, 0);
            this.date2.ValueChanged += new System.EventHandler(this.Filtrele);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(126, 39);
            this.label8.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 21);
            this.label8.TabIndex = 10;
            this.label8.Text = "ile";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.lblpartino, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblfirinno, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblyetkino, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 500);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(821, 31);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // lblpartino
            // 
            this.lblpartino.AutoSize = true;
            this.lblpartino.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblpartino.Location = new System.Drawing.Point(275, 3);
            this.lblpartino.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.lblpartino.Name = "lblpartino";
            this.lblpartino.Size = new System.Drawing.Size(0, 25);
            this.lblpartino.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(187, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 25);
            this.label7.TabIndex = 22;
            this.label7.Text = "Parti No:";
            // 
            // lblfirinno
            // 
            this.lblfirinno.AutoSize = true;
            this.lblfirinno.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblfirinno.Location = new System.Drawing.Point(87, 3);
            this.lblfirinno.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.lblfirinno.Name = "lblfirinno";
            this.lblfirinno.Size = new System.Drawing.Size(0, 25);
            this.lblfirinno.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Fırın No:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(93, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Yetki No:";
            // 
            // lblyetkino
            // 
            this.lblyetkino.AutoSize = true;
            this.lblyetkino.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblyetkino.Location = new System.Drawing.Point(181, 3);
            this.lblyetkino.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.lblyetkino.Name = "lblyetkino";
            this.lblyetkino.Size = new System.Drawing.Size(0, 25);
            this.lblyetkino.TabIndex = 22;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(807, 461);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "EKS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.sicakliklar.ResumeLayout(false);
            this.veriler.ResumeLayout(false);
            this.veriler.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataveriler)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudfont)).EndInit();
            this.partiler.ResumeLayout(false);
            this.partiler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datapartiler)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private CustomTabPage sicakliklar;
        private CustomTabPage veriler;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cbsirketler;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gösterGizleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsirketayrinti;
        private CustomDataGridView dataveriler;
        private System.Windows.Forms.Button btnbaslatdurdur;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblkayitsayi;
        private System.Windows.Forms.Button btnrapor;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private CustomTableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cboturumlar;
        private System.Windows.Forms.Label label2;
        private CustomTableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.NumericUpDown nudfont;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private CustomTabPage partiler;
        private System.Windows.Forms.Button btnpartiayrinti;
        private CustomDataGridView datapartiler;
        private System.Windows.Forms.Panel panel3;
        private CustomTableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox cbtariharalik;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.Label label8;
        private CustomTableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblfirinno;
        private System.Windows.Forms.Label lblyetkino;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnpartiraporal;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_bt;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_bta;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_sure;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_sayi;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_sid;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_ad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblpartino;
        private System.Windows.Forms.TextBox txtara;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private CustomFlowLayoutPanel flowLayoutPanel1;
    }
}

