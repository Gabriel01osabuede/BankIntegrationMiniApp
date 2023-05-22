using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankIntegrationMiniApp
{
    public class BankPayload
    {
        public string bankApi { get; set; }
        public string amount { get; set; }
        public string beneficiaryAccountName { get; set; }
        public string beneficiaryAccountNumber { get; set; }
        public string beneficiaryBankVerificationNumber { get; set; }
        public string beneficiaryKYCLevel { get; set; }
        public string channelCode { get; set; }
        public string destinationInstitutionCode { get; set; }
        public string nameEnquiryRef { get; set; }
        public string narration { get; set; }
        public string originatorAccountName { get; set; }
        public string originatorAccountNumber { get; set; }
        public string originatorBankVerificationNumber { get; set; }
        public string originatorInstitutionCode { get; set; }
        public string originatorKYCLevel { get; set; }
        public string sessionID { get; set; }
        public string responseCode { get; set; }
        public string fee { get; set; }

        //IVKey and Secret
        public string IVKey { get; set; }
        public string Secret { get; set; }
    }
}
