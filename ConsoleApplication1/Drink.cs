using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// Class for Items
    /// </summary>
    public class Drink : SodaItems
    {
        public Drink(
            string productName,
            decimal price,
            int itemsRemaining)
            : base(
                productName,
                price,
                itemsRemaining)
        {
        }
    }
}
