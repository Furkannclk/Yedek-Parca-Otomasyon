using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracYedekParcaTakipOtomasyonu
{
    public partial class YoneticiPenceresi : Form
    {
        public YoneticiPenceresi()
        {
            InitializeComponent();
        }

        private void ithalatFirmaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IthalatKayitPencere Ekle = new IthalatKayitPencere();
            Ekle.ShowDialog();
        }

         
         
        public static byte HangiPencereAcilacakNo = 0;
        public static bool Duzenleme = false;
        private void ithalatFirmasiAramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ithalatAramaArsivlemeListeleme AramaYap = new ithalatAramaArsivlemeListeleme();
            HangiPencereAcilacakNo = 0;
            AramaYap.ShowDialog();
        }

        private void ithalatFirmaArsivleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ithalatAramaArsivlemeListeleme Arsivle = new ithalatAramaArsivlemeListeleme();
            HangiPencereAcilacakNo = 1;
            Arsivle.ShowDialog();
        }

        private void ithalatFirmaListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ithalatAramaArsivlemeListeleme FirmaListesi = new ithalatAramaArsivlemeListeleme();
            HangiPencereAcilacakNo = 2;
            FirmaListesi.ShowDialog();
        }

        private void markaModelEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkaModelPenceresi Kayit = new MarkaModelPenceresi();
            Kayit.ShowDialog();
        }

        private void markaModelAramaYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            MarkaModelAramaSilmeListeleme AramaYap = new MarkaModelAramaSilmeListeleme();
            HangiPencereAcilacakNo = 0;
            AramaYap.ShowDialog();

        }

        private void markaModelSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            MarkaModelAramaSilmeListeleme AramaYap = new MarkaModelAramaSilmeListeleme();
            HangiPencereAcilacakNo = 1;
            AramaYap.ShowDialog();
        }

        private void markaModelListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            MarkaModelAramaSilmeListeleme AramaYap = new MarkaModelAramaSilmeListeleme();
            HangiPencereAcilacakNo = 2;
            AramaYap.ShowDialog();
        }

        private void ithalatFirmaDuzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Duzenleme = true;
            IthalatKayitPencere Duzenle = new IthalatKayitPencere();
            Duzenle.ShowDialog();
            Duzenleme = false;
        }

        private void markaModelAramaDuzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Duzenleme = true;
            MarkaModelPenceresi Duzenle = new MarkaModelPenceresi();
            Duzenle.ShowDialog();
            Duzenleme = false;
        }

        private void musteriAramaYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            MusteriAramaBanlaListele MusteriAramaYap = new MusteriAramaBanlaListele();
            HangiPencereAcilacakNo = 0;
            MusteriAramaYap.ShowDialog();
        }

        private void musteriBanlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            MusteriAramaBanlaListele MusteriAramaYap = new MusteriAramaBanlaListele();
            HangiPencereAcilacakNo = 1;
            MusteriAramaYap.ShowDialog();
        }

        private void musteriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusteriAramaBanlaListele MusteriAramaYap = new MusteriAramaBanlaListele();
            HangiPencereAcilacakNo = 2;
            MusteriAramaYap.ShowDialog();
        }

        public static Byte ListeIslemHangiPencere;
        private void ithalatFirmaArşivListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListeIslemPenceresi ArsivListe = new ListeIslemPenceresi();
            ListeIslemHangiPencere = 0;
            ArsivListe.ShowDialog();
        }

        private void hesapKapatanMüşteriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListeIslemPenceresi ArsivListe = new ListeIslemPenceresi();
            ListeIslemHangiPencere = 1;
            ArsivListe.ShowDialog();
        }

        private void banlananMusteriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListeIslemPenceresi ArsivListe = new ListeIslemPenceresi();
            ListeIslemHangiPencere = 2;
            ArsivListe.ShowDialog();
        }

        private void yedekParcaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YedekParcaEkleDuzenlePenceresi YPEkle = new YedekParcaEkleDuzenlePenceresi();
            YPEkle.ShowDialog();
            TabloGetir();
        }

        private void yedekParcaAramaYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YedekParcaAramaArsivleListe AramaYap=new YedekParcaAramaArsivleListe();
            HangiPencereAcilacakNo = 0;
            AramaYap.ShowDialog();
            TabloGetir();
        }

        private void yedekParcaArsivleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YedekParcaAramaArsivleListe Arsivle = new YedekParcaAramaArsivleListe();
            HangiPencereAcilacakNo = 1;
            Arsivle.ShowDialog();
            TabloGetir();
        }

        ConnectionClassString DbBaglanti = new ConnectionClassString();
        SqlProcess SQLKutuphanem = new SqlProcess();
        MessageClass MesajKutuphanem = new MessageClass();
        private void YoneticiPenceresi_Load(object sender, EventArgs e)
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

        private void yedekParcaArsivListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ListeIslemPenceresi ArsivListe = new ListeIslemPenceresi();
            ListeIslemHangiPencere = 3;
            ArsivListe.ShowDialog();
            TabloGetir();
        }

        private void yedekalidParcaListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YedekParcaAlisListesi ac = new YedekParcaAlisListesi();
            ac.ShowDialog();
            TabloGetir();
        }
        public static bool YedekParcaDuzen;
        private void yedekParcaDuzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YedekParcaDuzen = true;
            YedekParcaEkleDuzenlePenceresi Duzenle = new YedekParcaEkleDuzenlePenceresi();
            Duzenle.ShowDialog();
            YedekParcaDuzen = false;
            TabloGetir();
        }

        private void YoneticiPenceresi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
