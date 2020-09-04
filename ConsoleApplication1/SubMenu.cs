using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// Main Logic to display content
    /// </summary>
    public class SubMenu
    {
        private readonly SodaMachine _sodaMachine;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sodaMachine"></param>
        public SubMenu(SodaMachine sodaMachine)
        {
            this._sodaMachine = sodaMachine;
        }
        /// <summary>
        /// Main Method to display content
        /// </summary>
        public void Display()
        {
            while (true)
            {
                Header();
                var input = Console.ReadLine();
                //For Adding money
                if (input != null && input.StartsWith("insert"))
                {
                    var amount = input.Split(' ')[1];
                    if (this._sodaMachine.Money.AddMoney(amount))
                    { 
                        Console.WriteLine("Adding " + this._sodaMachine.MoneyInMachine + " to credit");
                        continue;
                    }
                }
                //For placing order
                if (input != null && input.StartsWith("order"))
                {
                    var soda = input.Split(' ')[1];
                    var item = this._sodaMachine.ItemExists(soda);
                    if (item == null)
                    {
                        Console.WriteLine("No such soda");
                        continue;
                    }
                    else if (!item.Equals(null) && item.ItemsRemaining < 1)
                    {
                        Console.WriteLine(item.SoldOutMsg);
                        continue;
                    }
                    else if (!item.Equals(null) && this._sodaMachine.MoneyInMachine < item.Price)
                    {
                        Console.WriteLine($"need {item.Price - this._sodaMachine.MoneyInMachine} more");
                        continue;
                    }
                    else
                    {
                        this._sodaMachine.RetrieveItem(item);
                        Console.WriteLine($"{item.SuccessMsg} \n Giving {this._sodaMachine.Money.MoneyInMachine} in change");
                        _sodaMachine.Money.RemoveMoney(this._sodaMachine.MoneyInMachine);
                        continue;
                    }

                }
                //For placing order through SMS
                if (input != null && input.StartsWith("sms order"))
                {
                    var soda = input.Split(' ')[2];
                    var item = this._sodaMachine.ItemExists(soda);
                    if (item != null)
                    {
                       if (item.RemoveItem())
                       {
                           Console.WriteLine(item.SuccessMsg);
                           continue;
                       }
                       else
                       {
                           Console.WriteLine(item.SoldOutMsg);
                           continue;
                       }

                    }
                }
                //For rollback whole amount
                if (input != null && input.Equals("recall"))
                {
                    //Give money back
                    Console.WriteLine("Returning " + this._sodaMachine.MoneyInMachine + " to customer");
                    _sodaMachine.Money.RemoveMoney(this._sodaMachine.MoneyInMachine);
                     continue;
                }
                Console.ReadLine();
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        public void Header()
        {
            var sodas = this._sodaMachine.SodaItems.Select(x => x.Name).ToList();
            var products = string.Join(",", sodas);
            Console.WriteLine();
            Console.WriteLine("\n\nAvailable commands:");
            Console.WriteLine("insert (money) - Money put into money slot");
            Console.WriteLine($"order {products} - Order from machines buttons");
            Console.WriteLine($"sms order {products} - Order sent by sms");
            Console.WriteLine("recall - gives money back");
            Console.WriteLine("-------");
            Console.WriteLine("Inserted money: " + this._sodaMachine.MoneyInMachine);
            Console.WriteLine("-------\n\n");
        }
    }
}
