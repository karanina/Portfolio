using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class Checkout
    {
        // the current rules for pricing an item.
        public List<PricingRules> pricingRules;

        // key is item identifier, value is quantity of item in cart.
        public Dictionary<String, decimal> cart;

        public Checkout()
        {
            this.pricingRules = new List<PricingRules>();
            this.cart = new Dictionary<String, decimal>();
        }

        // adds a new pricing rule to the pricingRules list if one doesn't already exist
        public void New(PricingRules rule)
        {
            if (!PricingRuleExists(rule.item))
            {
                this.pricingRules.Add(rule);
            }
            else
            {
                throw new ArgumentException("Pricing rule already exists for this item", "item");
            }
        }

        // checks whether there is already a rule for a particular item
        public bool PricingRuleExists(string item)
        {
            return this.pricingRules.Any(pr => pr.item == item);
        }

        // finds a pricing rule by item code in the pricingRules list
        public PricingRules GetPricingRuleByItemCode(string item)
        {
            return this.pricingRules.FirstOrDefault(pr => pr.item.Contains(item))
                ?? new PricingRules();
        }

        // adds an item to the cart
        public void Scan(String item)
        {
            if (PricingRuleExists(item))
            {
                AddToCart(item);
            }
            else
            {
                throw new ArgumentException($"{item} does not have a corresponding Pricing Rule", "item");
            }
        }

        public void AddToCart(string item)
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
                // get the pricing rule for the item in the cart
                PricingRules rule = GetPricingRuleByItemCode(item.Key);
                if (!string.IsNullOrWhiteSpace(rule.specialPrice))
                {
                    total += CalculateLineTotalSpecialPrice(
                        rule.specialPrices,
                        rule.specialPrice,
                        rule.unitPrice,
                        item.Value
                    );
                }
                else
                {
                    total += CalculateLineTotalUnitPrice(rule.unitPrice, item.Value);
                }
            }
            /// don't need to round here as both calculation methods called return a 
            /// rounded number to 2 decimal places
            return total;
        }

        // calculates the line total for an item in the cart.
        public decimal CalculateLineTotalUnitPrice(decimal unitPrice, decimal quantity)
        {
            return Math.Round(unitPrice * quantity, 2);
        }

        // calculates the line total for an item in the cart where a special price is applicable.
        public decimal CalculateLineTotalSpecialPrice(List<string> specialPrices, decimal quantity)
        {
            // used to keep track of muliple rounds of special price application.
            decimal remainingQuantity = quantity;
            decimal lineTotal = 0;

            (decimal multiQty, decimal multiPrice) = ExtractSpecialPrice(specialPrices, quantity);

            while ((remainingQuantity / multiQty) >= 1)
            {
                lineTotal += multiPrice;
                remainingQuantity -= multiQty;
            }
            lineTotal += CalculateLineTotalUnitPrice(unitPrice, remainingQuantity);

            return Math.Round(lineTotal, 2);
        }

        /// <summary>
        /// Extracts the decimal values from a specialPrice string.
        /// Assumes that when there is only 1 decimal value it is the price, rather than an applicable quantity.
        /// This way both "3 for 45" and "1.55 per gram" type formats are caught.
        /// In the caes of "1.55 per gram" type formats, multiQty is returned as 1.
        /// </summary>
        /// <param name="specialPrice"></param>
        /// <returns>multiQty -  the quantity applicable for the multibuy
        /// multiPrice - the price applicable for the multibuy</returns>
        /// <exception cref="ArgumentException"></exception>
        public (decimal, decimal) ExtractSpecialPrice(List<string> specialPrices, decimal quantity)
        {
            decimal multiQty = 0;
            decimal multiPrice = 0;
            List<(decimal, decimal)> validSpecials = new List<(decimal, decimal)>();

            if (specialPrices.Count >= 1)
            {
                for (int k = 0; k < specialPrices.Count; k++)
                {

                    string[] parts = specialPrices[k].Split();

                    for (int i = 0; i < parts.Length; i++)
                    {
                        if (parts[i].Contains("$"))
                        {
                            parts[i] = parts[i].Replace("$", "");
                        }
                        if (decimal.TryParse(parts[i], out decimal num))
                        {
                            if (multiPrice == 0)
                            {
                                multiPrice = num;
                            }
                            else
                            {
                                multiQty = multiPrice;
                                multiPrice = num;
                            }
                        }

                        if (multiQty >= quantity)
                        {
                            validSpecials.Add((multiQty, multiPrice));
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Special Price is empty.", "specialPrice");
            }
            // 
            int bestMatch = 0;
            if (validSpecials.Count > 1)
            {
                for (int i = 0; i < validSpecials.Count - 1; i++)
                {
                    (var mQty1, var mPrice1 ) = validSpecials[i];
                    (var mQty2, var mPrice2) = validSpecials[i + 1];

                    if (mQty1 > mQty2)
                    {
                        bestMatch = i;
                    }
                }
                return validSpecials[bestMatch];
            }
            else
            {
                return validSpecials[0];
            }
            // for (int j = 0, j < qualified

            if (multiQty == 0 && multiPrice == 0)
                {
                    throw new ArgumentException("Special Price format is not recognised.", "specialPrice");
                }

                // if there is only one decimal in the string, return a 1 so the total calculation methods don't break.
                multiQty = (multiQty == 0) ? 1 : multiQty;
                return (multiQty, multiPrice);
            }




            // multiQty is the quantity applicable for the multibuy
            // multiPrice is the price applicable for the multibuy
            //public (decimal, decimal) ExtractSpecialPrice(string specialPrice)
            //{
            //    // this works for strings like "3 for 20"
            //    string[] parts = specialPrice.Split();

            //    if (parts.Contains("for"))
            //    {
            //        decimal.TryParse(parts[0], out decimal multiQty);
            //        decimal.TryParse(parts[2], out decimal multiPrice);

            //        return (multiQty, multiPrice);
            //    }
            //    else
            //    {
            //        throw new ArgumentException("Special Price format is not recognised.", "specialPrice");
            //    }
            //}
        }
    }
