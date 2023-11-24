using BankingApp.Fundamentals.OOP.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Fundamentals.OOP
{
    public class Report
    {
        private StringBuilder raportAccount = new StringBuilder();
        public Report(CurrentAccount account )
        {
            raportAccount.Append(account.accountTransactions);
        }
        public void GenerateReport()
        {
            Console.WriteLine( raportAccount.ToString() );
        }
        public void GenerateReportPerCategories()
        {
            //add custom logic for diferite categories
            //get a categori and after it use a for eacht on transactions  
            Console.WriteLine(raportAccount.ToString() );
        }
    }
}
