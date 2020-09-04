using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Money
    {
        /// <summary>
        /// initializing money
        /// </summary>
        public Money()
        {
            this.MoneyInMachine = 0M;
        }

        public decimal MoneyInMachine { get; private set; }
        /// <summary>
        /// Adding money 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool AddMoney(string amount)
        {
            if (!decimal.TryParse(amount, out var amountInserted))
            {
                amountInserted = 0M;
                return false;
            }
            // Add the money
            this.MoneyInMachine += amountInserted;
            return true;
        }
        /// <summary>
        /// Deducting money 
        /// </summary>
        /// <param name="amountToRemove"></param>
        /// <returns></returns>
        public bool RemoveMoney(decimal amountToRemove)
        {
            if (this.MoneyInMachine <= 0)
            {
                return false;
            }

            this.MoneyInMachine -= amountToRemove;
            return true;
        }
    }
}
