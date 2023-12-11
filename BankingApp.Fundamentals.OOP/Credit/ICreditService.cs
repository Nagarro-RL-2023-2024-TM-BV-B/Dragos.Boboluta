
using BankingApp.Fundamentals.OOP.Entities;

namespace BankingApp.Fundamentals.OOP.Credit
{
    public interface ICreditService
    {
        void AssignCredit(User user, CreditAccount creditAccount);
        string[] GetCreditDetails(User user);
    }
}
