using Newtonsoft.Json;
using System;
using System.Threading;

namespace BankIntegrationMiniApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Authorization in Base 64 String == long.Parse(DateTime.Today.ToString("yyyyMMdd")); 
            //Signature String of Encrypted SHa256 == System.Text.Encoding.UTF8.GetBytes(model.originatorInstitutionCode);
            //SerialIze payload 
            //Payload Encrypted with the right Encryption 
            //Iv Key
            //Secret Key


            ///What do you want to do intor question
            ///Get Authorization 1
            ///Get Signature 2
            ///Encrypt Payload
            ///Decrypt Payload
            ///Iv Key
            ///Secret Key
            ///

            //Initialize Classes

            var Decryption = new DecryptPayload();
            var Encrypt = new EncryptPayLoad();
            var Authorization = new Authorization();
            var Signature = new Signature();


            Console.WriteLine("Welcome to Bank Integration App\nSelect any Options to  handle the needed Task.\n");
            while (true)
            {

                Console.WriteLine("\nPress 1 for Authorization\nPress 2 for Signature\nPress 3 to Encrypt Payload\nPress 4 to Decrypt Paload\nPress 5 for Complex-Biller-Authorization\nPress 6 for complex-Biller-Signature\nPress 7 for Sample Payload\nPress 8 to Close App\nEnter Selection : ");
                var selection = Console.ReadLine();
                var input = Convert.ToInt32(selection);
            
                if (input == 1)
                {
                    //Collect Originator Institution Code and pass to method
                    Console.WriteLine("Enter Originator Institution Code : ");
                    var originatorInstitutionCode = Console.ReadLine();
                    if (originatorInstitutionCode != null)
                    {
                        Console.WriteLine($"\nAuthorization String = {Authorization.GetBase64AuthorizationString(originatorInstitutionCode)}");

                    }
                    else
                    {
                        Console.WriteLine("Kindly fill in the complete details.");
                    }
                }
                else if (input == 2)
                {
                    //collect originator institution code + signature date string + secret key and pass to method to get result
                    Console.WriteLine("Enter Originator Institution Code : ");
                    var originatorInstitutionCode = Console.ReadLine();
                    Console.WriteLine("Enter Secret Key : ");
                    var secret = Console.ReadLine();
                    if (originatorInstitutionCode != null && secret != null)
                    {
                        Console.WriteLine($"\nSignature String = {Signature.GetSignatureString(originatorInstitutionCode, secret)}\n");
                    }
                    else
                    {
                        Console.WriteLine("Kindly fill in the complete details.");
                    }
                }
                else if (input == 3)
                {
                    //Collect Payload as string and pass along with other details [Secret and Iv Key] to Encrypt
                    Console.WriteLine("Enter Payload : ");
                    var Payload = Console.ReadLine();
                    Console.WriteLine("Enter Secret Key : ");
                    var secret = Console.ReadLine();
                    Console.WriteLine("Enter IV Key : ");
                    var IvKey = Console.ReadLine();
                    if (Payload != null && secret != null & IvKey != null)
                    {
                        Console.WriteLine($"\nEncrypted Payload = {Encrypt.EncryptBankPayload(Payload, secret, IvKey)}\n");
                    }
                    else
                    {
                        Console.WriteLine("\nKindly fill in the complete details.");
                    }

                }
                else if (input == 4)
                {
                    Console.WriteLine("Enter Encrypted Payload : ");
                    var Payload = Console.ReadLine();
                    Console.WriteLine("Enter Secret Key : ");
                    var secret = Console.ReadLine();
                    Console.WriteLine("Enter IV Key : ");
                    var IvKey = Console.ReadLine();
                    if (Payload != null && secret != null & IvKey != null)
                    {
                        Console.WriteLine($"\nDecrypted Payload = {Decryption.Decrypt(Payload, secret, IvKey)}\n");
                    }
                    else
                    {
                        Console.WriteLine("\nKindly fill in the complete details.\n");
                    }
                }
                else if(input == 5)
                {
                    ComplexBillerDetails.ComplexBillerAuthorization();
                }
                else if(input == 6)
                {
                    ComplexBillerDetails.ComplexBillerSignature();
                }
                else if (input == 7)
                {
                    var model = new BankPayload()
                    {
                        bankApi = "bankApi",
                        amount = "Amount",
                        beneficiaryAccountName = "beneficiaryAccountName",
                        beneficiaryAccountNumber = "beneficiaryAccountNumber",
                        beneficiaryBankVerificationNumber = "beneficiaryBankVerificationNumber",
                        beneficiaryKYCLevel = "beneficiaryKYCLevel",
                        channelCode = "channelCode",
                        destinationInstitutionCode = "destinationInstitutionCode",
                        nameEnquiryRef = "nameEnquiryRef",
                        narration = "narration",
                        originatorAccountName = "originatorAccountName",
                        originatorAccountNumber = "originatorAccountNumber",
                        originatorBankVerificationNumber = "originatorBankVerificationNumber",
                        originatorInstitutionCode = "originatorInstitutionCode",
                        originatorKYCLevel = "originatorKYCLevel",
                        sessionID = "sessionID",
                        responseCode = "responseCode",
                        fee = "fee"
                    };

                    var payLoad = JsonConvert.SerializeObject(model);
                    Console.WriteLine($"\nSmaple PayLoad = {payLoad}\n");
                }
                else if (input == 8)
                {
                    Console.WriteLine("\nApp Shutting Down .........");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Enter a Valid Selection .");
                }

            }
        }
    }
}
