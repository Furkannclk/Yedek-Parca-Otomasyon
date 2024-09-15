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
    public partial class GirisPenceresi : Form
    {
        public GirisPenceresi()
        {
            InitializeComponent();
        }
        ConnectionClassString DbBaglanti = new ConnectionClassString();
        SqlProcess SQLKutuphanem = new SqlProcess();
        MessageClass MesajKutuphanem = new MessageClass();
        private void BtnUyeOl_Click(object sender, EventArgs e)
        {
            UyeOlPencere UyelikIslemleri = new UyeOlPencere();
            UyelikIslemleri.ShowDialog();
        }

        private void kapat_pb_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GirisPenceresi_Load(object sender, EventArgs e)
        {
            CmbDurum.SelectedIndex = 0;
            TxtParola.UseSystemPasswordChar = true;
        }
        public static string tcbilgisi;
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            ArrayList GelenVeriler = SQLKutuphanem.SQLTabloAlanDiziReturn("tcno", "TblMusteri where tcno='" + TxbKullaniciAd.Text + "' and (soyad+SUBSTRING(tcno,8,10) )='"+TxtParola.Text+"'", DbBaglanti.Baglan());
            if (GelenVeriler.Count==1)
            {
                if (CmbDurum.SelectedIndex==0)
                {
                    tcbilgisi = TxbKullaniciAd.Text;
                    MusteriPenceresi MusteriIslemleriniAc = new MusteriPenceresi();
                    MusteriIslemleriniAc.Show();
                    this.Hide();
                }
                else if (CmbDurum.SelectedIndex == 1)
                {
                    if (GelenVeriler[0].ToString()=="00000000000")
                    {
                        YoneticiPenceresi YoneticiGiris = new YoneticiPenceresi();
                        YoneticiGiris.Show();
                        this.Hide();
                    }
                    else
                    {
                        MesajKutuphanem.MessageKonuBaslikSimge("YETKİ DIŞI İŞLEMLER", "GİRİŞ İŞLEMLERİ", "HATA");
                    }
                    

                }
                
            }
            else
            {
                MesajKutuphanem.MessageKonuBaslikSimge("KULLANICI ADI VEYA PAROLA HATALIDIR...","GİRİŞ İŞLEMLERİ","HATA");
            }
        }

        private void BtnCikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
