using PointOfSale;
using PointOfSale.Domain.Inventory.Products;
using PointOfSale.Domain.Inventory.StockLevel;
using PointOfSale.Domain.Sales;
using PointOfSale.Tests.TestDoubles;

public class SaleTestContext
{
    // This context provides the standard setup for testing the Sale class.
    public TestProductSpecification Product { get; }
    public IProductCatalogue Catalogue { get; }
    public InventoryManagement Inventory { get; }
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
        Product = new TestProductSpecification(productId, description, sellPrice);

        Catalogue = new ProductCatalogue();
        Catalogue.AddProduct(Product);

        Inventory = new InventoryManagement();
        Inventory.IncreaseStock(productId, quantityOnHand);

        Customer = customer;

        Sale = new Sale(Customer, Inventory, Catalogue);
    }
}
