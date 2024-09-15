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
    public partial class ithalatAramaArsivlemeListeleme : Form
    {
        public ithalatAramaArsivlemeListeleme()
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
        private void ithalatAramaArsivlemeListeleme_Load(object sender, EventArgs e)
        {
            IthalatTabloCek();
            TabloDuzen();
            Pnl_AramaYap.Visible = false;
            Pnl_Arsivleme.Visible = false;
            if (YoneticiPenceresi.HangiPencereAcilacakNo == 0)//arama yeri
            {
                this.Text = "İTHALAT FİRMA ARAMA YAP PENCERESİ";
                Pnl_AramaYap.Visible = true;
                CmbKonu.Items.AddRange(new string[] { "UNVAN","İ. ADRES","VERGİ NO" });
                CmbKonu.SelectedIndex = 0;
            }
            else if (YoneticiPenceresi.HangiPencereAcilacakNo == 1)//arşivleme
            {
                this.Text = "İTHALAT FİRMA ARŞİVLE PENCERESİ";
                Pnl_AramaYap.Visible = true;
                Pnl_Arsivleme.Visible = true;
                CmbKonu.Items.AddRange(new string[] { "UNVAN", "İ. ADRES", "VERGİ NO" });
                CmbKonu.SelectedIndex = 0;
            }
            else if (YoneticiPenceresi.HangiPencereAcilacakNo == 2)//listeleme
            {
                this.Text = "İTHALAT FİRMA LİSTE PENCERESİ";
                Pnl_AramaYap.Visible = false;
                Pnl_Arsivleme.Visible = false;
            }
        }
        private void IthalatTabloCek()
        {
            AlanAdlari.Clear();
            Sartlar.Clear();
            
            AlanAdlari.Add("IthalatArsiv");
            Sartlar.Add(1);

            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLTabloAlanVeriSartDataGridViewReturn(AlanAdlari, "Tblithalat",Sartlar , DbBaglanti.Baglan()).Tables[0];
        }
        private void TabloDuzen()
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

        private void BtnAramaYap_Click(object sender, EventArgs e)
        {
            AlanAdlari.Clear();
            Sartlar.Clear();
            if (CmbKonu.Text=="UNVAN")
            {
                AlanAdlari.Add("IthalatUnvan");
            }
            else if (CmbKonu.Text=="İ. ADRES")
            {
                AlanAdlari.Add("IthalatAdres");
            }
            else if (CmbKonu.Text=="VERGİ NO")
            {
                AlanAdlari.Add("IthalatVergiNo");
            }
            AlanAdlari.Add("IthalatArsiv");

            Sartlar.Add(TxtKonuIcerigi.Text);
            Sartlar.Add(1);
            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLTabloAlanVeriSartDataGridViewSearchReturn(AlanAdlari, "Tblithalat", Sartlar, DbBaglanti.Baglan()).Tables[0];
        }

        private void BtnTumTablo_Click(object sender, EventArgs e)
        {
            IthalatTabloCek();
        }

        private void BtnArsivle_Click(object sender, EventArgs e)
        {
            AlanAdlari.Clear(); AlanVeri.Clear();
            Sartlar.Clear();    SartVeri.Clear();

            AlanAdlari.Add("IthalatArsiv");
            AlanVeri.Add(0);
            Sartlar.Add("IthalatID");
            SartVeri.Add(tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString());



            if (SQLKutuphanem.SQLTabloAlanVeriSartVeriUpdateReturn("Tblithalat", AlanAdlari, AlanVeri, Sartlar, SartVeri, DbBaglanti.Baglan()))
            {
                MesajKutuphanem.MessageKonuBaslikSimge("ARŞİVLEME İŞLEMİ BAŞARILI", "İTHALAT FİRMA İŞLEMLERİ", "BİLGİ");
                IthalatTabloCek();
            }
        }

        private void Btn_iptalEt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
