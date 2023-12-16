using BankingApp.Fundamentals.OOP.Entities;
using BankingApp.Fundamentals.OOP.Enums;
using BankingApp.Fundamentals.OOP.Exceptions;

namespace BankingApp.Fundamentals.OOP.Accounts
{
    public class CurrentAccount : Account
    {
        public string accountTransactions = "" ;
        public List<Transaction> transactionList = new List<Transaction>();
        public CurrentAccount(string accountNumber, double initialBalance, Currency currency) : base(accountNumber, initialBalance, currency) {}
        
        public override void Deposit(double amount )
        {
            balance += amount;
            Transaction transaction = new Transaction(this,Category.Deposit,amount);
            transactionList.Add(transaction);
        }

        public override void Withdraw(double amount)
        {   try
            {
              if (balance - amount >= 0)
              {
                balance -= amount;
                Transaction transaction = new Transaction(this,Category.Widraw, amount);
                transactionList.Add(transaction);
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
