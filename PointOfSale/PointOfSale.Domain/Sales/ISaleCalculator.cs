namespace PointOfSale.Domain.Sales
{
    // This interface defines the contract for calculating various aspects of a sale, such as subtotals, discounts, and taxes.
    public interface ISaleCalculator
    {
        decimal CalculateLineTotal(Sale sale, SaleItemView item);
        decimal CalculateTotal(Sale sale);
        decimal CalculateGST(Sale sale, int gstRate);
    }
}
