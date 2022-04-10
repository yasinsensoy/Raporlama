using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Raporlama
{
    public partial class Form1 : CustomForm
    {
        private bool veriislem = false, otodurdur = false;
        private int oid, ksay = 0, sayac, asure;
        private DateTime giristarih, dateTime;
        private System.Threading.Timer WorkTimer;
        private Thread IsiThread;
        public bool a = false;

        public Form1(bool c)
        {
            InitializeComponent();
            Ayar.IconDegis(this);
            notifyIcon1.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            a = c;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!a)
                Application.Exit();
            List<string> files = new List<string>(Directory.GetFiles(Application.StartupPath, "*.ysayar"));
            if (files.Count > 0)
            {
                Kayit kayit = new Kayit();
                if (kayit.Yukle(files[0]) == "Yüklendi")
                {
                    Ayar.FirmaAd = kayit.ayarlar.FirmaAd;
                    Ayar.DurdurAdres = kayit.ayarlar.DurdurAdres;
                    Ayar.OtoDurSure = kayit.ayarlar.DurdurSure;
                    Ayar.PlcAdres = kayit.ayarlar.PlcAdres;
                    Ayar.FirinNo = kayit.ayarlar.FirinNo;
                    Ayar.YetkiNo = kayit.ayarlar.YetkiNo;
                    Ayar.PlcAdres = kayit.ayarlar.PlcAdres;
                    Ayar.Ip = kayit.ayarlar.Ip;
                    Ayar.Port = kayit.ayarlar.Port;
                    if (kayit.ayarlar.Adreslers.Length > 0)
                        Ayar.bagl.VeriEkleSilGuncelle("DELETE FROM ADRESLER", null, false);
                    foreach (Adresler item in kayit.ayarlar.Adreslers)
                    {
                        Ayar.veriler.Clear();
                        Ayar.veriler.Add(new FbParameter("@adres", item.Adres));
                        Ayar.veriler.Add(new FbParameter("@isim", item.Isim));
                        Ayar.bagl.VeriEkleSilGuncelle("INSERT INTO ADRESLER(ADRES,ISIM) VALUES(@adres,@isim)", Ayar.veriler, false);
                    }
                    foreach (string item in files)
                        File.Delete(item);
                }
            }
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dataveriler, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, datapartiler, new object[] { true });
            Rectangle rct = Screen.GetWorkingArea(this);
            Size = new Size(Convert.ToInt32(rct.Width * 0.7), Convert.ToInt32(rct.Height * 0.7));
            CenterToScreen();
            DateTime date = DateTime.Now;
            giristarih = date;
            nudfont.Value = Convert.ToDecimal(Ayar.FontSize);
            backgroundWorker1.RunWorkerAsync();
            lblfirinno.Text = Ayar.FirinNo.ToString();
            lblyetkino.Text = Ayar.YetkiNo.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.BackColor = Ayar.veri.Durum ? Color.DarkGreen : Color.DarkRed;
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
            toolStripStatusLabel5.Text = $"{(veriislem ? "Çalışıyor" : "Çalışmıyor")}";
            toolStripStatusLabel5.ForeColor = veriislem ? Color.DarkGreen : Color.DarkRed;
            toolStripStatusLabel7.Text = $"{(Ayar.veri.Durdur ? "Aktif" : "Pasif")}";
            toolStripStatusLabel7.ForeColor = Ayar.veri.Durdur ? Color.DarkGreen : Color.DarkRed;
            toolStripStatusLabel8.Text = timer2.Enabled ? $"Kalan Süre: {Ayar.ZamanDuzenle(TimeSpan.FromSeconds(sayac))}" : "";
            if (veriislem && Ayar.veri.Durdur && !timer2.Enabled)
            {
                ksay++;
                if (ksay >= 30)
                {
                    sayac = Ayar.OtoDurSure * 60;
                    timer2.Enabled = true;
                }
            }
        }

        private void toolStripStatusLabel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !veriislem)
            {
                Onay frm = new Onay();
                frm.ShowDialog();
                if (frm.islem)
                {
                    Ayarlar frm1 = new Ayarlar();
                    frm1.ShowDialog();
                    if (frm1.islem)
                        backgroundWorker1.RunWorkerAsync();
                    if (frm1.oislem)
                    {
                        SirketlerGuncelle();
                        PartilerGuncelle();
                    }
                    lblfirinno.Text = Ayar.FirinNo.ToString();
                    lblyetkino.Text = Ayar.YetkiNo.ToString();
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (IsiThread != null)
            {
                IsiThread.Abort();
                IsiThread.Join();
            }
            Invoke((MethodInvoker)delegate { flowLayoutPanel1.Controls.Clear(); });
            DataTable table = Ayar.bagl.VeriGetir("SELECT * FROM ADRESLER ORDER BY ID", null, false);
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    Sicaklik s = new Sicaklik();
                    s.Baslik = row["ISIM"].ToString();
                    s.Adres = Convert.ToInt32(row["ADRES"]);
                    Invoke((MethodInvoker)delegate { flowLayoutPanel1.Controls.Add(s); });
                }
            }
            IsiThread = new Thread(new ThreadStart(IsiCek));
            IsiThread.Start();
        }

        private void IsiCek()
        {
            do
            {
                Ayar.veri.Baglan(Ayar.Ip, Ayar.Port, false);
                if (Ayar.veri.Durum)
                {
                    Ayar.veri.DurdurKontrol(Ayar.DurdurAdres, false);
                    foreach (Sicaklik item in flowLayoutPanel1.Controls)
                    {
                        Donus donus = Ayar.veri.VeriCek(item.Adres, false);
                        if (!donus.Hata)
                            Invoke((MethodInvoker)delegate { item.Derece = donus.Deger; });
                    }
                }
                Thread.Sleep(500);
            } while (true);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "veriler": if (!veriislem) SirketlerGuncelle(); break;
                case "partiler": PartilerGuncelle(); if (!veriislem) lblpartino.Text = ""; break;
            }
        }

        #region "Partiler"
        private void PartilerGuncelle()
        {
            txtara.Text = "";
            DataTable table = Ayar.bagl.VeriGetir("SELECT ID,SID,BASTARIH,BITTARIH,BASZAMAN,BITZAMAN,(SELECT COUNT(ID) AS ADET FROM VERILER WHERE OID=OTURUMLAR.ID),(SELECT AD FROM SIRKETLER WHERE ID=OTURUMLAR.SID) FROM OTURUMLAR ORDER BY ID DESC");
            DataTable t = new DataTable();
            if (table != null)
            {
                t.Columns.Add("ID", typeof(int));
                t.Columns.Add("SID", typeof(int));
                t.Columns.Add("BASTARIH", typeof(DateTime));
                t.Columns.Add("BITTARIH", typeof(DateTime));
                t.Columns.Add("SURE", typeof(string));
                t.Columns.Add("ADET", typeof(int));
                t.Columns.Add("AD", typeof(string));
                foreach (DataRow row in table.Rows)
                {
                    List<object> list = new List<object>();
                    list.Add(row["ID"]);
                    list.Add(row["SID"]);
                    DateTime bas = DateTime.Parse(row["BASTARIH"].ToString()).Add(TimeSpan.Parse(row["BASZAMAN"].ToString()));
                    DateTime bit = new DateTime();
                    string bt = row["BITTARIH"].ToString();
                    if (bt != "")
                        bit = DateTime.Parse(bt).Add(TimeSpan.Parse(row["BITZAMAN"].ToString()));
                    else
                        continue;
                    string ad = Ayar.ZamanDuzenle(bit - bas);
                    list.Add(bas);
                    list.Add(bit);
                    list.Add(ad);
                    list.Add(row["ADET"]);
                    list.Add(row["AD"]);
                    t.Rows.Add(list.ToArray());
                }
            }
            Ayar.DataSourceDegis(datapartiler, t);
        }

        private void btnpartiraporal_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(datapartiler.SelectedRows[0].Cells["o_sayi"].Value) <= 0)
            {
                MessageBox.Show("Seçili partide kayıtlı veri bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int id = Convert.ToInt32(datapartiler.SelectedRows[0].Cells["o_id"].Value);
            Ayar.veriler.Clear();
            Ayar.veriler.Add(new FbParameter("@oid", id));
            DataTable table = Ayar.bagl.VeriGetir("SELECT * FROM VERILER WHERE OID=@oid ORDER BY ID DESC", Ayar.veriler);
            DataTable t = new DataTable();
            if (table != null && table.Rows.Count > 0)
            {
                Ayar.veriler.Clear();
                Ayar.veriler.Add(new FbParameter("@oid", id));
                DataTable sutun = Ayar.bagl.VeriGetir("SELECT SUTUN FROM SUTUNLAR WHERE OID=@oid", Ayar.veriler);
                if (sutun != null && sutun.Rows.Count > 0)
                {
                    t.Columns.Add("Id", typeof(int));
                    t.Columns.Add("Tarih", typeof(string));
                    t.Columns.Add("Saat", typeof(string));
                    foreach (string ad in sutun.Rows[0]["SUTUN"].ToString().Split(','))
                        t.Columns.Add(ad, typeof(string));
                    int a = table.Rows.Count;
                    foreach (DataRow row in table.Rows)
                    {
                        List<object> list = new List<object>();
                        DateTime tarih = DateTime.Parse(row["TARIH"].ToString());
                        TimeSpan saat = TimeSpan.Parse(row["ZAMAN"].ToString());
                        list.Add(a--);
                        list.Add(tarih.ToString("dd.MM.yyyy"));
                        list.Add(saat.ToString(@"hh\:mm\:ss"));
                        foreach (string isi in row["ISI"].ToString().Split('a'))
                            list.Add($"{isi} °C");
                        t.Rows.Add(list.ToArray());
                    }
                }
            }
            Rapor frm = new Rapor();
            frm.table = t;
            frm.mtable = MTable(id);
            frm.oid = id;
            frm.sirket = datapartiler.SelectedRows[0].Cells["o_ad"].Value.ToString();
            frm.ShowDialog();
        }

        private void datapartiler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datapartiler.ClearSelection();
        }

        private void datapartiler_SelectionChanged(object sender, EventArgs e)
        {
            btnpartiraporal.Enabled = datapartiler.SelectedRows.Count == 1;
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
        #endregion

        #region "Veriler"
        private void SirketlerGuncelle()
        {
            cbsirketler.DisplayMember = "AD";
            cbsirketler.ValueMember = "ID";
            cboturumlar.DataSource = null;
            dataveriler.DataSource = null;
            lblkayitsayi.Text = "";
            lblpartino.Text = "";
            DataTable sirket = Ayar.bagl.VeriGetir("SELECT * FROM SIRKETLER ORDER BY AD ASC");
            btnbaslatdurdur.Enabled = btnpartiayrinti.Enabled = sirket != null && sirket.Rows.Count > 0;
            cbsirketler.DataSource = sirket;
        }

        private void cbsirketler_SelectedIndexChanged(object sender, EventArgs e)
        {
            OturumlarGuncelle();
        }

        private void OturumlarGuncelle()
        {
            cboturumlar.DisplayMember = "AD";
            cboturumlar.ValueMember = "ID";
            Invoke((MethodInvoker)delegate
            {
                lblkayitsayi.Text = "";
                dataveriler.DataSource = null;
                dataveriler.Columns.Clear();
            });
            Ayar.veriler.Clear();
            Invoke((MethodInvoker)delegate { Ayar.veriler.Add(new FbParameter("@sid", Convert.ToInt32(cbsirketler.SelectedValue))); });
            DataTable table = Ayar.bagl.VeriGetir("SELECT * FROM OTURUMLAR WHERE SID=@sid ORDER BY ID DESC", Ayar.veriler);
            DataTable t = new DataTable();
            t.Columns.Add("ID", typeof(int));
            t.Columns.Add("AD", typeof(string));
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    int id = Convert.ToInt32(row["ID"]);
                    DateTime bas = DateTime.Parse(row["BASTARIH"].ToString()).Add(TimeSpan.Parse(row["BASZAMAN"].ToString()));
                    DateTime bit = new DateTime();
                    string bt = row["BITTARIH"].ToString();
                    if (bt != "")
                        bit = DateTime.Parse(bt).Add(TimeSpan.Parse(row["BITZAMAN"].ToString()));
                    string ad = $"{id} - {bas} - {bit} ({Ayar.ZamanDuzenle(bit - bas)})";
                    t.Rows.Add(new object[] { id, ad });
                }
            }
            Invoke((MethodInvoker)delegate { cboturumlar.DataSource = t; });
        }

        private void VerilerGuncelle(int id, bool hata = true)
        {
            Invoke((MethodInvoker)delegate
            {
                lblkayitsayi.Text = "";
                dataveriler.DataSource = null;
                dataveriler.Columns.Clear();
            });
            Ayar.veriler.Clear();
            Ayar.veriler.Add(new FbParameter("@oid", id));
            DataTable table = Ayar.bagl.VeriGetir("SELECT * FROM VERILER WHERE OID=@oid ORDER BY ID DESC", Ayar.veriler, hata);
            DataTable t = new DataTable();
            if (table != null && table.Rows.Count > 0)
            {
                Ayar.veriler.Clear();
                Ayar.veriler.Add(new FbParameter("@oid", id));
                DataTable sutun = Ayar.bagl.VeriGetir("SELECT SUTUN FROM SUTUNLAR WHERE OID=@oid", Ayar.veriler, hata);
                if (sutun != null && sutun.Rows.Count > 0)
                {
                    t.Columns.Add("Id", typeof(int));
                    t.Columns.Add("Tarih", typeof(string));
                    t.Columns.Add("Saat", typeof(string));
                    foreach (string ad in sutun.Rows[0]["SUTUN"].ToString().Split(','))
                        t.Columns.Add(ad, typeof(string));
                    int a = table.Rows.Count;
                    foreach (DataRow row in table.Rows)
                    {
                        DateTime tarih = DateTime.Parse(row["TARIH"].ToString());
                        TimeSpan saat = TimeSpan.Parse(row["ZAMAN"].ToString());
                        List<object> list = new List<object>();
                        list.Add(a--);
                        list.Add(tarih.ToString("dd.MM.yyyy"));
                        list.Add(saat.ToString(@"hh\:mm\:ss"));
                        foreach (string isi in row["ISI"].ToString().Split('a'))
                            list.Add($"{isi} °C");
                        t.Rows.Add(list.ToArray());
                    }
                }
            }
            Invoke((MethodInvoker)delegate
            {
                Ayar.DataSourceDegis(dataveriler, t);
            });
        }

        private void dataveriler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataveriler.ClearSelection();
            foreach (DataGridViewColumn item in dataveriler.Columns)
                item.SortMode = DataGridViewColumnSortMode.Programmatic;
            lblkayitsayi.Text = $"Kayıt sayısı: {dataveriler.Rows.Count}";
        }

        private void cboturumlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerilerGuncelle(Convert.ToInt32(cboturumlar.SelectedValue));
            lblpartino.Text = $"{cboturumlar.SelectedValue}";
        }

        private void btnsirketayrinti_Click(object sender, EventArgs e)
        {
            Sirketler frm = new Sirketler();
            frm.sid = cbsirketler.Items.Count > 0 ? Convert.ToInt32(cbsirketler.SelectedValue) : 0;
            frm.ShowDialog();
            if (frm.sec && !frm.islem)
                cbsirketler.SelectedValue = frm.id;
            else if (frm.sec && frm.islem)
            {
                SirketlerGuncelle();
                cbsirketler.SelectedValue = frm.id;
            }
            else if (!frm.sec && frm.islem)
                SirketlerGuncelle();
        }

        private void btnbaslatdurdur_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count == 0)
            {
                MessageBox.Show("Kayıtlı adres bulunamadı. Önce en az 1 tane ısı kaydı ekleyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnbaslatdurdur.Enabled = false;
            if (btnbaslatdurdur.Text == "BAŞLAT")
            {
                if (!Ayar.veri.Durum)
                {
                    MessageBox.Show("Bağlantı kapalı. Bağlantı kurup tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnbaslatdurdur.Enabled = true;
                    return;
                }
                veriislem = true;
                GosterGizle(false);
                dateTime = DateTime.Now;
                Ayar.veriler.Clear();
                Invoke((MethodInvoker)delegate { Ayar.veriler.Add(new FbParameter("@sid", Convert.ToInt32(cbsirketler.SelectedValue))); });
                Ayar.veriler.Add(new FbParameter("@bastrh", dateTime.Date));
                Ayar.veriler.Add(new FbParameter("@baszmn", dateTime.TimeOfDay));
                if (Ayar.bagl.VeriEkleSilGuncelle("INSERT INTO OTURUMLAR(SID,BASTARIH,BASZAMAN) VALUES(@sid,@bastrh,@baszmn)", Ayar.veriler, false))
                {
                    DataTable data = Ayar.bagl.VeriGetir("SELECT FIRST 1 ID FROM OTURUMLAR ORDER BY ID DESC", null, false);
                    if (data == null || data.Rows.Count == 0)
                    {
                        MessageBox.Show("Beklenmeyen veritabanı hatası oluştu lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        veriislem = false;
                    }
                    else
                    {
                        dataveriler.DataSource = null;
                        dataveriler.Columns.Clear();
                        dataveriler.Columns.Add("", "Id");
                        dataveriler.Columns.Add("", "Tarih");
                        dataveriler.Columns.Add("", "Saat");
                        oid = Convert.ToInt32(data.Rows[0]["ID"]);
                        lblpartino.Text = oid.ToString();
                        string sut = "";
                        foreach (Sicaklik item in flowLayoutPanel1.Controls)
                        {
                            dataveriler.Columns.Add("", item.Baslik);
                            sut += $"{(sut == "" ? "" : ",")}{item.Baslik}";
                        }
                        foreach (DataGridViewColumn item in dataveriler.Columns)
                            item.SortMode = DataGridViewColumnSortMode.Programmatic;
                        Ayar.veriler.Clear();
                        Ayar.veriler.Add(new FbParameter("@oid", oid));
                        Ayar.veriler.Add(new FbParameter("@sut", sut));
                        Ayar.bagl.VeriEkleSilGuncelle("INSERT INTO SUTUNLAR(OID,SUTUN) VALUES(@oid,@sut)", Ayar.veriler, false);
                        Ayar.veriler.Clear();
                        Ayar.veriler.Add(new FbParameter("@sid", Convert.ToInt32(cbsirketler.SelectedValue)));
                        DataTable t = Ayar.bagl.VeriGetir($"SELECT * FROM MALZEMELER WHERE SID=@sid", Ayar.veriler, false);
                        string malz = "";
                        if (t != null)
                        {
                            foreach (DataRow row in t.Rows)
                                malz += $"{(malz == "" ? "" : "[b]")}{row["CINS"]}[a]{row["MIKTAR"]}";
                        }
                        Ayar.veriler.Clear();
                        Ayar.veriler.Add(new FbParameter("@oid", oid));
                        Ayar.veriler.Add(new FbParameter("@malz", malz));
                        Ayar.bagl.VeriEkleSilGuncelle("INSERT INTO OMALZEME(OID,MALZ) VALUES(@oid,@malz)", Ayar.veriler, false);
                        asure = 1;
                        WorkTimer = new System.Threading.Timer(DoWork, true, 0, 60000);
                        btnbaslatdurdur.Text = "DURDUR";
                    }
                }
                else
                {
                    MessageBox.Show("Beklenmeyen veritabanı hatası oluştu lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    veriislem = false;
                }
            }
            else if (btnbaslatdurdur.Text == "DURDUR")
            {
                Durdur();
                OturumlarGuncelle();
                GosterGizle(true);
                btnbaslatdurdur.Text = "BAŞLAT";
                veriislem = false;
                timer2.Enabled = false;
                otodurdur = false;
                ksay = 0;
            }
            btnbaslatdurdur.Enabled = true;
        }

        private void GosterGizle(bool deger)
        {
            label1.Enabled = deger;
            label2.Enabled = deger;
            cbsirketler.Enabled = deger;
            cboturumlar.Enabled = deger;
            btnsirketayrinti.Enabled = deger;
            btnpartiayrinti.Enabled = deger;
        }

        private void Durdur()
        {
            WorkTimer.Dispose();
            Ayar.veriler.Clear();
            Ayar.veriler.Add(new FbParameter("@id", oid));
            Ayar.veriler.Add(new FbParameter("@bittrh", dateTime.Date));
            Ayar.veriler.Add(new FbParameter("@bitzmn", dateTime.TimeOfDay));
            Ayar.bagl.VeriEkleSilGuncelle("UPDATE OTURUMLAR SET BITTARIH=@bittrh,BITZAMAN=@bitzmn WHERE ID=@id", Ayar.veriler, false);
        }

        private void DoWork(object state)
        {
            if (otodurdur)
            {
                btnrapor.Enabled = false;
                Durdur();
                OturumlarGuncelle();
                Invoke((MethodInvoker)delegate
                {
                    GosterGizle(true);
                    btnbaslatdurdur.Text = "BAŞLAT";
                });
                veriislem = false;
                btnrapor.Enabled = true;
                timer2.Enabled = false;
                otodurdur = false;
                ksay = 0;
                return;
            }
            string isi = "";
            foreach (Sicaklik item in flowLayoutPanel1.Controls)
                isi += $"{(isi == "" ? "" : "a")}{item.Derece}";
            dateTime = DateTime.Now;
            Ayar.veriler.Clear();
            Ayar.veriler.Add(new FbParameter("@oid", oid));
            Ayar.veriler.Add(new FbParameter("@tarih", dateTime.Date));
            Ayar.veriler.Add(new FbParameter("@zaman", dateTime.TimeOfDay));
            Ayar.veriler.Add(new FbParameter("@isi", isi));
            if (Ayar.bagl.VeriEkleSilGuncelle("INSERT INTO VERILER(OID,TARIH,ZAMAN,ISI) VALUES(@oid,@tarih,@zaman,@isi)", Ayar.veriler, false))
            {
                List<object> list = new List<object>();
                list.Add(asure++);
                list.Add(dateTime.Date.ToString("dd.MM.yyyy"));
                list.Add(dateTime.TimeOfDay.ToString(@"hh\:mm\:ss"));
                foreach (string s in isi.ToString().Split('a'))
                    list.Add($"{s} °C");
                Invoke((MethodInvoker)delegate
                {
                    dataveriler.Rows.Insert(0, list.ToArray());
                    lblkayitsayi.Text = $"Kayıt sayısı: {dataveriler.Rows.Count}";
                });
            }
        }

        private void btnrapor_Click(object sender, EventArgs e)
        {
            if (dataveriler.Rows.Count == 0)
            {
                MessageBox.Show("Seçili partide kayıtlı veri bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable t;
            if (veriislem)
            {
                t = new DataTable();
                foreach (DataGridViewColumn c in dataveriler.Columns)
                {
                    if (c.HeaderText == "Id")
                        t.Columns.Add(c.HeaderText, typeof(int));
                    else
                        t.Columns.Add(c.HeaderText, typeof(string));
                }
                foreach (DataGridViewRow r in dataveriler.Rows)
                {
                    List<object> list = new List<object>();
                    foreach (DataGridViewCell c in r.Cells)
                        list.Add(c.Value);
                    t.Rows.Add(list.ToArray());
                }
            }
            else
                t = dataveriler.DataSource as DataTable;
            Rapor frm = new Rapor();
            frm.table = t;
            int id = Convert.ToInt32(lblpartino.Text);
            frm.mtable = MTable(id);
            frm.oid = id;
            frm.sirket = cbsirketler.Text;
            frm.ShowDialog();
        }

        private DataTable MTable(int id)
        {
            DataTable t = new DataTable();
            t.Columns.Add("CINS", typeof(string));
            t.Columns.Add("MIKTAR", typeof(float));
            Ayar.veriler.Clear();
            Ayar.veriler.Add(new FbParameter("@oid", id));
            DataTable table = Ayar.bagl.VeriGetir("SELECT MALZ FROM OMALZEME WHERE OID=@oid", Ayar.veriler, false);
            if (table != null && table.Rows.Count > 0)
            {
                foreach (string malz in table.Rows[0]["MALZ"].ToString().Split(new string[] { "[b]" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] m = malz.Split(new string[] { "[a]" }, StringSplitOptions.RemoveEmptyEntries);
                    List<object> list = new List<object>();
                    list.Add(m[0]);
                    list.Add(Convert.ToSingle(m[1]));
                    t.Rows.Add(list.ToArray());
                }
            }
            return t;
        }
        #endregion

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Visible = !Visible;
        }

        private void gösterGizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = !Visible;
        }

        private void btnpartiayrinti_Click(object sender, EventArgs e)
        {
            Oturumlar frm = new Oturumlar();
            frm.sid = Convert.ToInt32(cbsirketler.SelectedValue);
            frm.Text = $"Partiler - {cbsirketler.Text}";
            frm.ShowDialog();
            if (frm.sec)
                cboturumlar.SelectedValue = frm.id;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DateTime tar = DateTime.Now;
            Ayar.veriler.Clear();
            Ayar.veriler.Add(new FbParameter("@girtrh", giristarih.Date));
            Ayar.veriler.Add(new FbParameter("@girsaat", giristarih.TimeOfDay));
            Ayar.veriler.Add(new FbParameter("@ckstrh", tar.Date));
            Ayar.veriler.Add(new FbParameter("@ckssaat", tar.TimeOfDay));
            Ayar.bagl.VeriEkleSilGuncelle("INSERT INTO GIRISLER(GIRISTARIH,GIRISSAAT,CIKISTARIH,CIKISSAAT) VALUES(@girtrh,@girsaat,@ckstrh,@ckssaat)", Ayar.veriler, false);
            if (IsiThread != null)
            {
                IsiThread.Abort();
                IsiThread.Join();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!a)
                return;
            DialogResult mesaj = MessageBox.Show($"{(veriislem ? "Veri kaydı devam ediyor" : "Programı")} kapatmak istediğinize emin misiniz?", "Kapanıyor", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            if (mesaj == DialogResult.Yes)
            {
                if (veriislem)
                    Durdur();
                string fdb = Path.Combine(Application.StartupPath, "raporlama.fdb");
                string konum = Path.Combine(Application.StartupPath, "backup");
                if (!Directory.Exists(konum))
                    Directory.CreateDirectory(konum);
                List<string> files = new List<string>(Directory.GetFiles(konum, "*.backup"));
                if (files.Count > 4)
                {
                    do
                    {
                        File.Delete(files[0]);
                        files.RemoveAt(0);
                    } while (files.Count > 4);
                }
                File.Copy(fdb, Path.Combine(konum, DateTime.Now.ToString().Replace(":", ".") + ".backup"));
            }
            else
                e.Cancel = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            otodurdur = sayac <= 0;
            if (sayac > 0)
                sayac--;
        }

        private void nudfont_ValueChanged(object sender, EventArgs e)
        {
            float size = Convert.ToSingle(nudfont.Value);
            dataveriler.DefaultCellStyle.Font = new Font(dataveriler.DefaultCellStyle.Font.FontFamily, size, GraphicsUnit.Pixel);
            Ayar.FontSize = size;
        }
    }
}
