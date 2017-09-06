using System.Collections;
using System.Collections.Generic;

namespace FXReporting.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public string IBAN { get; set; }
        public string MT4_Login { get; set; }
        public string Currency { get; set; }

        public ICollection<Robot> Robots { get; set; }
    }
}
