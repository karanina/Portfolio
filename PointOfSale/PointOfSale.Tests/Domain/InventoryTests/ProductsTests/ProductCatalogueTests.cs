using PointOfSale.Domain.Inventory.Products;
using PointOfSale.Tests.TestDoubles.Dummies;
using Xunit;

namespace PointOfSale.Tests.Domain.InventoryTests.ProductsTests
{
    public class ProductCatalogueTests
    {
        [Fact]
        public void Constructor_CreatesEmptyCatalogue()
        {
            // Act
            IProductCatalogue catalogue = new ProductCatalogue();

            // Assert
            Assert.NotNull(catalogue);
            Assert.Empty(catalogue.GetAllProducts());
        }

        [Fact]
        public void AddProduct_AddsProductSpecificationToCatalogue()
        {
            // Arrange
            IProductCatalogue catalogue = new ProductCatalogue();
            ProductSpecification product = new DummyProductSpecification(
                "B0001-65mm-9Y",
                "Test Product",
                199.99m
            );

            // Act
            catalogue.AddProduct(product);

            // Assert
            Assert.Equal(1, catalogue.GetCatalogueSize());
            Assert.Equal(product, catalogue.GetByProductId(product.ProductId));
        }

        [Fact]
        public void AddProduct_AddDuplicateProductId_ThrowsException()
        {
            // Arrange
            IProductCatalogue catalogue = new ProductCatalogue();
            ProductSpecification product1 = new DummyProductSpecification(
                "B0001-65mm-9Y",
                "Test Product 1",
                199.99m
            );
            ProductSpecification product2 = new DummyProductSpecification(
                "B0001-65mm-9Y",
                "Test Product 2",
                299.99m
            );
            catalogue.AddProduct(product1);

            // Act & Assert
            var exception = Assert.Throws<DuplicateProductException>(
                () => catalogue.AddProduct(product2)
            );

            // Assert
            Assert.Contains($"{product2.ProductId} already exists", exception.Message);
            Assert.Equal(1, catalogue.GetCatalogueSize());
        }

        [Fact]
        public void GetByProductId_ReturnsCorrectProduct()
        {
            // Arrange
            IProductCatalogue catalogue = new ProductCatalogue();
            ProductSpecification product1 = new DummyProductSpecification(
                "B0001-65mm-9Y",
                "Test Product",
                199.99m
            );

            ProductSpecification product2 = new DummyProductSpecification(
                "B0002-75mm-9Y",
                "Another Test Product",
                299.99m
            );

            catalogue.AddProduct(product1);
            catalogue.AddProduct(product2);

            // Act
            ProductSpecification retrievedProduct = catalogue.GetByProductId(product1.ProductId);

            // Assert
            Assert.Equal(product1, retrievedProduct);
        }
    }
}
