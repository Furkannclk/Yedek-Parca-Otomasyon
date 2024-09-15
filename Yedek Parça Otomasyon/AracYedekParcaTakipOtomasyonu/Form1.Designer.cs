
namespace AracYedekParcaTakipOtomasyonu
{
    partial class GirisPenceresi
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisPenceresi));
            this.kapat_pb = new System.Windows.Forms.PictureBox();
            this.giris_fotograf_pb = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CmbDurum = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnCikisYap = new System.Windows.Forms.Button();
            this.BtnUyeOl = new System.Windows.Forms.Button();
            this.kullanici_adi_pb = new System.Windows.Forms.PictureBox();
            this.TxbKullaniciAd = new System.Windows.Forms.TextBox();
            this.BtnGirisYap = new System.Windows.Forms.Button();
            this.TxtParola = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.parola_pb = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kapat_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giris_fotograf_pb)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kullanici_adi_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parola_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // kapat_pb
            // 
            this.kapat_pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kapat_pb.Image = ((System.Drawing.Image)(resources.GetObject("kapat_pb.Image")));
            this.kapat_pb.Location = new System.Drawing.Point(447, 3);
            this.kapat_pb.Name = "kapat_pb";
            this.kapat_pb.Size = new System.Drawing.Size(37, 28);
            this.kapat_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.kapat_pb.TabIndex = 25;
            this.kapat_pb.TabStop = false;
            this.kapat_pb.Click += new System.EventHandler(this.kapat_pb_Click);
            // 
            // giris_fotograf_pb
            // 
            this.giris_fotograf_pb.Dock = System.Windows.Forms.DockStyle.Top;
            this.giris_fotograf_pb.Image = ((System.Drawing.Image)(resources.GetObject("giris_fotograf_pb.Image")));
            this.giris_fotograf_pb.Location = new System.Drawing.Point(0, 0);
            this.giris_fotograf_pb.Name = "giris_fotograf_pb";
            this.giris_fotograf_pb.Size = new System.Drawing.Size(487, 298);
            this.giris_fotograf_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.giris_fotograf_pb.TabIndex = 24;
            this.giris_fotograf_pb.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CmbDurum);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.BtnCikisYap);
            this.groupBox1.Controls.Add(this.BtnUyeOl);
            this.groupBox1.Controls.Add(this.kullanici_adi_pb);
            this.groupBox1.Controls.Add(this.TxbKullaniciAd);
            this.groupBox1.Controls.Add(this.BtnGirisYap);
            this.groupBox1.Controls.Add(this.TxtParola);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.parola_pb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(15, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 201);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giriş Penceresi";
            // 
            // CmbDurum
            // 
            this.CmbDurum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.CmbDurum.FormattingEnabled = true;
            this.CmbDurum.Items.AddRange(new object[] {
            "\tÜYE GİRİŞ İŞLEMİ",
            "\tYÖNETİCİ GİRİŞ İŞLEMİ"});
            this.CmbDurum.Location = new System.Drawing.Point(176, 26);
            this.CmbDurum.Name = "CmbDurum";
            this.CmbDurum.Size = new System.Drawing.Size(269, 26);
            this.CmbDurum.TabIndex = 38;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(53, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 18);
            this.label4.TabIndex = 37;
            this.label4.Text = "Durum:";
            // 
            // BtnCikisYap
            // 
            this.BtnCikisYap.BackColor = System.Drawing.Color.White;
            this.BtnCikisYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCikisYap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCikisYap.Location = new System.Drawing.Point(176, 152);
            this.BtnCikisYap.Name = "BtnCikisYap";
            this.BtnCikisYap.Size = new System.Drawing.Size(269, 28);
            this.BtnCikisYap.TabIndex = 34;
            this.BtnCikisYap.Text = "Çıkış Yap";
            this.BtnCikisYap.UseVisualStyleBackColor = false;
            this.BtnCikisYap.Click += new System.EventHandler(this.BtnCikisYap_Click);
            // 
            // BtnUyeOl
            // 
            this.BtnUyeOl.BackColor = System.Drawing.Color.White;
            this.BtnUyeOl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUyeOl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnUyeOl.Location = new System.Drawing.Point(15, 152);
            this.BtnUyeOl.Name = "BtnUyeOl";
            this.BtnUyeOl.Size = new System.Drawing.Size(155, 28);
            this.BtnUyeOl.TabIndex = 35;
            this.BtnUyeOl.Text = "Üye Ol";
            this.BtnUyeOl.UseVisualStyleBackColor = false;
            this.BtnUyeOl.Click += new System.EventHandler(this.BtnUyeOl_Click);
            // 
            // kullanici_adi_pb
            // 
            this.kullanici_adi_pb.Image = ((System.Drawing.Image)(resources.GetObject("kullanici_adi_pb.Image")));
            this.kullanici_adi_pb.Location = new System.Drawing.Point(15, 58);
            this.kullanici_adi_pb.Name = "kullanici_adi_pb";
            this.kullanici_adi_pb.Size = new System.Drawing.Size(32, 24);
            this.kullanici_adi_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.kullanici_adi_pb.TabIndex = 29;
            this.kullanici_adi_pb.TabStop = false;
            // 
            // TxbKullaniciAd
            // 
            this.TxbKullaniciAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxbKullaniciAd.Location = new System.Drawing.Point(176, 58);
            this.TxbKullaniciAd.Name = "TxbKullaniciAd";
            this.TxbKullaniciAd.Size = new System.Drawing.Size(269, 24);
            this.TxbKullaniciAd.TabIndex = 27;
            this.TxbKullaniciAd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnGirisYap
            // 
            this.BtnGirisYap.BackColor = System.Drawing.Color.White;
            this.BtnGirisYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGirisYap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGirisYap.Location = new System.Drawing.Point(176, 118);
            this.BtnGirisYap.Name = "BtnGirisYap";
            this.BtnGirisYap.Size = new System.Drawing.Size(269, 28);
            this.BtnGirisYap.TabIndex = 33;
            this.BtnGirisYap.Text = "Giriş Yap";
            this.BtnGirisYap.UseVisualStyleBackColor = false;
            this.BtnGirisYap.Click += new System.EventHandler(this.BtnGirisYap_Click);
            // 
            // TxtParola
            // 
            this.TxtParola.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtParola.Location = new System.Drawing.Point(176, 88);
            this.TxtParola.Name = "TxtParola";
            this.TxtParola.Size = new System.Drawing.Size(269, 24);
            this.TxtParola.TabIndex = 28;
            this.TxtParola.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(53, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 32;
            this.label3.Text = "Parola:";
            // 
            // parola_pb
            // 
            this.parola_pb.Image = ((System.Drawing.Image)(resources.GetObject("parola_pb.Image")));
            this.parola_pb.Location = new System.Drawing.Point(15, 88);
            this.parola_pb.Name = "parola_pb";
            this.parola_pb.Size = new System.Drawing.Size(32, 24);
            this.parola_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.parola_pb.TabIndex = 30;
            this.parola_pb.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(53, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 18);
            this.label2.TabIndex = 31;
            this.label2.Text = "Kullanıcı Adı(T.C):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-4, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 24);
            this.label1.TabIndex = 28;
            this.label1.Text = "YEDEK PARÇA TAKİP SİSTEMİ";
            // 
            // GirisPenceresi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(487, 524);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kapat_pb);
            this.Controls.Add(this.giris_fotograf_pb);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GirisPenceresi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.GirisPenceresi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kapat_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giris_fotograf_pb)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kullanici_adi_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parola_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox kapat_pb;
        private System.Windows.Forms.PictureBox giris_fotograf_pb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbDurum;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnCikisYap;
        private System.Windows.Forms.Button BtnUyeOl;
        private System.Windows.Forms.PictureBox kullanici_adi_pb;
        private System.Windows.Forms.TextBox TxbKullaniciAd;
        private System.Windows.Forms.Button BtnGirisYap;
        private System.Windows.Forms.TextBox TxtParola;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox parola_pb;
        private System.Windows.Forms.Label label2;
    }
}

