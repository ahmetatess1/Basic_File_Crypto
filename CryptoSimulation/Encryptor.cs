using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;

namespace CryptoSimulation
{
    public static class Encryptor
    {
        
        // Public ve Private key uretilir 
        public static void GenerateRSAKeyPair(out string publicKey, out string privateKey, out string publicKey2, out string privateKey2)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            RSACryptoServiceProvider rsa1 = new RSACryptoServiceProvider(2048);
            publicKey = rsa.ToXmlString(false);
            privateKey = rsa.ToXmlString(true);
            publicKey2 = rsa1.ToXmlString(false);
            privateKey2 = rsa1.ToXmlString(true);
        }
        // Şifreleme işlemleri yapılır.
        public static string Encrypt(string plainFilePath,
            string encryptedFilePath,
            string manifestFilePath,
            string rsaPrivateKey,
            string rsaPublicKey2,
            int selection)
        {
            
            byte[] encryptionKey = GenerateRandom(32); // Aes şifreleme için random Key üretilir
            byte[] encryptionIV = GenerateRandom(16);  // Aes şifreleme için random IV üretilir


            if (selection == 0)
            {

                byte[] signature = CalculateSignature(plainFilePath);

                return CreateEncryptionXml(signature,rsaPrivateKey, manifestFilePath);
            }
            if (selection == 1)
            {

                EncryptFile(plainFilePath, encryptedFilePath, encryptionKey, encryptionIV);
                return CreateEncryptionXml(encryptionKey, encryptionIV, rsaPublicKey2, manifestFilePath);
            }
            if (selection == 2)
            {

                EncryptFile(plainFilePath, encryptedFilePath, encryptionKey, encryptionIV);

                byte[] signature = CalculateSignature(encryptedFilePath);

                return CreateEncryptionXml(signature,rsaPrivateKey, encryptionKey, encryptionIV, rsaPublicKey2, manifestFilePath);
            }
            return null;
        }
        // Şifre çözme işlemleri yapılır.
        public static bool Decrypt(string filePath,
            string decryptedFilePath,
            string EncryptData,
            string rsaPublicKey,
            string rsaPrivateKey2,
            int selection)
        {
           
            XDocument doc = XDocument.Parse(EncryptData);

            if (selection == 0)
            {
                byte[] signature2 = CalculateSignature(filePath);
                XElement signatureElement = doc.Root.XPathSelectElement("./DataSignature/Value");
              
                if (RSADescryptBytes(Convert.FromBase64String(signatureElement.Value), signature2, rsaPublicKey))
                {
                    return true;
                }
                else
                    return false;
            }
            if (selection == 1)
            {

                XElement aesKeyElement = doc.Root.XPathSelectElement("./DataEncryption/AESEncryptedKeyValue/Key");
                byte[] aesKey = RSADescryptBytes(Convert.FromBase64String(aesKeyElement.Value), rsaPrivateKey2);
                XElement aesIvElement = doc.Root.XPathSelectElement("./DataEncryption/AESEncryptedKeyValue/IV");
                byte[] aesIv = Encryptor.RSADescryptBytes(Convert.FromBase64String(aesIvElement.Value), rsaPrivateKey2);

                DecryptFile(decryptedFilePath, filePath, aesKey, aesIv);

            }
            if (selection == 2)
            {
                XElement aesKeyElement = doc.Root.XPathSelectElement("./DataEncryption/AESEncryptedKeyValue/Key");
                byte[] aesKey = RSADescryptBytes(Convert.FromBase64String(aesKeyElement.Value), rsaPrivateKey2);
                XElement aesIvElement = doc.Root.XPathSelectElement("./DataEncryption/AESEncryptedKeyValue/IV");
                byte[] aesIv = RSADescryptBytes(Convert.FromBase64String(aesIvElement.Value), rsaPrivateKey2);
                XElement signatureElement = doc.Root.XPathSelectElement("./DataSignature/Value");

                byte[] signature2 = CalculateSignature(filePath);
                if (RSADescryptBytes(Convert.FromBase64String(signatureElement.Value), signature2, rsaPublicKey))
                {
                    DecryptFile(decryptedFilePath, filePath, aesKey, aesIv);
                }
                else
                    return false;

            }
            return true;
        }
        // Daha sonra şifreyi çözebilmek için rsa ile şifreli olarak aes key ve sha256 hash bilgilerini dosyaya yazdırır.
        private static string CreateEncryptionXml(byte[] signature, string rsaPrivateKey, string manifestFilePath)
        {
            string template = "<DataInfo>" +
                     "<DataSignature algorithm='SHA256'>" +
                     "<Value />" +
                     "</DataSignature>" +
                     "</DataInfo>";

            XDocument doc = XDocument.Parse(template);
            doc.Descendants("DataSignature").Single().Descendants("Value").Single().Value = System.Convert.ToBase64String(RSAEncryptBytes(signature, rsaPrivateKey,0));
            doc.Save(manifestFilePath);
            return doc.ToString();           
        }
        private static string CreateEncryptionXml(byte[] encryptionKey, byte[] encryptionIV, string rsaPublicKey2, string manifestFilePath)
        {
            string template = "<DataInfo>" +
                "<Encrypted>True</Encrypted>" +
                "<KeyEncryption algorithm='RSA2048'>" +
                "</KeyEncryption>" +
                "<DataEncryption algorithm='AES256'>" +
                "<AESEncryptedKeyValue>" +
                "<Key/>" +
                "<IV/>" +
                "</AESEncryptedKeyValue>" +
                "</DataEncryption>" +
                "</DataInfo>";

            XDocument doc = XDocument.Parse(template);
            doc.Descendants("DataEncryption").Single().Descendants("AESEncryptedKeyValue").Single().Descendants("Key").Single().Value = System.Convert.ToBase64String(RSAEncryptBytes(encryptionKey, rsaPublicKey2,1));
            doc.Descendants("DataEncryption").Single().Descendants("AESEncryptedKeyValue").Single().Descendants("IV").Single().Value = System.Convert.ToBase64String(RSAEncryptBytes(encryptionIV, rsaPublicKey2,1));
            doc.Save(manifestFilePath);
            return doc.ToString();
        }
        private static string CreateEncryptionXml(byte[] signature,string rsaPrivateKey, byte[] encryptionKey, byte[] encryptionIV, string rsaPublicKey2,string manifestFilePath)
        {
            string template = "<DataInfo>" +
                "<Encrypted>True</Encrypted>" +
                "<KeyEncryption algorithm='RSA2048'>" +
                "</KeyEncryption>" +
                "<DataEncryption algorithm='AES256'>" +
                "<AESEncryptedKeyValue>" +
                "<Key/>" +
                "<IV/>" +
                "</AESEncryptedKeyValue>" +
                "</DataEncryption>" +
                "<DataSignature algorithm='SHA256'>" +
                "<Value />" +
                "</DataSignature>" +
                "</DataInfo>";

            XDocument doc = XDocument.Parse(template);
            doc.Descendants("DataEncryption").Single().Descendants("AESEncryptedKeyValue").Single().Descendants("Key").Single().Value = System.Convert.ToBase64String(RSAEncryptBytes(encryptionKey, rsaPublicKey2,1));
            doc.Descendants("DataEncryption").Single().Descendants("AESEncryptedKeyValue").Single().Descendants("IV").Single().Value = System.Convert.ToBase64String(RSAEncryptBytes(encryptionIV, rsaPublicKey2,1));
            doc.Descendants("DataSignature").Single().Descendants("Value").Single().Value = System.Convert.ToBase64String(RSAEncryptBytes(signature, rsaPrivateKey,0));
            doc.Save(manifestFilePath);
            return doc.ToString();
        }
        // random byte olarak anahtar üretmek için
        private static byte[] GenerateRandom(int length)
        {
            byte[] bytes = new byte[length];
            using (RNGCryptoServiceProvider random = new RNGCryptoServiceProvider())
            {
                random.GetBytes(bytes);
            }

            return bytes;
        }
        // Seçilen dosyayı aesle şifreleyip .encrypted olarak çıktı verilen yer
        private static void EncryptFile(string plainFilePath,
            string encryptedFilePath,
            byte[] key,
            byte[] iv)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.KeySize = 256;
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (FileStream plain = File.Open(plainFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (FileStream encrypted = File.Open(encryptedFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        using (CryptoStream cs = new CryptoStream(encrypted, encryptor, CryptoStreamMode.Write))
                        {
                            plain.CopyTo(cs);
                        }
                    }
                }
            }
        }
        // seçilen dosyanın aesle şifrenin çözüldüğü ve .decrypted olarak çıktı verilen yer
        public static void DecryptFile(string filePath, string decryptedFilePath, byte[] key, byte[] iv)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.KeySize = 256;
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (FileStream plain = File.Open(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (FileStream encrypted = File.Open(decryptedFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (CryptoStream cs = new CryptoStream(plain, decryptor, CryptoStreamMode.Write))
                        {
                            encrypted.CopyTo(cs);
                        }
                    }
                }
            }
        }
        //Aes keylerin rsa ile şifrelendiği yer ve dosyanın doğru kullanıcıdan geldiğini doğrulamak için hashli dosyanın private keyle şifrelendiği yer.
        public static byte[] RSAEncryptBytes(byte[] datas, string keyXml,int select)
        {
            byte[] encrypted = null;
            if (select == 1)
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
                {
                        rsa.FromXmlString(keyXml);
                        encrypted = rsa.Encrypt(datas, true);               
                }
            }
            else if (select == 0)
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
                {
                    rsa.FromXmlString(keyXml);
                    RSAPKCS1SignatureFormatter rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                    rsaFormatter.SetHashAlgorithm("SHA256");
                    encrypted = rsaFormatter.CreateSignature(datas);
                }
            }

            return encrypted;
        }
        //aes keylerinin rsa şifresinin çözüldüğü bölüm
        public static byte[] RSADescryptBytes(byte[] datas, string keyXml)
        {
            byte[] decrypted = null;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(keyXml);
                decrypted = rsa.Decrypt(datas, true);
            }

            return decrypted;
        }
        // hashlenmiş bilgilerin rsa public key ile belirlenen kullanıcıdan geldiğinin kontrolu
        public static Boolean RSADescryptBytes(byte[] datas, byte[] datas2, string keyXml)
        {
            Boolean check=false;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(keyXml);
                RSAPKCS1SignatureDeformatter rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
                rsaDeformatter.SetHashAlgorithm("SHA256");
                check = rsaDeformatter.VerifySignature(datas2, datas);
            }

            return check;
        }
        // dosyanın hashının alındığı yer.s
        private static byte[] CalculateSignature(string filePath)
        {
            byte[] sig = null;
            using (SHA256 sha = new SHA256Managed())
            {
                using (FileStream f = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    sig = sha.ComputeHash(f);
                }
            }

            return sig;
        }

    }
}
