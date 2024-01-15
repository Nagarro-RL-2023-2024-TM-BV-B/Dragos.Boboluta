using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Fundamentals.OOP.Entities.DataModels
{
    public class TransactionDataModel
    {
        public string TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionCategory { get; set; }
        public double TransactionAmount { get; set; }
    }
}
