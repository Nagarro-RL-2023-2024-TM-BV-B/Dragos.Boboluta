using BankingApp.Fundamentals.OOP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankingApp.Fundamentals.OOP.Entities.DataModels
{
    public class AccountDataModel
    {
        public string AccountNumber { get; set; }
        public double InitialBalance { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]

        public Currency Currency {  get; set; }
    }
}
