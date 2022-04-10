using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Raporlama
{
    public partial class Rapor : Form
    {
        public DataTable table, mtable;
        public int oid;
        public string sirket;

        public Rapor()
        {
            InitializeComponent();
            Ayar.IconDegis(this);
        }

        private void Rapor_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = numericUpDown1.Maximum = table.Rows.Count;
            lbltoplam.Text = $"Toplam Kayıt: {table.Rows.Count}";
            comboBox1.Items.Clear();
            foreach (string item in Ayar.Raporlar.Split(','))
            {
                string[] a = item.Split(' ');
                if (Convert.ToBoolean(a[1]))
                    comboBox1.Items.Add(a[0]);
            }
            if (comboBox1.Items.Count == 0)
                comboBox1.Items.Add("Pdf");
            comboBox1.SelectedIndex = Ayar.RaporIndex >= comboBox1.Items.Count ? 0 : Ayar.RaporIndex;
            txtkayityeri.Text = Ayar.RaporKlasor;
            checkedListBox1.Items.Clear();
            foreach (DataColumn col in table.Columns)
            {
                if (col.Ordinal != 0 && col.Ordinal != 1 && col.Ordinal != 2)
                    checkedListBox1.Items.Add(col.ColumnName);
            }
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);
            Text = $"Rapor - Parti No {oid}";
        }

        private void btnsec_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "Rapor klasörünü seçin...";
            folder.ShowNewFolderButton = true;
            folder.SelectedPath = Ayar.RaporKlasor;
            if (folder.ShowDialog() == DialogResult.OK)
            {
                Ayar.RaporKlasor = folder.SelectedPath;
                txtkayityeri.Text = folder.SelectedPath;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ayar.RaporIndex = comboBox1.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable t = Tablo();
            switch (comboBox1.Text)
            {
                case "Pdf":
                    if (checkedListBox1.CheckedItems.Count > 0)
                        Ayar.PdfAktar(Path.Combine(txtkayityeri.Text, $"Parti No {oid} Rapor.pdf"), sirket, Oturum(t), oid, t, mtable);
                    else
                        MessageBox.Show("Sütun seçmediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case "Excel":
                    if (checkedListBox1.CheckedItems.Count > 0)
                        Ayar.ExcelAktar(Path.Combine(txtkayityeri.Text, $"Parti No {oid} Rapor.xlsx"), sirket, Oturum(t), oid, t, mtable);
                    else
                        MessageBox.Show("Sütun seçmediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case "Grafik":
                    if (t.Rows.Count < 2)
                    {
                        MessageBox.Show("En az 2 kayıt olması lazım.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    Grafik frm = new Grafik();
                    frm.mtable = mtable;
                    frm.oid = oid;
                    frm.sirket = sirket;
                    frm.table = t;
                    frm.checkedListBox1.Items.Clear();
                    frm.numericUpDown1.Maximum = numericUpDown1.Maximum;
                    frm.numericUpDown1.Value = numericUpDown1.Value;
                    foreach (string col in checkedListBox1.Items)
                        frm.checkedListBox1.Items.Add(col);
                    foreach (object col in checkedListBox1.CheckedItems)
                        frm.checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(col), true);
                    frm.ShowDialog();
                    break;
            }
        }

        private DataTable Tablo()
        {
            DataTable t = new DataTable();
            t.Columns.Add(table.Columns[0].ColumnName, table.Columns[0].DataType);
            t.Columns.Add(table.Columns[1].ColumnName, table.Columns[1].DataType);
            t.Columns.Add(table.Columns[2].ColumnName, table.Columns[2].DataType);
            foreach (string item in checkedListBox1.CheckedItems)
                t.Columns.Add(item, typeof(string));
            int say = 1;
            int a = comboBox1.Text == "Grafik" ? -1 : table.Rows.Count - Convert.ToInt32(numericUpDown1.Value) - 1;
            for (int i = table.Rows.Count - 1; i > a; i--)
            {
                List<object> list = new List<object>();
                list.Add(say++);
                list.Add(table.Rows[i][1]);
                list.Add(table.Rows[i][2]);
                foreach (string item in checkedListBox1.CheckedItems)
                    list.Add(table.Rows[i][item]);
                t.Rows.Add(list.ToArray());
            }
            return t;
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

        private string Oturum(DataTable t)
        {
            DateTime bas = DateTime.Parse(t.Rows[0]["Tarih"].ToString()).Add(TimeSpan.Parse(t.Rows[0]["Saat"].ToString()));
            DateTime bit = DateTime.Parse(t.Rows[t.Rows.Count - 1]["Tarih"].ToString()).Add(TimeSpan.Parse(t.Rows[t.Rows.Count - 1]["Saat"].ToString()));
            return $"Başlama Zamanı: {bas} BitişZamanı: {bit} ({Ayar.ZamanDuzenle(bit - bas)})";
        }
    }
}
