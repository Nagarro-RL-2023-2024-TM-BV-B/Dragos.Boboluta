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
            if (!AccountNumberValidator.Validate(accountNumber))
            {
                throw new AccountNumberException();
            }

            this.accountNumber = accountNumber;
            this.balance = initialBalance;
            this.currency = currency;
        }

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void DisplayAccountInfo();
    }
}
