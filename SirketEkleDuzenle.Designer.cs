namespace Raporlama
{
    partial class SirketEkleDuzenle
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
            this.txtad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnekleduzenle = new System.Windows.Forms.Button();
            this.btnkapat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtad
            // 
            this.txtad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.txtad.Location = new System.Drawing.Point(119, 12);
            this.txtad.MaxLength = 120;
            this.txtad.Name = "txtad";
            this.txtad.Size = new System.Drawing.Size(257, 23);
            this.txtad.TabIndex = 0;
            this.txtad.TextChanged += new System.EventHandler(this.Duzenle);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ad";
            // 
            // btnekleduzenle
            // 
            this.btnekleduzenle.Location = new System.Drawing.Point(196, 50);
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
            this.btnkapat.Location = new System.Drawing.Point(301, 50);
            this.btnkapat.Margin = new System.Windows.Forms.Padding(12);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(75, 23);
            this.btnkapat.TabIndex = 11;
            this.btnkapat.TabStop = false;
            this.btnkapat.Text = "Kapat (Esc)";
            this.btnkapat.UseVisualStyleBackColor = true;
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // SirketEkleDuzenle
            // 
            this.AcceptButton = this.btnekleduzenle;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnkapat;
            this.ClientSize = new System.Drawing.Size(407, 157);
            this.Controls.Add(this.btnkapat);
            this.Controls.Add(this.btnekleduzenle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtad);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SirketEkleDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şirket Ekle";
            this.Load += new System.EventHandler(this.SirketEkleDuzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnkapat;
        public System.Windows.Forms.Button btnekleduzenle;
    }
}