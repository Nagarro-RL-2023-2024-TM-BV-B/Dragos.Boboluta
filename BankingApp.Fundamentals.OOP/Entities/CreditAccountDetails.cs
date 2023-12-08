using BankingApp.Fundamentals.OOP.Enums;
using System.Text.RegularExpressions;

namespace BankingApp.Fundamentals.OOP.Entityes
{
    public class CreditAccountDetails
    {
        public string Details = "";
        public DateTime Date { get; set; }
        public string Category = "";
        public CreditAccountDetails(CreditCategory category , double amount) 
        {
            Date = DateTime.Now;
            Category = Regex.Replace(category.ToString(), "([a-z])([A-Z])", "$1 $2").ToLower();
            Details = "In "+ Date + " was made a credit of type "+ Category + " and amount of "+amount.ToString()+"\n";
        }
    }
}
