using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace AracYedekParcaTakipOtomasyonu
{
    //BAĞLANTI ADRESİ SİSTEM DOSYASININ İÇİNDEN ÇEKİLİR.
    class ConnectionClassString
    {
        public SqlConnection Baglan()
        {
            StreamReader DosyaYoluBelirle = new StreamReader("Config.txt");
            string VerileriOku = DosyaYoluBelirle.ReadLine();
            string AdresiOlustur = "";
            while (VerileriOku!=null)
            {
                AdresiOlustur = VerileriOku;
                VerileriOku = DosyaYoluBelirle.ReadLine();
            }
            SqlConnection Baglanti = new SqlConnection(AdresiOlustur);
            Baglanti.Open();
            return Baglanti;
        }
    }
}
