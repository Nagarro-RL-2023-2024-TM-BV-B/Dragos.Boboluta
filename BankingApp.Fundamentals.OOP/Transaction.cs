using BankingApp.Fundamentals.OOP.Accounts;

namespace BankingApp.Fundamentals.OOP
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public DateTime DateTime { get; set; }
        public Category Category { get; set; } 
        public double Amount { get; set; }
        
        public Transaction(Account account, Category category, double amount)
        {
            Id = Guid.NewGuid();
            AccountNumber = account.AccountNumber;
            Category = category;
            Amount = amount;
            DateTime = DateTime.Now;
        }
    }
}
