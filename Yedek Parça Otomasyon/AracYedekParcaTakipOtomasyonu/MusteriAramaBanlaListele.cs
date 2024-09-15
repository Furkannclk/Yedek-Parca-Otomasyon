using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace AracYedekParcaTakipOtomasyonu
{
    public partial class MusteriAramaBanlaListele : Form
    {
        public MusteriAramaBanlaListele()
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
        private void MusteriAramaBanlaListele_Load(object sender, EventArgs e)
        {
            MusteritTabloCek();
            TabloDuzen();
            Pnl_AramaYap.Visible = false;
            Pnl_Banla.Visible = false;
            if (YoneticiPenceresi.HangiPencereAcilacakNo == 0)//arama
            {
                this.Text = "MÜŞTERİ ARAMA YAP PENCERESİ";
                Pnl_AramaYap.Visible = true;
                CmbKonu.Items.AddRange(new string[] { "T.C NO","AD","SOYAD","CEP TELEFON","EV ADRES"});
                CmbKonu.SelectedIndex = 0;
            }
            else if (YoneticiPenceresi.HangiPencereAcilacakNo == 1)//banlama
            {
                this.Text = "MÜŞTERİ BANLAMA PENCERESİ";
                Pnl_AramaYap.Visible = true;
                Pnl_Banla.Visible = true;
                CmbKonu.Items.AddRange(new string[] { "T.C NO", "AD", "SOYAD", "CEP TELEFON", "EV ADRES" });
                CmbKonu.SelectedIndex = 0;
            }
            else if (YoneticiPenceresi.HangiPencereAcilacakNo == 2)//listeleme
            {
                this.Text = "MÜŞTERİ LİSTE PENCERESİ";
                Pnl_AramaYap.Visible = false;
                Pnl_Banla.Visible = false;
            }
        }
        private void MusteritTabloCek()
        {
            AlanAdlari.Clear();
            Sartlar.Clear();

            AlanAdlari.Add("arsiv");
            AlanAdlari.Add("ban");
            Sartlar.Add(1);
            Sartlar.Add(0);

            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLTabloAlanVeriSartDataGridViewReturn(AlanAdlari, "TblMusteri", Sartlar, DbBaglanti.Baglan()).Tables[0];
        }
        private void TabloDuzen()
        {
            tablolari_listele_dgv.Columns["resimyol"].Visible = false;
            tablolari_listele_dgv.Columns["ban"].Visible = false;
            tablolari_listele_dgv.Columns["ban_aciklama"].Visible = false;
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

        private void Btn_iptalEt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAramaYap_Click(object sender, EventArgs e)
        {
            AlanAdlari.Clear();
            Sartlar.Clear();
            if (CmbKonu.Text == "T.C NO")
            {
                AlanAdlari.Add("tcno");
            }
            else if (CmbKonu.Text == "AD")
            {
                AlanAdlari.Add("ad");
            }
            else if (CmbKonu.Text == "SOYAD")
            {
                AlanAdlari.Add("soyad");
            }
            else if (CmbKonu.Text == "CEP TELEFON")
            {
                AlanAdlari.Add("cep_telefonu");
            }
            else if (CmbKonu.Text == "EV ADRES")
            {
                AlanAdlari.Add("ev_adresi");
            }
            AlanAdlari.Add("arsiv");
            AlanAdlari.Add("ban");

            Sartlar.Add(TxtKonuIcerigi.Text);
            Sartlar.Add(1);
            Sartlar.Add(0);
            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLTabloAlanVeriSartDataGridViewSearchReturn(AlanAdlari, "TblMusteri", Sartlar, DbBaglanti.Baglan()).Tables[0];
        
        }

        private void BtnTumTablo_Click(object sender, EventArgs e)
        {
            MusteritTabloCek();
        }

        private void BtnBanla_Click(object sender, EventArgs e)
        {
            if (TxtBanAciklama.Text!="")
            {
                AlanAdlari.Clear(); AlanVeri.Clear();
                Sartlar.Clear(); SartVeri.Clear();

                AlanAdlari.Add("ban");
                AlanAdlari.Add("ban_aciklama");
                AlanAdlari.Add("arsiv");
                AlanVeri.Add(1);
                AlanVeri.Add(TxtBanAciklama.Text);
                AlanVeri.Add(0);
                Sartlar.Add("tcno");
                SartVeri.Add(tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString());

                if (SQLKutuphanem.SQLTabloAlanVeriSartVeriUpdateReturn("TblMusteri", AlanAdlari, AlanVeri, Sartlar, SartVeri, DbBaglanti.Baglan()))
                {
                    MesajKutuphanem.MessageKonuBaslikSimge("BAN İŞLEMİ BAŞARILI", "MÜŞTERİ İŞLEMLERİ", "BİLGİ");
                    MusteritTabloCek();
                    TxtBanAciklama.Clear();
                }
            }
            else
            {
                MesajKutuphanem.MessageKonuBaslikSimge("BAN İÇİN AÇIKLAMA GİRİLMELI\nBAN SEBEBİNİ YAZINIZ.", "MÜŞTERİ İŞLEMLERİ", "UYARI");
            }
            
        }
    }
}
