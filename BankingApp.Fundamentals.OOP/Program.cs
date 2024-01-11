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
    
    User user1 = new User("Dragos");
    Account account = new CurrentAccount("3245132",5000,Currency.RON);
    Account account2 = new CurrentAccount("1245132", 7000, Currency.RON);
    CreditAccount creditAccount = new CreditAccount(2000, CreditCategory.PersonalLoan);
    DateTime startDate = DateTime.Now.AddDays(-1);
    DateTime endDate = DateTime.Now.AddDays(1);

   // user1.Accounts.Add(account);
   // user1.Accounts.Add(account2);
   // user1.CreditAccounts.Add(creditAccount);

    account.Withdraw(100);
    account.Withdraw(500);
    account.Deposit(600);
    account.Deposit(5000);
    account.Withdraw(5300);
    account.Deposit(150);
    account2.Withdraw(99);
    account2.Deposit(150);

    /* reporter.DisplayCreditInformation(user1);
    reporter.DisplayAllTransactions(user1);
    reporter.DisplayTransactionsAmountLowerThan(user1);
    reporter.DisplayTransactionsForSpecificCategory(Category.Widraw, user1);
    reporter.DisplayTransactionWithAmountBetweenARange(100, 400, user1);
    reporter.DisplayTransactionsForSpecificDatePeriod(startDate,endDate,user1);
    */
    var userFile = "User.json";
    var raportFile = "Raports.json";
    var creditAccountFile = "CreditAccount.json";
    var currentAccountFile = "CurrentAccount.json";


    try
    {
        using FileStream userStream = File.OpenRead(userFile);
        using FileStream creditAccountStream = File.OpenRead(creditAccountFile);
        using FileStream currentAccountStream = File.OpenRead(currentAccountFile);
       // using FileStream raportStream = File.OpenWrite(raportFile);


        UserDataModel userDeserialized = await JsonSerializer.DeserializeAsync<UserDataModel>(userStream);
        CreditAccountDataModel creditAccountDeserialized = await JsonSerializer.DeserializeAsync<CreditAccountDataModel>(creditAccountStream);
        AccountDataModel currentAccount = await JsonSerializer.DeserializeAsync<AccountDataModel>(currentAccountStream);

        User test = new User(userDeserialized.UserName); //creez userul 

        Account testAccount = new CurrentAccount(currentAccount.AccountNumber, currentAccount.InitialBalance, currentAccount.Currency);
            test.Accounts.Add(testAccount);

            testAccount.Withdraw(100);
            testAccount.Withdraw(500);
            testAccount.Deposit(600);

           var report =  reporter.DisplayAllTransactions(test);

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Eroare la citirea din fișier: {ex.Message}");
    }
}