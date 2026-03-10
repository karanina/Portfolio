namespace PointOfSale.Application.Sales
{
    public class ReceiptDto
    {
        // This DTO (Data Transfer Object) is used to transfer the receipt data from the application layer to the
        // presentation layer (e.g. for displaying the receipt to the user).
        // Is classified as a record type as it is a snapshot and should be immutable.

        public int Id { get; }
        public DateTime SaleDateTime { get; }
        public string CustomerName { get; }
        public decimal SubTotal { get; }
        public decimal GST { get; }
        public decimal Total { get; }
        public decimal AmountPaid { get; }
        public IReadOnlyList<ReceiptItemDto> Items { get; }

        public ReceiptDto(
            int id,
            DateTime saleDateTime,
            string customerName,
            decimal subTotal,
            decimal gst,
            decimal total,
            decimal amountPaid,
            IReadOnlyList<ReceiptItemDto> items
        )
        {
            Id = id;
            SaleDateTime = saleDateTime;
            CustomerName = customerName;
            SubTotal = subTotal;
            GST = gst;
            Total = total;
            AmountPaid = amountPaid;
            Items = items;
        }
    }
}
