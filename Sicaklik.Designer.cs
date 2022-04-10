namespace Raporlama
{
    partial class Sicaklik
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblsicaklik = new System.Windows.Forms.Label();
            this.lblmaxsicaklik = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblbaslik = new System.Windows.Forms.Label();
            this.panel2 = new CustomPanel();
            this.panel1 = new CustomTableLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblsicaklik
            // 
            this.lblsicaklik.AutoSize = true;
            this.lblsicaklik.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblsicaklik.Location = new System.Drawing.Point(64, 3);
            this.lblsicaklik.Margin = new System.Windows.Forms.Padding(3);
            this.lblsicaklik.Name = "lblsicaklik";
            this.lblsicaklik.Size = new System.Drawing.Size(48, 24);
            this.lblsicaklik.TabIndex = 0;
            this.lblsicaklik.Text = "0 °C";
            // 
            // lblmaxsicaklik
            // 
            this.lblmaxsicaklik.AutoSize = true;
            this.lblmaxsicaklik.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblmaxsicaklik.ForeColor = System.Drawing.Color.DarkRed;
            this.lblmaxsicaklik.Location = new System.Drawing.Point(64, 33);
            this.lblmaxsicaklik.Margin = new System.Windows.Forms.Padding(3);
            this.lblmaxsicaklik.Name = "lblmaxsicaklik";
            this.lblmaxsicaklik.Size = new System.Drawing.Size(48, 24);
            this.lblmaxsicaklik.TabIndex = 1;
            this.lblmaxsicaklik.Text = "0 °C";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Güncel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "En Fazla";
            // 
            // lblbaslik
            // 
            this.lblbaslik.AutoSize = true;
            this.lblbaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblbaslik.Location = new System.Drawing.Point(3, 0);
            this.lblbaslik.Name = "lblbaslik";
            this.lblbaslik.Size = new System.Drawing.Size(70, 25);
            this.lblbaslik.TabIndex = 4;
            this.lblbaslik.Text = "Başlık";
            this.lblbaslik.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(92, 66);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 200);
            this.panel2.TabIndex = 7;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.ColumnCount = 2;
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panel1.Controls.Add(this.lblmaxsicaklik, 1, 1);
            this.panel1.Controls.Add(this.panel2, 0, 2);
            this.panel1.Controls.Add(this.lblsicaklik, 1, 0);
            this.panel1.Controls.Add(this.label4, 0, 1);
            this.panel1.Controls.Add(this.label3, 0, 0);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.RowCount = 3;
            this.panel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel1.Size = new System.Drawing.Size(115, 272);
            this.panel1.TabIndex = 8;
            // 
            // Sicaklik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblbaslik);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "Sicaklik";
            this.Size = new System.Drawing.Size(115, 300);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Sicaklik_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblsicaklik;
        private System.Windows.Forms.Label lblmaxsicaklik;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblbaslik;
        private CustomPanel panel2;
        private CustomTableLayoutPanel panel1;
    }
}
