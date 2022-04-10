using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Raporlama_Ayar
{
    public partial class Form1 : Form
    {
        Kayit kayit = new Kayit();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            if (txtadres.Text == "")
            {
                MessageBox.Show("Adres boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtadres.Focus();
            }
            else if (txtisim.Text == "")
            {
                MessageBox.Show("İsim boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtisim.Focus();
            }
            else if (!int.TryParse(txtadres.Text, out int adr))
            {
                MessageBox.Show("Adres sayısal değer olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtadres.Focus();
            }
            else if (listView1.Items.Count > 0 && listView1.FindItemWithText(txtisim.Text, true, 0) != null)
            {
                MessageBox.Show("Aynı isim listede var.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtisim.Focus();
            }
            else
            {
                listView1.Items.Add(adr.ToString()).SubItems.Add(txtisim.Text);
                txtadres.Focus();
                txtadres.SelectAll();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
                listView1.Items.Remove(item);
        }

        private void btnyukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Ayar Dosyası | *.ysayar";
            file.Multiselect = false;
            file.Title = "Ayar dosyası seç...";
            if (file.ShowDialog() == DialogResult.OK)
            {
                string mesaj = kayit.Yukle(file.FileName);
                if (mesaj == "Yüklendi")
                {
                    txtfirmaad.Text = kayit.ayarlar.FirmaAd;
                    txtdurduradres.Text = kayit.ayarlar.DurdurAdres.ToString();
                    txtdurmasure.Text = kayit.ayarlar.DurdurSure.ToString();
                    txtplcadres.Text = kayit.ayarlar.PlcAdres.ToString();
                    txtip.Text = kayit.ayarlar.Ip;
                    txtport.Text = kayit.ayarlar.Port.ToString();
                    foreach (Adresler adres in kayit.ayarlar.Adreslers)
                        listView1.Items.Add(adres.Adres.ToString()).SubItems.Add(adres.Isim);
                }
                else
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtfirmaad.Text == "")
            {
                MessageBox.Show("Firma adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfirmaad.Focus();
            }
            else if (txtdurduradres.Text == "")
            {
                MessageBox.Show("Durdur adres boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdurduradres.Focus();
            }
            else if (txtdurmasure.Text == "")
            {
                MessageBox.Show("Durdur süre boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdurmasure.Focus();
            }
            else if (!int.TryParse(txtdurduradres.Text, out int dadres))
            {
                MessageBox.Show("Durdur adres sayısal olmalı hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdurduradres.Focus();
            }
            else if (!int.TryParse(txtdurmasure.Text, out int dsure))
            {
                MessageBox.Show("Durdur süre sayısal olmalı hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdurmasure.Focus();
            }
            else if (dadres == -1)
            {
                MessageBox.Show("Durdur Adres -1 olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdurduradres.Focus();
            }
            else if (dsure < 0)
            {
                MessageBox.Show("Durdur süre negatif olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdurmasure.Focus();
            }
            else if (txtplcadres.Text == "")
            {
                MessageBox.Show("PLC adres boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtplcadres.Focus();
            }
            else if (!int.TryParse(txtplcadres.Text, out int plcadres))
            {
                MessageBox.Show("PLC adres sayısal olmalı hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtplcadres.Focus();
            }
            else if (plcadres == -1)
            {
                MessageBox.Show("PLC adres -1 olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtplcadres.Focus();
            }
            else if (txtip.Text == "")
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
            else if (txtfirinno.Text == "")
            {
                MessageBox.Show("Fırın no boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfirinno.Focus();
            }
            else if (!int.TryParse(txtfirinno.Text, out int fno))
            {
                MessageBox.Show("Fırın no sayısal olmalı hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtfirinno.Focus();
            }
            else if (txtyetkino.Text == "")
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
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "Ayar Dosyası | *.ysayar";
                file.Title = "Ayar dosyasını kaydet...";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(file.FileName) != ".ysayar")
                        file.FileName = Path.Combine(Path.GetDirectoryName(file.FileName), $"{Path.GetFileNameWithoutExtension(file.FileName)}.ysayar");
                    kayit.ayarlar.FirmaAd = txtfirmaad.Text;
                    kayit.ayarlar.DurdurAdres = dadres;
                    kayit.ayarlar.DurdurSure = dsure;
                    kayit.ayarlar.PlcAdres = plcadres;
                    kayit.ayarlar.FirinNo = fno;
                    kayit.ayarlar.YetkiNo = yno;
                    txtip.Text = kayit.ayarlar.Ip = ip.ToString();
                    kayit.ayarlar.Port = port;
                    List<Adresler> adress = new List<Adresler>();
                    foreach (ListViewItem item in listView1.Items)
                        adress.Add(new Adresler(Convert.ToInt32(item.SubItems[0].Text), item.SubItems[1].Text));
                    kayit.ayarlar.Adreslers = adress.ToArray();
                    string mesaj = kayit.Kaydet(file.FileName);
                    if (mesaj == "Kaydedildi")
                        MessageBox.Show($"Ayar dosyası kaydedildi.\n{file.FileName}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnkaydet.PerformClick();
        }

        private void txtadres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnekle.PerformClick();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnsil.Enabled = listView1.SelectedItems.Count > 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Onay frm = new Onay();
            frm.ShowDialog();
            if (!frm.islem)
                Close();
        }

        private void btnolustur_Click(object sender, EventArgs e)
        {
            if(txtkey.Text == "")
            {
                MessageBox.Show("Pc kimliği boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtkey.Focus();
            }
            else
            {
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "Key Dosyası | *.yskey";
                file.Title = "Key dosyasını kaydet...";
                file.FileName = "RaporlamaKey";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(file.FileName) != ".yskey")
                        file.FileName = Path.Combine(Path.GetDirectoryName(file.FileName), $"{Path.GetFileNameWithoutExtension(file.FileName)}.yskey");
                    kayit.x315.X1 = txtkey.Text;
                    string mesaj = kayit.Kaydet(file.FileName, true);
                    if (mesaj == "Kaydedildi")
                        MessageBox.Show($"Key dosyası kaydedildi.\n{file.FileName}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnfirinnokaydet_Click(object sender, EventArgs e)
        {

        }
    }
}
