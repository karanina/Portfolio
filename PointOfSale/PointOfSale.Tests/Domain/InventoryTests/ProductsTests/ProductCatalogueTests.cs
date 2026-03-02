using PointOfSale.Domain.Inventory.Products;
using PointOfSale.Tests.TestDoubles;
using Xunit;

namespace PointOfSale.Tests.Domain.InventoryTests.ProductsTests
{
    public class ProductCatalogueTests
    {
        [Fact]
        public void Constructor_CreatesEmptyCatalogue()
        {
            // Act
            ProductCatalogue catalogue = new ProductCatalogue();

            // Assert
            Assert.NotNull(catalogue);
            Assert.Empty(catalogue.GetAllProducts());
        }

        [Fact]
        public void AddProduct_AddsProductSpecificationToCatalogue()
        {
            // Arrange
            ProductCatalogue catalogue = new ProductCatalogue();
            TestProductSpecification product = new TestProductSpecification(
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
            ProductCatalogue catalogue = new ProductCatalogue();
            TestProductSpecification product1 = new TestProductSpecification(
                "B0001-65mm-9Y",
                "Test Product 1",
                199.99m
            );
            TestProductSpecification product2 = new TestProductSpecification(
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
            Assert.Equal(
                $"A product with ID {product2.ProductId} already exists in the catalogue.",
                exception.Message
            );
            Assert.Equal(1, catalogue.GetCatalogueSize());
        }

        [Fact]
        public void GetByProductId_ReturnsCorrectProduct()
        {
            // Arrange
            ProductCatalogue catalogue = new ProductCatalogue();
            TestProductSpecification product1 = new TestProductSpecification(
                "B0001-65mm-9Y",
                "Test Product",
                199.99m
            );

            TestProductSpecification product2 = new TestProductSpecification(
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
