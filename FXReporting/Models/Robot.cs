using System;
using System.Collections.Generic;

namespace FXReporting.Models
{
    public class Robot
    {
        public int Id { get; set; }
        public int MagicalNumber { get; set; }
        public string Name { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Price { get; set; }
        public string CurrencySymbol { get; set; }

        public ICollection<ForexTransaction> ForexTransactions { get; set; }
    }
}
