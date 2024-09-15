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
using System.IO;

namespace AracYedekParcaTakipOtomasyonu
{
    public partial class UyeOlPencere : Form
    {
        public UyeOlPencere()
        {
            InitializeComponent();
        }
        ConnectionClassString DbBaglanti = new ConnectionClassString();
        SqlProcess SQLKutuphanem = new SqlProcess();
        MessageClass MesajKutuphanem = new MessageClass();
        private void erkek_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (erkek_rb.Checked == true)
            {
                pictureBox1.ImageLocation = Application.StartupPath + @"\image\ImageProgram\ErkekProfil.png";
            }
        }

        private void kadin_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (kadin_rb.Checked == true)
            {
                pictureBox1.ImageLocation = Application.StartupPath + @"\image\ImageProgram\KadinProfil.png";
            }
        }

        private void UyeOlPencere_Load(object sender, EventArgs e)
        {
            DbBaglanti.Baglan();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            
            CmbMailUzanti.Items.Add("mail.google.com");
            CmbMailUzanti.Items.Add("hotmail.com");
            CmbMailUzanti.Items.Add("gmail.com");
            CmbMailUzanti.Items.Add("windowslive.com");
            CmbMailUzanti.Items.Add("mail.yandex.com");
            CmbMailUzanti.Items.Add("mail.yahoo.com");
            CmbMailUzanti.Items.Add("mail.mynet.com");
            CmbMailUzanti.SelectedIndex = 1;
            Db_KisitlamaVeDuzenleme();
            IlleriCek();
            pictureBox1.ImageLocation = Application.StartupPath + @"\image\ImageProgram\ErkekProfil.png";

            ResimAc.Title = "Resim Aç";
            ResimAc.Filter = "Resim Dosyaları | *jpg; *png;";
            ResimAc.Multiselect = false;
            ResimAc.RestoreDirectory = true;
        }
        private void Db_KisitlamaVeDuzenleme()
        {
            ad_tb.MaxLength = soyad_tb.MaxLength = 20;//en fazla girilebilen hane kısıtlaması
            mail_tb.MaxLength = 50;
            adres_tb.MaxLength = 150;
        }
        private void IlleriCek()
        {
            foreach (var Sehirler in SQLKutuphanem.SQLTabloAlanDiziReturn("sehir", "Tbliller", DbBaglanti.Baglan()))
            {
                Cmbiller.Items.Add(Sehirler.ToString());
            }
            if (Cmbiller.Items.Count > 0)
            {
                Cmbiller.SelectedIndex = 0;
            }
        }

        private void Cmbiller_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbilceler.Items.Clear();
            foreach (var ilceler in SQLKutuphanem.SQLTabloAlanSartDiziReturn("ilce", "Tblilceler", ("sehir=" + (Cmbiller.SelectedIndex + 1)), DbBaglanti.Baglan()))
            {
                Cmbilceler.Items.Add(ilceler);
            }
            if (Cmbilceler.Items.Count > 0)
            {
                Cmbilceler.SelectedIndex = 0;
            }
        }

        private void BtnUyeOl_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(MtbTc.Text) == false)//tc yi boş bırakmamaya yarayan yer
            {
                if (MtbTc.Text.Count() == 11)//tc yi eksik girmemeye yarıyan yer
                {
                    UyeOlFk();
                }
                else
                {
                    MesajKutuphanem.MessageKonuBaslikSimge("TC KİMLİK NUMARANIZ EKSİKTİR...", "UYARI", "UYARI");
                }
            }
            else
            {
                MesajKutuphanem.MessageKonuBaslikSimge("TC KİMLİK NUMARANIZI DOLDURUNUZ...", "UYARI", "UYARI");
            }
        }
        private void UyeOlFk()
        {
            
            ArrayList AlanAdlari = new ArrayList();
            ArrayList AlanBilgi = new ArrayList();
            for (int i = 0; i < 14; i++)
            {
                AlanAdlari.Add("P" + i.ToString());
            }


            AlanBilgi.Add(MtbTc.Text);

            if (pictureBox1.ImageLocation == Application.StartupPath + @"\image\ImageProgram\ErkekProfil.png" || pictureBox1.ImageLocation == Application.StartupPath + @"\image\ImageProgram\KadinProfil.png")
            {
                AlanBilgi.Add(pictureBox1.ImageLocation);
            }
            else
            {
                AlanBilgi.Add(ResminKayitEdildigiAdresBilgisi);
            }
            AlanBilgi.Add(ad_tb.Text);
            AlanBilgi.Add(soyad_tb.Text);
            if (erkek_rb.Checked == true)
            {
                AlanBilgi.Add("ERKEK");
            }
            else
            {
                AlanBilgi.Add("KADIN");
            }

            AlanBilgi.Add(Cmbiller.SelectedItem.ToString());
            AlanBilgi.Add(Cmbilceler.SelectedItem.ToString());
            AlanBilgi.Add(cep_masketb.Text);
            AlanBilgi.Add(ev_masketb.Text);
            AlanBilgi.Add(mail_tb.Text + "@" + CmbMailUzanti.SelectedItem.ToString());
            AlanBilgi.Add(adres_tb.Text);
            AlanBilgi.Add(0);
            AlanBilgi.Add("Ban durumu yoktur");
            AlanBilgi.Add(1);

            try
            {
                if (SQLKutuphanem.SQLTabloAlanDiziAlanVeriInsert("TblMusteri", AlanAdlari, AlanBilgi, DbBaglanti.Baglan()) == true)
                {
                    
                    MesajKutuphanem.MessageKonuBaslikSimge("ÜYE İŞLEMLERİ BAŞARILI", "ÜYE İŞLEMLERİ", "BİLGİ");
                    if (ResminKayitEdildigiAdresBilgisi!="")
                    {
                        File.Copy(pictureBox1.ImageLocation, Application.StartupPath + ResminKayitEdildigiAdresBilgisi);
                        this.Close();
                    }
                    MesajKutuphanem.MessageKonuBaslikSimge("GİRİŞ İŞLEMLERİ İÇİN BİLGİ\n\nSİSTEME GİRİŞ YAPILMASI İÇİN; \n\nKULLANICI ADI:T.C KİMLİK NUMARASI\nPAROLANIZ:SOYADINIZ+T.C NO SON 4 HANESİ \n\nÖRNEK T.C NO:12345678999 SOYAD:YELİZLER\nPAROLANIZ:YELİZLER8999", "ÜYE İŞLEMLERİ", "BİLGİ");
                }
            }
            catch (Exception X)
            {
                MesajKutuphanem.MessageKonuBaslikSimge("ALANLARI LÜTFEN DOLDURUNUZ...\n"+X, "ALAN KONTROL", "UYARI");
            }


        }
        OpenFileDialog ResimAc = new OpenFileDialog();
        string ResminKayitEdildigiAdresBilgisi = "";
        private void BtnResimAc_Click(object sender, EventArgs e)
        {
            if (ResimAc.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ResimAc.FileName;
                ResminKayitEdildigiAdresBilgisi = @"\image\ImageProfil\" + Guid.NewGuid() + ".jpg";

            }
        }

        private void MtbTc_KeyUp(object sender, KeyEventArgs e)
        {
            if (MtbTc.Text.Count() == 11)//benzer tc varmı kontrol eden yer
            {
                if (SQLKutuphanem.SQLTabloAlanSartBenzersizlikKontrolReturn("tcno", "TblMusteri", MtbTc.Text.ToString(), DbBaglanti.Baglan()))
                {
                    MesajKutuphanem.MessageKonuBaslikSimge("LÜTFEN FARKLI BİR T.C KİMLİK NUMARASI İLE KAYIT OLUNUZ.\nSİSTEME KAYDINIZ GÖZÜKMEKTEDİR. SİSTEME GİRİŞ YAPAMIYORSANIZ LÜTFEN YÖNETİCİ İLE GÖRÜŞÜNÜZ.", "BENZERLİK SORUNU", "HATA");
                    MtbTc.Clear();
                }
            }
        }

        private void Btn_iptalEt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
