using BankingApp.Fundamentals.OOP.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Fundamentals.OOP.Entities.DataModels
{
    public class UserDataModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string CreditIds { get; set; }
        public string Credits { get; set; }
        public List<CreditAccountDataModel> Accounts { get; set; }
        public List<TransactionDataModel> Transactions { get; set; }
    }
}
