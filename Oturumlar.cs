using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Raporlama
{
    public partial class Oturumlar : Form
    {
        public string ad;
        public int id, sid;
        public bool sec = false;

        public Oturumlar()
        {
            InitializeComponent();
            Ayar.IconDegis(this);
        }

        private void Oturumlar_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, datapartiler, new object[] { true });
            Guncelle();
            var a = Screen.GetWorkingArea(this);
            Size = new Size(Convert.ToInt32(a.Width * 0.5), Convert.ToInt32(a.Height * 0.5));
            CenterToParent();
            DateTime date = DateTime.Now;
            date1.Value = date;
            date2.Value = date.AddDays(1);
        }

        private void btnsec_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(datapartiler.SelectedRows[0].Cells["o_id"].Value);
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
            btnsec.Enabled = datapartiler.SelectedRows.Count == 1;
        }

        private void datamusteriler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datapartiler.ClearSelection();
        }

        private void Guncelle()
        {
            txtara.Text = "";
            Ayar.veriler.Clear();
            Ayar.veriler.Add(new FbParameter("@sid", sid));
            DataTable table = Ayar.bagl.VeriGetir("SELECT * FROM OTURUMLAR WHERE SID=@sid ORDER BY ID DESC", Ayar.veriler);
            DataTable t = new DataTable();
            if (table != null)
            {
                t.Columns.Add("ID", typeof(int));
                t.Columns.Add("BASTARIH", typeof(DateTime));
                t.Columns.Add("BITTARIH", typeof(DateTime));
                t.Columns.Add("SURE", typeof(string));
                foreach (DataRow row in table.Rows)
                {
                    List<object> list = new List<object>();
                    list.Add(row["ID"]);
                    DateTime bas = DateTime.Parse(row["BASTARIH"].ToString()).Add(TimeSpan.Parse(row["BASZAMAN"].ToString()));
                    DateTime bit = new DateTime();
                    string bt = row["BITTARIH"].ToString();
                    if (bt != "")
                        bit = DateTime.Parse(bt).Add(TimeSpan.Parse(row["BITZAMAN"].ToString()));
                    string ad = Ayar.ZamanDuzenle(bit - bas);
                    list.Add(bas);
                    list.Add(bit);
                    list.Add(ad);
                    t.Rows.Add(list.ToArray());
                }
            }
            Ayar.DataSourceDegis(datapartiler, t);
        }

        private void cbtariharalik_CheckedChanged(object sender, EventArgs e)
        {
            date1.Enabled = date2.Enabled = label8.Enabled = cbtariharalik.Checked;
            Filtrele(sender, e);
        }

        private void Filtrele(object sender, EventArgs e)
        {
            if (datapartiler.DataSource == null)
                return;
            string f = "";
            if (int.TryParse(txtara.Text, out int id))
                f = txtara.Text == "" ? "" : $"ID={id}";
            string d = "";
            if (cbtariharalik.Checked)
            {
                if (date1.Value > date2.Value)
                {
                    if (sender == date1)
                        date1.Value = date2.Value;
                    else if (sender == date2)
                        date2.Value = date1.Value;
                }
                d = $"BASTARIH >= '{date1.Value.Date}' AND BASTARIH <= '{date2.Value.ToShortDateString()} 23:59:59'";
            }
            (datapartiler.DataSource as DataTable).DefaultView.RowFilter = d + (d == "" || f == "" ? "" : " AND ") + f;
            datapartiler.ClearSelection();
        }
    }
}