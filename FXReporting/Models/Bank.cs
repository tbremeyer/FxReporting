using System.Collections.Generic;

namespace FXReporting.Models
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; }
    }
}
