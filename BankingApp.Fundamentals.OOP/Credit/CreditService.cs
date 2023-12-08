using BankingApp.Fundamentals.OOP.Entityes;

namespace BankingApp.Fundamentals.OOP.Credit
{
    public class CreditService : ICreditService
    {
        public static string Credits = "";
        public void AssignCredit(User user, CreditAccount creditAccount)
        {
            user.CreditIds += creditAccount.CreditId;
            creditAccount.AccountId = user.UserId;

            user.Credits += creditAccount.CreditDetails.Details;
            Credits += creditAccount.CreditDetails;
        }

    }
}
