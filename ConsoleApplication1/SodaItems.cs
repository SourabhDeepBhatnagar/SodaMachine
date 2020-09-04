using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public abstract class SodaItems
    {
         /// <summary>
        /// The name of the Item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price of the VendingItem
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// How many of each Item remains
        /// </summary>
        public int ItemsRemaining { get; set; }

        /// <summary>
        /// What the menu displays when the VendingItem is vended
        /// </summary>
        public string SuccessMsg { get; set; }

        public string SoldOutMsg { get; set; }


        protected SodaItems(string productName, decimal price, int itemsRemaining)
        {
            this.Name = productName;
            this.Price = price;
            this.ItemsRemaining = itemsRemaining;
            this.SuccessMsg = $"giving {Name} out";
            this.SoldOutMsg = $"No {Name} left";
        }

        /// <summary>
        /// Returns false if it can't get the item
        /// </summary>
        /// <returns>bool</returns>
        public bool RemoveItem()
            {
            if (this.ItemsRemaining > 0)
            {
                this.ItemsRemaining--;
                return true;
            }
            return false;
        }
    }
}
