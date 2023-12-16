using BankingApp.Fundamentals.OOP.Accounts;
using BankingApp.Fundamentals.OOP.Credit;
using BankingApp.Fundamentals.OOP.Entities;

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
            try
            {
                List<CreditAccountDetails> creditDetails = _creditService.GetCreditDetails(user);
                if(creditDetails.Count == 0) throw new Exception($"User {user.UserName} doesn't have any credits until now \n");
                foreach (CreditAccountDetails creditDetail in creditDetails)
                {
                    Console.WriteLine($"Credit details : {creditDetail.Details} \n");
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

        public void DisplayAllTransactions(User user)
        {
            try
            {
                List<Transaction> transactions = GetAllTransactions(user);
                if (transactions.Count == 0) throw new Exception($"User {user.UserName} doesn't have any transactions until now \n");
                Console.WriteLine($"Transactions for user {user.UserName} are :\n");

                foreach (Transaction transaction in transactions)
                {
                    Console.WriteLine($" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime.ToShortTimeString()} and  \n");
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
        }
        public void DisplayTransactionsForSpecificCategory(Category category,User user)
        {
            try 
            {
                List<Transaction> transactions = GetAllTransactions(user);
                if (transactions.Count == 0) throw new Exception($"User {user.UserName} doesn't have any transactions until now \n");
                Console.WriteLine($"Transactions of type {category} for user {user.UserName} are :\n");
                List<Transaction> filtredTransactions = transactions.Where(x => x.Category == category).ToList();

                if (filtredTransactions.Count > 0)
                {

                    foreach (Transaction transaction in filtredTransactions)
                    {
                        Console.WriteLine($" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime.ToShortTimeString()} and  \n");
                    }
                }
                else
                {
                    Console.WriteLine($" User {user.UserName} doesn'n have any transactions of type {category} \n");
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
                if(startDate>=endDate) throw new Exception($"Invalid date period , please enter a valid start and end date \n");
                List<Transaction> transactions = GetAllTransactions(user);
                if (transactions.Count == 0) throw new Exception($"User {user.UserName} doesn't have any transactions until now \n");

                List<Transaction> filtredTransactions = transactions.Where(x => x.DateTime >= startDate && x.DateTime <= endDate).ToList();
                Console.WriteLine($"Transactions  for user {user.UserName} made between {startDate.ToShortDateString()} and {endDate.ToShortDateString()} are  :\n");
                if (filtredTransactions.Count > 0)
                {
                    foreach (Transaction transaction in filtredTransactions)
                    {
                        Console.WriteLine($" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime.ToShortTimeString()} and  \n");
                    }
                }
                else
                {
                    Console.WriteLine($" User {user.UserName} doesn'n have any transactions made between {startDate} and {endDate} \n");
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
                if (transactions.Count == 0) throw new Exception($"User {user.UserName} doesn't have any transactions until now \n");

                foreach (CurrentAccount account in user.Accounts)
                {
                    foreach (Transaction transaction in account.transactionList)
                    {
                        transactions.Add(transaction);
                    }
                }
                List<Transaction> filtredTransactions = transactions.Where(x => x.Amount < 1000).ToList();
                Console.WriteLine($"Transactions  for user {user.UserName} with amount less than 1000 are  : \n");
                if (transactions.Count > 0)
                {
                    foreach (Transaction transaction in filtredTransactions)
                    {
                        Console.WriteLine($" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime.ToShortTimeString()} and  \n");
                    }
                }
                else
                {
                    Console.WriteLine($" User {user.UserName} doesn'n have any transactions with amount lower than 1000 \n");
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
                if (minimum >= maximum) throw new Exception(" Invalid amount range , please enter a valid amount range \n");
                List<Transaction> transactions = GetAllTransactions(user);
                if (transactions.Count == 0) throw new Exception($"User {user.UserName} doesn't have any transactions until now \n");

                foreach (CurrentAccount account in user.Accounts)
                {
                    foreach (Transaction transaction in account.transactionList)
                    {
                        transactions.Add(transaction);
                    }
                }
                List<Transaction> filtredTransactions = transactions.Where(x => x.Amount >= minimum && x.Amount <= maximum).ToList();

                Console.WriteLine($"Transactions  for user {user.UserName} with amount between {minimum} and {maximum} are  : \n");
                if (filtredTransactions.Count > 0)
                {
                    foreach (Transaction transaction in filtredTransactions)
                    {
                        Console.WriteLine($" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime.ToShortTimeString()} and  \n");
                    }
                }
                else
                {
                    Console.WriteLine($" User {user.UserName} doesn'n have any transactions with amount between {minimum} and {maximum} \n");
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
        }
    }
}
