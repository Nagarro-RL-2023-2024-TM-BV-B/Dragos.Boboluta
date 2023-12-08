using BankingApp.Fundamentals.OOP.Credit;
using BankingApp.Fundamentals.OOP.Enums;

namespace BankingApp.Fundamentals.OOP.Entityes
{
    public class CreditAccount
    {
        public Guid CreditId { get; set; }
        public Guid AccountId { get; set; }
        public double CreditAmount { get; set; }
        public CreditCategory CreditType { get; set; }
        public CreditAccountDetails CreditDetails;
        public CreditAccount( double creditAmount , CreditCategory category ) 
        {
            CreditAmount = creditAmount;
            CreditType = category;
            CreditId = Guid.NewGuid();
            CreditDetails = new CreditAccountDetails(CreditType ,creditAmount);
;        }
    }
}
