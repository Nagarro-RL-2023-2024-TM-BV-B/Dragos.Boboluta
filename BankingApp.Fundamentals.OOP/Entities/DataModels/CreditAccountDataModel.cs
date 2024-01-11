using BankingApp.Fundamentals.OOP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankingApp.Fundamentals.OOP.Entities.DataModels
{
    public class CreditAccountDataModel
    {
        public string AccountId { get; set; }
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Currency Currency { get; set; }
        public List<TransactionDataModel> Transactions { get; set; }
    }
}
