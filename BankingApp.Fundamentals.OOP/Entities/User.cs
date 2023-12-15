using BankingApp.Fundamentals.OOP.Accounts;

namespace BankingApp.Fundamentals.OOP.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string CreditIds = "";
        public string Credits = "";
        public List<CreditAccount> CreditAccounts { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Transaction> Transactions { get; set; }
        public User( string userName ) 
        { 
            UserId = Guid.NewGuid();
            UserName = userName;
        }
    }
}
