namespace BankingSystem.Models
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public int PIN { get; set; }
        public double AccountBalance { get; set; }
    }
}
