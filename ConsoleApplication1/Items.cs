using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Items
    {
        /// <summary>
        /// Returning List of Items
        /// </summary>
        /// <returns></returns>
        public List<SodaItems> GetSodaItems()
        {
            return new List<SodaItems>()
            {
                {new Drink("coke", 20, 5)},
                {new Drink("sprite", 15, 5)},
                {new Drink("fanta", 15, 5)}
            };
        }

    }
}
