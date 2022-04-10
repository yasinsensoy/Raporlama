using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Raporlama
{
    public partial class AdresEkleDuzenle : Form
    {
        public string isim;
        public int id, adres;
        public bool islem = false;

        public AdresEkleDuzenle()
        {
            InitializeComponent();
            Ayar.IconDegis(this);
        }

        private void AdresEkleDuzenle_Load(object sender, EventArgs e)
        {
            if (btnekleduzenle.Text == "Düzenle (Enter)")
            {
                txtadres.Text = adres.ToString();
                txtisim.Text = isim;
            }
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnekleduzenle_Click(object sender, EventArgs e)
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
            else
            {
                txtisim.Text = txtisim.Text.Replace(",", "");
                Ayar.veriler.Clear();
                Ayar.veriler.Add(new FbParameter("@isim", txtisim.Text));
                DataTable tablo = Ayar.bagl.VeriGetir("SELECT ID FROM ADRESLER WHERE ISIM=@isim", Ayar.veriler);
                if (tablo != null && tablo.Rows.Count == 0)
                {
                    Ayar.veriler.Clear();
                    Ayar.veriler.Add(new FbParameter("@adres", adr));
                    Ayar.veriler.Add(new FbParameter("@isim", txtisim.Text));
                    if (btnekleduzenle.Text == "Ekle (Enter)")
                    {
                        if (Ayar.bagl.VeriEkleSilGuncelle("INSERT INTO ADRESLER(ADRES,ISIM) VALUES(@adres,@isim)", Ayar.veriler))
                        {
                            MessageBox.Show("Yeni adres başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            islem = true;
                        }
                    }
                    else if (btnekleduzenle.Text == "Düzenle (Enter)")
                    {
                        Ayar.veriler.Add(new FbParameter("@id", id));
                        if (Ayar.bagl.VeriEkleSilGuncelle("UPDATE ADRESLER SET ADRES=@adres,ISIM=@isim WHERE ID=@id", Ayar.veriler))
                        {
                            MessageBox.Show("Adres başarıyla düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            islem = true;
                            adres = adr;
                            isim = txtisim.Text;
                            btnekleduzenle.Enabled = false;
                            txtadres.Focus();
                        }
                    }
                }
                else if (tablo != null && tablo.Rows.Count > 0)
                {
                    MessageBox.Show("Aynı isimde adres var lütfen ismi değiştirin.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtisim.Focus();
                }
            }
        }

        private void Duzenle(object sender, EventArgs e)
        {
            if (btnekleduzenle.Text == "Düzenle (Enter)")
            {
                bool a = int.TryParse(txtadres.Text, out int adr);
                btnekleduzenle.Enabled = (a && adres != adr) || isim != txtisim.Text;
            }
        }
    }
}