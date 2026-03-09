using PointOfSale.Domain.Sales;

namespace PointOfSale.Tests.TestDoubles.Fakes
{
    public class FakeSaleCalculator : ISaleCalculator
    {
        public decimal Total { get; set; } = 100m;
        public decimal GST { get; set; } = 15m;

        public decimal CalculateLineTotal(Sale sale, SaleItemView item)
        {
            return item.UnitPrice * item.Quantity;
        }

        public decimal CalculateTotal(Sale sale)
        {
            return Total;
        }

        public decimal CalculateGST(Sale sale, int gstRate)
        {
            return GST;
        }
    }
}
