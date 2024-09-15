namespace AracYedekParcaTakipOtomasyonu
{
    partial class MusteriYedekParcaAl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblBilgi = new System.Windows.Forms.Label();
            this.Pnl_Banla = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Btn_iptalEt = new System.Windows.Forms.Button();
            this.BtnYedekAl = new System.Windows.Forms.Button();
            this.NUPAdet = new System.Windows.Forms.NumericUpDown();
            this.TblFiyat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Pnl_Banla.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUPAdet)).BeginInit();
            this.SuspendLayout();
            // 
            // LblBilgi
            // 
            this.LblBilgi.AutoSize = true;
            this.LblBilgi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblBilgi.Location = new System.Drawing.Point(12, 9);
            this.LblBilgi.Name = "LblBilgi";
            this.LblBilgi.Size = new System.Drawing.Size(17, 20);
            this.LblBilgi.TabIndex = 0;
            this.LblBilgi.Text = "x";
            // 
            // Pnl_Banla
            // 
            this.Pnl_Banla.Controls.Add(this.panel4);
            this.Pnl_Banla.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Pnl_Banla.Location = new System.Drawing.Point(0, 310);
            this.Pnl_Banla.Margin = new System.Windows.Forms.Padding(4);
            this.Pnl_Banla.Name = "Pnl_Banla";
            this.Pnl_Banla.Size = new System.Drawing.Size(460, 54);
            this.Pnl_Banla.TabIndex = 37;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Btn_iptalEt);
            this.panel4.Controls.Add(this.BtnYedekAl);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(56, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(404, 54);
            this.panel4.TabIndex = 73;
            // 
            // Btn_iptalEt
            // 
            this.Btn_iptalEt.BackColor = System.Drawing.Color.White;
            this.Btn_iptalEt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Btn_iptalEt.Location = new System.Drawing.Point(3, 9);
            this.Btn_iptalEt.Name = "Btn_iptalEt";
            this.Btn_iptalEt.Size = new System.Drawing.Size(137, 37);
            this.Btn_iptalEt.TabIndex = 17;
            this.Btn_iptalEt.Text = "İptal Et";
            this.Btn_iptalEt.UseVisualStyleBackColor = false;
            // 
            // BtnYedekAl
            // 
            this.BtnYedekAl.BackColor = System.Drawing.Color.White;
            this.BtnYedekAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnYedekAl.Location = new System.Drawing.Point(146, 9);
            this.BtnYedekAl.Name = "BtnYedekAl";
            this.BtnYedekAl.Size = new System.Drawing.Size(246, 37);
            this.BtnYedekAl.TabIndex = 16;
            this.BtnYedekAl.Text = "Yedek Parça Al";
            this.BtnYedekAl.UseVisualStyleBackColor = false;
            this.BtnYedekAl.Click += new System.EventHandler(this.BtnYedekAl_Click);
            // 
            // NUPAdet
            // 
            this.NUPAdet.Location = new System.Drawing.Point(164, 274);
            this.NUPAdet.Name = "NUPAdet";
            this.NUPAdet.Size = new System.Drawing.Size(130, 24);
            this.NUPAdet.TabIndex = 38;
            this.NUPAdet.ValueChanged += new System.EventHandler(this.NUPAdet_ValueChanged);
            // 
            // TblFiyat
            // 
            this.TblFiyat.Location = new System.Drawing.Point(318, 274);
            this.TblFiyat.Name = "TblFiyat";
            this.TblFiyat.Size = new System.Drawing.Size(130, 24);
            this.TblFiyat.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 18);
            this.label2.TabIndex = 40;
            this.label2.Text = "ALINAN ADET/FİYAT:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 18);
            this.label3.TabIndex = 41;
            this.label3.Text = "/";
            // 
            // MusteriYedekParcaAl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 364);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TblFiyat);
            this.Controls.Add(this.NUPAdet);
            this.Controls.Add(this.Pnl_Banla);
            this.Controls.Add(this.LblBilgi);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MusteriYedekParcaAl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yedek Parça Alma Penceresi";
            this.Load += new System.EventHandler(this.MusteriYedekParcaAl_Load);
            this.Pnl_Banla.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUPAdet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblBilgi;
        private System.Windows.Forms.Panel Pnl_Banla;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button Btn_iptalEt;
        private System.Windows.Forms.Button BtnYedekAl;
        private System.Windows.Forms.NumericUpDown NUPAdet;
        private System.Windows.Forms.TextBox TblFiyat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}