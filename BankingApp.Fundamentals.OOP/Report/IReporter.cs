using BankingApp.Fundamentals.OOP.Entities;

namespace BankingApp.Fundamentals.OOP.Report
{
    public interface IReporter
    {
        void DisplayCreditInformation(User user);
        void GetAllTransactions(User user);
        void GetTransactionsForSpecificCategory(Category category, User user);
        void GetTransactionsForSpecificDate(DateTime startDate, DateTime endDate, User user);
        void GetTransactionsAmountLowerThan(User user);
        void GetTransactionWithAmountBetweenARange(double minimum, double maximum, User user);
    }
}
