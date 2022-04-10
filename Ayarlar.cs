using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace Raporlama
{
    public partial class Ayarlar : Form
    {
        public bool islem = false, oislem = false;

        public Ayarlar()
        {
            InitializeComponent();
            Ayar.IconDegis(this);
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dataadresler, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, datagirisler, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dataoturumlar, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, datasirketler, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, datamalzemeler, new object[] { true });
            Rectangle rct = Screen.GetWorkingArea(this);
            Size = new Size(Convert.ToInt32(rct.Width * 0.5), Convert.ToInt32(rct.Height * 0.5));
            CenterToParent();
            GenelGuncelle();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "adres": AdreslerGuncelle(); break;
                case "genel": GenelGuncelle(); break;
                case "girisler": GirislerGuncelle(); break;
                case "oturumlar": SirketlerGuncelle(); break;
                case "firmalar": FirmalarGuncelle(); break;
            }
        }

        #region "Genel"
        private void GenelGuncelle()
        {
            txtfirmaad.Text = Ayar.FirmaAd;
            txtip.Text = Ayar.Ip;
            txtport.Text = Ayar.Port.ToString();
            txtdurduradres.Text = Ayar.DurdurAdres == -1 ? "" : Ayar.DurdurAdres.ToString();
            txtdurmasure.Text = Ayar.OtoDurSure.ToString();
            txtplcadres.Text = Ayar.PlcAdres == -1 ? "" : Ayar.PlcAdres.ToString();
            txtgms.Text = Ayar.GMS;
            txtfirinno.Text = Ayar.FirinNo.ToString();
            txtyetkino.Text = Ayar.YetkiNo.ToString();
            checkedListBox1.Items.Clear();
            foreach (string item in Ayar.Raporlar.Split(','))
            {
                string[] a = item.Split(' ');
                checkedListBox1.Items.Add(a[0], Convert.ToBoolean(a[1]));
            }
            lblip.Text = "";
            foreach (Ag ag in Ayar.IpGetir())
            {
                lblip.Text += $"Ip: {ag.Ip}{string.Concat(Enumerable.Repeat(" ", 15 - ag.Ip.Length))} Ad: {ag.Isim}\n";
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string liste = "";
            if (checkedListBox1.Items.Count != 3)
                return;
            bool k = false;
            foreach (string item in checkedListBox1.Items)
            {
                bool b;
                if (checkedListBox1.Items[e.Index].ToString() == item)
                    b = e.NewValue == CheckState.Checked;
                else
                    b = checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf(item));
                if (!k)
                    k = b;
                liste += $"{(liste == "" ? "" : ",")}{item} {b}";
            }
            Ayar.Raporlar = liste;
            if (!k)
                MessageBox.Show("En az 1 tane rapor türü seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #region  "Fırın No Ayar"
        private void txtfirinno_TextChanged(object sender, EventArgs e)
        {
            bool a = int.TryParse(txtfirinno.Text, out int fno);
            btnfirinnokaydet.Enabled = (a && Ayar.FirinNo != fno);
        }

        private void txtfirinno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnfirinnokaydet.PerformClick();
        }

        private void btnfirinnokaydet_Click(object sender, EventArgs e)
        {
            if (txtfirinno.Text == "")
            {
                MessageBox.Show("Fırın no boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfirinno.Focus();
            }
            else if (!int.TryParse(txtfirinno.Text, out int fno))
            {
                MessageBox.Show("Fırın no sayısal olmalı hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfirinno.Focus();
            }
            else
            {
                Ayar.FirinNo = fno;
                MessageBox.Show("Değişiklikler kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnfirinnokaydet.Enabled = false;
            }
        }
        #endregion

        #region  "Yetki No Ayar"
        private void txtyetkino_TextChanged(object sender, EventArgs e)
        {
            bool a = int.TryParse(txtyetkino.Text, out int yno);
            btnyetkinokaydet.Enabled = (a && Ayar.YetkiNo != yno);
        }

        private void txtyetkino_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnyetkinokaydet.PerformClick();
        }

        private void btnyetkinokaydet_Click(object sender, EventArgs e)
        {
            if (txtyetkino.Text == "")
            {
                MessageBox.Show("Yetki no boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtyetkino.Focus();
            }
            else if (!int.TryParse(txtyetkino.Text, out int yno))
            {
                MessageBox.Show("Yetki no sayısal olmalı hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtyetkino.Focus();
            }
            else
            {
                Ayar.YetkiNo = yno;
                MessageBox.Show("Değişiklikler kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnyetkinokaydet.Enabled = false;
            }
        }
        #endregion

        #region  "GMS Ayar"
        private void txtgms_TextChanged(object sender, EventArgs e)
        {
            btngmskaydet.Enabled = Ayar.GMS != txtgms.Text;
        }

        private void txtgms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btngmskaydet.PerformClick();
        }

        private void btngmskaydet_Click(object sender, EventArgs e)
        {
            if (txtgms.Text == "")
            {
                MessageBox.Show("Şifre boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtgms.Focus();
            }
            else
            {
                Ayar.GMS = txtgms.Text;
                MessageBox.Show("Değişiklikler kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btngmskaydet.Enabled = false;
            }
        }
        #endregion

        #region  "Firma Ayar"
        private void txtfirmaad_TextChanged(object sender, EventArgs e)
        {
            btnfirmakaydet.Enabled = Ayar.FirmaAd != txtfirmaad.Text;
        }

        private void txtfirmaad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnfirmakaydet.PerformClick();
        }

        private void btnfirmakaydet_Click(object sender, EventArgs e)
        {
            if (txtfirmaad.Text == "")
            {
                MessageBox.Show("Firma adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfirmaad.Focus();
            }
            else
            {
                Ayar.FirmaAd = txtfirmaad.Text;
                MessageBox.Show("Değişiklikler kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnfirmakaydet.Enabled = false;
            }
        }
        #endregion

        #region  "Durdur Ayar"
        private void txtkontrol_TextChanged(object sender, EventArgs e)
        {
            bool a = int.TryParse(txtdurduradres.Text, out int adres);
            bool b = int.TryParse(txtdurmasure.Text, out int sure);
            btnadreskaydet.Enabled = (a && Ayar.DurdurAdres != adres) || (b && Ayar.OtoDurSure != sure);
        }

        private void txtkontrol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnadreskaydet.PerformClick();
        }

        private void btnadreskaydet_Click(object sender, EventArgs e)
        {
            if (txtdurduradres.Text == "")
            {
                MessageBox.Show("Adres boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdurduradres.Focus();
            }
            else if (txtdurmasure.Text == "")
            {
                MessageBox.Show("Süre boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdurmasure.Focus();
            }
            else if (!int.TryParse(txtdurduradres.Text, out int adres))
            {
                MessageBox.Show("Adres sayısal olmalı hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdurduradres.Focus();
            }
            else if (!int.TryParse(txtdurmasure.Text, out int sure))
            {
                MessageBox.Show("Süre sayısal olmalı hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdurmasure.Focus();
            }
            else if (adres == -1)
            {
                MessageBox.Show("Adres -1 olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdurduradres.Focus();
            }
            else if (sure < 0)
            {
                MessageBox.Show("Süre negatif olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdurmasure.Focus();
            }
            else
            {
                Ayar.DurdurAdres = adres;
                Ayar.OtoDurSure = sure;
                MessageBox.Show("Değişiklikler kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnadreskaydet.Enabled = false;
            }
        }

        private void btnadrestest_Click(object sender, EventArgs e)
        {
            if (txtdurduradres.Text == "")
            {
                MessageBox.Show("Adres boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdurduradres.Focus();
            }
            else if (!int.TryParse(txtdurduradres.Text, out int adres))
            {
                MessageBox.Show("Adres sayısal olmalı hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdurduradres.Focus();
            }
            else if (adres == -1)
            {
                MessageBox.Show("Adres -1 olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdurduradres.Focus();
            }
            else
            {
                PLCVeri test = new PLCVeri();
                if (test.Baglan(Ayar.Ip, Ayar.Port) && test.DurdurKontrol(adres))
                    MessageBox.Show($"Bağlantı başarılı.\nDeğer: {test.Durdur}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region  "PLC Ayar"
        private void txtplcadres_TextChanged(object sender, EventArgs e)
        {
            bool a = int.TryParse(txtplcadres.Text, out int adres);
            btnplckaydet.Enabled = (a && Ayar.PlcAdres != adres);
        }

        private void txtplcadres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnplckaydet.PerformClick();
        }

        private void btnplckaydet_Click(object sender, EventArgs e)
        {
            if (txtplcadres.Text == "")
            {
                MessageBox.Show("Adres boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtplcadres.Focus();
            }
            else if (!int.TryParse(txtplcadres.Text, out int adres))
            {
                MessageBox.Show("Adres sayısal olmalı hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtplcadres.Focus();
            }
            else if (adres == -1)
            {
                MessageBox.Show("Adres -1 olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtplcadres.Focus();
            }
            else
            {
                Ayar.PlcAdres = adres;
                MessageBox.Show("Değişiklikler kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnplckaydet.Enabled = false;
            }
        }

        private void btnplctest_Click(object sender, EventArgs e)
        {
            if (txtplcadres.Text == "")
            {
                MessageBox.Show("Adres boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtplcadres.Focus();
            }
            else if (!int.TryParse(txtplcadres.Text, out int adres))
            {
                MessageBox.Show("Adres sayısal olmalı hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtplcadres.Focus();
            }
            else if (adres == -1)
            {
                MessageBox.Show("Adres -1 olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtplcadres.Focus();
            }
            else
            {
                PLCVeri test = new PLCVeri();
                bool t = test.Baglan(Ayar.Ip, Ayar.Port);
                if (t && test.Durum)
                    MessageBox.Show("Bağlantı başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (t && !test.Durum)
                    MessageBox.Show("Plc doğrulanamadı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region  "İp Ayar"
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtip.Text == "")
            {
                MessageBox.Show("İp boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtip.Focus();
            }
            else if (txtport.Text == "")
            {
                MessageBox.Show("Port boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtport.Focus();
            }
            else if (!IPAddress.TryParse(txtip.Text, out IPAddress ip))
            {
                MessageBox.Show("İp biçimi hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtip.Focus();
            }
            else if (!int.TryParse(txtport.Text, out int port))
            {
                MessageBox.Show("Port sayısal olmalı hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtport.Focus();
            }
            else
            {
                Ayar.Ip = ip.ToString();
                txtip.Text = ip.ToString();
                Ayar.Port = port;
                MessageBox.Show("Değişiklikler kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnkaydet.Enabled = false;
            }
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            if (!IPAddress.TryParse(txtip.Text, out IPAddress ip))
            {
                MessageBox.Show("İp biçimi hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtip.Focus();
            }
            else if (!int.TryParse(txtport.Text, out int port))
            {
                MessageBox.Show("Port sayısal olmalı hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtport.Focus();
            }
            else
            {
                if (new PLCVeri().Baglan(ip.ToString(), port))
                    MessageBox.Show("Bağlantı başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Duzenle(object sender, EventArgs e)
        {
            bool a = int.TryParse(txtport.Text, out int port);
            bool b = IPAddress.TryParse(txtip.Text, out IPAddress ip);
            btnkaydet.Enabled = (a && Ayar.Port != port) || (b && Ayar.Ip != ip.ToString());
        }

        private void txtip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnkaydet.PerformClick();
        }
        #endregion
        #endregion

        #region "Adresler"
        private void AdreslerGuncelle()
        {
            Ayar.DataSourceDegis(dataadresler, Ayar.bagl.VeriGetir("SELECT * FROM ADRESLER ORDER BY ID"));
        }

        private void btnadresekle_Click(object sender, EventArgs e)
        {
            AdresEkleDuzenle frm = new AdresEkleDuzenle();
            frm.Text = "Adres Ekle";
            frm.btnekleduzenle.Text = "Ekle (Enter)";
            frm.ShowDialog();
            if (frm.islem)
            {
                AdreslerGuncelle();
                islem = true;
            }
        }

        private void btnadresduzenle_Click(object sender, EventArgs e)
        {
            AdresEkleDuzenle frm = new AdresEkleDuzenle();
            frm.Text = "Adres Düzenle";
            frm.btnekleduzenle.Text = "Düzenle (Enter)";
            frm.id = Convert.ToInt32(dataadresler.SelectedRows[0].Cells["a_id"].Value);
            frm.adres = Convert.ToInt32(dataadresler.SelectedRows[0].Cells["a_adres"].Value);
            frm.isim = dataadresler.SelectedRows[0].Cells["a_isim"].Value.ToString();
            frm.ShowDialog();
            if (frm.islem)
            {
                AdreslerGuncelle();
                islem = true;
            }
        }

        private void btnadressil_Click(object sender, EventArgs e)
        {
            DialogResult mesaj = MessageBox.Show("Seçili adresleri silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (mesaj == DialogResult.Yes)
            {
                string id = "";
                foreach (DataGridViewRow row in dataadresler.SelectedRows)
                    id += (id != "" ? "," : "") + row.Cells["a_id"].Value.ToString();
                if (Ayar.bagl.VeriEkleSilGuncelle($"DELETE FROM ADRESLER WHERE ID IN ({id})"))
                {
                    MessageBox.Show("Seçilen adresler başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdreslerGuncelle();
                    islem = true;
                }
            }
        }

        private void dataadresler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataadresler.ClearSelection();
        }

        private void dataadresler_SelectionChanged(object sender, EventArgs e)
        {
            btnadressil.Enabled = dataadresler.SelectedRows.Count > 0;
            btnadresduzenle.Enabled = dataadresler.SelectedRows.Count == 1;
        }
        #endregion

        #region "Girişler"
        private void GirislerGuncelle()
        {
            DataTable table = Ayar.bagl.VeriGetir("SELECT * FROM GIRISLER ORDER BY ID DESC");
            DataTable t = new DataTable();
            if (table != null)
            {
                foreach (DataColumn c in table.Columns)
                    t.Columns.Add(c.ColumnName, c.DataType);
                t.Columns.Add("SURE", typeof(string));
                foreach (DataRow row in table.Rows)
                {
                    List<object> list = new List<object>();
                    list.AddRange(row.ItemArray);
                    DateTime bas = DateTime.Parse(row["GIRISTARIH"].ToString()).Add(TimeSpan.Parse(row["GIRISSAAT"].ToString()));
                    DateTime bit = new DateTime();
                    string bt = row["CIKISTARIH"].ToString();
                    if (bt != "")
                        bit = DateTime.Parse(bt).Add(TimeSpan.Parse(row["CIKISSAAT"].ToString()));
                    string ad = Ayar.ZamanDuzenle(bit - bas);
                    list.Add(ad);
                    t.Rows.Add(list.ToArray());
                }
            }
            Ayar.DataSourceDegis(datagirisler, t);
        }

        private void btngirissil_Click(object sender, EventArgs e)
        {
            DialogResult mesaj = MessageBox.Show("Seçili girişleri silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (mesaj == DialogResult.Yes)
            {
                string id = "";
                foreach (DataGridViewRow row in datagirisler.SelectedRows)
                    id += (id != "" ? "," : "") + row.Cells["g_id"].Value.ToString();
                if (Ayar.bagl.VeriEkleSilGuncelle($"DELETE FROM GIRISLER WHERE ID IN ({id})"))
                {
                    MessageBox.Show("Seçilen girişler başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GirislerGuncelle();
                }
            }
        }

        private void datagirisler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datagirisler.ClearSelection();
        }

        private void datagirisler_SelectionChanged(object sender, EventArgs e)
        {
            btngirissil.Enabled = datagirisler.SelectedRows.Count > 0;
        }
        #endregion     

        #region "Oturumlar"
        private void SirketlerGuncelle()
        {
            DataTable data = Ayar.bagl.VeriGetir("SELECT * FROM SIRKETLER ORDER BY AD ASC");
            DataRow row = data.NewRow();
            row.ItemArray = new object[] { 0, "Tümü" };
            data.Rows.InsertAt(row, 0);
            cbsirketler.DataSource = data;
        }

        private void OturumlarGuncelle()
        {
            Ayar.veriler.Clear();
            Ayar.veriler.Add(new FbParameter("@sid", Convert.ToInt32(cbsirketler.SelectedValue)));
            DataTable table = Ayar.bagl.VeriGetir($"SELECT ID,BASTARIH,BITTARIH,BASZAMAN,BITZAMAN,(SELECT COUNT(ID) AS ADET FROM VERILER WHERE OID=OTURUMLAR.ID),(SELECT AD FROM SIRKETLER WHERE ID=OTURUMLAR.SID) FROM OTURUMLAR {(Convert.ToInt32(cbsirketler.SelectedValue) == 0 ? "" : "WHERE SID=@sid ")}ORDER BY ID DESC", Ayar.veriler);
            DataTable t = new DataTable();
            if (table != null)
            {
                foreach (DataColumn c in table.Columns)
                    t.Columns.Add(c.ColumnName, c.DataType);
                t.Columns.Add("SURE", typeof(string));
                foreach (DataRow row in table.Rows)
                {
                    List<object> list = new List<object>();
                    list.AddRange(row.ItemArray);
                    DateTime bas = DateTime.Parse(row["BASTARIH"].ToString()).Add(TimeSpan.Parse(row["BASZAMAN"].ToString()));
                    DateTime bit = new DateTime();
                    string bt = row["BITTARIH"].ToString();
                    if (bt != "")
                        bit = DateTime.Parse(bt).Add(TimeSpan.Parse(row["BITZAMAN"].ToString()));
                    string ad = Ayar.ZamanDuzenle(bit - bas);
                    list.Add(ad);
                    t.Rows.Add(list.ToArray());
                }
            }
            Ayar.DataSourceDegis(dataoturumlar, t);
        }

        private void cbsirketler_SelectedIndexChanged(object sender, EventArgs e)
        {
            OturumlarGuncelle();
        }

        private void btnoturumsil_Click(object sender, EventArgs e)
        {
            DialogResult mesaj = MessageBox.Show("Seçili partileri silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (mesaj == DialogResult.Yes)
            {
                string id = "";
                foreach (DataGridViewRow row in dataoturumlar.SelectedRows)
                    id += (id != "" ? "," : "") + row.Cells["o_id"].Value.ToString();
                if (Ayar.bagl.VeriEkleSilGuncelle($"DELETE FROM OTURUMLAR WHERE ID IN ({id})"))
                {
                    MessageBox.Show("Seçilen partiler başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OturumlarGuncelle();
                    oislem = true;
                }
            }
        }

        private void btnoturumsifirla_Click(object sender, EventArgs e)
        {
            DialogResult mesaj = MessageBox.Show("Tüm partiler ve veriler sıfırlanacak.\n Onaylıyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (mesaj == DialogResult.Yes)
            {
                if (Ayar.bagl.VeriEkleSilGuncelle("DELETE FROM OTURUMLAR") && Ayar.bagl.VeriEkleSilGuncelle("ALTER TABLE OTURUMLAR ALTER COLUMN ID RESTART"))
                {
                    Ayar.bagl.VeriEkleSilGuncelle("ALTER TABLE VERILER ALTER COLUMN ID RESTART", null, false);
                    MessageBox.Show("Tüm partiler ve veriler sıfırlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OturumlarGuncelle();
                    oislem = true;
                }
            }
        }

        private void dataoturumlar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataoturumlar.ClearSelection();
        }

        private void dataoturumlar_SelectionChanged(object sender, EventArgs e)
        {
            btnoturumsil.Enabled = dataoturumlar.SelectedRows.Count > 0;
        }
        #endregion

        #region "Firmalar"
        private void datamusteriler_SelectionChanged(object sender, EventArgs e)
        {
            btnduzenle.Enabled = datasirketler.SelectedRows.Count == 1;
            btnsil.Enabled = datasirketler.SelectedRows.Count > 0;
            btnmekle.Enabled = datasirketler.SelectedRows.Count == 1;
            MalzemelerGuncelle();
        }

        private void datamusteriler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datasirketler.ClearSelection();
        }

        private void FirmalarGuncelle()
        {
            txtara.Text = "";
            Ayar.DataSourceDegis(datasirketler, Ayar.bagl.VeriGetir("SELECT * FROM SIRKETLER ORDER BY AD ASC"));
        }

        private void MalzemelerGuncelle()
        {
            datamalzemeler.ColumnHeadersVisible = false;
            datamalzemeler.DataSource = Ayar.bagl.VeriGetir($"SELECT * FROM MALZEMELER WHERE SID={(datasirketler.SelectedRows.Count == 1 ? datasirketler.SelectedRows[0].Cells["s_id"].Value : 0)}");
        }

        private void datamalzemeler_SelectionChanged(object sender, EventArgs e)
        {
            btnmduzenle.Enabled = datamalzemeler.SelectedRows.Count == 1;
            btnmsil.Enabled = datamalzemeler.SelectedRows.Count > 0;
        }

        private void datamalzemeler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datamalzemeler.ColumnHeadersVisible = true;
            datamalzemeler.ClearSelection();
            panel2.Width = datamalzemeler.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 25;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SirketEkleDuzenle frm = new SirketEkleDuzenle();
            frm.Text = "Firma Ekle";
            frm.btnekleduzenle.Text = "Ekle (Enter)";
            frm.ShowDialog();
            if (frm.islem)
            {
                FirmalarGuncelle();
                oislem = true;
            }
        }

        private void btnduzenle_Click(object sender, EventArgs e)
        {
            SirketEkleDuzenle frm = new SirketEkleDuzenle();
            frm.Text = "Firma Düzenle";
            frm.btnekleduzenle.Text = "Düzenle (Enter)";
            frm.id = Convert.ToInt32(datasirketler.SelectedRows[0].Cells["s_id"].Value);
            frm.ad = datasirketler.SelectedRows[0].Cells["s_ad"].Value.ToString();
            frm.ShowDialog();
            if (frm.islem)
            {
                FirmalarGuncelle();
                oislem = true;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult mesaj = MessageBox.Show("Seçili firmaları silmek istiyor musunuz?\n\nÖnemli!!!\nSildiğiniz firmaların malzemeleri, partileri ve verileride silinecektir.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (mesaj == DialogResult.Yes)
            {
                string id = "";
                foreach (DataGridViewRow row in datasirketler.SelectedRows)
                    id += (id != "" ? "," : "") + row.Cells["s_id"].Value.ToString();
                if (Ayar.bagl.VeriEkleSilGuncelle($"DELETE FROM SIRKETLER WHERE ID IN ({id})"))
                {
                    MessageBox.Show("Seçilen firmalar başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FirmalarGuncelle();
                    oislem = true;
                }
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
        #endregion
    }
}
