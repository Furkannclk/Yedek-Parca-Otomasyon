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
    public partial class YedekParcaEkleDuzenlePenceresi : Form
    {
        public YedekParcaEkleDuzenlePenceresi()
        {
            InitializeComponent();
        }
        ConnectionClassString DbBaglanti = new ConnectionClassString();
        SqlProcess SQLKutuphanem = new SqlProcess();
        MessageClass MesajKutuphanem = new MessageClass();
        private void YedekParcaEkleDuzenlePenceresi_Load(object sender, EventArgs e)
        {
            Db_KisitlamaVeDuzenleme();
            MarkalariCek();
            IthakatciFirmaCek();
            CmbKategori.SelectedIndex = 0;
            tablolari_listele_dgv.Visible = false;
            if (YoneticiPenceresi.YedekParcaDuzen==true)
            {
                label2.Text = "DÜZENLEMEK YEDEK PARÇA SATIRINA ÇİFT TIKLAYINIZ";
                YedekParcaDListe();
                TabloDuzen();
                tablolari_listele_dgv.Visible = true;
                BtnYedekParcaEkle.Text = "Düzenle";
            }
        }
        private void YedekParcaDListe()
        {
            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLKodDataGridViewReturn("exec PrbDuzenleme", DbBaglanti.Baglan()).Tables[0];
        }
        private void TabloDuzen()
        {
            tablolari_listele_dgv.Columns["YedekParcaKod"].HeaderText = "YEDEK PARÇA KOD";
            tablolari_listele_dgv.Columns["YedekParcaAd"].HeaderText = "Y.PARÇA AD";
            tablolari_listele_dgv.Columns["YedekParcaKategori"].HeaderText = "KATEGORİ";
            tablolari_listele_dgv.Columns["YedekParcaSatisFiyat"].HeaderText = "SATIŞ FİYAT";
            tablolari_listele_dgv.Columns["YedekParcaAdet"].HeaderText = "SATIŞTAKİ ADET";
            tablolari_listele_dgv.Columns["Marka"].HeaderText = "MARKA";
            tablolari_listele_dgv.Columns["Model"].HeaderText = "MODEL";
            tablolari_listele_dgv.Columns["Yil"].HeaderText = "YIL";
            tablolari_listele_dgv.Columns["YedekParcaAciklama"].HeaderText = "AÇIKLAMA";
            tablolari_listele_dgv.Columns["AlisFiyat"].HeaderText = "ALIŞ FİYATİ";
            tablolari_listele_dgv.Columns["AlisTarih"].HeaderText = "ALIŞ TARİHİ";
            tablolari_listele_dgv.Columns["IthalatUnvan"].HeaderText = "İTHALAT UNVAN";
            tablolari_listele_dgv.Columns["ParcaAlisID"].HeaderText = "İŞLEM NO";
        }
        private void Db_KisitlamaVeDuzenleme()
        {
            TxtYedekKod.MaxLength = 10;
            TxtYedekParcaAd.MaxLength = 50;
            TxtAciklama.MaxLength = 200;
        }

        private void MarkalariCek()
        {
            foreach (var MarkaBilgi in SQLKutuphanem.SQLTabloAlanDiziReturn("Marka", "TblMarkaModel", DbBaglanti.Baglan()))
            {
                if (CmbMarka.Items.Contains(MarkaBilgi)==false)
                {
                    CmbMarka.Items.Add(MarkaBilgi);
                }
            }
            if (CmbMarka.Items.Count > 0)
            {
                CmbMarka.SelectedIndex = 0;
            }
        }

        private void IthakatciFirmaCek()
        {
            CmdFirmaAd.Items.Clear();
            foreach (var UnvanBilgi in SQLKutuphanem.SQLTabloAlanSartDiziReturn("IthalatUnvan", "Tblithalat", ("IthalatArsiv=1"), DbBaglanti.Baglan()))
            {
                if (CmdFirmaAd.Items.Contains(UnvanBilgi) == false)
                {
                    CmdFirmaAd.Items.Add(UnvanBilgi);
                }

            }
            if (CmdFirmaAd.Items.Count > 0)
            {
                CmdFirmaAd.SelectedIndex = 0;
            }
        }
        string MarkaModelID;
        private void CmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {

            CmdYil.Items.Clear();
            foreach (var YilBilgisi in SQLKutuphanem.SQLTabloAlanSartDiziReturn("Yil", "TblMarkaModel", ("Marka='" + CmbMarka.SelectedItem.ToString() + "' and Model='"+CmbModel.SelectedItem.ToString()+"'"), DbBaglanti.Baglan()))
            {
                if (CmdYil.Items.Contains(YilBilgisi) == false)
                {
                    CmdYil.Items.Add(YilBilgisi);
                }
            }
            if (CmdYil.Items.Count > 0)
            {
                CmdYil.SelectedIndex = 0;
            }

            foreach (var IDBilgi in SQLKutuphanem.SQLTabloAlanSartDiziReturn("ID", "TblMarkaModel", ("Marka='" + CmbMarka.SelectedItem.ToString() + "' and Model='" + CmbModel.SelectedItem.ToString() + "' and Yil='" + CmdYil.SelectedItem.ToString() + "'"), DbBaglanti.Baglan()))
            {
                MarkaModelID = IDBilgi.ToString();
            }
        }

        private void CmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbModel.Items.Clear();
            foreach (var ModelBilgi in SQLKutuphanem.SQLTabloAlanSartDiziReturn("Model", "TblMarkaModel", ("Marka='" + CmbMarka.SelectedItem.ToString()+"'"), DbBaglanti.Baglan()))
            {
                if (CmbModel.Items.Contains(ModelBilgi) == false)
                {
                    CmbModel.Items.Add(ModelBilgi);
                }

            }
            if (CmbModel.Items.Count > 0)
            {
                CmbModel.SelectedIndex = 0;
            }
        }

        private void CmdYil_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var IDBilgi in SQLKutuphanem.SQLTabloAlanSartDiziReturn("ID", "TblMarkaModel", ("Marka='" + CmbMarka.SelectedItem.ToString() + "' and Model='" + CmbModel.SelectedItem.ToString() + "' and Yil='" + CmdYil.SelectedItem.ToString() + "'"), DbBaglanti.Baglan()))
            {
                MarkaModelID = IDBilgi.ToString();
            }
        }
        string ithalatID;
        private void CmdFirmaAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var IDBilgi in SQLKutuphanem.SQLTabloAlanSartDiziReturn("IthalatID", "Tblithalat", ("IthalatUnvan='" + CmdFirmaAd.SelectedItem.ToString() + "' and IthalatArsiv=1"), DbBaglanti.Baglan()))
            {
                ithalatID = IDBilgi.ToString();
            }
        }

        private void Btn_iptalEt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnYedekParcaEkle_Click(object sender, EventArgs e)
        {
            if (TxtYedekKod.Text!="")
            {
                if (TxtYedekKod.TextLength== 10)
                {
                    if (TxtYedekParcaAd.Text != "")
                    {
                        if (TxtAlisFiyat.Text != "")
                        {
                            if (TxtSatisFiyat.Text != "")
                            {
                                if (TxtAdet.Text != "")
                                {
                                    if (TxtAciklama.Text != "")
                                    {
                                        if (YoneticiPenceresi.YedekParcaDuzen)
                                        {
                                            Duzenle1();
                                            Duzenle2();
                                            if (duzenle1 == true && duzenle2 == true)
                                            {
                                                MesajKutuphanem.MessageKonuBaslikSimge("YEDEK PARÇA DÜZENLEME İŞLEMİ BAŞARILI", "YEDEK PARÇA İŞLEMLERİ", "BİLGİ");
                                                this.Close();
                                            }
                                            duzenle1 = duzenle2 = false;
                                        }
                                        else
                                        {
                                            ParcaKayit1();
                                            ParcaKayit2();
                                            if (Kayit1 == true && Kayit2 == true)
                                            {
                                                MesajKutuphanem.MessageKonuBaslikSimge("YEDEK PARÇA EKLEME İŞLEMİ BAŞARILI", "YEDEK PARÇA İŞLEMLERİ", "BİLGİ");
                                                this.Close();
                                            }
                                            Kayit1 = Kayit2 = false;
                                        }
                                       
                                    }
                                    else
                                    {
                                        MesajKutuphanem.MessageKonuBaslikSimge("AÇIKLAMA KUTUSU BOŞ GEÇİLEMEZ...", "UYARI", "UYARI");
                                    }
                                }
                                else
                                {
                                    MesajKutuphanem.MessageKonuBaslikSimge("ADET KUTUSU BOŞ GEÇİLEMEZ...", "UYARI", "UYARI");
                                }
                            }
                            else
                            {
                                MesajKutuphanem.MessageKonuBaslikSimge("SATIŞ FİYAT KUTUSU BOŞ GEÇİLEMEZ...", "UYARI", "UYARI");
                            }
                        }
                        else
                        {
                            MesajKutuphanem.MessageKonuBaslikSimge("ALIŞ FİYAT KUTUSU BOŞ GEÇİLEMEZ...", "UYARI", "UYARI");
                        }
                    }
                    else
                    {
                        MesajKutuphanem.MessageKonuBaslikSimge("YEDEK PARÇA AD KUTUSU BOŞ GEÇİLEMEZ...", "UYARI", "UYARI");
                    }
                }
                else
                {
                    MesajKutuphanem.MessageKonuBaslikSimge("YEDEK PARÇA KOD 10 HANELI KOD GİRİLMELİ", "UYARI", "UYARI");
                }
            }
            else
            {
                MesajKutuphanem.MessageKonuBaslikSimge("YEDEK PARÇA KOD KUTUSU BOŞ GEÇİLEMEZ...","UYARI","UYARI");
            }

        }
        bool Kayit1 = false,Kayit2=false;
        private void ParcaKayit1()
        {
            ArrayList AlanAdlari = new ArrayList();
            ArrayList AlanBilgi = new ArrayList();
            for (int i = 0; i < 8; i++)
            {
                AlanAdlari.Add("P" + i.ToString());
            }


            AlanBilgi.Add(TxtYedekKod.Text);
            AlanBilgi.Add(TxtYedekParcaAd.Text);
            AlanBilgi.Add(CmbKategori.SelectedItem.ToString());
            AlanBilgi.Add(TxtSatisFiyat.Text);
            AlanBilgi.Add(TxtAdet.Text);
            AlanBilgi.Add(MarkaModelID.ToString());
            AlanBilgi.Add(TxtAciklama.Text);
            AlanBilgi.Add(1);

            try
            {
                if (SQLKutuphanem.SQLTabloAlanDiziAlanVeriInsert("TblYedekParca", AlanAdlari, AlanBilgi, DbBaglanti.Baglan()) == true)
                {
                    Kayit1 = true;
                }
            }
            catch (Exception X)
            {
                MesajKutuphanem.MessageKonuBaslikSimge("ALANLARI LÜTFEN DOLDURUNUZ...\n" + X, "ALAN KONTROL", "UYARI");
            }
        }

        private void ParcaKayit2()
        {
            ArrayList AlanAdlari = new ArrayList();
            ArrayList AlanBilgi = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                AlanAdlari.Add("P" + i.ToString());
            }


            AlanBilgi.Add(ithalatID);
            AlanBilgi.Add(TxtYedekKod.Text);
            AlanBilgi.Add(TxtAdet.Text);
            AlanBilgi.Add(TxtAlisFiyat.Text);
            AlanBilgi.Add(DTAlisTarihi.Text);
            try
            {
                if (SQLKutuphanem.SQLTabloAlanDiziAlanVeriInsert("TblParcaAlisBilgi", AlanAdlari, AlanBilgi, DbBaglanti.Baglan()) == true)
                {
                    Kayit2 = true;
                }
            }
            catch (Exception X)
            {
                MesajKutuphanem.MessageKonuBaslikSimge("ALANLARI LÜTFEN DOLDURUNUZ...\n" + X, "ALAN KONTROL", "UYARI");
            }
        }

        bool duzenle1 = false, duzenle2 = false;
        private void Duzenle1()
        {
            ArrayList AlanAdlari = new ArrayList();
            ArrayList AlanVeri = new ArrayList();
            ArrayList Sartlar = new ArrayList();
            ArrayList SartVeri = new ArrayList();

            AlanAdlari.Add("YedekParcaKod"); AlanVeri.Add(TxtYedekKod.Text);
            AlanAdlari.Add("YedekParcaAd"); AlanVeri.Add(TxtYedekParcaAd.Text);
            AlanAdlari.Add("YedekParcaKategori"); AlanVeri.Add(CmbKategori.SelectedItem.ToString());
            AlanAdlari.Add("YedekParcaSatisFiyat"); AlanVeri.Add(TxtSatisFiyat.Text);
            AlanAdlari.Add("YedekParcaAdet"); AlanVeri.Add(TxtAdet.Text);
            AlanAdlari.Add("MarkaModelID"); AlanVeri.Add(MarkaModelID);
            AlanAdlari.Add("YedekParcaAciklama"); AlanVeri.Add(TxtAciklama.Text);

            Sartlar.Add("YedekParcaKod");
            SartVeri.Add(YedekParcaKod);


            if (SQLKutuphanem.SQLTabloAlanVeriSartVeriUpdateReturn("TblYedekParca", AlanAdlari, AlanVeri, Sartlar, SartVeri, DbBaglanti.Baglan()))
            {
                duzenle1 = true;
            }
        }
        private void Duzenle2()
        {
            ArrayList AlanAdlari = new ArrayList();
            ArrayList AlanVeri = new ArrayList();
            ArrayList Sartlar = new ArrayList();
            ArrayList SartVeri = new ArrayList();

            AlanAdlari.Add("IthalatID"); AlanVeri.Add(ithalatID);
            AlanAdlari.Add("YedekParcaKod"); AlanVeri.Add(TxtYedekKod.Text);
            AlanAdlari.Add("AlisAdeti"); AlanVeri.Add(TxtAdet.Text);
            AlanAdlari.Add("AlisFiyat"); AlanVeri.Add(TxtAlisFiyat.Text);
            AlanAdlari.Add("AlisTarih"); AlanVeri.Add(DTAlisTarihi.Value.ToString());

            Sartlar.Add("ParcaAlisID");
            SartVeri.Add(AlisKod);


            if (SQLKutuphanem.SQLTabloAlanVeriSartVeriUpdateReturn("TblParcaAlisBilgi", AlanAdlari, AlanVeri, Sartlar, SartVeri, DbBaglanti.Baglan()))
            {
                duzenle2 = true;
            }
        }



        string YedekParcaKod = "",AlisKod="";
        private void tablolari_listele_dgv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TxtYedekKod.Text =YedekParcaKod= tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString();
                TxtYedekParcaAd.Text = tablolari_listele_dgv.CurrentRow.Cells[1].Value.ToString();
                CmbKategori.SelectedItem= tablolari_listele_dgv.CurrentRow.Cells[2].Value.ToString();
                TxtSatisFiyat.Text = tablolari_listele_dgv.CurrentRow.Cells[3].Value.ToString();
                TxtAdet.Text= tablolari_listele_dgv.CurrentRow.Cells[4].Value.ToString();
                CmbMarka.SelectedItem = tablolari_listele_dgv.CurrentRow.Cells[5].Value.ToString();
                CmbModel.SelectedItem = tablolari_listele_dgv.CurrentRow.Cells[6].Value.ToString();
                CmdYil.SelectedItem = tablolari_listele_dgv.CurrentRow.Cells[7].Value.ToString();
                TxtAciklama.Text= tablolari_listele_dgv.CurrentRow.Cells[8].Value.ToString();
                TxtAlisFiyat.Text = tablolari_listele_dgv.CurrentRow.Cells[9].Value.ToString();
                DTAlisTarihi.Value =Convert.ToDateTime(tablolari_listele_dgv.CurrentRow.Cells[10].Value.ToString());
                CmdFirmaAd.SelectedItem= tablolari_listele_dgv.CurrentRow.Cells[11].Value.ToString();
                AlisKod = tablolari_listele_dgv.CurrentRow.Cells[12].Value.ToString();

                tablolari_listele_dgv.Visible = false;
                WindowState = FormWindowState.Normal;
                this.Size = new Size(595,500);
                label2.Text = this.Text;
            }
            catch (Exception)
            {
                MesajKutuphanem.MessageKonuBaslikSimge("YEDEK PARÇA SEÇİNİZ", "ALAN KONTROL", "HATA");
            }
        }
    }
}
