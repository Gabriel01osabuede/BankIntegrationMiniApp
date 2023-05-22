using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BankIntegrationMiniApp
{
    public class ComplexBillerDetails
    {
        public static void ComplexBillerAuthorization()
        {
            Console.WriteLine("Kindly your Biller name.");
            var billerName = Console.ReadLine();
            if (billerName == null)
            {
                Console.WriteLine("Input cannot be null.");
            }
            
            var authorizationBytes = Encoding.UTF8.GetBytes(billerName);
            var authorization = Convert.ToBase64String(authorizationBytes);

            Console.WriteLine(authorization);
        }

        public static void ComplexBillerSignature()
        {
            Console.WriteLine("Enter your secret key.");
            var secretKey = Console.ReadLine();
            if (secretKey == null)
            {
                Console.WriteLine("Input cannot be emppty");
            }

            var signatureDateFormat = long.Parse(DateTime.Today.ToString("yyyyMMdd"));
            Console.WriteLine(signatureDateFormat.ToString() + secretKey);
            var signatureString = ComputeSha256HashTool(signatureDateFormat.ToString() + secretKey);
            Console.WriteLine(signatureString);
        }


        public static string ComputeSha256HashTool(string rawData)
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

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
