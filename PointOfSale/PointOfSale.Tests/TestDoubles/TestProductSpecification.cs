using PointOfSale.Inventory.Products;

namespace PointOfSale.Tests.TestDoubles
{
    // This class is a test double for ProductSpecification, allowing us to create ProductSpecification objects
    // for testing purposes, since ProductSpecification is an abstract class and cannot be instantiated directly,
    // but is needed for testing the creation of a SaleItem in various Sales classes.
    public class TestProductSpecification : ProductSpecification
    {
        public TestProductSpecification(string productId, string name, decimal price)
            : base(productId, name, price) { }
    }
}
