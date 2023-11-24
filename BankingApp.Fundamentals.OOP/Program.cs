using BankingApp.Fundamentals.OOP;
using BankingApp.Fundamentals.OOP.Accounts;

Account savingsAccount = new SavingsAccount("RO-123456", 1000, Currency.RON);
Account checkingAccount = new CurrentAccount("DE-789012", 500, Currency.EUR);

CurrentAccount testAccount = new CurrentAccount("DE-7890122222", 500, Currency.USD);

savingsAccount.Deposit(4500);
checkingAccount.Withdraw(600);

savingsAccount.DisplayAccountInfo();
checkingAccount.DisplayAccountInfo();
