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
    public partial class MarkaModelPenceresi : Form
    {
        public MarkaModelPenceresi()
        {
            InitializeComponent();
        }
        ConnectionClassString DbBaglanti = new ConnectionClassString();
        SqlProcess SQLKutuphanem = new SqlProcess();
        MessageClass MesajKutuphanem = new MessageClass();
        private void MarkaModelEkle()
        {
            ArrayList AlanAdlari = new ArrayList();
            ArrayList AlanBilgi = new ArrayList();
            for (int i = 0; i < 3; i++)
            {
                AlanAdlari.Add("P" + i.ToString());
            }
            AlanBilgi.Add(TxtMarka.Text);
            AlanBilgi.Add(TxtModel.Text);
            AlanBilgi.Add(TxtYil.Text);

            try
            {
                if (SQLKutuphanem.SQLTabloAlanDiziAlanVeriInsert("TblMarkaModel", AlanAdlari, AlanBilgi, DbBaglanti.Baglan()) == true)
                {
                    MesajKutuphanem.MessageKonuBaslikSimge("MARKA/MODEL KAYDI BAŞARILI", "KAYIT İŞLEMLERİ", "BİLGİ");
                }
            }
            catch (Exception)
            {
                MesajKutuphanem.MessageKonuBaslikSimge("ALANLARI LÜTFEN DOLDURUNUZ...", "ALAN KONTROL", "UYARI");
            }
        }

        private void BtnMMEkle_Click(object sender, EventArgs e)
        {
            if (TxtMarka.Text != "")
            {
                if (TxtModel.Text != "")
                {
                    if (TxtYil.Text != "")
                    {
                        if (YoneticiPenceresi.Duzenleme)
                        {
                            MarkaModelDuzenle();
                        }
                        else
                        {
                            MarkaModelEkle();
                        }
                    }
                    else
                    {
                        MesajKutuphanem.MessageKonuBaslikSimge("YIL KUTUSU BOŞ GEÇİLEMEZ...", "UYARI", "UYARI");
                    }
                }
                else
                {
                    MesajKutuphanem.MessageKonuBaslikSimge("MODEL KUTUSU BOŞ GEÇİLEMEZ...", "UYARI", "UYARI");
                }
            }
            else
            {
                MesajKutuphanem.MessageKonuBaslikSimge("MARKA KUTUSU BOŞ GEÇİLEMEZ...", "UYARI", "UYARI");
            }
        }
        private void MarkaModelDuzenle()
        {
            ArrayList AlanAdlari = new ArrayList();
            ArrayList AlanVeri = new ArrayList();
            ArrayList Sartlar = new ArrayList();
            ArrayList SartVeri = new ArrayList();

            AlanAdlari.Add("Marka"); AlanVeri.Add(TxtMarka.Text);
            AlanAdlari.Add("Model"); AlanVeri.Add(TxtModel.Text);
            AlanAdlari.Add("Yil"); AlanVeri.Add(TxtYil.Text);

            Sartlar.Add("ID");
            SartVeri.Add(MarkaModelID);


            if (SQLKutuphanem.SQLTabloAlanVeriSartVeriUpdateReturn("TblMarkaModel", AlanAdlari, AlanVeri, Sartlar, SartVeri, DbBaglanti.Baglan()))
            {
                MesajKutuphanem.MessageKonuBaslikSimge("MARKA/MODEL BİLGİ DÜZENLEME İŞLEMİ BAŞARILI", "MARKA MODEL İŞLEMLERİ", "BİLGİ");
                this.Close();
            }
        }
        private void MarkaModelPenceresi_Load(object sender, EventArgs e)
        {
            
            TxtMarka.MaxLength = TxtModel.MaxLength = 20;
            TxtYil.MaxLength = 4;
            tablolari_listele_dgv.Visible = false;
            if (YoneticiPenceresi.Duzenleme)
            {
                this.Text = "Marka/Model Bilgi Düzenleme Penceresi";
                label2.Text = "BİLGİ DÜZENLEME İÇİN SEÇİLEN SATIRA ÇİFT TIKLAYINIZ";
                BtnMMEkle.Text = "Marka Model Düzenle";
                tablolari_listele_dgv.Visible = true;
                this.Size = new Size(800, 522);
                MarkaModelTabloCek();
                TabloDuzen();
            }
        }
        private void MarkaModelTabloCek()
        {
            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLTabloAlanVeriDataGridViewReturn("TblMarkaModel",DbBaglanti.Baglan()).Tables[0];
        }
        private void TabloDuzen()
        {
            tablolari_listele_dgv.Columns["ID"].HeaderText = "ID";
            tablolari_listele_dgv.Columns["Marka"].HeaderText = "MARKA";
            tablolari_listele_dgv.Columns["Model"].HeaderText = "MODEL";
            tablolari_listele_dgv.Columns["Yil"].HeaderText = "YIL";
        }

        string MarkaModelID;
        private void tablolari_listele_dgv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                MarkaModelID = tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString();
                TxtMarka.Text = tablolari_listele_dgv.CurrentRow.Cells[1].Value.ToString();
                TxtModel.Text = tablolari_listele_dgv.CurrentRow.Cells[2].Value.ToString();
                TxtYil.Text = tablolari_listele_dgv.CurrentRow.Cells[3].Value.ToString();

                tablolari_listele_dgv.Visible = false;
                WindowState = FormWindowState.Normal;
                this.Size = new Size(361,327);
                label2.Text = this.Text;
            }
            catch (Exception)
            {
                MesajKutuphanem.MessageKonuBaslikSimge("SATIR SEÇİNİZ", "ALAN KONTROL", "HATA");
            }
        }
    }
}
