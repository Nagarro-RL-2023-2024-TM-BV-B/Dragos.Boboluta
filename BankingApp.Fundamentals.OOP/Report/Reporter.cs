using BankingApp.Fundamentals.OOP.Accounts;
using BankingApp.Fundamentals.OOP.Credit;
using BankingApp.Fundamentals.OOP.Entities;
using System.IO;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace BankingApp.Fundamentals.OOP.Report
{
    public class Reporter : IReporter
    {
        private  string raportFile = "Raports.json";
 
        private readonly ICreditService _creditService;
        public  StringBuilder StringBuilder = new StringBuilder();
        public Reporter(ICreditService creditService)
        {
            _creditService = creditService; 
        }
        public void DisplayCreditInformation(User user )
        {
            try
            {
                using (StreamWriter raportWriter = new StreamWriter(raportFile))
                {
                    List<CreditAccountDetails> creditDetails = _creditService.GetCreditDetails(user);
                    if (creditDetails.Count == 0) throw new Exception($"User {user.UserName} doesn't have any credits until now  ");
                    foreach (CreditAccountDetails creditDetail in creditDetails)
                    {
                        string text = $"Credit details : {creditDetail.Details} ";
                        raportWriter.WriteLine(text);
                        Console.WriteLine(text);
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
        }
        private List<Transaction> GetAllTransactions(User user)
        {
            List<Transaction> transactions = new List<Transaction>();

            foreach (CurrentAccount account in user.Accounts)
            {
                foreach (Transaction transaction in account.transactionList)
                {
                    transactions.Add(transaction);
                }
            }
            return transactions;
        }

        public void  DisplayAllTransactions(User user)
        {
            try
            {
                using (StreamWriter raportWriter = new StreamWriter(raportFile))
                {
                    List<Transaction> transactions = GetAllTransactions(user);
                    if (transactions.Count == 0) throw new Exception($"User {user.UserName} doesn't have any transactions until now  ");
                    Console.WriteLine($"Transactions for user {user.UserName} are : ");
                    raportWriter.WriteLine($"Transactions for user {user.UserName} are : ");
                    string text = "";
                    foreach (Transaction transaction in transactions)
                    {
                        text = $" A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime} ;";
                        Console.WriteLine($" => {text}");
                        raportWriter.WriteLine(text); 
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void DisplayTransactionsForSpecificCategory(Category category,User user)
        {
            try 
            {
                using (StreamWriter raportWriter = new StreamWriter(raportFile))
                {
                    List<Transaction> transactions = GetAllTransactions(user);
                    if (transactions.Count == 0) throw new Exception($"User {user.UserName} doesn't have any transactions until now  ");
                    Console.WriteLine($"Transactions of type {category} for user {user.UserName} are : ");
                    raportWriter.WriteLine($"Transactions of type {category} for user {user.UserName} are : ");
                    List<Transaction> filtredTransactions = transactions.Where(x => x.Category == category).ToList();
                    string text = "";

                    if (filtredTransactions.Count > 0)
                    {

                        foreach (Transaction transaction in filtredTransactions)
                        {
                            text = $" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime}   ";
                            raportWriter.WriteLine(text);
                            Console.WriteLine(text);
                        }
                    }

                    else
                    {
                        Console.WriteLine($" User {user.UserName} doesn'n have any transactions of type {category}  ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

          
        }
        public void DisplayTransactionsForSpecificDatePeriod(DateTime startDate ,DateTime endDate,User user)
        {
            try
            {
                if (startDate >= endDate) throw new Exception($"Invalid date period , please enter a valid start and end date  ");
                List<Transaction> transactions = GetAllTransactions(user);
                if (transactions.Count == 0) throw new Exception($"User {user.UserName} doesn't have any transactions until now  ");

                List<Transaction> filtredTransactions = transactions.Where(x => x.DateTime >= startDate && x.DateTime <= endDate).ToList();
                string text = "";
                using (StreamWriter raportWriter = new StreamWriter(raportFile))
                {
                    Console.WriteLine($"Transactions  for user {user.UserName} made between {startDate.ToShortDateString()} and {endDate.ToShortDateString()} are  : ");
                    raportWriter.WriteLine($"Transactions  for user {user.UserName} made between {startDate.ToShortDateString()} and {endDate.ToShortDateString()} are  : ");
                    if (filtredTransactions.Count > 0)
                    {
                        foreach (Transaction transaction in filtredTransactions)
                        {
                            text = $" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime}   ";
                            Console.WriteLine(text);
                            raportWriter.WriteLine(text);
                        }
                    }
                    else
                    {
                        Console.WriteLine($" User {user.UserName} doesn'n have any transactions made between {startDate} and {endDate}  ");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
        public void DisplayTransactionsAmountLowerThan(User user)
        {
            try
            {
                List<Transaction> transactions = GetAllTransactions(user);
                if (transactions.Count == 0) throw new Exception($"User {user.UserName} doesn't have any transactions until now  ");

                foreach (CurrentAccount account in user.Accounts)
                {
                    foreach (Transaction transaction in account.transactionList)
                    {
                        transactions.Add(transaction);
                    }
                }
                List<Transaction> filtredTransactions = transactions.Where(x => x.Amount < 1000).ToList();
                string text = "";
                using (StreamWriter raportWriter = new StreamWriter(raportFile))
                {
                    Console.WriteLine($"Transactions  for user {user.UserName} with amount less than 1000 are  :  ");
                    raportWriter.WriteLine($"Transactions  for user {user.UserName} with amount less than 1000 are  :  ");

                    if (transactions.Count > 0)
                    {
                        foreach (Transaction transaction in filtredTransactions)
                        {
                            text = $" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime}   ";
                            Console.WriteLine(text);
                            raportWriter.WriteLine(text);
                        }
                    }
                    else
                    {
                        Console.WriteLine($" User {user.UserName} doesn'n have any transactions with amount lower than 1000  ");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           
        }
        public void DisplayTransactionWithAmountBetweenARange(double minimum,double maximum,User user)
        {
            try
            {
                if (minimum >= maximum) throw new Exception(" Invalid amount range , please enter a valid amount range  ");
                List<Transaction> transactions = GetAllTransactions(user);
                if (transactions.Count == 0) throw new Exception($"User {user.UserName} doesn't have any transactions until now  ");

                foreach (CurrentAccount account in user.Accounts)
                {
                    foreach (Transaction transaction in account.transactionList)
                    {
                        transactions.Add(transaction);
                    }
                }
                List<Transaction> filtredTransactions = transactions.Where(x => x.Amount >= minimum && x.Amount <= maximum).ToList();

                Console.WriteLine($"Transactions  for user {user.UserName} with amount between {minimum} and {maximum} are  :  ");
                if (filtredTransactions.Count > 0)
                {
                    foreach (Transaction transaction in filtredTransactions)
                    {
                        Console.WriteLine($" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime}   ");
                    }
                }
                else
                {
                    Console.WriteLine($" User {user.UserName} doesn'n have any transactions with amount between {minimum} and {maximum}  ");
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }

           
        }
    }
}
