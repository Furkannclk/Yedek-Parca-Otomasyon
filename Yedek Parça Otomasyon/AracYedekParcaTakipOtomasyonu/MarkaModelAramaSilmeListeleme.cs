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
    public partial class MarkaModelAramaSilmeListeleme : Form
    {
        public MarkaModelAramaSilmeListeleme()
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
        private void Btn_iptalEt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        enum AramaKonusu
        {
            MARKA,MODEL
        }
        private void MarkaModelAramaSilmeListeleme_Load(object sender, EventArgs e)
        {
            MarkaModelTablosunuCek();
            TabloDuzen();
            Pnl_AramaYap.Visible = false;
            Pnl_Silme.Visible = false;
            if (YoneticiPenceresi.HangiPencereAcilacakNo == 0)//arama
            {
                this.Text = "MARKA MODEL ARAMA YAP PENCERESİ";
                Pnl_AramaYap.Visible = true;
                CmbKonu.Items.AddRange(new string[] { "MARKA", "MODEL"});
                CmbKonu.SelectedIndex = 0;
            }
            else if (YoneticiPenceresi.HangiPencereAcilacakNo == 1)//silme
            {
                this.Text = "MARKA MODEL SİLME PENCERESİ";
                Pnl_AramaYap.Visible = true;
                Pnl_Silme.Visible = true;
                CmbKonu.Items.AddRange(new string[] { "MARKA", "MODEL" });
                CmbKonu.SelectedIndex = 0;
            }
            else if (YoneticiPenceresi.HangiPencereAcilacakNo == 2)//listeleme
            {
                this.Text = "MARKA MODEL LİSTE PENCERESİ";
                Pnl_AramaYap.Visible = false;
                Pnl_Silme.Visible = false;
            }
        }
        private void MarkaModelTablosunuCek()
        {
            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLTabloAlanVeriDataGridViewReturn("TblMarkaModel", DbBaglanti.Baglan()).Tables[0];
        }
        private void TabloDuzen()
        {//AotuSizeMode ile fill olarak dolduruldu.
            tablolari_listele_dgv.Columns["ID"].HeaderText = "MARKA MODEL ID";
            tablolari_listele_dgv.Columns["Marka"].HeaderText = "MARKA";
            tablolari_listele_dgv.Columns["Model"].HeaderText = "MODEL";
            tablolari_listele_dgv.Columns["Yil"].HeaderText = "YIL";
        }

        private void BtnTumTablo_Click(object sender, EventArgs e)
        {
            MarkaModelTablosunuCek();
        }

        private void BtnAramaYap_Click(object sender, EventArgs e)
        {
            AlanAdlari.Clear();
            Sartlar.Clear();
            if (CmbKonu.Text == "MARKA")
            {
                AlanAdlari.Add("Marka");
            }
            else if (CmbKonu.Text == "MODEL")
            {
                AlanAdlari.Add("Model");
            }
            Sartlar.Add(TxtKonuIcerigi.Text);
            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLTabloAlanVeriSartDataGridViewSearchReturn(AlanAdlari, "TblMarkaModel", Sartlar, DbBaglanti.Baglan()).Tables[0];
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            AlanAdlari.Clear(); AlanVeri.Clear();
            Sartlar.Clear(); SartVeri.Clear();

            Sartlar.Add("ID");
            SartVeri.Add(tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString());

            if (SQLKutuphanem.SQLTabloAlanVeriSartVeriDeleteReturn("TblMarkaModel", Sartlar, SartVeri, DbBaglanti.Baglan()))
            {
                MesajKutuphanem.MessageKonuBaslikSimge("SİLME İŞLEMİ BAŞARILI", "MARKA MODEL İŞLEMLERİ", "BİLGİ");
                MarkaModelTablosunuCek();
            }
        }
    }
}
