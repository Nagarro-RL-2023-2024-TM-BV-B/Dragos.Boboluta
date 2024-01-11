using Autofac;
using BankingApp.Fundamentals.OOP;
using BankingApp.Fundamentals.OOP.Accounts;
using BankingApp.Fundamentals.OOP.Credit;
using BankingApp.Fundamentals.OOP.Entities;
using BankingApp.Fundamentals.OOP.Entities.DataModels;
using BankingApp.Fundamentals.OOP.Enums;
using BankingApp.Fundamentals.OOP.Report;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

var container = AutofacConfig.ConfigureContainer();
using (var scope = container.BeginLifetimeScope())
{
    IReporter reporter = scope.Resolve<IReporter>();
    ICreditService creditService = scope.Resolve<ICreditService>();
    
  
    DateTime startDate = DateTime.Now.AddDays(-1);
    DateTime endDate = DateTime.Now.AddDays(1);

    var userFile = "User.json";
    var raportFile = "Raports.json";
    var creditAccountFile = "CreditAccount.json";
    var currentAccountFile = "CurrentAccount.json";


    try
    {
        using FileStream userStream = File.OpenRead(userFile);
        using FileStream creditAccountStream = File.OpenRead(creditAccountFile);
        using FileStream currentAccountStream = File.OpenRead(currentAccountFile);

        UserDataModel userDeserialized = await JsonSerializer.DeserializeAsync<UserDataModel>(userStream);
        CreditAccountDataModel creditAccountDeserialized = await JsonSerializer.DeserializeAsync<CreditAccountDataModel>(creditAccountStream);
        AccountDataModel currentAccount = await JsonSerializer.DeserializeAsync<AccountDataModel>(currentAccountStream);

        User test = new User(userDeserialized.UserName);  

        Account testAccount = new CurrentAccount(currentAccount.AccountNumber, currentAccount.InitialBalance, currentAccount.Currency);
            test.Accounts.Add(testAccount);

            testAccount.Withdraw(100);
            testAccount.Withdraw(500);
            testAccount.Deposit(600);

        reporter.DisplayTransactionsForSpecificCategory(Category.Widraw, test);
        reporter.DisplayAllTransactions(test);
        reporter.DisplayTransactionsAmountLowerThan(test);
        reporter.DisplayTransactionsForSpecificCategory(Category.Widraw, test);
        reporter.DisplayTransactionWithAmountBetweenARange(100, 400, test);
        reporter.DisplayTransactionsForSpecificDatePeriod(startDate, endDate, test);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Eroare la citirea din fișier: {ex.Message}");
    }
   
}