using BankingApp.Fundamentals.OOP.Enums;

namespace BankingApp.Fundamentals.OOP.Entityes
{
    public class CreditAccountDetails
    {
        public string Details = " ";
        public  DateTime Date { get; set; }
        public CreditAccountDetails(  CreditCategory category , double amount) {
            Date = DateTime.Now;
            Details = "In "+ Date + " was made a credit of type "+ category.ToString()+" and amount of "+amount.ToString()+"\n";
        }
    }
}
