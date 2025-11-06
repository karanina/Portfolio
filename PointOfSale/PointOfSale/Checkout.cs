using System;

namespace PointOfSale
{
    public class Checkout
    {
        ShoppingCart Cart { get; set; }
        List<decimal> LineTotals { get; set; }

        public Checkout(ShoppingCart cart)
        {
            Cart = cart;
            LineTotals = new List<decimal>();
        }

        // Calculates the line total for a single CartItem and adds it to the LineTotals list.
        // If there is a manual discount rate on the item it is used instead of the Customer's discount rate.
        public void CalculateLineTotal(CartItem item)
        {
            int discountRate = 0;
            if (!item.IsManualUnitPrice)
            {
                if (item.ManualDiscountRate > 0)
                {
                    discountRate = item.ManualDiscountRate;
                }
                else
                {
                    discountRate = Cart.GetCustomerDiscountRate();
                }
            }
            LineTotals.Add(
                Math.Round(item.SellPrice * item.Quantity * (1 - (discountRate / 100m)), 2)
            );
        }

        // Calculates line totals for all items in the cart.
        public void CalculateLineTotals()
        {
            foreach (CartItem item in Cart.GetItems().Values)
            {
                CalculateLineTotal(item);
            }
        }

        // Returns the list of line totals.
        public List<decimal> GetLineTotals()
        {
            return LineTotals;
        }

        // Returns the subtotal for the cart by summing the line totals.
        public decimal CalculateSubTotal()
        {
            CalculateLineTotals();
            return LineTotals.Sum();
        }
    }
}
