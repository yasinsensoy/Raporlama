using System;
using System.IO;
using System.Windows.Forms;

namespace Raporlama
{
    public partial class Form2 : Form
    {
        private string id;
        private Kayit kayit = new Kayit();
        public bool a = false;

        public Form2()
        {
            InitializeComponent();
            Ayar.IconDegis(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id = Ayar.GetUUID();
            textBox1.Text = id;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            id = Ayar.GetUUID();
            textBox1.Text = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Key Dosyası | *.yskey";
            file.Multiselect = false;
            file.Title = "Key dosyası seç...";
            if (file.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = file.FileName;
                string mesaj = kayit.Yukle(file.FileName, true);
                if (mesaj == "Yüklendi")
                {
                    if (id != "" && kayit.x315.X1 == id)
                    {
                        MessageBox.Show($"Kayıt işlemi başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        File.Move(file.FileName, Path.Combine(Application.StartupPath, Path.GetFileName(file.FileName)));
                        a = true;
                        Close();
                    }
                    else
                        MessageBox.Show("Yanlış key dosyası seçildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show($"Kayıt işlemi başarısız.\n{mesaj}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
