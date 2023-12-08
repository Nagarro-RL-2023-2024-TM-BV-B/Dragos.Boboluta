using BankingApp.Fundamentals.OOP.Enums;

namespace BankingApp.Fundamentals.OOP.Entityes
{
    public class CreditAccountDetails
    {

        public string Details = " ";
        public CreditAccountDetails( string details , CreditCategory category , double amount) {
            
            Details = "Credit de tip "+category.ToString()+" cu suma de  "+ amount.ToString();
        }
    }
}
