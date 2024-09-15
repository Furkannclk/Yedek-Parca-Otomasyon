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
    public partial class YedekParcaAramaArsivleListe : Form
    {
        public YedekParcaAramaArsivleListe()
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
        private void YedekParcaAramaArsivleListe_Load(object sender, EventArgs e)
        {
            TabloGetir();
            TabloDuzen();
            Pnl_AramaYap.Visible = false;
            Pnl_Arsivleme.Visible = false;
            if (YoneticiPenceresi.HangiPencereAcilacakNo == 0)//arama
            {
                this.Text = "YEDEK PARÇA ARAMA YAP PENCERESİ";
                Pnl_AramaYap.Visible = true;
                CmbKonu.Items.AddRange(new string[] { "KOD","AD","KATEGORİ","MARKA","MODEL","AÇIKLAMA" });
                CmbKonu.SelectedIndex = 0;
            }
            else if (YoneticiPenceresi.HangiPencereAcilacakNo == 1)//arşivleme
            {
                this.Text = "YEDEK PARÇA ARŞİVLE PENCERESİ";
                Pnl_AramaYap.Visible = true;
                Pnl_Arsivleme.Visible = true;
                CmbKonu.Items.AddRange(new string[] { "KOD", "AD", "KATEGORİ", "MARKA", "MODEL", "AÇIKLAMA" });
                CmbKonu.SelectedIndex = 0;
            }
        }

        private void TabloGetir()
        {
            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLKodDataGridViewReturn("exec PrcBirlestirYedekMarka", DbBaglanti.Baglan()).Tables[0];
        }
        private void TabloDuzen()
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

        private void BtnTumTablo_Click(object sender, EventArgs e)
        {
            TabloGetir();
        }

        private void BtnAramaYap_Click(object sender, EventArgs e)
        {
            
            if (CmbKonu.Text == "KOD")
            {
                tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLKodDataGridViewReturn("select TblYedekParca.YedekParcaKod,YedekParcaAd,YedekParcaKategori,YedekParcaSatisFiyat,YedekParcaAdet,Marka,Model,Yil,YedekParcaAciklama from TblYedekParca inner join TblParcaAlisBilgi on TblYedekParca.YedekParcaKod=TblParcaAlisBilgi.YedekParcaKod inner join TblMarkaModel on TblMarkaModel.ID=TblYedekParca.MarkaModelID where TblYedekParca.Arsiv=1 and TblYedekParca.YedekParcaKod like '%"+TxtKonuIcerigi.Text+"%'", DbBaglanti.Baglan()).Tables[0];
            }
            else if (CmbKonu.Text == "AD")
            {
                tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLKodDataGridViewReturn("select TblYedekParca.YedekParcaKod,YedekParcaAd,YedekParcaKategori,YedekParcaSatisFiyat,YedekParcaAdet,Marka,Model,Yil,YedekParcaAciklama from TblYedekParca inner join TblParcaAlisBilgi on TblYedekParca.YedekParcaKod=TblParcaAlisBilgi.YedekParcaKod inner join TblMarkaModel on TblMarkaModel.ID=TblYedekParca.MarkaModelID where TblYedekParca.Arsiv=1 and TblYedekParca.YedekParcaAd like '%" + TxtKonuIcerigi.Text + "%'", DbBaglanti.Baglan()).Tables[0];
            }
            else if (CmbKonu.Text == "KATEGORİ")
            {
                tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLKodDataGridViewReturn("select TblYedekParca.YedekParcaKod,YedekParcaAd,YedekParcaKategori,YedekParcaSatisFiyat,YedekParcaAdet,Marka,Model,Yil,YedekParcaAciklama from TblYedekParca inner join TblParcaAlisBilgi on TblYedekParca.YedekParcaKod=TblParcaAlisBilgi.YedekParcaKod inner join TblMarkaModel on TblMarkaModel.ID=TblYedekParca.MarkaModelID where TblYedekParca.Arsiv=1 and TblYedekParca.YedekParcaKategori like '%" + TxtKonuIcerigi.Text + "%'", DbBaglanti.Baglan()).Tables[0];
            }
            else if (CmbKonu.Text == "MARKA")
            {
                tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLKodDataGridViewReturn("select TblYedekParca.YedekParcaKod,YedekParcaAd,YedekParcaKategori,YedekParcaSatisFiyat,YedekParcaAdet,Marka,Model,Yil,YedekParcaAciklama from TblYedekParca inner join TblParcaAlisBilgi on TblYedekParca.YedekParcaKod=TblParcaAlisBilgi.YedekParcaKod inner join TblMarkaModel on TblMarkaModel.ID=TblYedekParca.MarkaModelID where TblYedekParca.Arsiv=1 and Marka like '%" + TxtKonuIcerigi.Text + "%'", DbBaglanti.Baglan()).Tables[0];
            }
            else if (CmbKonu.Text == "MODEL")
            {
                tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLKodDataGridViewReturn("select TblYedekParca.YedekParcaKod,YedekParcaAd,YedekParcaKategori,YedekParcaSatisFiyat,YedekParcaAdet,Marka,Model,Yil,YedekParcaAciklama from TblYedekParca inner join TblParcaAlisBilgi on TblYedekParca.YedekParcaKod=TblParcaAlisBilgi.YedekParcaKod inner join TblMarkaModel on TblMarkaModel.ID=TblYedekParca.MarkaModelID where TblYedekParca.Arsiv=1 and Model like '%" + TxtKonuIcerigi.Text + "%'", DbBaglanti.Baglan()).Tables[0];
            }
            else if (CmbKonu.Text == "AÇIKLAMA")
            {
                tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLKodDataGridViewReturn("select TblYedekParca.YedekParcaKod,YedekParcaAd,YedekParcaKategori,YedekParcaSatisFiyat,YedekParcaAdet,Marka,Model,Yil,YedekParcaAciklama from TblYedekParca inner join TblParcaAlisBilgi on TblYedekParca.YedekParcaKod=TblParcaAlisBilgi.YedekParcaKod inner join TblMarkaModel on TblMarkaModel.ID=TblYedekParca.MarkaModelID where TblYedekParca.Arsiv=1 and TblYedekParca.YedekParcaAciklama like '%" + TxtKonuIcerigi.Text + "%'", DbBaglanti.Baglan()).Tables[0];
            }
        }

        private void BtnArsivle_Click(object sender, EventArgs e)
        {
            AlanAdlari.Clear(); AlanVeri.Clear();
            Sartlar.Clear(); SartVeri.Clear();

            AlanAdlari.Add("Arsiv");
            AlanVeri.Add(0);
            Sartlar.Add("YedekParcaKod");
            SartVeri.Add(tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString());

            if (SQLKutuphanem.SQLTabloAlanVeriSartVeriUpdateReturn("TblYedekParca", AlanAdlari, AlanVeri, Sartlar, SartVeri, DbBaglanti.Baglan()))
            {
                MesajKutuphanem.MessageKonuBaslikSimge("ARŞİVLEME İŞLEMİ BAŞARILI", "YEDEK PARÇA İŞLEMLERİ", "BİLGİ");
                BtnTumTablo.PerformClick();
            }
        }

        private void Btn_iptalEt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
