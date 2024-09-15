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
    public partial class MusteriYedekIptalAldiklarimListe : Form
    {
        public MusteriYedekIptalAldiklarimListe()
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
        SqlCommand Komut;
        private void MusteriYedekIptalAldiklarimListe_Load(object sender, EventArgs e)
        {
            TabloGetir();
            TabloDuzen();
            if (MusteriPenceresi.iptaletmePencere==false)
            {
                this.Text = "YEDEK PARÇA ALDIKLARIM";
                Pnl_Arsivleme.Visible = false;
            }
        }
        private void TabloGetir()
        {
            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLKodDataGridViewReturn("execute MusteriAldiklarim", DbBaglanti.Baglan()).Tables[0];
        }
        private void TabloDuzen()
        {
            tablolari_listele_dgv.Columns["YedekParcaKod"].HeaderText = "YEDEK PARÇA KOD";
            tablolari_listele_dgv.Columns["YedekParcaAd"].HeaderText = "YEDEK PARÇA AD";
            tablolari_listele_dgv.Columns["YedekParcaSatisFiyat"].HeaderText = "SATIŞ FİYAT";
            tablolari_listele_dgv.Columns["alis_adet"].HeaderText = "ALINANA ADET";
            tablolari_listele_dgv.Columns["toplam_fiyat"].HeaderText = "ÖDENEN TOPLAM ÜCRET";
        }

        private void Btniptalet_Click(object sender, EventArgs e)
        {
            Komut = new SqlCommand("Update TblYedekParca set YedekParcaAdet=YedekParcaAdet+@P1 ,Arsiv=1 where YedekParcaKod=@P2", DbBaglanti.Baglan());
            Komut.Parameters.Add("@P1",tablolari_listele_dgv.CurrentRow.Cells[4].Value.ToString());
            Komut.Parameters.Add("@P2", tablolari_listele_dgv.CurrentRow.Cells[1].Value.ToString());
            Komut.ExecuteNonQuery();

            AlanAdlari.Clear(); AlanVeri.Clear();
            Sartlar.Clear(); SartVeri.Clear();

            Sartlar.Add("ID");
            SartVeri.Add(tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString());

            if (SQLKutuphanem.SQLTabloAlanVeriSartVeriDeleteReturn("MusteriYedekParcaListesi", Sartlar, SartVeri, DbBaglanti.Baglan()))
            {
                MesajKutuphanem.MessageKonuBaslikSimge("İPTAL İŞLEMİ BAŞARILI", "İPTAL İŞLEMLERİ", "BİLGİ");
                TabloGetir();
            }


        }

        private void Btn_iptalEt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
