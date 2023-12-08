using BankingApp.Fundamentals.OOP.Accounts;
using BankingApp.Fundamentals.OOP.Enums;
using BankingApp.Fundamentals.OOP.Report;

Account savingsAccount = new SavingsAccount("RO-123456", 1000, Currency.RON);
Account checkingAccount = new CurrentAccount("DE-789012", 500, Currency.EUR);

CurrentAccount testAccount = new CurrentAccount("DE-789012", 0, Currency.USD);

testAccount.Deposit(5000);
testAccount.Withdraw(100);
testAccount.Withdraw(200);

ReportCreator report = new ReportCreator();

report.GenerateReport(testAccount);
report.GenerateReportPerCategories(testAccount);
