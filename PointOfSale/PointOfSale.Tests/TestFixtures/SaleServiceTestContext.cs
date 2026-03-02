using PointOfSale.Domain.Inventory.Products;
using PointOfSale.Domain.Inventory.StockLevel;
using PointOfSale.Domain.Sales;
using PointOfSale.Tests.TestDoubles;

namespace PointOfSale.Tests.TestFixtures
{
    public class SaleServiceTestContext
    {
        // This context provides the standard setup for testing the SaleService class.
        public TestProductSpecification Product { get; }
        public IProductCatalogue Catalogue { get; }
        public InventoryManagement Inventory { get; }
        public SaleCalculator Calculator { get; }

        public SaleServiceTestContext(
            string productId,
            int quantityOnHand,
            string description,
            decimal sellPrice
        )
        {
            Product = new TestProductSpecification(productId, description, sellPrice);

            Catalogue = new ProductCatalogue();
            Catalogue.AddProduct(Product);

            Inventory = new InventoryManagement();
            Inventory.IncreaseStock(productId, quantityOnHand);
            
            Calculator = new SaleCalculator();
        }
    }
}
