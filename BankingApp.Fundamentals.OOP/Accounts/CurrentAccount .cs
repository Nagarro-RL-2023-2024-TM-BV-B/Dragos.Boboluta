using BankingApp.Fundamentals.OOP.Exceptions;
using System.Text;

namespace BankingApp.Fundamentals.OOP.Accounts
{
    public class CurrentAccount : Account
    {

        public string accountTransactions = "" ;
        public CurrentAccount(string accountNumber, double initialBalance, Currency currency) : base(accountNumber, initialBalance, currency) { }
        
        public override void Deposit(double amount)
        {
            balance += amount;
            //add amount in balance 
            //create new transaction 
            Transaction transaction = new Transaction(this,Category.deposit,amount);
            accountTransactions += $"A transaction of type :{transaction.Category} , amount of {transaction.Amount} in account : {transaction.AccountNumber.ToString()} in date :{transaction.DateTime}\n";
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
                accountTransactions += $"A transaction of type :{transaction.Category} , amount of {transaction.Amount} in account : {transaction.AccountNumber.ToString()} in date :{transaction.DateTime}\n";
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
