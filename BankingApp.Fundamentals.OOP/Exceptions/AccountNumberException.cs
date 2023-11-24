namespace BankingApp.Fundamentals.OOP.Exceptions
{
    public class AccountNumberException : Exception
    {
        public AccountNumberException() : base($"Account Number must contain 12 characters") { }
    }
}
