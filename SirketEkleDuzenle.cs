using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Raporlama
{
    public partial class SirketEkleDuzenle : Form
    {
        public string ad;
        public int id;
        public bool islem = false;

        public SirketEkleDuzenle()
        {
            InitializeComponent();
            Ayar.IconDegis(this);
        }

        private void SirketEkleDuzenle_Load(object sender, EventArgs e)
        {
            if (btnekleduzenle.Text == "Düzenle (Enter)")
                txtad.Text = ad;
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnekleduzenle_Click(object sender, EventArgs e)
        {
            if (txtad.Text == "")
            {
                MessageBox.Show("Ad boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtad.Focus();
            }
            else
            {
                Ayar.veriler.Clear();
                Ayar.veriler.Add(new FbParameter("@ad", txtad.Text));
                DataTable tablo = Ayar.bagl.VeriGetir("SELECT ID FROM SIRKETLER WHERE AD=@ad", Ayar.veriler);
                if (tablo != null && tablo.Rows.Count == 0)
                {
                    Ayar.veriler.Clear();
                    Ayar.veriler.Add(new FbParameter("@ad", txtad.Text));
                    if (btnekleduzenle.Text == "Ekle (Enter)")
                    {
                        if (Ayar.bagl.VeriEkleSilGuncelle("INSERT INTO SIRKETLER(AD) VALUES(@ad)", Ayar.veriler))
                        {
                            MessageBox.Show("Yeni firma başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            islem = true;
                        }
                    }
                    else if (btnekleduzenle.Text == "Düzenle (Enter)")
                    {
                        Ayar.veriler.Add(new FbParameter("@id", id));
                        if (Ayar.bagl.VeriEkleSilGuncelle("UPDATE SIRKETLER SET AD=@ad WHERE ID=@id", Ayar.veriler))
                        {
                            MessageBox.Show("Firma başarıyla düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            islem = true;
                            ad = txtad.Text;
                            btnekleduzenle.Enabled = false;
                            txtad.Focus();
                        }
                    }
                }
                else if (tablo != null && tablo.Rows.Count > 0)
                {
                    MessageBox.Show("Aynı isimde firma var lütfen ismi değiştirin.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtad.Focus();
                }
            }
        }

        private void Duzenle(object sender, EventArgs e)
        {
            if (btnekleduzenle.Text == "Düzenle (Enter)")
                btnekleduzenle.Enabled = ad != txtad.Text;
        }
    }
}