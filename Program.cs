using System;
using System.Threading;
using System.Windows.Forms;

namespace Raporlama
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Mutex(true, "Raporlama", out bool kontrol);
            if (!kontrol)
            {
                MessageBox.Show("Program zaten çalışıyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Ayar.Kontrol())
                Application.Run(new Form1(true));
            else
            {
                Form2 frm = new Form2();
                frm.ShowDialog();
                if (frm.a)
                    Application.Run(new Form1(true));
            }
        }
    }
}
