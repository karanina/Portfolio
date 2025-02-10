using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;

namespace Checkout;

public class Checkout
// considered making this a static class, but decided against it as in real life you would
// have more than one user shopping at once.
{
    // the current rules for pricing an item.
    public List<PricingRules> pricing_rules = new List<PricingRules>();

    // key is item identifier, value is quantity of item in cart.
    public Dictionary<String, decimal> cart = new Dictionary<String, decimal>();

    // adds a new pricing rule to the pricing_rules list
    public void New(PricingRules pricing_rules)
    {
        this.pricing_rules.Add(pricing_rules);
    }

    // finds a pricing rule by item code in the pricing_rules list
    public PricingRules GetPricingRuleByItemCode(string searchItem)
    {
        return pricing_rules.FirstOrDefault(pr => pr.item.Contains(searchItem))
            ?? new PricingRules();
    }

    // adds an item to the cart
    public void Scan(String item)
    {
        // if the cart already contains the item, add one the cart's value (is quantity).
        if (this.cart.ContainsKey(item))
        {
            this.cart[item] += 1;
        }
        else
        {
            // else, add the key to the cart with an initial value (quantity) of 1.
            this.cart[item] = 1;
        }
    }

    // totals the items in the cart.
    public decimal Total()
    {
        decimal total = 0;
        foreach (var item in this.cart)
        {
            // get the pricing rule for the
            PricingRules pricingRule = GetPricingRuleByItemCode(item.Key);
            Console.WriteLine("Item: " + item.Key);
            if (pricingRule.special_price != "")
            {
                total += CalculateLineTotalSpecialPrice(
                    pricingRule.special_price,
                    pricingRule.unit_price,
                    item.Value
                );
            }
            else
            {
                total += CalculateLineTotalUnitPrice(pricingRule.unit_price, item.Value);
            }
        }

        return total;
    }

    // calculates the line total for an item in the cart.
    public decimal CalculateLineTotalUnitPrice(decimal unitPrice, decimal quantity)
    {
        return unitPrice * quantity;
    }

    // calculates the line total for an item in the cart where a special price is applicable.
    public decimal CalculateLineTotalSpecialPrice(
        string specialPrice,
        decimal unitPrice,
        decimal quantity
    )
    {
        // this works for strings like "3 for 20"
        string[] parts = specialPrice.Split();
        // the quantity applicable for the multibuy
        decimal multiQty = Convert.ToDecimal(parts[0]);
        // the price applicable for the multibuy
        decimal multiPrice = Convert.ToDecimal(parts[2]);
        // used to keep track of muliple rounds of special price application.
        decimal remainingQuantity = quantity;
        decimal lineTotal = 0;

        while ((remainingQuantity / multiQty) >= 1)
        {
            Console.WriteLine(
                $"Remaining Quantity: {remainingQuantity}, Multibuy Quantity: {multiQty}, Multibuy Price: {multiPrice}"
            );
            lineTotal += multiPrice;
            remainingQuantity -= multiQty;
            Console.WriteLine(
                $"Remaining Quantity after multiQuantity deuction: {remainingQuantity}"
            );
        }
        Console.WriteLine($"Remaining Quantity: {remainingQuantity}");
        lineTotal += CalculateLineTotalUnitPrice(unitPrice, remainingQuantity);
        Console.WriteLine("line total: " + lineTotal);
        return lineTotal;
    }
}
