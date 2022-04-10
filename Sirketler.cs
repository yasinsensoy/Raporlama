using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Raporlama
{
    public partial class Sirketler : Form
    {
        public string ad;
        public int id, sid;
        public bool islem = false, sec = false;

        public Sirketler()
        {
            InitializeComponent();
            Ayar.IconDegis(this);
        }

        private void Sirketler_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, datasirketler, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, datamalzemeler, new object[] { true });
            Guncelle();
            var a = Screen.GetWorkingArea(this);
            Size = new Size(Convert.ToInt32(a.Width * 0.5), Convert.ToInt32(a.Height * 0.5));
            CenterToParent();
        }

        private void btnsec_Click(object sender, EventArgs e)
        {
            ad = datasirketler.SelectedRows[0].Cells["s_ad"].Value.ToString();
            id = Convert.ToInt32(datasirketler.SelectedRows[0].Cells["s_id"].Value);
            sec = true;
            Close();
        }

        private void datamusteriler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnsec.PerformClick();
        }

        private void datamusteriler_SelectionChanged(object sender, EventArgs e)
        {
            btnsec.Enabled = datasirketler.SelectedRows.Count == 1;
            btnmekle.Enabled = datasirketler.SelectedRows.Count == 1;
            MalzemelerGuncelle();
        }

        private void datamusteriler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datasirketler.ClearSelection();
            DataGridViewRow r = datasirketler.Rows.OfType<DataGridViewRow>().FirstOrDefault(x => (int)x.Cells["s_id"].Value == sid);
            if (r != null)
                r.Selected = true;
        }

        private void Guncelle()
        {
            txtara.Text = "";
            Ayar.DataSourceDegis(datasirketler, Ayar.bagl.VeriGetir("SELECT * FROM SIRKETLER ORDER BY AD ASC"));
        }

        private void MalzemelerGuncelle()
        {
            datamalzemeler.ColumnHeadersVisible = false;
            datamalzemeler.DataSource = Ayar.bagl.VeriGetir($"SELECT * FROM MALZEMELER WHERE SID={(datasirketler.SelectedRows.Count == 1 ? datasirketler.SelectedRows[0].Cells["s_id"].Value : 0)}");
        }

        private void datamalzemeler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datamalzemeler.ColumnHeadersVisible = true;
            datamalzemeler.ClearSelection();
            panel2.Width = Math.Max(datamalzemeler.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 25, flowLayoutPanel2.Width);
        }

        private void datamalzemeler_SelectionChanged(object sender, EventArgs e)
        {
            btnmduzenle.Enabled = datamalzemeler.SelectedRows.Count == 1;
            btnmsil.Enabled = datamalzemeler.SelectedRows.Count > 0;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SirketEkleDuzenle frm = new SirketEkleDuzenle();
            frm.Text = "Firma Ekle";
            frm.btnekleduzenle.Text = "Ekle (Enter)";
            frm.ShowDialog();
            if (frm.islem)
            {
                Guncelle();
                islem = true;
            }
        }

        private void btnmekle_Click(object sender, EventArgs e)
        {
            MalzemeEkleDuzenle frm = new MalzemeEkleDuzenle();
            frm.Text = "Malzeme Ekle";
            frm.btnekleduzenle.Text = "Ekle (Enter)";
            frm.sid = Convert.ToInt32(datasirketler.SelectedRows[0].Cells["s_id"].Value);
            frm.ShowDialog();
            if (frm.islem)
                MalzemelerGuncelle();
        }

        private void btnmduzenle_Click(object sender, EventArgs e)
        {
            MalzemeEkleDuzenle frm = new MalzemeEkleDuzenle();
            frm.Text = "Malzeme Düzenle";
            frm.btnekleduzenle.Text = "Düzenle (Enter)";
            frm.id = Convert.ToInt32(datamalzemeler.SelectedRows[0].Cells["m_id"].Value);
            frm.cins = datamalzemeler.SelectedRows[0].Cells["m_cins"].Value.ToString();
            frm.miktar = Convert.ToSingle(datamalzemeler.SelectedRows[0].Cells["m_miktar"].Value);
            frm.ShowDialog();
            if (frm.islem)
                MalzemelerGuncelle();
        }

        private void btnmsil_Click(object sender, EventArgs e)
        {
            DialogResult mesaj = MessageBox.Show("Seçili malzemeleri silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (mesaj == DialogResult.Yes)
            {
                string id = "";
                foreach (DataGridViewRow row in datamalzemeler.SelectedRows)
                    id += (id != "" ? "," : "") + row.Cells["m_id"].Value.ToString();
                if (Ayar.bagl.VeriEkleSilGuncelle($"DELETE FROM MALZEMELER WHERE ID IN ({id})"))
                {
                    MessageBox.Show("Seçilen malzemeler başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MalzemelerGuncelle();
                }
            }
        }

        private void Filtrele(object sender, EventArgs e)
        {
            if (datasirketler.DataSource == null)
                return;
            (datasirketler.DataSource as DataTable).DefaultView.RowFilter = (txtara.Text == "" ? "" : $"AD LIKE '%{txtara.Text}%'");
            datasirketler.ClearSelection();
        }
    }
}