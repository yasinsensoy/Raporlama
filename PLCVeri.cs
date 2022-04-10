using EasyModbus;
using System;
using System.Windows.Forms;

namespace Raporlama
{
    public class PLCVeri
    {
        private readonly ModbusClient tcpclient = new ModbusClient();
        public bool Durum = false, Durdur = false;

        public bool Baglan(string ip, int port, bool hatagoster = true)
        {
            try
            {
                tcpclient.Connect(ip, port);
                if (Ayar.PlcAdres == -1)
                {
                    Durum = false;
                    return false;
                }
                bool[] mb = tcpclient.ReadCoils(Ayar.PlcAdres, 1);
                if (mb[0])
                {
                    Durum = true;
                    return true;
                }
                else
                    throw new Exception("PLC Doğrulanamadı.");

            }
            catch (Exception ex)
            {
                Durum = false;
                if (hatagoster)
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public Donus VeriCek(int adres, bool hatagoster = true)
        {
            try
            {
                int[] mi = tcpclient.ReadHoldingRegisters(adres, 2);
                if (mi.Length > 0)
                    return new Donus(false, mi[0] / 10.0);
                else
                    return new Donus(true, 0);
            }
            catch (Exception ex)
            {
                if (hatagoster)
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Donus(true, 0);
            }
        }

        public bool DurdurKontrol(int adres, bool hatagoster = true)
        {
            try
            {
                if (adres == -1)
                {
                    Durdur = false;
                    return false;
                }
                bool[] mb = tcpclient.ReadCoils(adres, 1);
                if (mb.Length > 0)
                    Durdur = mb[0];
                else
                    Durdur = false;
                return Durdur;
            }
            catch (Exception ex)
            {
                if (hatagoster)
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Durdur = false;
                return false;
            }
        }
    }

    public class Donus
    {
        public bool Hata;
        public double Deger;

        public Donus(bool hata, double deger)
        {
            Hata = hata;
            Deger = deger;
        }
    }
}
