namespace BankingApp.Fundamentals.OOP.Exceptions
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() : base($"Insufficient funds") { }
    }
}
