
using BankingApp.Fundamentals.OOP.Entityes;

namespace BankingApp.Fundamentals.OOP.Credit
{
    public interface ICreditService
    {
        void AssignCredit(User user, CreditAccount creditAccount);
    }
}
