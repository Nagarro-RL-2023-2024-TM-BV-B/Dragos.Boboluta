using BankingApp.Fundamentals.OOP.Accounts;
using BankingApp.Fundamentals.OOP.Credit;
using BankingApp.Fundamentals.OOP.Entities;
using System.IO;
using System.Text;
using System.Text.Json;

namespace BankingApp.Fundamentals.OOP.Report
{
    public class Reporter : IReporter
    {
        private readonly ICreditService _creditService;
        public  StringBuilder StringBuilder = new StringBuilder();
        public Reporter(ICreditService creditService)
        {
            _creditService = creditService; 
        }
        public string DisplayCreditInformation(User user )
        {
            try
            {
                List<CreditAccountDetails> creditDetails = _creditService.GetCreditDetails(user);
                if(creditDetails.Count == 0) throw new Exception($"User {user.UserName} doesn't have any credits until now  ");
                foreach (CreditAccountDetails creditDetail in creditDetails)
                {
                    StringBuilder.Append($"Credit details : {creditDetail.Details} | ");
                }
                return StringBuilder.ToString();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                StringBuilder.Clear();
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

        public async Task<string> DisplayAllTransactions(User user)
        {
            try
            {
                var raportFile = "Raports.json";

                using (StreamWriter raportWriter = new StreamWriter(raportFile))
                {
                    List<Transaction> transactions = GetAllTransactions(user);
                    if (transactions.Count == 0) throw new Exception($"User {user.UserName} doesn't have any transactions until now  ");
                    Console.WriteLine($"Transactions for user {user.UserName} are : ");

                    foreach (Transaction transaction in transactions)
                    {
                        var text = $" A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime} ;";
                        Console.WriteLine($" => {text}");
                        raportWriter.WriteLine(text); 

                        StringBuilder.Append($"{text} {Environment.NewLine}");
                    }
                }

                return StringBuilder.ToString();
            }
            catch (Exception ex)
            {
                // Tratează excepțiile aici
                Console.WriteLine($"Error: {ex.Message}");
                return string.Empty;
            }


            finally
            {
                StringBuilder.Clear();
            }
        }
        public string DisplayTransactionsForSpecificCategory(Category category,User user)
        {
            try 
            {
                List<Transaction> transactions = GetAllTransactions(user);
                if (transactions.Count == 0) throw new Exception($"User {user.UserName} doesn't have any transactions until now  ");
                Console.WriteLine($"Transactions of type {category} for user {user.UserName} are : ");
                List<Transaction> filtredTransactions = transactions.Where(x => x.Category == category).ToList();

                if (filtredTransactions.Count > 0)
                {

                    foreach (Transaction transaction in filtredTransactions)
                    {

                        Console.WriteLine($" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime}   ");
                    }
                }
                else
                {
                    Console.WriteLine($" User {user.UserName} doesn'n have any transactions of type {category}  ");
                }
                return StringBuilder.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            finally
            {
                StringBuilder.Clear();
            }
        }
        public string DisplayTransactionsForSpecificDatePeriod(DateTime startDate ,DateTime endDate,User user)
        {
            try
            {
                if(startDate >= endDate) throw new Exception($"Invalid date period , please enter a valid start and end date  ");
                List<Transaction> transactions = GetAllTransactions(user);
                if (transactions.Count == 0) throw new Exception($"User {user.UserName} doesn't have any transactions until now  ");

                List<Transaction> filtredTransactions = transactions.Where(x => x.DateTime >= startDate && x.DateTime <= endDate).ToList();
                Console.WriteLine($"Transactions  for user {user.UserName} made between {startDate.ToShortDateString()} and {endDate.ToShortDateString()} are  : ");
                if (filtredTransactions.Count > 0)
                {
                    foreach (Transaction transaction in filtredTransactions)
                    {
                        Console.WriteLine($" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime}   ");
                    }
                }
                else
                {
                    Console.WriteLine($" User {user.UserName} doesn'n have any transactions made between {startDate} and {endDate}  ");
                }
                return StringBuilder.ToString() ;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                StringBuilder.Clear();
            }
        }
        public string DisplayTransactionsAmountLowerThan(User user)
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
                Console.WriteLine($"Transactions  for user {user.UserName} with amount less than 1000 are  :  ");
                if (transactions.Count > 0)
                {
                    foreach (Transaction transaction in filtredTransactions)
                    {
                        Console.WriteLine($" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime}   ");
                    }
                }
                else
                {
                    Console.WriteLine($" User {user.UserName} doesn'n have any transactions with amount lower than 1000  ");
                }
                return StringBuilder.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            finally
            {
                StringBuilder.Clear();
            }
        }
        public string DisplayTransactionWithAmountBetweenARange(double minimum,double maximum,User user)
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
                return StringBuilder.ToString() ;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return null;
            }

            finally
            {
                StringBuilder.Clear();
            }
        }
    }
}
