﻿using BankingApp.Fundamentals.OOP.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Fundamentals.OOP
{
    public class Report
    {
        public void GenerateReport(CurrentAccount account)
        {
            StringBuilder reportAccount = new StringBuilder();

            reportAccount.Append("======================================================================\n");
            reportAccount.Append(account.accountTransactions);
            reportAccount.Append("----------------------------------------------------------------------\n");
            reportAccount.Append("Total amount of the account is : " + account.Balance + "\n");
            reportAccount.Append("======================================================================\n");

            Console.WriteLine(reportAccount.ToString() );
            reportAccount.Clear();
        }
        public void GenerateReportPerCategories(CurrentAccount account)
        {
            StringBuilder filteredTransactions = new StringBuilder();
            string transactionLog = account.accountTransactions;
            string[] transactions = transactionLog.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            filteredTransactions.Append("Transactions filtred by type : \n");
            foreach (Category type in Enum.GetValues(typeof(Category)))
            {
                filteredTransactions.Append("======================================================================\n");
                filteredTransactions.Append(type + " transactions on account :" + account.AccountNumber + " are :\n");
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
            filteredTransactions.Append("Total amount of the account is : " + account.Balance + "\n");
            filteredTransactions.Append("======================================================================\n");

            Console.WriteLine(filteredTransactions.ToString() );
            filteredTransactions.Clear();
        }
    }
}
