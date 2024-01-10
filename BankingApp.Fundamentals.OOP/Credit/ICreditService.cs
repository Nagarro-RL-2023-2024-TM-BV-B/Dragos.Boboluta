
using BankingApp.Fundamentals.OOP.Entities;

namespace BankingApp.Fundamentals.OOP.Credit
{
    public interface ICreditService
    {
        void AssignCredit(User user, CreditAccount creditAccount);
        List<CreditAccountDetails> GetCreditDetails(User user);
    }
}
