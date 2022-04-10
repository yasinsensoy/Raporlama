namespace Raporlama
{
    partial class MalzemeEkleDuzenle
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
            this.btnekleduzenle = new System.Windows.Forms.Button();
            this.btnkapat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcins = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmiktar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnekleduzenle
            // 
            this.btnekleduzenle.Location = new System.Drawing.Point(215, 79);
            this.btnekleduzenle.Name = "btnekleduzenle";
            this.btnekleduzenle.Size = new System.Drawing.Size(99, 23);
            this.btnekleduzenle.TabIndex = 10;
            this.btnekleduzenle.TabStop = false;
            this.btnekleduzenle.Text = "Ekle (Enter)";
            this.btnekleduzenle.UseVisualStyleBackColor = true;
            this.btnekleduzenle.Click += new System.EventHandler(this.btnekleduzenle_Click);
            // 
            // btnkapat
            // 
            this.btnkapat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnkapat.Location = new System.Drawing.Point(320, 79);
            this.btnkapat.Margin = new System.Windows.Forms.Padding(12);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(75, 23);
            this.btnkapat.TabIndex = 11;
            this.btnkapat.TabStop = false;
            this.btnkapat.Text = "Kapat (Esc)";
            this.btnkapat.UseVisualStyleBackColor = true;
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Malzeme Cinsi";
            // 
            // txtcins
            // 
            this.txtcins.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.txtcins.Location = new System.Drawing.Point(119, 12);
            this.txtcins.MaxLength = 120;
            this.txtcins.Name = "txtcins";
            this.txtcins.Size = new System.Drawing.Size(276, 23);
            this.txtcins.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Malzeme Miktarı";
            // 
            // txtmiktar
            // 
            this.txtmiktar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.txtmiktar.Location = new System.Drawing.Point(119, 41);
            this.txtmiktar.MaxLength = 50;
            this.txtmiktar.Name = "txtmiktar";
            this.txtmiktar.Size = new System.Drawing.Size(276, 23);
            this.txtmiktar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Not: Küsürat için virgül (,) kullanın";
            // 
            // MalzemeEkleDuzenle
            // 
            this.AcceptButton = this.btnekleduzenle;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnkapat;
            this.ClientSize = new System.Drawing.Size(407, 157);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtmiktar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtcins);
            this.Controls.Add(this.btnkapat);
            this.Controls.Add(this.btnekleduzenle);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MalzemeEkleDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şirket Ekle";
            this.Load += new System.EventHandler(this.MalzemeEkleDuzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnkapat;
        public System.Windows.Forms.Button btnekleduzenle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcins;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtmiktar;
        private System.Windows.Forms.Label label1;
    }
}