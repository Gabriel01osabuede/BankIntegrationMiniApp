using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BankIntegrationMiniApp
{
    public class Signature
    {
        public static DateTime CurrentDate { get; set; } = DateTime.Today;
        
        public static string GetSignatureString(string originatorInstitutionCode, string Secret)
        {
            var signatureDateFormat = long.Parse(CurrentDate.ToString("yyyyMMdd"));

            var signatureString = ComputeSha256Hash(originatorInstitutionCode + signatureDateFormat.ToString() + Secret);

            return signatureString;
        }


        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
