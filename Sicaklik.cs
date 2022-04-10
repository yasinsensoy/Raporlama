using System;
using System.Drawing;
using System.Windows.Forms;

namespace Raporlama
{
    public partial class Sicaklik : UserControl
    {
        private double derece = 0;
        private double maxderece = 0;
        private readonly Pen pen = new Pen(Brushes.Black, 1);
        private readonly Font font = new Font("Arial", 8);
        private readonly string[] sicakliklar = { "100", "90", "80", "70", "60", "50", "40", "30", "20", "10", "0" };

        public Sicaklik()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public double Derece { get => derece; set { derece = value; lblsicaklik.Text = $"{value} °C"; if (value > maxderece) MaxDerece = value; panel2.Refresh(); } }
        public double MaxDerece { get => maxderece; set { lblmaxsicaklik.Text = $"{value} °C"; maxderece = value; } }
        public string Baslik { get => lblbaslik.Text; set => lblbaslik.Text = value; }
        public int Adres { get; set; }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            int max = Convert.ToInt32(sicakliklar[0]);
            int y = panel2.Height - (panel2.Height * Convert.ToInt32(derece) / max);
            e.Graphics.FillRectangle((derece >= 57 ? Brushes.DarkGreen : Brushes.DarkRed), 0, y, panel2.Width, panel2.Height - y);
            e.Graphics.DrawRectangle(pen, 0, 0, panel2.Width - 1, panel2.Height - 1);
        }

        private void Sicaklik_Paint(object sender, PaintEventArgs e)
        {
            int aralik = panel2.Height / (sicakliklar.Length - 1);
            int y = panel2.Top + panel1.Top;
            for (int i = 0; i < sicakliklar.Length; i++)
            {
                if (i == sicakliklar.Length - 1)
                    y = panel2.Top + panel1.Top + panel2.Height - 1;
                e.Graphics.DrawLine(pen, panel2.Left - 3, y, panel2.Left, y);
                Size size = TextRenderer.MeasureText(sicakliklar[i], font);
                e.Graphics.DrawString(sicakliklar[i], font, Brushes.Black, panel2.Left - size.Width - 3, y - (size.Height / 2));
                y += aralik;
            }
        }
    }
}
