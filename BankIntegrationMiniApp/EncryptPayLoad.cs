using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BankIntegrationMiniApp
{
    public class EncryptPayLoad
    {
        public string EncryptBankPayload(string model,string secret, string IvKey)
        {
            //var payload = JsonConvert.SerializeObject(model);

            var data = Encrypt(model, secret, IvKey);
            
            return data;
        }



        private static string Encrypt(string plaintext, string secretkey, string iv)
        {
            using (Aes myAes = Aes.Create())
            {
                myAes.Key = Encoding.UTF8.GetBytes(secretkey);
                myAes.IV = Encoding.UTF8.GetBytes(iv);
                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes_Aes(plaintext, myAes.Key,
                myAes.IV);
                string ciphertext = ByteArrayToString(encrypted);
                return ciphertext;
            }
        }


        private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key,
       byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key,
                aesAlg.IV);
                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt,
                    encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        private static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
