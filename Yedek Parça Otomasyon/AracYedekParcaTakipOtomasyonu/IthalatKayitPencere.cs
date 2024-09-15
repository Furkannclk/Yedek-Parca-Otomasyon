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

    public partial class IthalatKayitPencere : Form
    {
        public IthalatKayitPencere()
        {
            InitializeComponent();
        }
        ConnectionClassString DbBaglanti = new ConnectionClassString();
        SqlProcess SQLKutuphanem = new SqlProcess();
        MessageClass MesajKutuphanem = new MessageClass();

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            if (TxtIthalatUnvan.Text != "")
            {
                if (MstTxtTelefon1.Text.Count() == 13)
                {
                    if (TxtPosta.Text != "")
                    {
                        if (TxtAdres.Text != "")
                        {
                            if (TxtVergiNo.Text != "")
                            {
                                if (YoneticiPenceresi.Duzenleme)
                                {
                                    Duzenle();
                                }
                                else
                                {
                                    Kaydet();
                                }
                                
                            }
                            else
                            {
                                MesajKutuphanem.MessageKonuBaslikSimge("İTHALAT VERGİ NUMARASI BOŞ GEÇİLEMEZ...", "UYARI", "UYARI");
                            }
                        }
                        else
                        {
                            MesajKutuphanem.MessageKonuBaslikSimge("İTHALAT ADRES BOŞ GEÇİLEMEZ...", "UYARI", "UYARI");
                        }
                    }
                    else
                    {
                        MesajKutuphanem.MessageKonuBaslikSimge("İTHALAT E-POSTA ADRESİ BOŞ GEÇİLEMEZ...", "UYARI", "UYARI");
                    }
                }
                else
                {
                    MesajKutuphanem.MessageKonuBaslikSimge("İTHALAT TELEFON(1) BOŞ VEYA EKSİK GEÇİLEMEZ...", "UYARI", "UYARI");
                }
            }
            else
            {
                MesajKutuphanem.MessageKonuBaslikSimge("İTHALAT UNVAN/AD SOYAD GİRİNİZ", "UYARI", "UYARI");
            }
        }

        private void Kaydet()
        { 
            ArrayList AlanAdlari = new ArrayList();
            ArrayList AlanBilgi = new ArrayList();
            for (int i = 0; i < 7; i++)
            {
                AlanAdlari.Add("P" + i.ToString());
            }
            AlanBilgi.Add(TxtIthalatUnvan.Text);
            AlanBilgi.Add(MstTxtTelefon1.Text);
            AlanBilgi.Add(MstTxtTelefon2.Text);
            AlanBilgi.Add((TxtPosta.Text + "@" + CmbMailUzanti.SelectedItem.ToString()));
            AlanBilgi.Add(TxtAdres.Text);
            AlanBilgi.Add(TxtVergiNo.Text);
            AlanBilgi.Add(1);

            try
            {
                if (SQLKutuphanem.SQLTabloAlanDiziAlanVeriInsert("Tblithalat", AlanAdlari, AlanBilgi, DbBaglanti.Baglan()) == true)
                {
                    MesajKutuphanem.MessageKonuBaslikSimge("İTHALAT KAYIT BAŞARILI", "KAYIT İŞLEMLERİ", "BİLGİ");
                }
            }
            catch (Exception)
            {
                MesajKutuphanem.MessageKonuBaslikSimge("ALANLARI LÜTFEN DOLDURUNUZ...", "ALAN KONTROL", "UYARI");
            }
        }
        private void Duzenle()
        {
            ArrayList AlanAdlari = new ArrayList();
            ArrayList AlanVeri = new ArrayList();
            ArrayList Sartlar = new ArrayList();
            ArrayList SartVeri = new ArrayList();

            AlanAdlari.Add("IthalatUnvan"); AlanVeri.Add(TxtIthalatUnvan.Text);
            AlanAdlari.Add("IthalatTelefon1"); AlanVeri.Add(MstTxtTelefon1.Text);
            AlanAdlari.Add("IthalatTelefon2"); AlanVeri.Add(MstTxtTelefon2.Text);
            AlanAdlari.Add("IthalatMail"); AlanVeri.Add((TxtPosta.Text+"@"+CmbMailUzanti.SelectedItem.ToString()));
            AlanAdlari.Add("IthalatAdres"); AlanVeri.Add(TxtAdres.Text);
            AlanAdlari.Add("IthalatVergiNo"); AlanVeri.Add(TxtVergiNo.Text);

            Sartlar.Add("IthalatID");
            SartVeri.Add(DuzenlemeIcinID);


            if (SQLKutuphanem.SQLTabloAlanVeriSartVeriUpdateReturn("Tblithalat", AlanAdlari, AlanVeri, Sartlar, SartVeri, DbBaglanti.Baglan()))
            {
                MesajKutuphanem.MessageKonuBaslikSimge("İTHALAT FİRMA BİLGİ DÜZENLEME İŞLEMİ BAŞARILI", "İTHALAT FİRMA İŞLEMLERİ", "BİLGİ");
                this.Close();
            }
        }
        private void IthalatKayitPencere_Load(object sender, EventArgs e)
        {
            
            CmbMailUzanti.Items.Add("mail.google.com");
            CmbMailUzanti.Items.Add("hotmail.com");
            CmbMailUzanti.Items.Add("gmail.com");
            CmbMailUzanti.Items.Add("windowslive.com");
            CmbMailUzanti.Items.Add("mail.yandex.com");
            CmbMailUzanti.Items.Add("mail.yahoo.com");
            CmbMailUzanti.Items.Add("mail.mynet.com");
            CmbMailUzanti.SelectedIndex = 1;
            tablolari_listele_dgv.Visible = false;
            if (YoneticiPenceresi.Duzenleme)
            {
                this.Text = "İthalat Bilgi Düzenleme Penceresi";
                label2.Text = "BİLGİ DÜZENLEME İÇİN SEÇİLEN İTHALAT FİRMASİ ÇİFT TIKLAYINIZ";
                BtnKayit.Text = "Düzenle";
                tablolari_listele_dgv.Visible = true;
                this.Size = new Size(800,522);
                IthalatTabloCek();
                TabloDuzen();
            }
        }
        private void IthalatTabloCek()
        {
            ArrayList AlanAdlari = new ArrayList();
            ArrayList Sartlar = new ArrayList();

            AlanAdlari.Add("IthalatArsiv");
            Sartlar.Add(1);

            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLTabloAlanVeriSartDataGridViewReturn(AlanAdlari, "Tblithalat", Sartlar, DbBaglanti.Baglan()).Tables[0];
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
        private void Btn_iptalEt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string DuzenlemeIcinID;
        private void tablolari_listele_dgv_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                DuzenlemeIcinID = tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString();
                TxtIthalatUnvan.Text = tablolari_listele_dgv.CurrentRow.Cells[1].Value.ToString();
                MstTxtTelefon1.Text = tablolari_listele_dgv.CurrentRow.Cells[2].Value.ToString();
                MstTxtTelefon2.Text = tablolari_listele_dgv.CurrentRow.Cells[3].Value.ToString();
                TxtPosta.Text = (tablolari_listele_dgv.CurrentRow.Cells[4].Value.ToString()).Split('@')[0];
                CmbMailUzanti.SelectedItem = (tablolari_listele_dgv.CurrentRow.Cells[4].Value.ToString()).Split('@')[1];
                TxtAdres.Text = tablolari_listele_dgv.CurrentRow.Cells[5].Value.ToString();
                TxtVergiNo.Text = tablolari_listele_dgv.CurrentRow.Cells[6].Value.ToString();
                tablolari_listele_dgv.Visible = false;
                WindowState = FormWindowState.Normal;
                this.Size = new Size(364, 582);
                label2.Text = this.Text;
            }
            catch (Exception)
            {
                MesajKutuphanem.MessageKonuBaslikSimge("İTHALAT FİRMASI SEÇİNİZ", "ALAN KONTROL", "HATA");
            }
        }
    }
}
