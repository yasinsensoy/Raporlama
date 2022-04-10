using System.Windows.Forms;

namespace Raporlama
{
    public partial class Onay : Form
    {
        public bool islem = false;
        public Onay()
        {
            InitializeComponent();
            Ayar.IconDegis(this);
        }

        private void txtsifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtsifre.Text == Ayar.GMS)
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
