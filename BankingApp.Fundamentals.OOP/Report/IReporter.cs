using BankingApp.Fundamentals.OOP.Entities;

namespace BankingApp.Fundamentals.OOP.Report
{
    public interface IReporter
    {
        string DisplayCreditInformation(User user);
        Task<string> DisplayAllTransactions(User user);
        string DisplayTransactionsForSpecificCategory(Category category, User user);
        string DisplayTransactionsForSpecificDatePeriod(DateTime startDate, DateTime endDate, User user);
        string DisplayTransactionsAmountLowerThan(User user);
        string DisplayTransactionWithAmountBetweenARange(double minimum, double maximum, User user);
    }
}
