namespace CryptoSimulation
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1_Encryption = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.şifreleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.şifreÇözToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publicPrİvateKeyOluşturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publicKeyiAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.privateKeyiniAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2_Decryption = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.privateKeyiOkuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.karşıTarafınPublicKeyiniAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManifestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1_Encryption.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2_Decryption.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1_Encryption
            // 
            this.panel1_Encryption.Controls.Add(this.button2);
            this.panel1_Encryption.Controls.Add(this.label2);
            this.panel1_Encryption.Controls.Add(this.comboBox1);
            this.panel1_Encryption.Controls.Add(this.button1);
            this.panel1_Encryption.Controls.Add(this.textBox1);
            this.panel1_Encryption.Controls.Add(this.label1);
            this.panel1_Encryption.Controls.Add(this.menuStrip1);
            this.panel1_Encryption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1_Encryption.Location = new System.Drawing.Point(0, 0);
            this.panel1_Encryption.Name = "panel1_Encryption";
            this.panel1_Encryption.Size = new System.Drawing.Size(508, 190);
            this.panel1_Encryption.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(417, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Uygula";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(22, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Yapmak istediğiniz İşlem :";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(18, 124);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(475, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(455, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 62);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(431, 28);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(22, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Şifrelenecek dosyayı seçiniz :";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.ayarlarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(508, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.şifreleToolStripMenuItem,
            this.şifreÇözToolStripMenuItem});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // şifreleToolStripMenuItem
            // 
            this.şifreleToolStripMenuItem.Name = "şifreleToolStripMenuItem";
            this.şifreleToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.şifreleToolStripMenuItem.Text = "Şifrele";
            this.şifreleToolStripMenuItem.Click += new System.EventHandler(this.şifreleToolStripMenuItem_Click);
            // 
            // şifreÇözToolStripMenuItem
            // 
            this.şifreÇözToolStripMenuItem.Name = "şifreÇözToolStripMenuItem";
            this.şifreÇözToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.şifreÇözToolStripMenuItem.Text = "Şifre Çöz";
            this.şifreÇözToolStripMenuItem.Click += new System.EventHandler(this.şifreÇözToolStripMenuItem_Click);
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.publicPrİvateKeyOluşturToolStripMenuItem,
            this.publicKeyiAlToolStripMenuItem,
            this.privateKeyiniAlToolStripMenuItem});
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.ayarlarToolStripMenuItem.Text = "Ayarlar";
            // 
            // publicPrİvateKeyOluşturToolStripMenuItem
            // 
            this.publicPrİvateKeyOluşturToolStripMenuItem.Name = "publicPrİvateKeyOluşturToolStripMenuItem";
            this.publicPrİvateKeyOluşturToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.publicPrİvateKeyOluşturToolStripMenuItem.Text = "Public/Private Key Oluştur";
            this.publicPrİvateKeyOluşturToolStripMenuItem.Click += new System.EventHandler(this.publicPrİvateKeyOluşturToolStripMenuItem_Click);
            // 
            // publicKeyiAlToolStripMenuItem
            // 
            this.publicKeyiAlToolStripMenuItem.Name = "publicKeyiAlToolStripMenuItem";
            this.publicKeyiAlToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.publicKeyiAlToolStripMenuItem.Text = "Karşı tarafın Public Keyini Al";
            this.publicKeyiAlToolStripMenuItem.Click += new System.EventHandler(this.publicKeyiAlToolStripMenuItem_Click);
            // 
            // privateKeyiniAlToolStripMenuItem
            // 
            this.privateKeyiniAlToolStripMenuItem.Name = "privateKeyiniAlToolStripMenuItem";
            this.privateKeyiniAlToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.privateKeyiniAlToolStripMenuItem.Text = "Private Keyini Al";
            this.privateKeyiniAlToolStripMenuItem.Click += new System.EventHandler(this.privateKeyiniAlToolStripMenuItem_Click);
            // 
            // panel2_Decryption
            // 
            this.panel2_Decryption.Controls.Add(this.button3);
            this.panel2_Decryption.Controls.Add(this.label3);
            this.panel2_Decryption.Controls.Add(this.comboBox2);
            this.panel2_Decryption.Controls.Add(this.button4);
            this.panel2_Decryption.Controls.Add(this.textBox2);
            this.panel2_Decryption.Controls.Add(this.label4);
            this.panel2_Decryption.Controls.Add(this.menuStrip2);
            this.panel2_Decryption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2_Decryption.Location = new System.Drawing.Point(0, 0);
            this.panel2_Decryption.Name = "panel2_Decryption";
            this.panel2_Decryption.Size = new System.Drawing.Size(508, 190);
            this.panel2_Decryption.TabIndex = 1;
            this.panel2_Decryption.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(417, 156);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Uygula";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(22, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Yapmak istediğiniz İşlem :";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(18, 126);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(475, 21);
            this.comboBox2.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(455, 64);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(38, 28);
            this.button4.TabIndex = 10;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(18, 64);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(431, 28);
            this.textBox2.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(22, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Şifreli dosyayı seçiniz :";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem4});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(508, 24);
            this.menuStrip2.TabIndex = 7;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(51, 20);
            this.toolStripMenuItem1.Text = "Dosya";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItem2.Text = "Şifrele";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItem3.Text = "Şifre Çöz";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.privateKeyiOkuToolStripMenuItem,
            this.karşıTarafınPublicKeyiniAlToolStripMenuItem,
            this.ManifestToolStripMenuItem});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(56, 20);
            this.toolStripMenuItem4.Text = "Ayarlar";
            // 
            // privateKeyiOkuToolStripMenuItem
            // 
            this.privateKeyiOkuToolStripMenuItem.Name = "privateKeyiOkuToolStripMenuItem";
            this.privateKeyiOkuToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.privateKeyiOkuToolStripMenuItem.Text = "Private Keyi Al";
            this.privateKeyiOkuToolStripMenuItem.Click += new System.EventHandler(this.privateKeyiOkuToolStripMenuItem_Click);
            // 
            // karşıTarafınPublicKeyiniAlToolStripMenuItem
            // 
            this.karşıTarafınPublicKeyiniAlToolStripMenuItem.Name = "karşıTarafınPublicKeyiniAlToolStripMenuItem";
            this.karşıTarafınPublicKeyiniAlToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.karşıTarafınPublicKeyiniAlToolStripMenuItem.Text = "Karşı Tarafın Public Keyini Al";
            this.karşıTarafınPublicKeyiniAlToolStripMenuItem.Click += new System.EventHandler(this.karşıTarafınPublicKeyiniAlToolStripMenuItem_Click);
            // 
            // ManifestToolStripMenuItem
            // 
            this.ManifestToolStripMenuItem.Name = "ManifestToolStripMenuItem";
            this.ManifestToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.ManifestToolStripMenuItem.Text = "Manifest Dosyasını Al";
            this.ManifestToolStripMenuItem.Click += new System.EventHandler(this.ManifestToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 190);
            this.Controls.Add(this.panel1_Encryption);
            this.Controls.Add(this.panel2_Decryption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifreleyici";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1_Encryption.ResumeLayout(false);
            this.panel1_Encryption.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2_Decryption.ResumeLayout(false);
            this.panel2_Decryption.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1_Encryption;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem şifreleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem şifreÇözToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publicPrİvateKeyOluşturToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2_Decryption;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem privateKeyiOkuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publicKeyiAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManifestToolStripMenuItem;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ToolStripMenuItem privateKeyiniAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem karşıTarafınPublicKeyiniAlToolStripMenuItem;
    }
}

