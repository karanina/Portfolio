using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout;

namespace Checkout.Tests
{
    public static class TestSetup
    {
        // for tests where multiple PricingRules need to be added to the Pricing Rules list before the test begins.
        public static void SetUp_PricingRules(Checkout co)
        {
            co.New(new PricingRules("A", 50, "3 for 130"));
            co.New(new PricingRules("B", 30, "2 for 45"));
            co.New(new PricingRules("C", 20));
            co.New(new PricingRules("D", 15));
        }

        // for tests where multiple PricingRules need to be added to the cart before the test begins.
        public static void SetUp_Cart(Checkout co, string[] items)
        {
            foreach (string item in items)
            {
                co.Scan(item);
            }
        }

        public static IEnumerable<object[]> SetUp_CheckoutTotalTestData()
        {
            yield return new object[] { 50m, new string[] { "A" } }; // single item
            yield return new object[] { 80m, new string[] { "A", "B" } }; // 2 different items
            yield return new object[] { 115m, new string[] { "C", "D", "B", "A" } }; // 1 of each item
            yield return new object[] { 100m, new string[] { "A", "A" } }; // 2 of the same items
            yield return new object[] { 130m, new string[] { "A", "A", "A" } }; // 1 multibuy
            yield return new object[] { 180m, new string[] { "A", "A", "A", "A" } }; // multibuy plus 1 extra
            yield return new object[] { 230m, new string[] { "A", "A", "A", "A", "A" } }; // multibuy plus 2 extra
            yield return new object[] { 260m, new string[] { "A", "A", "A", "A", "A", "A" } }; // 2 multibuys
            yield return new object[] { 160m, new string[] { "A", "A", "A", "B" } }; // 1 multibuy plus 1 other item
            yield return new object[] { 175m, new string[] { "A", "A", "A", "B", "B" } }; // 2 different multibuys
            yield return new object[] { 190m, new string[] { "A", "A", "A", "B", "B", "D" } }; // 2 different multibuys plus 1 other item

            // 2 different multibuys plus 1 other item - non ordered
            yield return new object[] { 190m, new string[] { "D", "A", "B", "A", "B", "A" } };

        }
    }
}
