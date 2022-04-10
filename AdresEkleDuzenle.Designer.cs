namespace Raporlama
{
    partial class AdresEkleDuzenle
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtisim = new System.Windows.Forms.TextBox();
            this.btnekleduzenle = new System.Windows.Forms.Button();
            this.btnkapat = new System.Windows.Forms.Button();
            this.txtadres = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Adres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "İsim";
            // 
            // txtisim
            // 
            this.txtisim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.txtisim.Location = new System.Drawing.Point(92, 41);
            this.txtisim.MaxLength = 100;
            this.txtisim.Name = "txtisim";
            this.txtisim.Size = new System.Drawing.Size(180, 23);
            this.txtisim.TabIndex = 1;
            this.txtisim.TextChanged += new System.EventHandler(this.Duzenle);
            // 
            // btnekleduzenle
            // 
            this.btnekleduzenle.Location = new System.Drawing.Point(92, 79);
            this.btnekleduzenle.Name = "btnekleduzenle";
            this.btnekleduzenle.Size = new System.Drawing.Size(99, 23);
            this.btnekleduzenle.TabIndex = 2;
            this.btnekleduzenle.TabStop = false;
            this.btnekleduzenle.Text = "Ekle (Enter)";
            this.btnekleduzenle.UseVisualStyleBackColor = true;
            this.btnekleduzenle.Click += new System.EventHandler(this.btnekleduzenle_Click);
            // 
            // btnkapat
            // 
            this.btnkapat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnkapat.Location = new System.Drawing.Point(197, 79);
            this.btnkapat.Margin = new System.Windows.Forms.Padding(12);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(75, 23);
            this.btnkapat.TabIndex = 3;
            this.btnkapat.TabStop = false;
            this.btnkapat.Text = "Kapat (Esc)";
            this.btnkapat.UseVisualStyleBackColor = true;
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // txtadres
            // 
            this.txtadres.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.txtadres.Location = new System.Drawing.Point(92, 12);
            this.txtadres.MaxLength = 5;
            this.txtadres.Name = "txtadres";
            this.txtadres.Size = new System.Drawing.Size(180, 23);
            this.txtadres.TabIndex = 0;
            // 
            // AdresEkleDuzenle
            // 
            this.AcceptButton = this.btnekleduzenle;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnkapat;
            this.ClientSize = new System.Drawing.Size(288, 116);
            this.Controls.Add(this.txtadres);
            this.Controls.Add(this.btnkapat);
            this.Controls.Add(this.btnekleduzenle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtisim);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdresEkleDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Ekle";
            this.Load += new System.EventHandler(this.AdresEkleDuzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtisim;
        private System.Windows.Forms.Button btnkapat;
        public System.Windows.Forms.Button btnekleduzenle;
        private System.Windows.Forms.TextBox txtadres;
    }
}