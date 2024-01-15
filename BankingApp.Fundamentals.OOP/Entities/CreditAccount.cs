using BankingApp.Fundamentals.OOP.Credit;
using BankingApp.Fundamentals.OOP.Enums;
using System;
using System.Text.Json.Serialization;

namespace BankingApp.Fundamentals.OOP.Entities
{
    
    public class CreditAccount
    {
        public Guid CreditId { get; set; }
        public Guid AccountId { get; set; }
        public double CreditAmount { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CreditCategory CreditType { get; set; }
        public CreditAccountDetails CreditDetails;

        public CreditAccount(){}
        public CreditAccount( double creditAmount , CreditCategory category ) 
        {
                    CreditAmount = creditAmount;
                    CreditType = category;
                    CreditId = Guid.NewGuid();
                    CreditDetails = new CreditAccountDetails(CreditType, creditAmount);
;        }
    }
}
