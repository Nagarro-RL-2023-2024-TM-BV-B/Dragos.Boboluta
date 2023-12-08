using BankingApp.Fundamentals.OOP.Enums;
using BankingApp.Fundamentals.OOP.Exceptions;

namespace BankingApp.Fundamentals.OOP.Accounts
{
    public abstract class Account
    {
        private readonly string accountNumber;
        protected double balance;
        protected Currency currency;

        public string AccountNumber => accountNumber;
        public double Balance => balance;
        public Currency Currency => currency;

        public Account(string accountNumber, double initialBalance, Currency currency)
        {
            try
            {
                if (!AccountNumberValidator.Validate(accountNumber))
                {
                    throw new AccountNumberException();
                }

                this.accountNumber = accountNumber;
                this.balance = initialBalance;
                this.currency = currency;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void DisplayAccountInfo();
    }
}
