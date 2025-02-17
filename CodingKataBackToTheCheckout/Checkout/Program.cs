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
            rules.Add(new PricingRules("B", 30, "$45 per gram"));
            rules.Add(new PricingRules("C", 20));
            rules.Add(new PricingRules("D", 15));

            Checkout co = new Checkout();

            foreach (var rule in rules)
            {
                co.New(rule);
            }

            string[] shoppingList = new string[]
            {
            "A",
            "B",
            "C",
            "D",//
            "A",
            "B",
            "C",
            "D",//
            "A",
            "B",
            "C",
            "D",//
            "A",
            "B",
            "C",
            "D",//
            };

            foreach (string item in shoppingList)
            {
                co.Scan(item);
            }

          //  Console.WriteLine("Total of the shopping list comes to: " + co.Total());

            Console.WriteLine(co.ExtractSpecialPrice("three for one hundred and thirty"));
        }
    }
}
