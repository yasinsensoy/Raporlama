using System.Windows.Forms;

namespace Raporlama_Ayar
{
    public partial class Onay : Form
    {
        public bool islem = false;
        public Onay()
        {
            InitializeComponent();
        }

        private void txtsifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtsifre.Text == "314591")
                {
                    islem = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Hatalı şifre.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtsifre.Focus();
                }
            }
        }
    }
}
