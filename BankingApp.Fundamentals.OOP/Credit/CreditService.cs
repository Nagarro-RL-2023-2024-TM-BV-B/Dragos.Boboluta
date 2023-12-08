using BankingApp.Fundamentals.OOP.Entityes;
using System.Text;

namespace BankingApp.Fundamentals.OOP.Credit
{
    public class CreditService : ICreditService
    {
        public void AssignCredit(User user, CreditAccount creditAccount)
        {
                    user.CreditIds += creditAccount.CreditId + " ";
                    creditAccount.AccountId = user.UserId;  
                    user.Credits += creditAccount.CreditDetails.Details;
        }
        public string[] GetCreditDetails(User user)
        {
            string creditsDetails = user.Credits;
            string[] credits = creditsDetails.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);


            return credits;
        }
    }
}
