using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace AracYedekParcaTakipOtomasyonu
{
    class MessageClass
    {
        public void MessageKonuBaslikSimge(string Konu, string Baslik, string Simge = "BİLGİ")
        {//VARSAYILAN BUTON "OK" ÜÇ SİMGE MEVCUT BİLGİ,HATA,UYARI
            if (Simge == "BİLGİ")
            {
                MessageBox.Show(Konu.ToUpper(), Baslik.ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Simge == "UYARI")
            {
                MessageBox.Show(Konu.ToUpper(), Baslik.ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Simge == "HATA")
            {
                MessageBox.Show(Konu.ToUpper(), Baslik.ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
