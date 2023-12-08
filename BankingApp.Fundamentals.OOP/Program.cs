﻿using Autofac;
using BankingApp.Fundamentals.OOP;
using BankingApp.Fundamentals.OOP.Credit;
using BankingApp.Fundamentals.OOP.Entityes;
using BankingApp.Fundamentals.OOP.Enums;
using BankingApp.Fundamentals.OOP.Report;

var container = AutofacConfig.ConfigureContainer();
using (var scope = container.BeginLifetimeScope())
{
    var reporter = scope.Resolve<IReporter>();
    var creditService = scope.Resolve<ICreditService>();
    
    User user = new User("Dragos");
    User user2 = new User("Daniel");

    CreditAccount creditAccount = new CreditAccount(2000,CreditCategory.PersonalLoan);
    CreditAccount creditAccount2 = new CreditAccount(5000, CreditCategory.HomeLoan);

    creditService.AssignCredit(user, creditAccount);
    creditService.AssignCredit(user, creditAccount2);


    CreditAccount creditAccount3 = new CreditAccount(7000, CreditCategory.PersonalLoan);
    CreditAccount creditAccount4 = new CreditAccount(1000, CreditCategory.HomeLoan);

    creditService.AssignCredit(user2, creditAccount3);
    creditService.AssignCredit(user2, creditAccount4);
    

    reporter.DisplayCreditInformation(user);
    reporter.DisplayCreditInformation(user2);
}