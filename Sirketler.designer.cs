namespace Raporlama
{
    partial class Sirketler
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnsec = new System.Windows.Forms.Button();
            this.btnekle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtara = new System.Windows.Forms.TextBox();
            this.datasirketler = new System.Windows.Forms.DataGridView();
            this.s_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.datamalzemeler = new System.Windows.Forms.DataGridView();
            this.m_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_sid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_cins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnmekle = new System.Windows.Forms.Button();
            this.btnmduzenle = new System.Windows.Forms.Button();
            this.btnmsil = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datasirketler)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datamalzemeler)).BeginInit();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtara);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 50);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnsec);
            this.flowLayoutPanel1.Controls.Add(this.btnekle);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(114, 47);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // btnsec
            // 
            this.btnsec.AutoSize = true;
            this.btnsec.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnsec.Enabled = false;
            this.btnsec.FlatAppearance.BorderSize = 0;
            this.btnsec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsec.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.btnsec.ForeColor = System.Drawing.Color.White;
            this.btnsec.Location = new System.Drawing.Point(2, 3);
            this.btnsec.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnsec.Name = "btnsec";
            this.btnsec.Size = new System.Drawing.Size(53, 41);
            this.btnsec.TabIndex = 1;
            this.btnsec.TabStop = false;
            this.btnsec.Text = "Seç";
            this.btnsec.UseVisualStyleBackColor = false;
            this.btnsec.Click += new System.EventHandler(this.btnsec_Click);
            // 
            // btnekle
            // 
            this.btnekle.AutoSize = true;
            this.btnekle.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnekle.FlatAppearance.BorderSize = 0;
            this.btnekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnekle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.btnekle.ForeColor = System.Drawing.Color.White;
            this.btnekle.Location = new System.Drawing.Point(59, 3);
            this.btnekle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(53, 41);
            this.btnekle.TabIndex = 2;
            this.btnekle.TabStop = false;
            this.btnekle.Text = "Ekle";
            this.btnekle.UseVisualStyleBackColor = false;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(277, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ara";
            // 
            // txtara
            // 
            this.txtara.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtara.Location = new System.Drawing.Point(280, 21);
            this.txtara.Name = "txtara";
            this.txtara.Size = new System.Drawing.Size(166, 23);
            this.txtara.TabIndex = 0;
            this.txtara.TextChanged += new System.EventHandler(this.Filtrele);
            // 
            // datasirketler
            // 
            this.datasirketler.AllowUserToAddRows = false;
            this.datasirketler.AllowUserToDeleteRows = false;
            this.datasirketler.AllowUserToResizeRows = false;
            this.datasirketler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datasirketler.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.datasirketler.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.datasirketler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datasirketler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.s_id,
            this.s_ad});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datasirketler.DefaultCellStyle = dataGridViewCellStyle1;
            this.datasirketler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datasirketler.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.datasirketler.Location = new System.Drawing.Point(0, 50);
            this.datasirketler.Name = "datasirketler";
            this.datasirketler.ReadOnly = true;
            this.datasirketler.RowHeadersVisible = false;
            this.datasirketler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datasirketler.Size = new System.Drawing.Size(449, 424);
            this.datasirketler.TabIndex = 5;
            this.datasirketler.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datamusteriler_CellDoubleClick);
            this.datasirketler.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.datamusteriler_DataBindingComplete);
            this.datasirketler.SelectionChanged += new System.EventHandler(this.datamusteriler_SelectionChanged);
            // 
            // s_id
            // 
            this.s_id.DataPropertyName = "ID";
            this.s_id.HeaderText = "Id";
            this.s_id.Name = "s_id";
            this.s_id.ReadOnly = true;
            this.s_id.Visible = false;
            // 
            // s_ad
            // 
            this.s_ad.DataPropertyName = "AD";
            this.s_ad.HeaderText = "Ad";
            this.s_ad.Name = "s_ad";
            this.s_ad.ReadOnly = true;
            this.s_ad.Width = 47;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.datamalzemeler);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(449, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 474);
            this.panel2.TabIndex = 7;
            // 
            // datamalzemeler
            // 
            this.datamalzemeler.AllowUserToAddRows = false;
            this.datamalzemeler.AllowUserToDeleteRows = false;
            this.datamalzemeler.AllowUserToResizeRows = false;
            this.datamalzemeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datamalzemeler.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.datamalzemeler.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.datamalzemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datamalzemeler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_id,
            this.m_sid,
            this.m_cins,
            this.m_miktar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datamalzemeler.DefaultCellStyle = dataGridViewCellStyle2;
            this.datamalzemeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datamalzemeler.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.datamalzemeler.Location = new System.Drawing.Point(0, 50);
            this.datamalzemeler.Name = "datamalzemeler";
            this.datamalzemeler.ReadOnly = true;
            this.datamalzemeler.RowHeadersVisible = false;
            this.datamalzemeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datamalzemeler.Size = new System.Drawing.Size(340, 424);
            this.datamalzemeler.TabIndex = 9;
            this.datamalzemeler.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.datamalzemeler_DataBindingComplete);
            this.datamalzemeler.SelectionChanged += new System.EventHandler(this.datamalzemeler_SelectionChanged);
            // 
            // m_id
            // 
            this.m_id.DataPropertyName = "ID";
            this.m_id.HeaderText = "Id";
            this.m_id.Name = "m_id";
            this.m_id.ReadOnly = true;
            this.m_id.Visible = false;
            this.m_id.Width = 23;
            // 
            // m_sid
            // 
            this.m_sid.DataPropertyName = "SID";
            this.m_sid.HeaderText = "Firma Id";
            this.m_sid.Name = "m_sid";
            this.m_sid.ReadOnly = true;
            this.m_sid.Visible = false;
            this.m_sid.Width = 56;
            // 
            // m_cins
            // 
            this.m_cins.DataPropertyName = "CINS";
            this.m_cins.HeaderText = "Cins";
            this.m_cins.Name = "m_cins";
            this.m_cins.ReadOnly = true;
            this.m_cins.Width = 55;
            // 
            // m_miktar
            // 
            this.m_miktar.DataPropertyName = "MIKTAR";
            this.m_miktar.HeaderText = "Miktar";
            this.m_miktar.Name = "m_miktar";
            this.m_miktar.ReadOnly = true;
            this.m_miktar.Width = 66;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.flowLayoutPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(340, 50);
            this.panel3.TabIndex = 8;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.btnmekle);
            this.flowLayoutPanel2.Controls.Add(this.btnmduzenle);
            this.flowLayoutPanel2.Controls.Add(this.btnmsil);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(181, 47);
            this.flowLayoutPanel2.TabIndex = 10;
            // 
            // btnmekle
            // 
            this.btnmekle.AutoSize = true;
            this.btnmekle.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnmekle.Enabled = false;
            this.btnmekle.FlatAppearance.BorderSize = 0;
            this.btnmekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmekle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.btnmekle.ForeColor = System.Drawing.Color.White;
            this.btnmekle.Location = new System.Drawing.Point(2, 3);
            this.btnmekle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnmekle.Name = "btnmekle";
            this.btnmekle.Size = new System.Drawing.Size(53, 41);
            this.btnmekle.TabIndex = 2;
            this.btnmekle.TabStop = false;
            this.btnmekle.Text = "Ekle";
            this.btnmekle.UseVisualStyleBackColor = false;
            this.btnmekle.Click += new System.EventHandler(this.btnmekle_Click);
            // 
            // btnmduzenle
            // 
            this.btnmduzenle.AutoSize = true;
            this.btnmduzenle.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnmduzenle.Enabled = false;
            this.btnmduzenle.FlatAppearance.BorderSize = 0;
            this.btnmduzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmduzenle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.btnmduzenle.ForeColor = System.Drawing.Color.White;
            this.btnmduzenle.Location = new System.Drawing.Point(59, 3);
            this.btnmduzenle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnmduzenle.Name = "btnmduzenle";
            this.btnmduzenle.Size = new System.Drawing.Size(63, 41);
            this.btnmduzenle.TabIndex = 11;
            this.btnmduzenle.TabStop = false;
            this.btnmduzenle.Text = "Düzenle";
            this.btnmduzenle.UseVisualStyleBackColor = false;
            this.btnmduzenle.Click += new System.EventHandler(this.btnmduzenle_Click);
            // 
            // btnmsil
            // 
            this.btnmsil.AutoSize = true;
            this.btnmsil.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnmsil.Enabled = false;
            this.btnmsil.FlatAppearance.BorderSize = 0;
            this.btnmsil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmsil.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.btnmsil.ForeColor = System.Drawing.Color.White;
            this.btnmsil.Location = new System.Drawing.Point(126, 3);
            this.btnmsil.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnmsil.Name = "btnmsil";
            this.btnmsil.Size = new System.Drawing.Size(53, 41);
            this.btnmsil.TabIndex = 12;
            this.btnmsil.TabStop = false;
            this.btnmsil.Text = "Sil";
            this.btnmsil.UseVisualStyleBackColor = false;
            this.btnmsil.Click += new System.EventHandler(this.btnmsil_Click);
            // 
            // Sirketler
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(789, 474);
            this.Controls.Add(this.datasirketler);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(431, 217);
            this.Name = "Sirketler";
            this.Text = "İş Yapılan Firmalar";
            this.Load += new System.EventHandler(this.Sirketler_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datasirketler)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datamalzemeler)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnsec;
        private System.Windows.Forms.DataGridView datasirketler;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtara;
        private System.Windows.Forms.Button btnekle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView datamalzemeler;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnmekle;
        private System.Windows.Forms.Button btnmduzenle;
        private System.Windows.Forms.Button btnmsil;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_sid;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_cins;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_miktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_ad;
    }
}