using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace AracYedekParcaTakipOtomasyonu
{
    public partial class MusteriYedekParcaAl : Form
    {
        public MusteriYedekParcaAl()
        {
            InitializeComponent();
        }
        double fiyat;
        ConnectionClassString DbBaglanti = new ConnectionClassString();
        SqlProcess SQLKutuphanem = new SqlProcess();
        MessageClass MesajKutuphanem = new MessageClass();
        ArrayList AlanAdlari = new ArrayList();
        ArrayList AlanVeri = new ArrayList();
        ArrayList Sartlar = new ArrayList();
        ArrayList SartVeri = new ArrayList();
        private void MusteriYedekParcaAl_Load(object sender, EventArgs e)
        {
            TblFiyat.ReadOnly = true;
            LblBilgi.Text = "YEDEK PARÇA KODU:" + MusteriPenceresi.Kod+"\nYEDEK PARÇA ADI:"+MusteriPenceresi.Ad+"\nKATEGORİ:"+MusteriPenceresi.Kategori+"\nMARKA:"+MusteriPenceresi.marka+"\nMODEL:"+MusteriPenceresi.model+"\nYIL:"+MusteriPenceresi.yil+"\nAÇIKLAMA:"+MusteriPenceresi.aciklama;
            fiyat =Convert.ToDouble(MusteriPenceresi.Fiyat);
            TblFiyat.Text = fiyat.ToString();
            NUPAdet.Maximum = Convert.ToInt32(MusteriPenceresi.Adet);
            NUPAdet.Minimum = 1;
            NUPAdet.Increment = 1;
        }

        private void NUPAdet_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                TblFiyat.Text = (Convert.ToDouble(NUPAdet.Value) * fiyat).ToString();
            }
            catch (Exception)
            {
            }
            
        }

        private void BtnYedekAl_Click(object sender, EventArgs e)
        {
            ParcaAl();
        }
        private void ParcaAl()
        {
            ArrayList AlanAdlari = new ArrayList();
            ArrayList AlanBilgi = new ArrayList();
            for (int i = 0; i < 4; i++)
            {
                AlanAdlari.Add("P" + i.ToString());
            }


            AlanBilgi.Add(GirisPenceresi.tcbilgisi);
            AlanBilgi.Add(MusteriPenceresi.Kod);
            AlanBilgi.Add(NUPAdet.Value.ToString());
            AlanBilgi.Add(TblFiyat.Text);

            try
            {
                if (SQLKutuphanem.SQLTabloAlanDiziAlanVeriInsert("MusteriYedekParcaListesi", AlanAdlari, AlanBilgi, DbBaglanti.Baglan()) == true)
                {
                    AdetDus();
                }
            }
            catch (Exception X)
            {
                MesajKutuphanem.MessageKonuBaslikSimge("HATA OLUŞTU\n" + X, "HATA", "HATA");
            }
        }

        private void AdetDus()
        {
            ArrayList AlanAdlari = new ArrayList();
            ArrayList AlanVeri = new ArrayList();
            ArrayList Sartlar = new ArrayList();
            ArrayList SartVeri = new ArrayList();

            AlanAdlari.Add("YedekParcaAdet"); AlanVeri.Add(((Convert.ToInt32(MusteriPenceresi.Adet)-NUPAdet.Value).ToString()));
            if (NUPAdet.Value==NUPAdet.Maximum)
            {
                AlanAdlari.Add("arsiv"); AlanVeri.Add(0);
            }


            Sartlar.Add("YedekParcaKod");
            SartVeri.Add(MusteriPenceresi.Kod);


            if (SQLKutuphanem.SQLTabloAlanVeriSartVeriUpdateReturn("TblYedekParca", AlanAdlari, AlanVeri, Sartlar, SartVeri, DbBaglanti.Baglan()))
            {
                MesajKutuphanem.MessageKonuBaslikSimge("SATIŞ İŞLEMİ BAŞARILI", "SATIŞ İŞLEMLERİ", "BİLGİ");
                this.Close();
            }
        }

    }
}
