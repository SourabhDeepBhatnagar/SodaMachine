using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Menu
    {
        /// <summary>
        /// Displaying content
        /// </summary>
        public void Display()
        {
            while (true)
            {
                var sodaMachine = new SodaMachine();
                var subMenu = new SubMenu(sodaMachine);
                subMenu.Display(); 
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
