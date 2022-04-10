using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Raporlama
{
    public class Baglanti
    {
        private readonly string bsatir = $"User ID=sysdba;Password=masterkey;Database={Path.Combine(Application.StartupPath, "raporlama.fdb") };Charset=UTF8;ServerType=1;ClientLibrary={Path.Combine(Application.StartupPath, "fb", "fbclient.dll") };";

        public DataTable VeriGetir(string sql, List<FbParameter> ogeler = null, bool hatagoster = true)
        {
            try
            {
                FbConnection con = new FbConnection(bsatir);
                FbCommand cmd = new FbCommand(sql, con);
                if (ogeler != null)
                    cmd.Parameters.AddRange(ogeler.ToArray());
                FbDataAdapter da = new FbDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                if (hatagoster)
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool VeriEkleSilGuncelle(string sql, List<FbParameter> ogeler = null, bool hatagoster = true)
        {
            try
            {
                FbConnection con = new FbConnection(bsatir);
                FbCommand cmd = new FbCommand(sql, con);
                if (ogeler != null)
                    cmd.Parameters.AddRange(ogeler.ToArray());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (hatagoster)
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }
    }
}