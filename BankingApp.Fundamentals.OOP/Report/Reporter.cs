using BankingApp.Fundamentals.OOP.Accounts;
using BankingApp.Fundamentals.OOP.Credit;
using BankingApp.Fundamentals.OOP.Entityes;
using BankingApp.Fundamentals.OOP.Enums;
using System.Security.Principal;
using System.Text;
using System.Transactions;

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
            StringBuilder userCredits = new StringBuilder();
           
            string[] creditDetails = _creditService.GetCreditDetails(user); 

            userCredits.Append("======================================================================\n");
            userCredits.Append("Credits for the user " + user.UserName + " are : \n");
            userCredits.Append("======================================================================\n");
            foreach (string credit in creditDetails)
            {
                userCredits.AppendLine("  " + credit);
            }
            userCredits.Append("======================================================================\n");

            Console.WriteLine(userCredits.ToString());
            userCredits.Clear();
        }

        public void GenerateReport(CurrentAccount account)
        {
            StringBuilder reportAccount = new StringBuilder();

            reportAccount.Append("======================================================================\n");
            reportAccount.Append("Transactions for the current account are : \n");
            reportAccount.Append("======================================================================\n");
            reportAccount.Append(account.accountTransactions);
            reportAccount.Append("----------------------------------------------------------------------\n");
            reportAccount.Append("Total amount of the account is : " + account.Balance + "\n");
            reportAccount.Append("======================================================================\n");

            Console.WriteLine(reportAccount.ToString());
            reportAccount.Clear();
        }
        public void GenerateReportPerCategories(CurrentAccount account)
        {
            StringBuilder filteredTransactions = new StringBuilder();
            string transactionLog = account.accountTransactions;
            string[] transactions = transactionLog.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            filteredTransactions.Append("Transactions filtred by type for current account are : \n");
            foreach (Category type in Enum.GetValues(typeof(Category)))
            {
                filteredTransactions.Append("======================================================================\n");
                filteredTransactions.Append(type + " transactions on current account are :\n");
                foreach (string transaction in transactions)
                {
                    if (transaction.Contains(type.ToString()))
                    {
                        filteredTransactions.AppendLine("  " + transaction);
                    }
                }
            }
            filteredTransactions.Append("======================================================================\n");
            filteredTransactions.Append("----------------------------------------------------------------------\n");
            filteredTransactions.Append("Total amount of the current account is : " + account.Balance + "\n");
            filteredTransactions.Append("======================================================================\n");

            Console.WriteLine(filteredTransactions.ToString());
            filteredTransactions.Clear();
        }
    }
}
