using BankingApp.Fundamentals.OOP.Accounts;
using BankingApp.Fundamentals.OOP.Credit;
using BankingApp.Fundamentals.OOP.Entities;
using BankingApp.Fundamentals.OOP.Enums;
using System;
using System.Security.Principal;
using System.Text;

namespace BankingApp.Fundamentals.OOP.Report
{
    public class Reporter : IReporter
    {
        private readonly ICreditService _creditService;
        public Reporter(ICreditService creditService)
        {
            _creditService = creditService; 
        }
        public void DisplayCreditInformation(User user ) 
        { 
            List<CreditAccountDetails> creditDetails = _creditService.GetCreditDetails(user); 
            foreach(CreditAccountDetails creditDetail in creditDetails)
            {
                Console.WriteLine($"Credit details : {creditDetail.Details} \n");
            }
        }

        public void GenerateReport(CurrentAccount account)
        {

            List<Transaction> transactions = account.transactionList;
            foreach(Transaction transaction in transactions)
            {
                Console.WriteLine($"Account transactions: {transaction.Id} \n");
            }
        }
        public void GenerateReportPerCategories(CurrentAccount account)
        {
            List<Transaction> transactions = account.transactionList;
            foreach (Transaction transaction in transactions)
            {
                if(transaction.Category == Category.Deposit)
                {
                    Console.WriteLine($"A Deposit transaction :{transaction.Id}");
                }else if(transaction.Category == Category.Widraw)
                {
                    Console.WriteLine($"A Widraw transaction : {transaction.Id}");
                }
            }
        }
        //1. Get all transactions for a specific user

        public void GetAllTransactions(User user)
        {

        }
        //2. Get transactions for a specific user and category
        public void GetTransactionsForSpecificCategory(Category category,User user)
        { 

        }
        //3. Get transactions for s specific date(start date, end date)
        public void GetTransactionsForSpecificDate(DateTime startDate ,DateTime endDate)
        {

        }
        //4. Get transactions which amount is lower than 1000 (currency)
        public void GetTransactionsAmountLowerThan(User user)
        {

        }
        //5. Get transactions which amount is between a specific range.
        public void GetTransactionWithAmountBetweenARange(double minimum,double maximum)
        {

        }
    }
}
