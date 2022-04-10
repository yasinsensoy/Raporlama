using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Raporlama
{
    public partial class Grafik : Form
    {
        public DataTable table, mtable;
        public int oid;
        public string sirket;
        private int aralik = 0;

        public Grafik()
        {
            InitializeComponent();
            Ayar.IconDegis(this);
        }

        private void Grafik_Load(object sender, EventArgs e)
        {
            DateTime tar1 = DateTime.Parse(table.Rows[0]["Tarih"].ToString()).Add(TimeSpan.Parse(table.Rows[0]["Saat"].ToString()));
            DateTime tar2 = DateTime.Parse(table.Rows[1]["Tarih"].ToString()).Add(TimeSpan.Parse(table.Rows[1]["Saat"].ToString()));
            TimeSpan ar = tar2 - tar1;
            aralik = Convert.ToInt32(Math.Round(ar.TotalMinutes));
            chart1.Titles["firma"].Text = $"Firma Adı: {Ayar.FirmaAd}";
            chart1.Titles["nos"].Text = $"Parti No: {oid} Fırın No: {Ayar.FirinNo} Yetki No: {Ayar.YetkiNo}";
            chart1.Titles["sirket"].Text = $"Açıklama: {sirket}";
            lbltoplam.Text = $"Toplam Kayıt: {table.Rows.Count}";
            string malz = "";
            foreach (DataRow row in mtable.Rows)
                malz += $"{(malz == "" ? "" : "\n")}Cinsi: { row["CINS"]} Miktar: { row["MIKTAR"]}";
            chart1.Titles["malzemeler"].Text = malz;
            chart1.ChartAreas[0].AxisX.Title = $"Aralık ({aralik} dak)";
            numericUpDown1_ValueChanged(sender, e);
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<string> liste = new List<string>();
            foreach (string item in checkedListBox1.Items)
            {
                if (checkedListBox1.Items[e.Index].ToString() == item && e.NewValue == CheckState.Unchecked)
                    continue;
                if (checkedListBox1.Items[e.Index].ToString() == item || checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf(item)))
                    liste.Add(item);
            }
            Ciz(liste.ToArray());
        }

        private void Ciz(string[] ogeler)
        {
            int a = Convert.ToInt32(numericUpDown1.Value) - 1;
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = a * aralik;
            DateTime bas = DateTime.Parse(table.Rows[0]["Tarih"].ToString()).Add(TimeSpan.Parse(table.Rows[0]["Saat"].ToString()));
            DateTime bit = DateTime.Parse(table.Rows[a]["Tarih"].ToString()).Add(TimeSpan.Parse(table.Rows[a]["Saat"].ToString()));
            chart1.Titles["oturum"].Text = $"Başlama Zamanı: {bas} BitişZamanı: {bit} ({Ayar.ZamanDuzenle(bit - bas)})";
            chart1.Titles["kayit"].Text = $"Kayıt Sayısı: {numericUpDown1.Value}";
            chart1.Titles["tarih"].Text = $"Tarih: {DateTime.Now:d MMMM yyyy HH:mm:ss}";
            foreach (string item in ogeler)
            {
                Series seri = chart1.Series.Add(item);
                seri.BorderWidth = 3;
                seri.ChartType = SeriesChartType.Line;
                seri.XValueType = ChartValueType.Int32;
                seri.YValueType = ChartValueType.Double;
                int say = 0;
                for (int i = 0; i <= a; i++)
                {
                    string d = table.Rows[i][item].ToString().Replace(" °C", "");
                    seri.Points.AddXY(say, Convert.ToDouble(d));
                    say += aralik;
                }
            }
        }

        private void btnhsec_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);
        }

        private void btnhsecme_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            List<string> liste = new List<string>();
            foreach (string item in checkedListBox1.CheckedItems)
                liste.Add(item);
            Ciz(liste.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                try
                {
                    FormBorderStyle = FormBorderStyle.None;
                    tableLayoutPanel1.Visible = false;
                    WindowState = FormWindowState.Maximized;
                    FormWindowState state = WindowState;
                    string konum = Path.Combine(Ayar.RaporKlasor, $"Parti No {oid} Grafik.png");
                    chart1.SaveImage(konum, System.Drawing.Imaging.ImageFormat.Png);
                    FormBorderStyle = FormBorderStyle.Sizable;
                    tableLayoutPanel1.Visible = true;
                    WindowState = state;
                    MessageBox.Show($"Grafik kaydedildi.\nKonum: {konum}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(konum);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Sütun seçmediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
