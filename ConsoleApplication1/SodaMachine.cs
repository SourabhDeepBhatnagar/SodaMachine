using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 
    /// </summary>
    public class SodaMachine
    {
        #region declarions
        public List<SodaItems> SodaItems = new List<SodaItems>();
        readonly Items _items = new Items();
        public Money Money { get; }
        /// <summary>
        /// 
        /// </summary>
        public SodaMachine()
        {
            this.SodaItems = _items.GetSodaItems();
            this.Money = new Money();
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal MoneyInMachine
        {
            get
            {
                return this.Money.MoneyInMachine;
            }
        }
        #endregion
        #region Methods
        /// <summary> 
        /// Returning the Item back
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public SodaItems ItemExists(string itemName)
        {
            return SodaItems.FirstOrDefault(x => x.Name == itemName);
        }
        /// <summary>
        /// Retrieving Items from collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public SodaItems RetrieveItem(SodaItems item)
        {
            if (this.Money.MoneyInMachine >= item.Price && item.ItemsRemaining > 0 && item.RemoveItem())
            {
                // Remove the money
                this.Money.RemoveMoney(item.Price);
                return item;
            }
            return null;
        }
     #endregion
    }
}
