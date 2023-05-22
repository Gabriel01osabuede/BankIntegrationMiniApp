using System;
using System.Collections.Generic;
using System.Text;

namespace BankIntegrationMiniApp
{
    public class Authorization
    {
        public static string GetBase64AuthorizationString(string OriginatorInstitutionCode)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(OriginatorInstitutionCode);

            var authorization = Convert.ToBase64String(plainTextBytes);

            return authorization;
        }
    }
}
