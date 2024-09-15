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

namespace AracYedekParcaTakipOtomasyonu
{
    public partial class YedekParcaAlisListesi : Form
    {
        public YedekParcaAlisListesi()
        {
            InitializeComponent();
        }
        ConnectionClassString DbBaglanti = new ConnectionClassString();
        SqlProcess SQLKutuphanem = new SqlProcess();
        private void YedekParcaAlisListesi_Load(object sender, EventArgs e)
        {
            AlisTabloCek();
            TabloDuzen();
        }
        private void AlisTabloCek()
        {
            tablolari_listele_dgv.DataSource = SQLKutuphanem.SQLKodDataGridViewReturn("exec AlisListesiBilgi", DbBaglanti.Baglan()).Tables[0];
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
        }
    }
}
