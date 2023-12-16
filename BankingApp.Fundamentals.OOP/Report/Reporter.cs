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
            List<Transaction> transactions = new List<Transaction>();

            foreach(CurrentAccount account in user.Accounts)
            {
                foreach(Transaction transaction in account.transactionList)
                {
                    transactions.Add(transaction);
                }
            }
            Console.WriteLine($"Transactions for user {user.UserName} are :\n");

            foreach (Transaction transaction in transactions)
            {
                Console.WriteLine($" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime.ToShortTimeString()} and  \n");
            }

        }
        //2. Get transactions for a specific user and category
        public void GetTransactionsForSpecificCategory(Category category,User user)
        {
            List<Transaction> transactions = new List<Transaction>();

            foreach (CurrentAccount account in user.Accounts)
            {
                foreach (Transaction transaction in account.transactionList)
                {
                    transactions.Add(transaction);
                }
            }
            Console.WriteLine($"Transactions of type {category} for user {user.UserName } are :\n");
            List<Transaction> filtredTransactions = transactions.Where(x=>x.Category == category).ToList();

            foreach(Transaction transaction in filtredTransactions)
            {
                Console.WriteLine($" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime.ToShortTimeString()} and  \n");
            }
        }
        //3. Get transactions for s specific date(start date, end date)
        public void GetTransactionsForSpecificDate(DateTime startDate ,DateTime endDate,User user)
        {
            List<Transaction> transactions = new List<Transaction>();

            foreach (CurrentAccount account in user.Accounts)
            {
                foreach (Transaction transaction in account.transactionList)
                {
                    transactions.Add(transaction);
                }
            }

            List<Transaction> filtredTransactions = transactions.Where(x=>x.DateTime>=startDate&&x.DateTime<=endDate).ToList();
            Console.WriteLine($"Transactions  for user {user.UserName} made between {startDate.ToShortDateString()} and {endDate.ToShortDateString()}are  :\n");


            foreach (Transaction transaction in filtredTransactions)
            {
                Console.WriteLine($" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime.ToShortTimeString()} and  \n");
            }
        }
        //4. Get transactions which amount is lower than 1000 (currency)
        public void GetTransactionsAmountLowerThan(User user)
        {
            List<Transaction> transactions = new List<Transaction>();

            foreach (CurrentAccount account in user.Accounts)
            {
                foreach (Transaction transaction in account.transactionList)
                {
                    transactions.Add(transaction);
                }
            }
            List<Transaction> filtredTransactions = transactions.Where(x => x.Amount<1000).ToList();
            Console.WriteLine($"Transactions  for user {user.UserName} with amount less than 1000 are  : \n");

            foreach (Transaction transaction in filtredTransactions)
            {
                Console.WriteLine($" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime.ToShortTimeString()} and  \n");
            }
        }
        //5. Get transactions which amount is between a specific range.
        public void GetTransactionWithAmountBetweenARange(double minimum,double maximum,User user)
        {
            List<Transaction> transactions = new List<Transaction>();

            foreach (CurrentAccount account in user.Accounts)
            {
                foreach (Transaction transaction in account.transactionList)
                {
                    transactions.Add(transaction);
                }
            }
            List<Transaction> filtredTransactions = transactions.Where(x => x.Amount >=minimum&&x.Amount<=maximum).ToList();

            Console.WriteLine($"Transactions  for user {user.UserName} with amount between {minimum} and {maximum} are  : \n");

            foreach (Transaction transaction in filtredTransactions)
            {
                Console.WriteLine($" => A transaction of amount {transaction.Amount} and type {transaction.Category.ToString()} was made in date {transaction.DateTime.ToShortTimeString()} and  \n");

            }
        }
    }
}
