using System;

namespace FXReporting.Models
{
    public class ForexTransaction
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public DateTime OrderOpenTime { get; set; }
        public OrderType OrderType { get; set; }
        public decimal LotSize { get; set; }
        public string Symbol { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal StopLoss { get; set; }
        public decimal TakeProfit { get; set; }
        public DateTime OrderCloseTime { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal Swap { get; set; }
        public decimal Profit { get; set; }
        public string Comment { get; set; }
        public decimal Commission { get; set; }
        public DateTime Expiration { get; set; }
        public int MagicalNumber { get; set; }

        public Robot Robot { get; set; }
    }
}
