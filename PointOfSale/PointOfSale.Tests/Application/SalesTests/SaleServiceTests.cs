using PointOfSale.Application.Sales;
using PointOfSale.Domain.Inventory.Products;
using PointOfSale.Domain.Inventory.StockLevel;
using PointOfSale.Domain.Sales;
using PointOfSale.Tests.TestFixtures;
using Xunit;

namespace PointOfSale.Tests.Application.SalesTests
{
    public class SaleServiceTests
    {
        // Happy Path workflow tests

        [Fact]
        public void CreateSale_AddItem_MakePayment_CompleteSale_SuccessfulWorkflow()
        {
            // Arrange
            int saleQuantity = 1;

            SaleServiceTestContext context = new SaleServiceTestContext(
                productId: "B0001-65mm-9Y",
                quantityOnHand: 10,
                description: "Test Product",
                sellPrice: 199.99m
            );
            var saleService = new SaleService(
                context.Catalogue,
                context.Inventory,
                context.Calculator
            );

            // Act
            saleService.CreateSale(new Customer(1, "Test customer", 10));
            saleService.AddItem(context.Product.ProductId, saleQuantity);

            decimal subTotal = saleService.GetTotal();

            saleService.MakePayment(context.Product.SellPrice * saleQuantity);

            SaleStatus status = saleService.CompleteSale();

            // Assert
            Assert.True(subTotal > 0);
            Assert.Equal(SaleStatus.Completed, status);
        }

        // Guard tests
        [Fact]
        public void AddItem_WithoutExistingSale_ThrowsException()
        {
            // Arrange
            var saleService = new SaleService(
                new ProductCatalogue(),
                new InventoryManagement(),
                new SaleCalculator()
            );

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(
                () => saleService.AddItem("B0001-65mm-9Y", 1)
            );

            Assert.Equal(
                "No active sale. Please create a sale to perform this action.",
                exception.Message
            );
        }

        [Fact]
        public void CompleteSale_WithoutExistingSale_ThrowsException()
        {
            // Arrange
            var saleService = new SaleService(
                new ProductCatalogue(),
                new InventoryManagement(),
                new SaleCalculator()
            );

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(
                () => saleService.CompleteSale()
            );

            Assert.Equal(
                "No active sale. Please create a sale to perform this action.",
                exception.Message
            );
        }

        [Fact]
        public void CreateSale_WithExistingSale_ThrowsException()
        {
            // Arrange
            var saleService = new SaleService(
                new ProductCatalogue(),
                new InventoryManagement(),
                new SaleCalculator()
            );
            saleService.CreateSale(new Customer(1, "Test Customer 1", 10));

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(
                () => saleService.CreateSale(new Customer(2, "Test Customer 2", 10))
            );

            Assert.Equal("A sale is already in progress.", exception.Message);
        }
    }
}
