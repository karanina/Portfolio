using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Checkout;

public class PricingRules
{
    public string item { get; set; }
    public decimal unit_price { get; set; }
    public string special_price { get; set; }

    public PricingRules()
    {
        // default constructor
        this.item = "";
        this.unit_price = 0;
        this.special_price = "";
    }

    // constructor for an item with a special price as well as a unit price.
    public PricingRules(string item, decimal unit_price, string special_price)
    {
        this.item = item;
        this.unit_price = unit_price;
        this.special_price = special_price;
    }

    // constructor for an item with only a unit price.
    public PricingRules(string item, decimal unit_price)
    {
        this.item = item;
        this.unit_price = unit_price;
        this.special_price = "";
    }
}
