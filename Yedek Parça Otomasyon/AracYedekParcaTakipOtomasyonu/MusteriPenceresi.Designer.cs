namespace AracYedekParcaTakipOtomasyonu
{
    partial class MusteriPenceresi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.seçiliYedekParcayıAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yedekParcaiptalEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aldiklariminListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablolari_listele_dgv = new System.Windows.Forms.DataGridView();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablolari_listele_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.RoyalBlue;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seçiliYedekParcayıAlToolStripMenuItem,
            this.yedekParcaiptalEtToolStripMenuItem,
            this.aldiklariminListesiToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(921, 24);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // seçiliYedekParcayıAlToolStripMenuItem
            // 
            this.seçiliYedekParcayıAlToolStripMenuItem.Name = "seçiliYedekParcayıAlToolStripMenuItem";
            this.seçiliYedekParcayıAlToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.seçiliYedekParcayıAlToolStripMenuItem.Text = "Seçili Yedek Parçayı Al";
            this.seçiliYedekParcayıAlToolStripMenuItem.Click += new System.EventHandler(this.seçiliYedekParcayıAlToolStripMenuItem_Click);
            // 
            // yedekParcaiptalEtToolStripMenuItem
            // 
            this.yedekParcaiptalEtToolStripMenuItem.Name = "yedekParcaiptalEtToolStripMenuItem";
            this.yedekParcaiptalEtToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.yedekParcaiptalEtToolStripMenuItem.Text = "Yedek Parça İptal Et";
            this.yedekParcaiptalEtToolStripMenuItem.Click += new System.EventHandler(this.yedekParcaiptalEtToolStripMenuItem_Click);
            // 
            // aldiklariminListesiToolStripMenuItem
            // 
            this.aldiklariminListesiToolStripMenuItem.Name = "aldiklariminListesiToolStripMenuItem";
            this.aldiklariminListesiToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.aldiklariminListesiToolStripMenuItem.Text = "Aldiklarimin Listesi";
            this.aldiklariminListesiToolStripMenuItem.Click += new System.EventHandler(this.aldiklariminListesiToolStripMenuItem_Click);
            // 
            // tablolari_listele_dgv
            // 
            this.tablolari_listele_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablolari_listele_dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablolari_listele_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablolari_listele_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablolari_listele_dgv.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablolari_listele_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.tablolari_listele_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablolari_listele_dgv.Location = new System.Drawing.Point(0, 24);
            this.tablolari_listele_dgv.Name = "tablolari_listele_dgv";
            this.tablolari_listele_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablolari_listele_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tablolari_listele_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablolari_listele_dgv.Size = new System.Drawing.Size(921, 424);
            this.tablolari_listele_dgv.TabIndex = 40;
            this.tablolari_listele_dgv.Click += new System.EventHandler(this.tablolari_listele_dgv_Click);
            // 
            // MusteriPenceresi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(921, 448);
            this.Controls.Add(this.tablolari_listele_dgv);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "MusteriPenceresi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ÜYE PENCERESİ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MusteriPenceresi_FormClosing);
            this.Load += new System.EventHandler(this.MusteriPenceresi_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablolari_listele_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem seçiliYedekParcayıAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yedekParcaiptalEtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aldiklariminListesiToolStripMenuItem;
        private System.Windows.Forms.DataGridView tablolari_listele_dgv;
    }
}