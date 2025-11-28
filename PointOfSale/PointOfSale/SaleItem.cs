using System;

namespace PointOfSale
{
    public class SaleItem
    {
        // TODO: Add validation to check that the Id is currently in stock in inventory management.
        public string Id { get; set; }
        public string Description { get; set; }
        public decimal SellPrice { get; set; }
        public int Quantity { get; set; }
        public int ManualDiscountRate { get; set; } // percentage as whole number

        // a flag to indicate if the sell price was manually overridden, and therefore not eligible for further discounts
        // TO DO: have this set when the sell price differs from the product price in inventory management.
        public bool IsManualUnitPrice { get; set; }

        public SaleItem(
            // Required parameters
            string id,
            string description,
            decimal sellPrice,
            // Optional parameters
            int quantity = 1,
            int manualDiscountRate = 0,
            bool isManualUnitPrice = false
        )
        {
            Id = id;
            Description = description;

            UpdateSellPrice(sellPrice);

            UpdateQuantity(quantity);

            ValidateManualDiscountRate(manualDiscountRate, isManualUnitPrice);
            ManualDiscountRate = manualDiscountRate;
            IsManualUnitPrice = isManualUnitPrice;
        }

        public void ValidateQuantity(int quantity)
        {
            if (quantity < 1)
            {
                throw new ArgumentException("Quantity must be at least 1.");
            }
        }

        public void ValidateSellPrice(decimal sellPrice)
        {
            if (sellPrice < 0)
            {
                throw new ArgumentException("Sell price cannot be negative.");
            }
        }

        public void ValidateManualDiscountRate(int manualDiscountRate, bool isManualUnitPrice)
        {
            if (manualDiscountRate < 0 || manualDiscountRate > 100)
            {
                throw new ArgumentException("Manual discount rate must be between 0 and 100.");
            }
            if (manualDiscountRate > 0 && isManualUnitPrice)
            {
                throw new ArgumentException(
                    "Cannot set a manual discount rate when the sell price has been overridden manually."
                );
            }
        }

        public void UpdateQuantity(int newQuantity)
        {
            ValidateQuantity(newQuantity);
            Quantity = newQuantity;
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public void UpdateSellPrice(decimal newSellPrice)
        {
            ValidateSellPrice(newSellPrice);
            SellPrice = newSellPrice;
        }
    }
}
