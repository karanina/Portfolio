using PointOfSale.Domain;
using PointOfSale.Domain.Inventory.Products;
using PointOfSale.Domain.Inventory.StockLevel;
using PointOfSale.Domain.Sales;
using PointOfSale.Tests.TestDoubles.Dummies;
using PointOfSale.Tests.TestDoubles.Fakes;

namespace PointOfSale.Tests.TestFixtures
{
    public class SaleTestContext
    {
        // This context provides the standard setup for testing the Sale class.
        public ProductSpecification Product { get; }
        public IProductCatalogue Catalogue { get; }
        public IInventoryManagement Inventory { get; }
        public Customer Customer { get; }
        public Sale Sale { get; }

        public SaleTestContext(
            string productId,
            int quantityOnHand,
            string description,
            decimal sellPrice,
            Customer customer
        )
        {
            Product = new DummyProductSpecification(productId, description, sellPrice);

            Catalogue = new FakeProductCatalogue();
            Catalogue.AddProduct(Product);

            Inventory = new FakeInventoryManagement();
            Inventory.IncreaseStock(productId, quantityOnHand);

            Customer = customer;

            Sale = new Sale(1, Customer, Inventory, Catalogue);
        }
    }
}
