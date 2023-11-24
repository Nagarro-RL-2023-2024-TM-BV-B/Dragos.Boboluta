namespace BankingApp.Fundamentals.OOP
{
  public static class AccountNumberValidator
  {
    public static bool Validate(string accoutNumber)
    {
      if (accoutNumber.Length < 12)
      {
        return true;
      }

      return false;
    }
  }
}
