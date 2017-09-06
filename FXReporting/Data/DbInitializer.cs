using System;
using System.Linq;
using FXReporting.Models;

namespace FXReporting.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ForexContext context)
        {
            context.Database.EnsureCreated();

            if (context.ForexTransactions.Any())
            {
                return;  // DB has been seeded
            }

            var transactions = new ForexTransaction[]
            {
                new ForexTransaction {Order = 6346672,OrderOpenTime = new DateTime(2017,01,27,19,57,16),OrderType=OrderType.Balance,OrderCloseTime = new DateTime(2017,01,18)},
                new ForexTransaction {Order = 6575938,OrderOpenTime = new DateTime(2017,02,01,19,16,05), OrderType = OrderType.Sell, LotSize  = new decimal(0.03), Symbol = "eurusd", OrderPrice  =  new decimal(1.07499), StopLoss = new decimal(1.0778), Commission  = new decimal(0), OrderCloseTime = new DateTime(2017,02,01,20,05,17),  Swap   = 0m, Profit = -7.85m },
                new ForexTransaction{ Order = 6581212, OrderOpenTime = new DateTime( 2017,02,01,21,13,29), OrderType = OrderType.Sell, LotSize = 0.03m, Symbol = "gbpchf", OrderPrice =    1.25668m, StopLoss =  1.2585m, TakeProfit = 1.24515m, OrderCloseTime =       new DateTime(2017,02,02,13,21,41),ClosePrice =    1.24508m , Swap = - 0.53m, Profit =   32.58m},
                new ForexTransaction{ Order = 6607073, OrderOpenTime = new DateTime( 2017,02,02,21,26,10), OrderType = OrderType.Sell, LotSize = 0.03m, Symbol = "eurgbp", OrderPrice =    0.85882m, StopLoss =  0.86182m, TakeProfit =  0.85082m, OrderCloseTime =     new DateTime(2017,02,03,15,02,59),ClosePrice =    0.86182m , Swap =   0.01m, Profit = - 10.44m},
                new ForexTransaction{ Order = 6607266, OrderOpenTime = new DateTime( 2017,02,02,21,41,43), OrderType = OrderType.Buy, LotSize = 0.03m, Symbol = "gbpchf", OrderPrice =     1.24481m , StopLoss = 1.2413m, TakeProfit =   1.2523m, OrderCloseTime =      new DateTime(2017,02,03,10,47,48),ClosePrice =    1.24123m , Swap =   0.04m, Profit = - 10.04m },
                new ForexTransaction{ Order = 6607559, OrderOpenTime = new DateTime( 2017,02,02,21,52,56), OrderType = OrderType.Sell, LotSize = 0.03m, Symbol = "gbpusd", OrderPrice =     1.25383m, StopLoss =  1.25233m, TakeProfit =  1.21788m, OrderCloseTime =    new DateTime(2017,02,06,18,07,36),ClosePrice =    1.24467m , Swap = - 0.02m, Profit =   25.6m},
                new ForexTransaction{ Order = 6659585, OrderOpenTime = new DateTime( 2017,02,06,20,52,18), OrderType = OrderType.Buy, LotSize = 0.03m, Symbol = "gbpusd", OrderPrice =     1.24742m, StopLoss =  1.2443m, TakeProfit =   0m, OrderCloseTime =           new DateTime(2017,02,07,07,45,43),ClosePrice =    1.24427m , Swap = - 0.11m, Profit = - 8.84m},
                new ForexTransaction{ Order = 6659773, OrderOpenTime = new DateTime( 2017,02,06,21,07,27), OrderType = OrderType.Buy, LotSize = 0.03m, Symbol = "nzdjpy", OrderPrice =     81.835m, StopLoss =   81.621m, TakeProfit =   0m, OrderCloseTime =           new DateTime(2017,02,07,01,51,33),ClosePrice =    81.621m , Swap =   0.07m, Profit = - 5.35m},
                new ForexTransaction{ Order = 6659799, OrderOpenTime = new DateTime( 2017,02,06,21,11,15), OrderType = OrderType.Sell, LotSize = 0.03m, Symbol = "usdcad", OrderPrice =     1.30907m, StopLoss =  1.31504m, TakeProfit =  0m, OrderCloseTime =          new DateTime(2017,02,07,08,59,49),ClosePrice =    1.31506m , Swap = - 0.07m, Profit = - 12.8m},
                new ForexTransaction{ Order = 6660126, OrderOpenTime = new DateTime( 2017,02,06,21,40,45), OrderType = OrderType.Buy, LotSize = 0.03m, Symbol = "eurchf", OrderPrice =     1.06533m, StopLoss =  1.06335m, TakeProfit =  0m, OrderCloseTime =           new DateTime(2017,02,08,12,40,07),ClosePrice =    1.06336m , Swap = - 0.05m, Profit = - 5.56m },
                new ForexTransaction{ Order = 6722643, OrderOpenTime = new DateTime( 2017,02,08,19,13,53), OrderType = OrderType.Sell, LotSize = 0.03m, Symbol = "usdchf", OrderPrice =     0.99481m, StopLoss =  1.00081m, TakeProfit =  0m, OrderCloseTime =          new DateTime(2017,02,09,16,00,37),ClosePrice =    1.00081m , Swap = - 0.52m, Profit = - 16.87m},
                new ForexTransaction{ Order = 6722775, OrderOpenTime = new DateTime( 2017,02,08,19,17,59), OrderType = OrderType.Sell, LotSize = 0.03m, Symbol = "usdjpy", OrderPrice =     112.035m, StopLoss =  113m, TakeProfit =  0m, OrderCloseTime =              new DateTime(2017,02,09,16,02,47),ClosePrice =    113.001m , Swap = - 0.33m, Profit = - 24.06m },
                new ForexTransaction{ Order = 6753988, OrderOpenTime = new DateTime( 2017,02,09,21,38,29), OrderType = OrderType.Sell, LotSize = 0.03m, Symbol = "cadjpy", OrderPrice =     86.182m, StopLoss =   86.224m, TakeProfit =   0m, OrderCloseTime =          new DateTime(2017,02,09,21,54,46),ClosePrice =    86.224m  , Swap =   0m, Profit = - 1.04m},
                new ForexTransaction{ Order = 6804133, OrderOpenTime = new DateTime( 2017,02,14,02,58,04), OrderType = OrderType.BuyStop, LotSize = 0.03m, Symbol = "gbpchf", OrderPrice =     1.2618m, StopLoss =   0m, TakeProfit =    0m, OrderCloseTime =           new DateTime(2017,02,14,18,19,52),ClosePrice =    1.25602m,Comment = "cancelled"},
                new ForexTransaction{ Order = 6804138, OrderOpenTime = new DateTime( 2017,02,14,10,30,01), OrderType = OrderType.Sell, LotSize =  0.03m, Symbol = "gbpchf", OrderPrice =     1.25542m, StopLoss =  1.25585m, TakeProfit =  0m, OrderCloseTime =         new DateTime(2017,02,14,18,44,58),ClosePrice =    1.25584m , Swap =   0m, Profit = - 1.18m},
                new ForexTransaction{ Order = 6865593, OrderOpenTime = new DateTime( 2017,02,16,07,22,21), OrderType = OrderType.Buy, LotSize = 0.65m, Symbol = "eurchf", OrderPrice =     1.06558m, StopLoss =  1.06612m, TakeProfit =  1.06909m, OrderCloseTime =     new DateTime(2017,02,22,23,54,41),ClosePrice =    1.06609m , Swap = - 2.71m, Profit =   31.09m},
                new ForexTransaction{ Order = 6968277, OrderOpenTime = new DateTime( 2017,02,23,16,46,22), OrderType = OrderType.Buy, LotSize = 0.65m, Symbol = "gbpusd", OrderPrice =     1.25295m, StopLoss =  1.2541m, TakeProfit =   1.26179m, OrderCloseTime =     new DateTime(2017,02,23,18,55,00),ClosePrice =    1.2541m  , Swap =   0m, Profit =   70.74m},
                new ForexTransaction{ Order = 6968365, OrderOpenTime = new DateTime( 2017,02,22,20,49,29), OrderType = OrderType.SellStop, LotSize = 0.65m, Symbol = "gbpusd", OrderPrice =     1.23903m, StopLoss =  1.24203m, TakeProfit =  1.2308m, OrderCloseTime = new DateTime(2017,02,23,18,10,22),ClosePrice =    1.25535m, Comment = "cancelled"},
                new ForexTransaction{ Order = 7043398, OrderOpenTime = new DateTime( 2017,02,27,19,26,09), OrderType = OrderType.BuyStop , LotSize = 0.5m, Symbol = "gbpchf", OrderPrice =     1.2684m, StopLoss =   1.26325m, TakeProfit =  1.2828m, OrderCloseTime =  new DateTime(2017,03,09,05,44,59),ClosePrice =    1.23553m, Comment = "cancelled"},
                new ForexTransaction{ Order = 7043722, OrderOpenTime = new DateTime( 2017,03,08,10,30,37), OrderType = OrderType.Sell, LotSize = 0.4m, Symbol = "gbpchf", OrderPrice =     1.23232m, StopLoss =  1.23252m, TakeProfit =  1.2042m, OrderCloseTime =      new DateTime(2017,03,08,10,30,37),ClosePrice =    1.23266m , Swap =   0m, Profit = - 12.73m},
                new ForexTransaction{ Order = 7044424, OrderOpenTime = new DateTime( 2017,02,27,19,38,28), OrderType = OrderType.SellStop, LotSize = 0.4m,Symbol = "cadjpy", OrderPrice =     84.037m, StopLoss =   84.667m, TakeProfit =   78.759m, OrderCloseTime =   new DateTime(2017,03,15,05,08,52),ClosePrice =    85.261m, Comment = "cancelled"},
                new ForexTransaction{ Order = 7253027, OrderOpenTime = new DateTime( 2017,03,08,19,06,24), OrderType = OrderType.Sell, LotSize = 0.4m, Symbol = "gbpchf", OrderPrice =     1.23407m, StopLoss =  1.23242m, TakeProfit =  1.2042m, OrderCloseTime =      new DateTime(2017,03,13,08,08,28),ClosePrice =    1.23242m , Swap = - 11.27m, Profit =  61.12m},
                new ForexTransaction{ Order = 7323754, OrderOpenTime = new DateTime( 2017,03,15,07,11,20), OrderType = OrderType.Sell, LotSize = 0.4m, Symbol = "eurgbp", OrderPrice =     0.87044m, StopLoss =  0.86751m, TakeProfit =  0.85685m, OrderCloseTime =     new DateTime(2017,03,16,18,57,20),ClosePrice =    0.86751m , Swap =   0.39m, Profit =    135.1m},
                new ForexTransaction{ Order = 7323789, OrderOpenTime = new DateTime( 2017,03,20,14,36,52), OrderType = OrderType.Sell, LotSize = 0.4m, Symbol = "cadchf", OrderPrice =     0.74578m, StopLoss =  0.74549m, TakeProfit =  0.73434m, OrderCloseTime =     new DateTime(2017,03,23,13,05,22),ClosePrice =    0.74549m , Swap = - 7.61m, Profit =   10.83m},
                new ForexTransaction{ Order = 7525136, OrderOpenTime = new DateTime( 2017,03,29,02,10,16), OrderType = OrderType.Sell , LotSize = 0.4m, Symbol = "gbpjpy", OrderPrice =     137.585m, StopLoss =  143.73m, TakeProfit =   130.202m, OrderCloseTime =    new DateTime(2017,03,31,05,13,22),ClosePrice =    140.079m , Swap = - 6.98m, Profit = - 832.65m},
                new ForexTransaction{ Order = 7746412, OrderOpenTime = new DateTime( 2017,04,03,05,11,03), OrderType = OrderType.Sell, LotSize = 0.4m, Symbol = "gbpchf", OrderPrice =     1.2556m, StopLoss =   1.25108m, TakeProfit =  1.23252m, OrderCloseTime =     new DateTime(2017,04,04,06,01,28),ClosePrice =    1.25109m , Swap = - 2.28m, Profit =   168.81m},
                new ForexTransaction{ Order = 7746459, OrderOpenTime = new DateTime( 2017,04,03,05,16,33), OrderType = OrderType.Sell, LotSize = 0.4m, Symbol = "gbpusd", OrderPrice =     1.2542m, StopLoss =   1.24936m, TakeProfit =  1.23317m, OrderCloseTime =     new DateTime(2017,04,04,05,46,54),ClosePrice =    1.24939m , Swap =   0.22m, Profit =    180.33m},
                new ForexTransaction{ Order = 7828423, OrderOpenTime = new DateTime( 2017,04,05,21,49,04), OrderType = OrderType.Buy, LotSize = 0.4m, Symbol = "eurjpy", OrderPrice =     118.189m, StopLoss =  118.082m, TakeProfit =  120.358m, OrderCloseTime =      new DateTime(2017,04,06,19,21,45),ClosePrice =    118.082m , Swap = - 3.43m, Profit = - 36.25m},
                new ForexTransaction{ Order = 7895774, OrderOpenTime = new DateTime( 2017,04,11,16,51,57), OrderType = OrderType.Sell, LotSize = 0.4m, Symbol = "chfjpy", OrderPrice =     109.171m, StopLoss =  108.969m, TakeProfit =  106.68m, OrderCloseTime =      new DateTime(2017,04,12,09,16,46),ClosePrice =    108.969m , Swap =   0.07m, Profit =    69.35m},
                new ForexTransaction{ Order = 7903059, OrderOpenTime = new DateTime( 2017,04,13,15,01,39), OrderType = OrderType.Sell, LotSize = 0.4m, Symbol = "eurnzd", OrderPrice =     1.51592m, StopLoss =  1.51335m, TakeProfit =  1.49066m, OrderCloseTime =     new DateTime(2017,04,17,08,17,02),ClosePrice =    1.51337m , Swap =   3.89m, Profit =    67.4m},
                new ForexTransaction{ Order = 7980496, OrderOpenTime = new DateTime( 2017,04,12,19,34,43), OrderType = OrderType.Buy, LotSize = 0.4m, Symbol = "eurnzd", OrderPrice =     1.5319m, StopLoss =   1.53391m, TakeProfit =  1.54371m, OrderCloseTime =      new DateTime(2017,04,12,21,19,00),ClosePrice =    1.53384m , Swap =   0m, Profit =   50.59m},
                new ForexTransaction{ Order = 8102460, OrderOpenTime = new DateTime( 2017,04,18,13,30,00), OrderType = OrderType.Buy, LotSize = 0.16m,   Symbol = "gbpjpy", OrderPrice =     137.947m, StopLoss =  135.448m, TakeProfit =  138.948m, OrderCloseTime =   new DateTime(2017,04,18,19,41,22),ClosePrice =    138.968m , Swap =   0m, Profit =   140.56m},
                new ForexTransaction { Order = 8139668, OrderOpenTime = new DateTime(2017, 04, 18, 20, 00, 01), OrderType = OrderType.Buy, LotSize = 0.32m, Symbol = "gbpjpy", OrderPrice = 139.193m, StopLoss = 136.697m, TakeProfit = 140.197m, OrderCloseTime = new DateTime(2017, 04, 20, 16, 10, 48), ClosePrice = 140.198m, Swap = -1.67m, Profit = 273m }
            };
            foreach (var transaction in transactions)
            {
                context.ForexTransactions.Add(transaction);
            }

            var robots = new Robot[]
            {
                new Robot
                {
                    Name = "FXStabilizer AUD 1.4_466277",
                    PurchaseDate = new DateTime(2017, 5, 28),
                    Price = 948.05m,
                    CurrencySymbol = "CHF"
                },
                new Robot
                {
                    Name = "FXStabilizer_EUR 1.4_466278",
                    PurchaseDate = new DateTime(2017, 5, 28),
                    Price = 948.05m,
                    CurrencySymbol = "CHF"
                },
                new Robot
                {
                    Name = "Foreximba_1_1_612607",
                    PurchaseDate = new DateTime(2017, 5, 28),
                    Price = 948.05m,
                    CurrencySymbol = "CHF"
                },
                new Robot
                {
                    Name = "inControl Reborn Full 2.03_466280",
                    PurchaseDate = new DateTime(2017, 5, 28),
                    Price = 948.05m,
                    CurrencySymbol = "CHF"
                },
                new Robot
                {
                    Name = "inControl Reborn Full 2.03_466280",
                    PurchaseDate = new DateTime(2017, 5, 28),
                    Price = 948.05m,
                    CurrencySymbol = "CHF"
                },
                new Robot
                {
                    Name = "RT_GBPCHF_1Hour_Trend",
                    PurchaseDate = new DateTime(2017, 3, 16),
                    Price = 149m,
                    CurrencySymbol = "USD"
                },
                new Robot
                {
                    Name = "FXSecret_1_AUDUSD_1.3_465583",
                    PurchaseDate = new DateTime(2017, 5, 28),
                    Price = 948.05m,
                    CurrencySymbol = "CHF"
                },
                new Robot
                {
                    Name = "FXSecret_2_EURUSD_1.3_465583",
                    PurchaseDate = new DateTime(2017, 5, 28),
                    Price = 948.05m,
                    CurrencySymbol = "CHF"
                },
                new Robot
                {
                    Name = "FXSecret_3_USDJPY_1.3_465583",
                    PurchaseDate = new DateTime(2017, 5, 28),
                    Price = 948.05m,
                    CurrencySymbol = "CHF"
                },
                new Robot
                {
                    Name = "RT_GBPJPY-15min_Trend-Following-Cumulative",
                    PurchaseDate = new DateTime(2017, 3, 16),
                    Price = 149m,
                    CurrencySymbol = "USD"
                },
                new Robot
                {
                    Name = "RT_GBPJPY-30M_Consolidation_Cumulative_StayAtMax",
                    PurchaseDate = new DateTime(2017, 3, 16),
                    Price = 149m,
                    CurrencySymbol = "USD"
                },
                new Robot
                {
                    Name = "RT_GBPJPY-15min_Momentum",
                    PurchaseDate = new DateTime(2017, 8, 13),
                    Price = 29m,
                    CurrencySymbol = "USD"
                },
                new Robot {Name = "Zorro Z12"},
                new Robot
                {
                    Name = "FXCharger_Advanced 1.6_466279",
                    PurchaseDate = new DateTime(2017, 5, 28),
                    Price = 948.05m,
                    CurrencySymbol = "CHF"
                },
                new Robot
                {
                    Name = "FXCharger_Advanced 1.6_466279",
                    PurchaseDate = new DateTime(2017, 5, 28),
                    Price = 948.05m,
                    CurrencySymbol = "CHF"
                },
                new Robot
                {
                    Name = "FXBuilder",
                    PurchaseDate = new DateTime(2017, 5, 28),
                    Price = 948.05m,
                    CurrencySymbol = "CHF"
                },
                new Robot
                {
                    Name = "FunnelTrader",
                    PurchaseDate = new DateTime(2017, 9, 1),
                    Price = 450.0m,
                    CurrencySymbol = "USD"
                },
                new Robot
                {
                    Name = "ForexTrendDetector_V3.0",
                    PurchaseDate = new DateTime(2017, 6, 09),
                    Price = 948.05m,
                    CurrencySymbol = "CHF"
                },
                new Robot
                {
                    Name = "Harmonic Trader",
                    PurchaseDate = new DateTime(2017, 6, 13),
                    Price = 299.0m,
                    CurrencySymbol = "EUR"
                },
                new Robot
                {
                    Name = "Inertia Trader",
                    PurchaseDate = new DateTime(2017, 6, 21),
                    Price = 347m,
                    CurrencySymbol = "USD"
                },
                new Robot
                {
                    Name = "Volatility Factor 2.0",
                    PurchaseDate = new DateTime(2017, 6, 13),
                    Price = 137m,
                    CurrencySymbol = "USD"
                },
                new Robot
                {
                    Name = "FX-Splitter",
                    PurchaseDate = new DateTime(2017, 6, 13),
                    Price = 299m,
                    CurrencySymbol = "CHF"
                },
                new Robot
                {
                    Name = "Harmonic Trader",
                    PurchaseDate = new DateTime(2017, 6, 28),
                    Price = 209.30m,
                    CurrencySymbol = "EUR"
                }

            };
            foreach (var robot in robots)
            {
                context.Robots.Add(robot);
            }

            var banks = new Bank[]
            {
                new Bank { Name = "Swissquote"},
                new Bank { Name = "AxiTrader" },
                new Bank { Name = "Oanda" }
            };

            foreach (var bank in banks)
            {
                context.Banks.Add(bank);
            }

            var bankaccounts = new BankAccount[]
            {
                new BankAccount { MT4_Login = "610428", Currency = "EUR"},
                new BankAccount { MT4_Login = "612954", Currency = "EUR" },
                new BankAccount { MT4_Login = "612607", Currency = "USD" },
                new BankAccount { MT4_Login = "615658", Currency = "CHF" },
                new BankAccount { MT4_Login = "615657", Currency = "CHF" }
            };

            foreach (var bankAccount in bankaccounts)
            {
                context.BankAccounts.Add(bankAccount);
            }

            context.SaveChanges();
        }
    }
}
