using BankingApp.Fundamentals.OOP.Exceptions;

namespace BankingApp.Fundamentals.OOP.Accounts
{
    public class CurrentAccount : Account
    {
        public CurrentAccount(string accountNumber, double initialBalance, Currency currency) : base(accountNumber, initialBalance, currency) { }

        public override void Deposit(double amount)
        {
            balance += amount;
        }

        public override void Withdraw(double amount)
        {   try
            {
              if (balance - amount >= 0)
              {
                balance -= amount;
              }
              else
              {
                throw new InsufficientFundsException();
              }
            }
            catch 
            {
              Console.WriteLine("Withdrawal failed: Insufficient funds.");
            }
        }

        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Checking Account - Account Number: {AccountNumber}, Balance: {balance} {Currency}");
        }
    }
}
