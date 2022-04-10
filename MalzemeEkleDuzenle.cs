using FirebirdSql.Data.FirebirdClient;
using System;
using System.Windows.Forms;

namespace Raporlama
{
    public partial class MalzemeEkleDuzenle : Form
    {
        public string cins;
        public int id, sid;
        public float miktar;
        public bool islem = false;

        public MalzemeEkleDuzenle()
        {
            InitializeComponent();
            Ayar.IconDegis(this);
        }

        private void MalzemeEkleDuzenle_Load(object sender, EventArgs e)
        {
            if (btnekleduzenle.Text == "Düzenle (Enter)")
            {
                txtcins.Text = cins;
                txtmiktar.Text = miktar.ToString();
            }
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnekleduzenle_Click(object sender, EventArgs e)
        {
            if (txtcins.Text == "")
            {
                MessageBox.Show("Malzeme cinsi boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcins.Focus();
            }
            else if (txtmiktar.Text == "")
            {
                MessageBox.Show("Malzeme miktarı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtmiktar.Focus();
            }
            else if (!float.TryParse(txtmiktar.Text, out float mktr))
            {
                MessageBox.Show("Malzeme miktarı sayısal olmalı hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtmiktar.Focus();
            }
            else
            {
                txtmiktar.Text = mktr.ToString();
                Ayar.veriler.Clear();
                Ayar.veriler.Add(new FbParameter("@cins", txtcins.Text));
                Ayar.veriler.Add(new FbParameter("@miktar", mktr));
                if (btnekleduzenle.Text == "Ekle (Enter)")
                {
                    Ayar.veriler.Add(new FbParameter("@sid", sid));
                    if (Ayar.bagl.VeriEkleSilGuncelle("INSERT INTO MALZEMELER(SID,CINS,MIKTAR) VALUES(@sid,@cins,@miktar)", Ayar.veriler))
                    {
                        MessageBox.Show("Yeni malzeme başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        islem = true;
                    }
                }
                else if (btnekleduzenle.Text == "Düzenle (Enter)")
                {
                    Ayar.veriler.Add(new FbParameter("@id", id));
                    if (Ayar.bagl.VeriEkleSilGuncelle("UPDATE MALZEMELER SET CINS=@cins,MIKTAR=@miktar WHERE ID=@id", Ayar.veriler))
                    {
                        MessageBox.Show("Malzeme başarıyla düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        islem = true;
                        cins = txtcins.Text;
                        miktar = mktr;
                        btnekleduzenle.Enabled = false;
                        txtcins.Focus();
                    }
                }
            }
        }

        private void Duzenle(object sender, EventArgs e)
        {
            if (btnekleduzenle.Text == "Düzenle (Enter)")
            {
                bool a = float.TryParse(txtmiktar.Text, out float mktr);
                btnekleduzenle.Enabled = (a && miktar != mktr) || cins != txtcins.Text;
            }
        }
    }
}