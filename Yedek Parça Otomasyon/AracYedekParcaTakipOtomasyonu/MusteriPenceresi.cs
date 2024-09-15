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
    public partial class MusteriPenceresi : Form
    {
        public MusteriPenceresi()
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
        private void MusteriPenceresi_Load(object sender, EventArgs e)
        {
            TabloGetir();
            TabloDuzen();
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
        public static string Kod, Ad, Kategori, Fiyat, Adet, marka, model, yil, aciklama;
        private void tablolari_listele_dgv_Click(object sender, EventArgs e)
        {
            try
            {
                if (tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString() != "")
                {
                    Kod = tablolari_listele_dgv.CurrentRow.Cells[0].Value.ToString();
                    Ad = tablolari_listele_dgv.CurrentRow.Cells[1].Value.ToString();
                    Kategori = tablolari_listele_dgv.CurrentRow.Cells[2].Value.ToString();
                    Fiyat = tablolari_listele_dgv.CurrentRow.Cells[3].Value.ToString();
                    Adet = tablolari_listele_dgv.CurrentRow.Cells[4].Value.ToString();
                    marka = tablolari_listele_dgv.CurrentRow.Cells[5].Value.ToString();
                    model = tablolari_listele_dgv.CurrentRow.Cells[6].Value.ToString();
                    yil = tablolari_listele_dgv.CurrentRow.Cells[7].Value.ToString();
                    aciklama = tablolari_listele_dgv.CurrentRow.Cells[8].Value.ToString();
                }
            }
            catch (Exception)
            {
                MesajKutuphanem.MessageKonuBaslikSimge("SEÇİLEN BİLGİLEN ALINAMADI...","HATA","HATA");
            }
            
        }

        private void seçiliYedekParcayıAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Kod!="")
            {
                MusteriYedekParcaAl AlimIslemleri = new MusteriYedekParcaAl();
                AlimIslemleri.ShowDialog();
                TabloGetir();
            }
            else
            {
                MesajKutuphanem.MessageKonuBaslikSimge("YEDEK PARÇA SEÇİLMELI", "HATA", "HATA");
            }
        }
        public static bool iptaletmePencere = false;
        private void yedekParcaiptalEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iptaletmePencere=true;
            MusteriYedekIptalAldiklarimListe iptalet = new MusteriYedekIptalAldiklarimListe();
            iptalet.ShowDialog();
            TabloGetir();
            iptaletmePencere=false;
        }

        private void aldiklariminListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iptaletmePencere = false;
            MusteriYedekIptalAldiklarimListe Aldiklarim = new MusteriYedekIptalAldiklarimListe();
            Aldiklarim.ShowDialog();
            TabloGetir();
        }

        private void MusteriPenceresi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
