using FirebirdSql.Data.FirebirdClient;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using Raporlama.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Raporlama
{
    public static class Ayar
    {
        public static Baglanti bagl = new Baglanti();
        public static PLCVeri veri = new PLCVeri();
        public static List<FbParameter> veriler = new List<FbParameter>();

        public static string Ip { get { DataTable data = bagl.VeriGetir("SELECT IP FROM AYAR WHERE ID=1", null, false); return data != null && data.Rows.Count > 0 ? Convert.ToString(data.Rows[0][0]) : ""; } set { veriler.Clear(); veriler.Add(new FbParameter("@ip", value)); bagl.VeriEkleSilGuncelle("UPDATE AYAR SET IP=@ip WHERE ID=1", veriler, false); } }
        public static int Port { get { DataTable data = bagl.VeriGetir("SELECT PORT FROM AYAR WHERE ID=1", null, false); return data != null && data.Rows.Count > 0 ? Convert.ToInt32(data.Rows[0][0]) : 502; } set { veriler.Clear(); veriler.Add(new FbParameter("@port", value)); bagl.VeriEkleSilGuncelle("UPDATE AYAR SET PORT=@port WHERE ID=1", veriler, false); } }
        public static float FontSize { get => Settings.Default.fontsize; set { Settings.Default.fontsize = value; Settings.Default.Save(); } }
        public static int RaporIndex { get => Settings.Default.raporindex; set { Settings.Default.raporindex = value; Settings.Default.Save(); } }
        public static string Raporlar { get => Settings.Default.rapor; set { Settings.Default.rapor = value; Settings.Default.Save(); } }
        public static string RaporKlasor { get => (Settings.Default.raporklasor == "" ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : Settings.Default.raporklasor); set { Settings.Default.raporklasor = value; Settings.Default.Save(); } }
        public static int DurdurAdres { get { DataTable data = bagl.VeriGetir("SELECT DURDURADRES FROM AYAR WHERE ID=1", null, false); return data != null && data.Rows.Count > 0 ? Convert.ToInt32(data.Rows[0][0]) : -1; } set { veriler.Clear(); veriler.Add(new FbParameter("@adres", value)); bagl.VeriEkleSilGuncelle("UPDATE AYAR SET DURDURADRES=@adres WHERE ID=1", veriler, false); } }
        public static int FirinNo { get { DataTable data = bagl.VeriGetir("SELECT FIRINNO FROM AYAR WHERE ID=1", null, false); return data != null && data.Rows.Count > 0 ? Convert.ToInt32(data.Rows[0][0]) : 0; } set { veriler.Clear(); veriler.Add(new FbParameter("@fno", value)); bagl.VeriEkleSilGuncelle("UPDATE AYAR SET FIRINNO=@fno WHERE ID=1", veriler, false); } }
        public static int YetkiNo { get { DataTable data = bagl.VeriGetir("SELECT YETKINO FROM AYAR WHERE ID=1", null, false); return data != null && data.Rows.Count > 0 ? Convert.ToInt32(data.Rows[0][0]) : 0; } set { veriler.Clear(); veriler.Add(new FbParameter("@yno", value)); bagl.VeriEkleSilGuncelle("UPDATE AYAR SET YETKINO=@yno WHERE ID=1", veriler, false); } }
        public static int OtoDurSure { get { DataTable data = bagl.VeriGetir("SELECT OTODURSURE FROM AYAR WHERE ID=1", null, false); return data != null && data.Rows.Count > 0 ? Convert.ToInt32(data.Rows[0][0]) : 0; } set { veriler.Clear(); veriler.Add(new FbParameter("@sure", value)); bagl.VeriEkleSilGuncelle("UPDATE AYAR SET OTODURSURE=@sure WHERE ID=1", veriler, false); } }
        public static int PlcAdres { get { DataTable data = bagl.VeriGetir("SELECT PLCADRES FROM AYAR WHERE ID=1", null, false); return data != null && data.Rows.Count > 0 ? Convert.ToInt32(data.Rows[0][0]) : -1; } set { veriler.Clear(); veriler.Add(new FbParameter("@adres", value)); bagl.VeriEkleSilGuncelle("UPDATE AYAR SET PLCADRES=@adres WHERE ID=1", veriler, false); } }
        public static string FirmaAd { get { DataTable data = bagl.VeriGetir("SELECT FIRMAAD FROM AYAR WHERE ID=1", null, false); return data != null && data.Rows.Count > 0 ? Convert.ToString(data.Rows[0][0]) : ""; } set { veriler.Clear(); veriler.Add(new FbParameter("@ad", value)); bagl.VeriEkleSilGuncelle("UPDATE AYAR SET FIRMAAD=@ad WHERE ID=1", veriler, false); } }
        public static string GMS { get { DataTable data = bagl.VeriGetir("SELECT GMS FROM AYAR WHERE ID=1", null, false); return data != null && data.Rows.Count > 0 ? Convert.ToString(data.Rows[0][0]) : ""; } set { veriler.Clear(); veriler.Add(new FbParameter("@gms", value)); bagl.VeriEkleSilGuncelle("UPDATE AYAR SET GMS=@gms WHERE ID=1", veriler, false); } }

        public static List<Ag> IpGetir()
        {
            List<Ag> ips = new List<Ag>();
            try
            {
                foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if ((item.NetworkInterfaceType == NetworkInterfaceType.Ethernet || item.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) && item.OperationalStatus == OperationalStatus.Up)
                    {
                        foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                                ips.Add(new Ag(ip.Address.ToString(), item.Name));
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ips;
        }

        public static void IconDegis(Form form)
        {
            form.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        public static void DataSourceDegis(DataGridView data, DataTable table)
        {
            data.ColumnHeadersVisible = false;
            data.DataSource = table;
            data.ColumnHeadersVisible = true;
        }

        public static string ZamanDuzenle(TimeSpan time)
        {
            string d = "";
            if (time.Days > 0) d = $"{time.Days} gün";
            if (time.Hours > 0) d += $"{(d == "" ? "" : " ")}{time.Hours} saat";
            if (time.Minutes > 0) d += $"{(d == "" ? "" : " ")}{time.Minutes} dak";
            if (time.Seconds > 0) d += $"{(d == "" ? "" : " ")}{time.Seconds} san";
            return d;
        }

        public static string GetUUID()
        {
            string output = "";
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = "cmd.exe",
                    Arguments = "/C wmic csproduct get UUID"
                };
                process.StartInfo = startInfo;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                process.WaitForExit();
                output = process.StandardOutput.ReadToEnd().Trim().Split('\n')[1];
            }
            catch (Exception)
            {

            }
            return output;
        }

        public static bool Kontrol()
        {
            return true;
            //List<string> files = new List<string>(Directory.GetFiles(Application.StartupPath, "*.yskey"));
            //if (files.Count > 0)
            //{
            //    Kayit kayit = new Kayit();
            //    if (kayit.Yukle(files[0], true) == "Yüklendi")
            //    {
            //        string id = GetUUID();
            //        if (id != "" && kayit.x315.X1 == id)
            //            return true;
            //    }
            //}
            //return false;
        }

        public static void PdfAktar(string konum, string sirket, string oturum, int pno, DataTable dataTable, DataTable mtable)
        {
            try
            {
                if (File.Exists(konum))
                    File.Delete(konum);
                Document document = new Document();
                Style style = document.Styles["Normal"];
                style.Font.Name = "Calibri";
                style.Font.Bold = true;
                style.Font.Size = 15;
                style = document.AddStyle("Table", "Normal");
                style.Font.Size = 10;
                style = document.AddStyle("Tarih", "Normal");
                style.Font.Size = 9;
                style.Font.Bold = false;
                style = document.AddStyle("Malzeme", "Normal");
                style.Font.Size = 9;
                style.Font.Bold = false;
                System.Drawing.Font font = new System.Drawing.Font("Calibri", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                System.Drawing.Font font1 = new System.Drawing.Font("Calibri", 15, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                System.Drawing.Font font2 = new System.Drawing.Font("Calibri", 9, System.Drawing.GraphicsUnit.Point);
                Section section = document.AddSection();
                section.PageSetup.PageFormat = PageFormat.Letter;
                section.PageSetup.LeftMargin = 5;
                section.PageSetup.RightMargin = 0;
                section.PageSetup.TopMargin = 5;
                section.PageSetup.BottomMargin = 0;

                Paragraph paragraph = section.AddParagraph();
                string tarih = $"Rapor tarihi: {DateTime.Now:d MMMM yyyy HH:mm:ss}";
                paragraph.AddFormattedText(tarih, "Tarih");
                paragraph.AddLineBreak();
                paragraph.AddText(oturum);
                paragraph.AddLineBreak();
                string nolar = $"Parti No: {pno} Fırın No: {FirinNo} Yetki No: {YetkiNo}";
                paragraph.AddText(nolar);
                paragraph.AddLineBreak();
                string acikla = $"Açıklama: {sirket}";
                paragraph.AddText(acikla);
                paragraph.AddLineBreak();
                foreach (DataRow item in mtable.Rows)
                {
                    paragraph.AddText($"Cinsi: { item["CINS"]} Miktar: { item["MIKTAR"]}");
                    paragraph.AddLineBreak();
                }
                string fad = $"Firma Adı: {FirmaAd}";
                paragraph.AddText(fad);
                paragraph.AddLineBreak();
                string kayitsayi = $"Kayıt Sayısı: {dataTable.Rows.Count}";
                paragraph.AddText(kayitsayi);
                paragraph.AddLineBreak();

                Table table = section.AddTable();
                table.Style = "Table";
                table.Borders.Color = Colors.Black;
                table.Borders.Width = 0.25;
                table.Rows.LeftIndent = 0;
                Column column;
                foreach (DataColumn col in dataTable.Columns)
                {
                    column = table.AddColumn();
                    column.Width = Unit.FromPoint((TextRenderer.MeasureText(col.ColumnName, font).Width * 0.75) + 3);
                    column.Shading.Color = Colors.DarkGray;
                }
                Row row = table.AddRow();
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    row.Cells[i].AddParagraph(dataTable.Columns[i].ColumnName);
                    row.Cells[i].Format.Font.Color = Colors.White;
                    row.Cells[i].Format.Alignment = ParagraphAlignment.Left;
                    row.Cells[i].VerticalAlignment = VerticalAlignment.Center;
                }

                Row newRow;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    newRow = table.AddRow();
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        newRow.Cells[j].VerticalAlignment = VerticalAlignment.Center;
                        newRow.Cells[j].Format.Alignment = ParagraphAlignment.Left;
                        newRow.Cells[j].Shading.Color = Colors.White;
                        string metin = dataTable.Rows[i][j].ToString();
                        Column col = table.Columns[j];
                        col.Width = Math.Max(col.Width.Point, (TextRenderer.MeasureText(metin, font).Width * 0.75) + 3);
                        newRow.Cells[j].AddParagraph(metin);
                    }
                }
                double gen = 10;
                foreach (Column item in table.Columns)
                    gen += item.Width.Point;
                double sgen = 10 + (TextRenderer.MeasureText(sirket, font1).Width * 0.75);
                double bgen = 10 + (TextRenderer.MeasureText(oturum, font1).Width * 0.75);
                double ngen = 10 + (TextRenderer.MeasureText(nolar, font1).Width * 0.75);
                double agen = 10 + (TextRenderer.MeasureText(acikla, font1).Width * 0.75);
                double fgen = 10 + (TextRenderer.MeasureText(fad, font1).Width * 0.75);
                section.PageSetup.PageWidth = Unit.FromPoint(Math.Max(gen, Math.Max(Math.Max(Math.Max(Math.Max(sgen, bgen), ngen), agen), fgen)));
                if (section.PageSetup.PageWidth.Centimeter < 23)
                    section.PageSetup.PageWidth = Unit.FromCentimeter(23);
                section.PageSetup.PageHeight = Unit.FromCentimeter(29.7);
                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true)
                {
                    Document = document
                };
                pdfRenderer.RenderDocument();
                pdfRenderer.Save(konum);
                MessageBox.Show($"Rapor kaydedildi.\nKonum: {konum}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(konum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ExcelAktar(string konum, string sirket, string oturum, int pno, DataTable dataTable, DataTable mtable)
        {
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;
            try
            {
                if (File.Exists(konum))
                    File.Delete(konum);
                Excel.Range chartRange;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add();
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Name = sirket;
                foreach (DataColumn item in dataTable.Columns)
                {
                    xlWorkSheet.Cells[6 + mtable.Rows.Count, item.Ordinal + 1] = item.ColumnName;
                    xlWorkSheet.Cells[6 + mtable.Rows.Count, item.Ordinal + 1].BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                }
                int r = 7 + mtable.Rows.Count;
                foreach (DataRow row in dataTable.Rows)
                {
                    int i = 1;
                    foreach (object item in row.ItemArray)
                    {
                        xlWorkSheet.Cells[r, i] = item;
                        xlWorkSheet.Cells[r, i++].BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    }
                    r++;
                }

                Excel.Range tumu = xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[dataTable.Rows.Count + 6 + mtable.Rows.Count, dataTable.Columns.Count]];
                tumu.HorizontalAlignment = 2;
                tumu.VerticalAlignment = 2;
                tumu.Font.Size = 15;
                tumu.Font.Bold = true;

                chartRange = xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, dataTable.Columns.Count]];
                chartRange.Merge();
                chartRange.FormulaR1C1 = oturum;
                chartRange.Font.Size = 15;

                chartRange = xlWorkSheet.Range[xlWorkSheet.Cells[2, 1], xlWorkSheet.Cells[2, dataTable.Columns.Count]];
                chartRange.Merge();
                chartRange.FormulaR1C1 = $"Parti No: {pno} Fırın No: {FirinNo} Yetki No: {YetkiNo}";
                chartRange.Font.Size = 15;

                chartRange = xlWorkSheet.Range[xlWorkSheet.Cells[3, 1], xlWorkSheet.Cells[3, dataTable.Columns.Count]];
                chartRange.Merge();
                chartRange.FormulaR1C1 = $"Açıklama: {sirket}";
                chartRange.Font.Size = 15;

                chartRange = xlWorkSheet.Range[xlWorkSheet.Cells[4 + mtable.Rows.Count, 1], xlWorkSheet.Cells[4 + mtable.Rows.Count, dataTable.Columns.Count]];
                chartRange.Merge();
                chartRange.FormulaR1C1 = $"Firma Adı: {FirmaAd}";
                chartRange.Font.Size = 15;

                chartRange = xlWorkSheet.Range[xlWorkSheet.Cells[5 + mtable.Rows.Count, 1], xlWorkSheet.Cells[5 + mtable.Rows.Count, dataTable.Columns.Count]];
                chartRange.Merge();
                chartRange.FormulaR1C1 = $"Toplam kayıt: {dataTable.Rows.Count} - Rapor tarihi: {DateTime.Now:d MMMM yyyy HH:mm:ss}";
                chartRange.Font.Size = 15;

                chartRange = xlWorkSheet.Range[xlWorkSheet.Cells[6 + mtable.Rows.Count, 1], xlWorkSheet.Cells[6 + mtable.Rows.Count, dataTable.Columns.Count]];
                chartRange.Font.Size = 18;
                chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);

                int c = 4;
                foreach (DataRow item in mtable.Rows)
                {
                    chartRange = xlWorkSheet.Range[xlWorkSheet.Cells[c, 1], xlWorkSheet.Cells[c, dataTable.Columns.Count]];
                    chartRange.Merge();
                    chartRange.FormulaR1C1 = $"Cinsi: { item["CINS"]} Miktar: { item["MIKTAR"]}";
                    chartRange.Font.Size = 15;
                    c++;
                }

                tumu.EntireColumn.AutoFit();

                xlWorkBook.SaveAs(konum);
                xlApp.Quit();
                ReleaseObject(xlApp);
                ReleaseObject(xlWorkBook);
                ReleaseObject(xlWorkSheet);
                MessageBox.Show($"Rapor kaydedildi.\nKonum: {konum}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(konum);
            }
            catch (Exception ex)
            {
                if (xlWorkBook != null)
                    xlWorkBook.Close(false);
                if (xlApp != null)
                    xlApp.Quit();
                if (ex.HResult == -2147221164)
                    MessageBox.Show("Bilgisayarınızda excel kurulu değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }

    public class Ag
    {
        public string Ip { get; set; }
        public string Isim { get; set; }

        public Ag(string ip, string isim)
        {
            Ip = ip;
            Isim = isim;
        }
    }
}