using PointOfSale.Application.Sales;
using PointOfSale.Domain.Inventory.Products;
using PointOfSale.Domain.Inventory.StockLevel;
using PointOfSale.Domain.Sales;
using PointOfSale.Tests.TestDoubles.Dummies;
using PointOfSale.Tests.TestDoubles.Fakes;

namespace PointOfSale.Tests.TestFixtures
{
    public class SaleServiceTestContext
    {
        // This context provides the standard setup for testing the SaleService class.
        public DummyProductSpecification Product { get; }
        public IProductCatalogue Catalogue { get; }
        public IInventoryManagement Inventory { get; }
        public ISaleCalculator Calculator { get; }
        public ISaleIdGenerator IdGenerator { get; }

        public SaleServiceTestContext(
            string productId,
            int quantityOnHand,
            string description,
            decimal sellPrice,
            int saleQuantity
        )
        {
            Product = new DummyProductSpecification(productId, description, sellPrice);

            Catalogue = new FakeProductCatalogue();
            Catalogue.AddProduct(Product);

            Inventory = new FakeInventoryManagement();
            Inventory.IncreaseStock(productId, quantityOnHand);

            Calculator = new FakeSaleCalculator
            {
                Total = sellPrice * saleQuantity,
                GST = sellPrice * saleQuantity * 0.15m,
            };
            IdGenerator = new FakeSaleIdGenerator();

        }
    }
}
