using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PricingRules> rules = new List<PricingRules>();
            rules.Add(new PricingRules("A", 50, "3 for $130"));
            rules.Add(new PricingRules("B", 30, "2 for 45"));
            rules.Add(new PricingRules("C", 20));
            rules.Add(new PricingRules("D", 15));

            Checkout co = new Checkout();

            foreach (var rule in rules)
            {
                co.New(rule);
            }

            string[] shoppingList = new string[] { "D", "A", "C", "B", "B", "D", "A", "A" };

            foreach (string item in shoppingList)
            {
                co.Scan(item);
            }

          Console.WriteLine("Total of the shopping list comes to: " + co.Total());
        }
    }
}
