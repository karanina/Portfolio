using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class PricingRules
    {
        public string item { get; set; }
        public decimal unitPrice { get; set; }
        //public string specialPrice { get; set; }
        public List<string> specialPrices { get; set; }

        public PricingRules()
        {
            // default constructor
            this.item = "";
            this.unitPrice = 0;
            this.specialPrices = new List<string>();
        }

        // constructor for an item with a special price as well as a unit price.
        public PricingRules(string item, decimal unitPrice, string specialPrice)
        {
            if (unitPrice > 0)
            {
                this.item = item;
                this.unitPrice = unitPrice;
                this.specialPrices = new List<string>() { specialPrice };
              //  this.specialPrice = specialPrice;
                    }
            else
            {
                throw new ArgumentException("Unit price cannot be negative", "unitPrice");
            }
        }

        // constructor for an item with only a unit price.
        public PricingRules(string item, decimal unitPrice)
        {
            if (unitPrice > 0)
            {
                this.item = item;
                this.unitPrice = unitPrice;
                this.specialPrices = new List<string>();
              //  this.specialPrice = "";
            }
            else
            {
                throw new ArgumentException("Unit price cannot be negative", "unitPrice");
            }
        }
    }
}
