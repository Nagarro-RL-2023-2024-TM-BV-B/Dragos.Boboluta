namespace BankingApp.Fundamentals.OOP.Entityes
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string CreditIds = "";
        public string Credits = "";
        public User( string userName ) 
        { 
            UserId = Guid.NewGuid();
            UserName = userName;
        }
       
    }
}
