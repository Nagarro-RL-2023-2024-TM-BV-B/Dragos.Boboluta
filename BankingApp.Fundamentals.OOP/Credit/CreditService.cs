using BankingApp.Fundamentals.OOP.Entities;
using System.Text;

namespace BankingApp.Fundamentals.OOP.Credit
{
    public class CreditService : ICreditService
    {
        public void AssignCredit(User user, CreditAccount creditAccount)
        {
                    user.CreditIds += $"{creditAccount.CreditId}  ";
                    creditAccount.AccountId = user.UserId;  
                    user.Credits += creditAccount.CreditDetails.Details;
        }
        public List<CreditAccountDetails> GetCreditDetails(User user)
        {
            List<CreditAccount>  creditAccounts = user.CreditAccounts;
            List<CreditAccountDetails> creditDetails = new List<CreditAccountDetails>();
            foreach(CreditAccount creditAccount in creditAccounts)
            {
                creditDetails.Add(creditAccount.CreditDetails);
            }

            return creditDetails;
        }
    }
}
