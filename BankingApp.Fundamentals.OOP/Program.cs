using Autofac;
using BankingApp.Fundamentals.OOP;
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
    User user2 = new User("Daniel");

    CreditAccount creditAccount = new CreditAccount(2000,CreditCategory.PersonalLoan);
    CreditAccount creditAccount2 = new CreditAccount(5000, CreditCategory.HomeLoan);

    creditService.AssignCredit(user1, creditAccount);
    creditService.AssignCredit(user1, creditAccount2);

    CreditAccount creditAccount3 = new CreditAccount(7000, CreditCategory.PersonalLoan);
    CreditAccount creditAccount4 = new CreditAccount(1000, CreditCategory.HomeLoan);
    CreditAccount creditAccount5 = new CreditAccount(500, CreditCategory.AutoLoan);
    CreditAccount creditAccount6 = new CreditAccount(6000, CreditCategory.BusinessLoan);

    creditService.AssignCredit(user2, creditAccount3);
    creditService.AssignCredit(user2, creditAccount4);
    creditService.AssignCredit(user2, creditAccount5);
    creditService.AssignCredit(user2, creditAccount6);

    reporter.DisplayCreditInformation(user1);
    reporter.DisplayCreditInformation(user2);
}