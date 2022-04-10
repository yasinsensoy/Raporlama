using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Raporlama
{
    public class Kayit
    {
        private readonly XmlSerializer serializer = new XmlSerializer(typeof(Ayars));
        private readonly XmlSerializer serializer1 = new XmlSerializer(typeof(X315));
        public Ayars ayarlar = new Ayars();
        public X315 x315 = new X315();
        private readonly DESCryptoServiceProvider crypto = new DESCryptoServiceProvider();
        private readonly byte[] key = Encoding.ASCII.GetBytes("ys939604");

        public string Kaydet(string yol, bool a = false)
        {
            try
            {
                using (FileStream fs = File.Open(yol, FileMode.Create))
                using (CryptoStream cryptoStream = new CryptoStream(fs, crypto.CreateEncryptor(key, key), CryptoStreamMode.Write))
                {
                    if (a)
                        serializer1.Serialize(cryptoStream, x315);
                    else
                        serializer.Serialize(cryptoStream, ayarlar);
                }

                return "Kaydedildi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Yukle(string yol, bool a = false)
        {
            if (File.Exists(yol))
            {
                try
                {
                    using (FileStream fs = File.Open(yol, FileMode.Open))
                    using (CryptoStream cryptoStream = new CryptoStream(fs, crypto.CreateDecryptor(key, key), CryptoStreamMode.Read))
                    {
                        if (a)
                            x315 = (X315)serializer1.Deserialize(cryptoStream);
                        else
                            ayarlar = (Ayars)serializer.Deserialize(cryptoStream);
                    }
                    return "Yüklendi";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
                return "Dosya bulunamadı";
        }
    }



    [Serializable()]
    public class Ayars
    {
        [XmlAttribute("firmaad")]
        public string FirmaAd { get; set; }

        [XmlAttribute("duradres")]
        public int DurdurAdres { get; set; }

        [XmlAttribute("dursure")]
        public int DurdurSure { get; set; }

        [XmlAttribute("plcadres")]
        public int PlcAdres { get; set; }

        [XmlAttribute("firinno")]
        public int FirinNo { get; set; }

        [XmlAttribute("yetkino")]
        public int YetkiNo { get; set; }

        [XmlAttribute("ip")]
        public string Ip { get; set; }

        [XmlAttribute("port")]
        public int Port { get; set; }

        public Adresler[] Adreslers { get; set; }

        public Ayars(string firmaad, int duradres, int dursure, int plcadres, int firinno, int yetkino, string ip, int port, Adresler[] adresler)
        {
            FirmaAd = firmaad;
            DurdurAdres = duradres;
            DurdurSure = dursure;
            PlcAdres = plcadres;
            FirinNo = firinno;
            YetkiNo = yetkino;
            Ip = ip;
            Port = port;
            Adreslers = adresler;
        }

        public Ayars()
        { }
    }

    [Serializable()]
    public class Adresler
    {
        [XmlAttribute("adres")]
        public int Adres { get; set; }

        [XmlAttribute("isim")]
        public string Isim { get; set; }

        public Adresler(int adres, string isim)
        {
            Adres = adres;
            Isim = isim;
        }

        public Adresler()
        { }
    }

    [Serializable()]
    public class X315
    {
        [XmlAttribute("X1")]
        public string X1 { get; set; }

        public X315(string x1)
        {
            X1 = x1;
        }

        public X315()
        { }
    }
}