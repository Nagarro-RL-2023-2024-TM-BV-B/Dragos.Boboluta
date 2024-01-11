using BankingApp.Fundamentals.OOP.Entities;

namespace BankingApp.Fundamentals.OOP.Report
{
    public interface IReporter
    {
        void DisplayCreditInformation(User user);
        void DisplayAllTransactions(User user);
        void DisplayTransactionsForSpecificCategory(Category category, User user);
        void DisplayTransactionsForSpecificDatePeriod(DateTime startDate, DateTime endDate, User user);
        void DisplayTransactionsAmountLowerThan(User user);
        void DisplayTransactionWithAmountBetweenARange(double minimum, double maximum, User user);
    }
}
