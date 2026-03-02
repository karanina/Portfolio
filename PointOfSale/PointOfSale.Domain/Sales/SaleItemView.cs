namespace PointOfSale.Domain.Sales
{
    // Sealed because we want exposed SaleItem objects to be read only views of the underlying SaleItem data,
    // and we don't want to allow inheritance which could introduce unintended behavior or complexity.
    public sealed class SaleItemView
    {
        public string ProductId { get; }
        public string Description { get; }
        public decimal UnitPrice { get; }
        public int Quantity { get; }
        public int? ManualDiscountRate { get; } // percentage as whole number
        public bool IsManualUnitPrice { get; }

        public SaleItemView(
            string productId,
            string description,
            decimal unitPrice,
            int quantity,
            int? manualDiscountRate,
            bool isManualUnitPrice
        )
        {
            ProductId = productId;
            Description = description;
            UnitPrice = unitPrice;
            Quantity = quantity;
            ManualDiscountRate = manualDiscountRate;
            IsManualUnitPrice = isManualUnitPrice;
        }
    }
}
