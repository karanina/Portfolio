namespace PointOfSale.Application.Sales
{
    public record ReceiptItemDto
    {
        // This DTO represents an individual item on the receipt, including product details and pricing information.
        // Is a record type as it is a snapshot of the item details at the time of purchase and should be immutable.

        public string ProductId { get; }
        public string ProductDescription { get; }
        public int Quantity { get; }
        public decimal UnitPrice { get; }
        public decimal LineTotal { get; }

        public ReceiptItemDto(
            string productId,
            string productDescription,
            int quantity,
            decimal unitPrice,
            decimal lineTotal
        )
        {
            ProductId = productId;
            ProductDescription = productDescription;
            Quantity = quantity;
            UnitPrice = unitPrice;
            LineTotal = lineTotal;
        }
    }
}
