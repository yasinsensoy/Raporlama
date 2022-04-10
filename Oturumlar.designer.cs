namespace Raporlama
{
    partial class Oturumlar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnsec = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtara = new System.Windows.Forms.TextBox();
            this.datapartiler = new System.Windows.Forms.DataGridView();
            this.o_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_bt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_bta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_sure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cbtariharalik = new System.Windows.Forms.CheckBox();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datapartiler)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(789, 50);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnsec);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(57, 47);
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
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(617, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "İşlem Parti No";
            // 
            // txtara
            // 
            this.txtara.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtara.Location = new System.Drawing.Point(620, 21);
            this.txtara.Name = "txtara";
            this.txtara.Size = new System.Drawing.Size(166, 23);
            this.txtara.TabIndex = 0;
            this.txtara.TextChanged += new System.EventHandler(this.Filtrele);
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
            this.o_sure});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datapartiler.DefaultCellStyle = dataGridViewCellStyle3;
            this.datapartiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datapartiler.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.datapartiler.Location = new System.Drawing.Point(0, 50);
            this.datapartiler.Name = "datapartiler";
            this.datapartiler.ReadOnly = true;
            this.datapartiler.RowHeadersVisible = false;
            this.datapartiler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datapartiler.Size = new System.Drawing.Size(789, 358);
            this.datapartiler.TabIndex = 5;
            this.datapartiler.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datamusteriler_CellDoubleClick);
            this.datapartiler.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.datamusteriler_DataBindingComplete);
            this.datapartiler.SelectionChanged += new System.EventHandler(this.datamusteriler_SelectionChanged);
            // 
            // o_id
            // 
            this.o_id.DataPropertyName = "ID";
            this.o_id.HeaderText = "Parti No";
            this.o_id.Name = "o_id";
            this.o_id.ReadOnly = true;
            this.o_id.Width = 75;
            // 
            // o_bt
            // 
            this.o_bt.DataPropertyName = "BASTARIH";
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.o_bt.DefaultCellStyle = dataGridViewCellStyle1;
            this.o_bt.HeaderText = "Başlama Tarihi";
            this.o_bt.Name = "o_bt";
            this.o_bt.ReadOnly = true;
            this.o_bt.Width = 107;
            // 
            // o_bta
            // 
            this.o_bta.DataPropertyName = "BITTARIH";
            dataGridViewCellStyle2.Format = "G";
            this.o_bta.DefaultCellStyle = dataGridViewCellStyle2;
            this.o_bta.HeaderText = "Bitiş Tarihi";
            this.o_bta.Name = "o_bta";
            this.o_bta.ReadOnly = true;
            this.o_bta.Width = 85;
            // 
            // o_sure
            // 
            this.o_sure.DataPropertyName = "SURE";
            this.o_sure.HeaderText = "Süre";
            this.o_sure.Name = "o_sure";
            this.o_sure.ReadOnly = true;
            this.o_sure.Width = 55;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.tableLayoutPanel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 408);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(789, 66);
            this.panel2.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.cbtariharalik, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.date1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.date2, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.label8, 1, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(281, 66);
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
            // Oturumlar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(789, 474);
            this.Controls.Add(this.datapartiler);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(431, 217);
            this.Name = "Oturumlar";
            this.Text = "Partiler";
            this.Load += new System.EventHandler(this.Oturumlar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datapartiler)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnsec;
        private System.Windows.Forms.DataGridView datapartiler;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtara;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox cbtariharalik;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_bt;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_bta;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_sure;
    }
}