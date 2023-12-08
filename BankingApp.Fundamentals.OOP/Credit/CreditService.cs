using BankingApp.Fundamentals.OOP.Entityes;

namespace BankingApp.Fundamentals.OOP.Credit
{
    public class CreditService : ICreditService
    {
        public void AssignCredit(User user, CreditAccount creditAccount)
        {
            user.CreditIds += creditAccount.CreditId+" ";
            creditAccount.AccountId = user.UserId;
            user.Credits += creditAccount.CreditDetails.Details;
        }
    }
}
