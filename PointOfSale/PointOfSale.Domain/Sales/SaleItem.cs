using PointOfSale.Domain.Inventory.Products;
using PointOfSale.Domain.Shared;

namespace PointOfSale.Domain.Sales
{
    // Represents an individual item in a sale.
    // It is used for write operations and contains methods to modify the item, such as changing quantity, applying discounts,
    // or overriding the unit price.
    public class SaleItem
    {
        public string ProductId { get; }

        public string Description { get; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }

        // Customer discounts can be applied in Sale Calculator, but the user MAY manually override the discount rate for a specific item.
        // This property captures that manual override, if any.
        public int? ManualDiscountRate { get; private set; } // percentage as whole number

        // a flag to indicate if the sell price was manually overridden, and therefore not eligible for further discounts
        public bool IsManualUnitPrice { get; private set; }

        // Do not use constructor directly in production code, as it does not enforce creation of SaleItem objects with data
        // from product catalogue.
        // Use CreateFromProductSpecification factory method instead.
        private SaleItem(string productId, string description, decimal unitPrice, int quantity)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentException(
                    "Product ID cannot be null or whitespace.",
                    nameof(productId)
                );
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException(
                    "Description cannot be null or whitespace.",
                    nameof(description)
                );
            }
            ProductId = productId;
            Description = description;

            ValidateUnitPrice(unitPrice);
            UnitPrice = unitPrice;

            ValidateQuantity(quantity);
            Quantity = quantity;

            IsManualUnitPrice = false;
        }

        // To be used in production to create SaleItem objects from ProductSpecification,
        // which is the source of truth for product data in our system.
        // This factory method ensures that only valid SaleItems can be created.
        public static SaleItem CreateFromProductSpecification(
            ProductSpecification product,
            int quantity
        )
        {
            if (product == null)
            {
                throw new ArgumentNullException(
                    nameof(product),
                    "Product specification must be provided to create a sale item."
                );
            }
            return new SaleItem(
                product.ProductId,
                product.Description,
                product.SellPrice,
                quantity
            );
        }

        private static void ValidateQuantity(int quantity)
        {
            if (quantity < 1)
            {
                throw new QuantityException("Quantity cannot be less than 1.");
            }
        }

        private static void ValidateUnitPrice(decimal unitPrice)
        {
            if (unitPrice < 0)
            {
                throw new PriceException("Unit price cannot be negative.");
            }
        }

        public void IncreaseQuantity(int quantity)
        {
            ValidateQuantity(quantity);
            Quantity += quantity;
        }

        public void ChangeQuantity(int newQuantity)
        {
            ValidateQuantity(newQuantity);
            Quantity = newQuantity;
        }

        public void OverrideUnitPrice(decimal newUnitPrice)
        {
            ValidateUnitPrice(newUnitPrice);
            UnitPrice = newUnitPrice;
            IsManualUnitPrice = true;
            // Clear any manual discount rate, as it's not applicable when unit price is manually overridden
            ManualDiscountRate = null;
        }

        public void ApplyManualDiscount(int manualDiscountRate)
        {
            if (manualDiscountRate < 0 || manualDiscountRate > 100)
            {
                throw new DiscountException("Manual discount rate must be between 0 and 100.");
            }
            if (IsManualUnitPrice)
            {
                throw new DiscountException(
                    "Cannot set a manual discount rate when the sell price has been overridden manually."
                );
            }
            ManualDiscountRate = manualDiscountRate;
        }
    }
}
