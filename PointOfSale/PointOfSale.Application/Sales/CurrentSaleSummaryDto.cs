namespace PointOfSale.Application.Sales
{
    public record CurrentSaleSummaryDto
    {
        public string CustomerName { get; }
        public decimal Subtotal { get; }
        public decimal Total { get; }
        public decimal GST { get; }
        public IReadOnlyList<ReceiptItemDto> Items { get; }

        public CurrentSaleSummaryDto(
            string customerName,
            decimal subtotal,
            decimal total,
            decimal gst,
            IReadOnlyList<ReceiptItemDto> items
        )
        {
            CustomerName = customerName;
            Subtotal = subtotal;
            Total = total;
            GST = gst;
            Items = items;
        }
    }
}
