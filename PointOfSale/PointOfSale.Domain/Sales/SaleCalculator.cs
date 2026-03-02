namespace PointOfSale.Domain.Sales
{
    // A policy class responsible for calculating line totals, applying discounts, and generating the final total.
    public class SaleCalculator
    {
        // Calculates the line total for a single SaleItem.
        // If there is a manual discount rate on the item it is used instead of the Customer's discount rate.
        // If the unit price is manually overridden, no discount is applied.
        public decimal CalculateLineTotal(Sale sale, SaleItemView item)
        {
            // Guard clause to ensure a valid SaleItem is provided.
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Valid sale item must be included");
            }

            decimal baseTotal = item.UnitPrice * item.Quantity;

            if (item.IsManualUnitPrice)
            {
                return Math.Round(baseTotal, 2);
            }

            // uses null coalescing operator to default to customer's discount rate if ManualDiscountRate is not set on the item
            int discountRate = item.ManualDiscountRate ?? sale.Customer.DiscountRate;

            return Math.Round(baseTotal * (1 - (discountRate / 100m)), 2);
        }

        // Returns the subtotal for the sale by summing the line totals.
        public decimal CalculateSubTotal(Sale sale)
        {
            return sale.GetItems().Sum(item => CalculateLineTotal(sale, item));
        }

        // Returns the GST amount for the sale based on the subtotal. Varying GST rates can be applied here if needed.
        public decimal CalculateGST(Sale sale, int gstRate)
        {
            decimal subTotal = CalculateSubTotal(sale);
            return Math.Round(subTotal - (subTotal / (1 + (gstRate / 100m))), 2);
        }
    }
}
