using BankingApp.Fundamentals.OOP.Exceptions;
using System.Text;

namespace BankingApp.Fundamentals.OOP.Accounts
{
    public class CurrentAccount : Account
    {

        public StringBuilder accountTransactions = new StringBuilder();
        public CurrentAccount(string accountNumber, double initialBalance, Currency currency) : base(accountNumber, initialBalance, currency) { }
        
        public override void Deposit(double amount)
        {
            balance += amount;
            //add amount in balance 
            //create new transaction 
            Transaction transaction = new Transaction(this,Category.deposit,amount);
            accountTransactions.Append("S-a facut o tranzactie " + transaction.AccountNumber.ToString());
        }

        public override void Withdraw(double amount)
        {   try
            {
              if (balance - amount >= 0)
              {
                balance -= amount;
                // minus ammount in balance  
                //create a transaction
                Transaction transaction = new Transaction(this,Category.widraw, amount);
                accountTransactions.Append("S-a facut o tranzactie " + transaction.AccountNumber.ToString());
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
