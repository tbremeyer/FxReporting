using System;
using System.Collections.Generic;
using System.Linq;
using FXReporting.Data;
using FXReporting.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FXReporting.Controllers
{
    [Route("api/forexTransaction")]
    public class ForexTransactionController : Controller
    {
        private readonly ForexContext context;

        public ForexTransactionController(ForexContext context)
        {
            this.context = context;

            if (!this.context.ForexTransactions.Any())
            {
                this.context.ForexTransactions.Add(new ForexTransaction()
                {
                    OrderType = OrderType.Buy,
                    Order = 123456,
                    OrderOpenTime = new DateTime(2017, 8, 31, 10, 32, 00),
                    OrderPrice = new decimal(1.12498),
                    ClosePrice = new decimal(1.12687),
                    LotSize = new decimal(1.1),
                    Comment = "Test Transaction",
                    Profit = new decimal(17.50)
                });
            }
        }

        [HttpGet]
        public IEnumerable<ForexTransaction> GetAll()
        {
            return this.context.ForexTransactions.ToList();
        }

        // GET: api/values
        [HttpGet("{order}", Name= "GetTransaction")]
        public IActionResult GetByOrder(int order)
        {
            var transaction = this.context.ForexTransactions.FirstOrDefault(t => t.Order == order);
            if (transaction == null)
            {
                return this.NotFound();
            }
            return new ObjectResult(transaction);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ForexTransaction transaction)
        {
            if (transaction == null)
            {
                return BadRequest();
            }

            this.context.ForexTransactions.Add(transaction);
            this.context.SaveChanges();

            return CreatedAtRoute("GetTransaction", new { transaction.Order }, transaction);
        }

        [HttpPut("{order}")]
        public IActionResult Update(int order, [FromBody] ForexTransaction transaction)
        {
            if (transaction == null || transaction.Order != order)
            {
                return BadRequest();
            }

            var fxTransaction = this.context.ForexTransactions.FirstOrDefault(t => t.Order == order);
            if (fxTransaction == null)
            {
                return NotFound();
            }

            fxTransaction.ClosePrice = transaction.ClosePrice;
            fxTransaction.Comment = transaction.Comment;
            fxTransaction.Commission = transaction.Commission;
            fxTransaction.Expiration = transaction.Expiration;
            fxTransaction.LotSize = transaction.LotSize;
            fxTransaction.MagicalNumber = transaction.MagicalNumber;
            fxTransaction.OrderCloseTime = transaction.OrderCloseTime;
            fxTransaction.OrderOpenTime = transaction.OrderOpenTime;
            fxTransaction.OrderPrice = transaction.OrderPrice;
            fxTransaction.Profit = transaction.Profit;
            fxTransaction.StopLoss = transaction.StopLoss;
            fxTransaction.Swap = transaction.Swap;
            fxTransaction.Symbol = transaction.Symbol;
            fxTransaction.TakeProfit = transaction.TakeProfit;
            fxTransaction.OrderType = transaction.OrderType;

            this.context.ForexTransactions.Update(fxTransaction);
            this.context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{order}")]
        public IActionResult Delete(int order)
        {
            var transaction = this.context.ForexTransactions.FirstOrDefault(t => t.Order == order);
            if (transaction == null)
            {
                return NotFound();
            }

            this.context.ForexTransactions.Remove(transaction);
            this.context.SaveChanges();
            return new NoContentResult();
        }
    }
}
