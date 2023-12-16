using Autofac;
using BankingApp.Fundamentals.OOP;
using BankingApp.Fundamentals.OOP.Accounts;
using BankingApp.Fundamentals.OOP.Credit;
using BankingApp.Fundamentals.OOP.Entities;
using BankingApp.Fundamentals.OOP.Enums;
using BankingApp.Fundamentals.OOP.Report;

var container = AutofacConfig.ConfigureContainer();
using (var scope = container.BeginLifetimeScope())
{
    IReporter reporter = scope.Resolve<IReporter>();
    ICreditService creditService = scope.Resolve<ICreditService>();
    
    User user1 = new User("Dragos");

    Account account = new CurrentAccount("3245132",5000,Currency.RON);
    user1.Accounts.Add(account);

    CreditAccount creditAccount = new CreditAccount(2000, CreditCategory.PersonalLoan);
    user1.CreditAccounts.Add(creditAccount);

    account.Withdraw(100);
    account.Withdraw(500);
    account.Deposit(600);
    account.Deposit(5000);
    account.Withdraw(5300);
    account.Deposit(150);
    
    reporter.DisplayCreditInformation(user1);

    reporter.DisplayAllTransactions(user1);
    
    reporter.DisplayTransactionsAmountLowerThan(user1);
    reporter.DisplayTransactionsForSpecificCategory(Category.Widraw, user1);
    reporter.DisplayTransactionWithAmountBetweenARange(100, 400, user1);
    reporter.DisplayTransactionsForSpecificDatePeriod(DateTime.Now.Add(new TimeSpan(-1, 0, 0)), DateTime.Now.Add(new TimeSpan(1, 0, 0)),user1);
    
}