﻿using BankingApp.Fundamentals.OOP.Accounts;

namespace BankingApp.Fundamentals.OOP.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public List<CreditAccount> CreditAccounts {  get; set; }
        public List<Account> Accounts = new List<Account>();
        public List<Transaction> Transactions = new List<Transaction>();
        public User( string userName ) 
        { 
            UserId = Guid.NewGuid();
            UserName = userName;
        }
    }
}
