using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoSimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String encryptPath = Application.StartupPath + "\\Encryption";
        String decryptPath = Application.StartupPath + "\\Decryption";
        String publicPrivateKeyPath = Application.StartupPath + "\\Keypair";
        private void Form1_Load(object sender, EventArgs e)
        {
            if(!Directory.Exists(encryptPath))
                Directory.CreateDirectory(encryptPath);
            if (!Directory.Exists(decryptPath))
                Directory.CreateDirectory(decryptPath);
            if (!Directory.Exists(publicPrivateKeyPath))
                Directory.CreateDirectory(publicPrivateKeyPath);

            comboBox1.Items.Add("Sadece İmzala");
            comboBox1.Items.Add("Sadece Şifrele");
            comboBox1.Items.Add("Şifrele ve İmzala");
            comboBox2.Items.Add("İmzayı Kontrol Et");
            comboBox2.Items.Add("Şifreyi Çöz");
            comboBox2.Items.Add("İmzayı Kontrol Et ve Şifreyi Çöz");
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
        private string publicKey, publicKey2;
        private string privateKey, privateKey2;

        // Şifrelemek istediğimiz dosyayı seçtiğimiz bölüm
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.RestoreDirectory = true;
                file.Filter = "Tüm Dosyalar |*.*";
                file.Title = "Şifrelemek istediğiniz dosyayı seçiniz..";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = file.FileName;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Bir hata oluştu !");
            }
        }
        String EncryptData;
        // şifrelemenin yapıldığı kısım:
        /*AES256 bit ile şifreleme yapılıp Rsa2048 ile aes keyi şifrelenmiştir.
          İmzalamak için rsa2048 ve dosyanın hashı sha256 ile alınmıştır.*/
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Dosya seçmelisiniz..");
                    return;
                }
                if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 2)
                    if (string.IsNullOrEmpty(privateKey))
                    {
                        MessageBox.Show("İmzalamak için Private Key Girmelisiniz.");
                        return;
                    }
                if (!(comboBox1.SelectedIndex == 0))
                    if (string.IsNullOrEmpty(publicKey2))
                    {
                        MessageBox.Show("Şifrelemek için Karşı tarafın Public Keyini Girmelisiniz.");
                        return;
                    }
                string filePath = textBox1.Text;
                string encryptedFileName = Path.GetFileNameWithoutExtension(filePath) + ".encrypted";                
                string encryptedFilePath = Path.Combine(encryptPath, encryptedFileName);
                string manifestFileName = Path.GetFileNameWithoutExtension(filePath) + ".manifest.xml";
                string manifestFilePath = Path.Combine(encryptPath, manifestFileName);

                EncryptData =Encryptor.Encrypt(filePath,encryptedFilePath, manifestFilePath, this.privateKey, this.publicKey2, comboBox1.SelectedIndex);
                MessageBox.Show("İşlem Başarılı");
            }
            catch (System.Security.Cryptography.CryptographicException EX)
            {
                MessageBox.Show("Hatalı bir key girdiniz.");
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu !");
            }
        }
        // deşifrelemenin yapıldığı kısım
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Dosya seçmelisiniz..");
                    return;
                }
                if (!(comboBox2.SelectedIndex == 0))
                    if (string.IsNullOrEmpty(privateKey2))
                    {
                        MessageBox.Show("Şifreyi çözmek için Private Key Girmelisiniz..");
                        return;
                    }
                if (string.IsNullOrEmpty(EncryptData))
                {
                    MessageBox.Show("Manifest dosyasını Girmelisiniz..");
                    return;
                }
                if (comboBox2.SelectedIndex == 0 || comboBox2.SelectedIndex == 2)
                    if (string.IsNullOrEmpty(publicKey))
                    {
                        MessageBox.Show("İmzalayı doğrulamak için karşı tarafın Public Keyini Girmelisiniz.");
                        return;
                    }
                string filePath = textBox2.Text;

                string decryptedFileName = Path.GetFileNameWithoutExtension(filePath) + ".decrypted";
                string decryptedFilePath = Path.Combine(decryptPath, decryptedFileName);

                Boolean check = Encryptor.Decrypt(filePath, decryptedFilePath, EncryptData, this.publicKey, this.privateKey2, comboBox2.SelectedIndex);
                if (comboBox2.SelectedIndex == 0)
                    if (check)
                    {
                        MessageBox.Show("İmza doğrulandı");
                    }
                    else
                    {
                        MessageBox.Show("İmza doğrulanamadı!");
                    }
                if (comboBox2.SelectedIndex == 1)
                    if (check)
                    {
                        MessageBox.Show("Şifre başarılı bir şekilde çözüldü");
                    }
                    else
                    {
                        MessageBox.Show("Şifre Çözülemedi!");
                    }
                if (comboBox2.SelectedIndex == 2)
                    if (check)
                    {
                        MessageBox.Show("İmza doğrulandı ve şifre çözüldü");
                    }
                    else
                    {
                        MessageBox.Show("İmza doğrulanamadı veya girilen key hatalı !");
                    }
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                MessageBox.Show("Hatalı bir key girdiniz.");
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu !");
            }
        }
        // public keyi dışarıdan okumak için
        private void publicKeyiAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
                OpenFileDialog file = new OpenFileDialog();
                file.RestoreDirectory = true;
                file.Filter = "Xml (*.xml)|*.xml";
                file.Title = "Public key dosyasini seçiniz..";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = File.OpenText(file.FileName))
                    {
                        this.publicKey2 = sr.ReadToEnd();
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Bir hata oluştu !");
            }

}
        // public ve private keylerin oluşturduğu kısım
        private void publicPrİvateKeyOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                string publicKeyPath = System.IO.Path.Combine(publicPrivateKeyPath, "publicKey.xml");
                string privateKeyPath = System.IO.Path.Combine(publicPrivateKeyPath, "privateKey.xml");
                string publicKeyPath2 = System.IO.Path.Combine(publicPrivateKeyPath, "publicKey2.xml");
                string privateKeyPath2 = System.IO.Path.Combine(publicPrivateKeyPath, "privateKey2.xml");

                string publicKey, publicKey2;
                string privateKey, privateKey2;
                Encryptor.GenerateRSAKeyPair(out publicKey, out privateKey, out publicKey2, out privateKey2);
                this.publicKey = publicKey;
                this.privateKey = privateKey;
                this.publicKey2 = publicKey2;
                this.privateKey2 = privateKey2;

                using (StreamWriter sw = File.CreateText(publicKeyPath))
                {
                    sw.Write(publicKey);
                }

                using (StreamWriter sw = File.CreateText(privateKeyPath))
                {
                    sw.Write(privateKey);
                }
                using (StreamWriter sw = File.CreateText(publicKeyPath2))
                {
                    sw.Write(publicKey2);
                }

                using (StreamWriter sw = File.CreateText(privateKeyPath2))
                {
                    sw.Write(privateKey2);
                }

        }
        // Şifresini çözmek istediğimiz dosyayı seçtiğimiz bölüm
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.RestoreDirectory = true;
                file.Filter = "Şifreli Dosya (*.encrypted)|*.encrypted|Tüm Dosyalar |*.*";
                file.Title = "Şifrelemek istediğiniz dosyayı seçiniz..";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = file.FileName;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Bir hata oluştu !");
            }
        }
        
        private void şifreleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1_Encryption.Visible = true;
            panel2_Decryption.Visible = false;
            this.Text = "Şifreleyici";
        }

        private void şifreÇözToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1_Encryption.Visible = false;
            panel2_Decryption.Visible = true;
            this.Text = "Şifre Çözücü";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panel1_Encryption.Visible = true;
            panel2_Decryption.Visible = false;
            this.Text = "Şifreleyici";
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            panel1_Encryption.Visible = false;
            panel2_Decryption.Visible = true;
            this.Text = "Şifre Çözücü";
        }
        // private keyi dışarıdan okumak için
        private void privateKeyiniAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.RestoreDirectory = true;
                file.Filter = "Xml (*.xml)|*.xml";
                file.Title = "Private key dosyasini seçiniz..";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = File.OpenText(file.FileName))
                    {
                        this.privateKey = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu !");
            }
        }
        // public keyi dışarıdan okumak için
        private void karşıTarafınPublicKeyiniAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.RestoreDirectory = true;
                file.Filter = "Xml (*.xml)|*.xml";
                file.Title = "Public key dosyasini seçiniz..";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = File.OpenText(file.FileName))
                    {
                        this.publicKey = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu !");
            }
        }
        // private keyi dışarıdan okumak için
        private void privateKeyiOkuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.RestoreDirectory = true;
                file.Filter = "Xml (*.xml)|*.xml";
                file.Title = "Private key dosyasini seçiniz..";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = File.OpenText(file.FileName))
                    {
                        this.privateKey2 = sr.ReadToEnd();
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Bir hata oluştu !");
            }
        }
        // Daha sonra şifreyi çözebilmek için manifest dosyasının okunduğu kısım
        private void ManifestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
                OpenFileDialog file = new OpenFileDialog();
                file.RestoreDirectory = true;
                file.Filter = "Xml (*.xml)|*.xml";
                file.Title = "Manifest dosyasini seçiniz..";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = File.OpenText(file.FileName))
                    {
                        this.EncryptData = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu !");
            }
        }
    }
}
