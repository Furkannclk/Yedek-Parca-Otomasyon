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
    public partial class ListeIslemPenceresi : Form
    {
        public ListeIslemPenceresi()
        {
            InitializeComponent();
        }
        ConnectionClassString DbBaglanti = new ConnectionClassString();
        SqlProcess SQLKutuphanem = new SqlProcess();
        MessageClass MesajKutuphanem = new MessageClass();
        ArrayList AlanAdlari = new ArrayList();
        ArrayList AlanVeri = new ArrayList();
        ArrayList Sartlar = new ArrayList();
        ArrayList SartVeri = new ArrayList();

        int a = 0;
       

        private void ListeIslemPenceresi_Load(object sender, EventArgs e)
        {
            

            if (YoneticiPenceresi.ListeIslemHangiPencere == 0)
            {
                
                MenuOrtakIslem.Text = "İthalat Firmasini Arşivden Çıkar";
                IthalatTabloCek();
                TabloDuzen();
            }
            else if (YoneticiPenceresi.ListeIslemHangiPencere == 1)
            {
                
                MenuOrtakIslem.Text = "Müşteri Bilgilerini Arşivden Çıkar";
                MusteritTabloCek();
                TabloDuzen();
            }
            else if (YoneticiPenceresi.ListeIslemHangiPencere == 2)
            {
                
                MenuOrtakIslem.Text = "Müşteriyi Ban Listesinden Çıkar";
                BanliMusteritTabloCek();
                TabloDuzen();
            }
            else if (YoneticiPenceresi.ListeIslemHangiPencere == 3)
            {
                
                MenuOrtakIslem.Text = "Yedek Parça Arşiv Listesinden Çıkar";
                YedekArsivCek();
                TabloDuzen();
            }
        }
        private void IthalatTabloCek()
        {
            AlanAdlari.Clear();
            Sartlar.Clear();

            AlanAdlari.Add("IthalatArsiv");
            Sartlar.Add(0);

            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLTabloAlanVeriSartDataGridViewReturn(AlanAdlari, "Tblithalat", Sartlar, DbBaglanti.Baglan()).Tables[0];
        }
        private void MusteritTabloCek()
        {
            AlanAdlari.Clear();
            Sartlar.Clear();

            AlanAdlari.Add("arsiv");
            AlanAdlari.Add("ban");
            Sartlar.Add(0);
            Sartlar.Add(0);

            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLTabloAlanVeriSartDataGridViewReturn(AlanAdlari, "TblMusteri", Sartlar, DbBaglanti.Baglan()).Tables[0];
        }

        private void BanliMusteritTabloCek()
        {
            AlanAdlari.Clear();
            Sartlar.Clear();

            AlanAdlari.Add("arsiv");
            AlanAdlari.Add("ban");
            Sartlar.Add(0);
            Sartlar.Add(1);

            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLTabloAlanVeriSartDataGridViewReturn(AlanAdlari, "TblMusteri", Sartlar, DbBaglanti.Baglan()).Tables[0];
        }
        private void YedekArsivCek()
        {
            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLKodDataGridViewReturn("exec PrcYedekMarkaArsivPasif", DbBaglanti.Baglan()).Tables[0];
        }
        private void TabloDuzen()
        {
            if (YoneticiPenceresi.ListeIslemHangiPencere == 0)
            {
                tablolari_listele_dgv.Columns["IthalatArsiv"].Visible = false;
                tablolari_listele_dgv.Columns["IthalatID"].HeaderText = "İTHALAT ID";
                tablolari_listele_dgv.Columns["IthalatUnvan"].HeaderText = "İTHALAT UNVAN";
                tablolari_listele_dgv.Columns["IthalatTelefon1"].HeaderText = "İTHALAT TELEFON(1)";
                tablolari_listele_dgv.Columns["IthalatTelefon2"].HeaderText = "İTHALAT TELEFON(2)";
                tablolari_listele_dgv.Columns["IthalatMail"].HeaderText = "İTHALAT E-POSTA ADRES";
                tablolari_listele_dgv.Columns["IthalatAdres"].HeaderText = "İTHALAT ADRES";
                tablolari_listele_dgv.Columns["IthalatVergiNo"].HeaderText = "İTHALAT VERGİ NO";
            }
            else if (YoneticiPenceresi.ListeIslemHangiPencere == 1 || YoneticiPenceresi.ListeIslemHangiPencere == 2)
            {
                tablolari_listele_dgv.Columns["resimyol"].Visible = false;
                tablolari_listele_dgv.Columns["ban"].Visible = false;
                if (YoneticiPenceresi.ListeIslemHangiPencere == 1)
                {
                    tablolari_listele_dgv.Columns["ban_aciklama"].Visible = false;
                }
                else
                {
                    tablolari_listele_dgv.Columns["ban_aciklama"].HeaderText = "BAN AÇIKLAMA";
                }
                
                tablolari_listele_dgv.Columns["arsiv"].Visible = false;

                tablolari_listele_dgv.Columns["tcno"].HeaderText = "T.C NO";
                tablolari_listele_dgv.Columns["ad"].HeaderText = "AD";
                tablolari_listele_dgv.Columns["soyad"].HeaderText = "SOYAD";
                tablolari_listele_dgv.Columns["cinsiyet"].HeaderText = "CİNSİYET";
                tablolari_listele_dgv.Columns["il"].HeaderText = "İL";
                tablolari_listele_dgv.Columns["ilce"].HeaderText = "İLÇE";
                tablolari_listele_dgv.Columns["cep_telefonu"].HeaderText = "CEP TELEFONU";
                tablolari_listele_dgv.Columns["ev_telefonu"].HeaderText = "EV TELEFONU";
                tablolari_listele_dgv.Columns["eposta"].HeaderText = "E POSTA";
                tablolari_listele_dgv.Columns["ev_adresi"].HeaderText = "EV ADRESİ";
            }
            else if (YoneticiPenceresi.ListeIslemHangiPencere == 3)
            {
                tablolari_listele_dgv.Columns["YedekParcaKod"].HeaderText = "YEDEK PARÇA KOD";
                tablolari_listele_dgv.Columns["YedekParcaAd"].HeaderText = "Y.PARÇA AD";
                tablolari_listele_dgv.Columns["YedekParcaKategori"].HeaderText = "KATEGORİ";
                tablolari_listele_dgv.Columns["YedekParcaSatisFiyat"].HeaderText = "SATIŞ FİYAT";
                tablolari_listele_dgv.Columns["YedekParcaAdet"].HeaderText = "ADET";
                tablolari_listele_dgv.Columns["Marka"].HeaderText = "MARKA";
                tablolari_listele_dgv.Columns["Model"].HeaderText = "MODEL";
                tablolari_listele_dgv.Columns["Yil"].HeaderText = "YIL";
                tablolari_listele_dgv.Columns["YedekParcaAciklama"].HeaderText = "AÇIKLAMA";
            }

        }

        private void MenuOrtakIslem_Click(object sender, EventArgs e)
        {
            if (YoneticiPenceresi.ListeIslemHangiPencere == 0)//ithalat arşivden çıkarma
            {
                AlanAdlari.Clear(); AlanVeri.Clear();
                Sartlar.Clear(); SartVeri.Clear();

                AlanAdlari.Add("IthalatArsiv");
                AlanVeri.Add(1);
                Sartlar.Add("IthalatID");
                SartVeri.Add(tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString());



                if (SQLKutuphanem.SQLTabloAlanVeriSartVeriUpdateReturn("Tblithalat", AlanAdlari, AlanVeri, Sartlar, SartVeri, DbBaglanti.Baglan()))
                {
                    MesajKutuphanem.MessageKonuBaslikSimge("ARŞİVDEN ÇIKARMA İŞLEMİ BAŞARILI", "İTHALAT FİRMA İŞLEMLERİ", "BİLGİ");
                    IthalatTabloCek();
                }
            }
            else if (YoneticiPenceresi.ListeIslemHangiPencere == 1)//müşteri arşivden çıkarma
            {
                AlanAdlari.Clear(); AlanVeri.Clear();
                Sartlar.Clear(); SartVeri.Clear();

                AlanAdlari.Add("arsiv");

                AlanVeri.Add(1);

                Sartlar.Add("tcno");
                SartVeri.Add(tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString());

                if (SQLKutuphanem.SQLTabloAlanVeriSartVeriUpdateReturn("TblMusteri", AlanAdlari, AlanVeri, Sartlar, SartVeri, DbBaglanti.Baglan()))
                {
                    MesajKutuphanem.MessageKonuBaslikSimge("ARŞİVDEN ÇIKARMA İŞLEMİ BAŞARILI", "MÜŞTERİ İŞLEMLERİ", "BİLGİ");
                    MusteritTabloCek();
                }
            }
            else if (YoneticiPenceresi.ListeIslemHangiPencere == 2)//müşteri ban kaldırma
            {
                AlanAdlari.Clear(); AlanVeri.Clear();
                Sartlar.Clear(); SartVeri.Clear();

                AlanAdlari.Add("arsiv");
                AlanAdlari.Add("ban");
                AlanVeri.Add(1);
                AlanVeri.Add(0);

                Sartlar.Add("tcno");
                SartVeri.Add(tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString());

                if (SQLKutuphanem.SQLTabloAlanVeriSartVeriUpdateReturn("TblMusteri", AlanAdlari, AlanVeri, Sartlar, SartVeri, DbBaglanti.Baglan()))
                {
                    MesajKutuphanem.MessageKonuBaslikSimge("BAN ÇIKARMA İŞLEMİ BAŞARILI", "MÜŞTERİ İŞLEMLERİ", "BİLGİ");
                    BanliMusteritTabloCek();
                }
            }
            else if (YoneticiPenceresi.ListeIslemHangiPencere == 3)//ydek parcaları arsivden çıkarma
            {
                AlanAdlari.Clear(); AlanVeri.Clear();
                Sartlar.Clear(); SartVeri.Clear();

                AlanAdlari.Add("Arsiv");
                AlanVeri.Add(1);

                Sartlar.Add("YedekParcaKod");
                SartVeri.Add(tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString());

                if (SQLKutuphanem.SQLTabloAlanVeriSartVeriUpdateReturn("TblYedekParca", AlanAdlari, AlanVeri, Sartlar, SartVeri, DbBaglanti.Baglan()))
                {
                    MesajKutuphanem.MessageKonuBaslikSimge("YEDEK PARÇA ÇIKARMA İŞLEMİ BAŞARILI", "YEDEK PARÇA İŞLEMLERİ", "BİLGİ");
                    YedekArsivCek();
                }
            }

        }

    }
}
