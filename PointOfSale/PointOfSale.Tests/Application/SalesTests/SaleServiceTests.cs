using PointOfSale.Application.Sales;
using PointOfSale.Domain.Sales;
using PointOfSale.Tests.TestDoubles.Fakes;
using PointOfSale.Tests.TestFixtures;
using Xunit;

namespace PointOfSale.Tests.Application.SalesTests
{
    public class SaleServiceTests
    {
        // Happy Path workflow tests

        [Fact]
        public void CreateSale_AddItem_MakePayment_CompleteSale_ReturnsReceipt()
        {
            // Arrange
            int saleQuantity = 1;

            SaleServiceTestContext context = new SaleServiceTestContext(
                productId: "B0001-65mm-9Y",
                quantityOnHand: 10,
                description: "Test Product",
                sellPrice: 199.99m,
                saleQuantity: saleQuantity
            );
            var saleService = new SaleService(
                context.Catalogue,
                context.Inventory,
                context.Calculator,
                context.IdGenerator
            );

            // Act
            string CustomerName = "Test Customer";
            saleService.CreateSale(new Customer(1, CustomerName, 10));
            saleService.AddItem(context.Product.ProductId, saleQuantity);

            decimal subTotal = saleService.GetTotal();

            saleService.MakePayment(context.Product.SellPrice * saleQuantity);

            ReceiptDto receipt = saleService.CompleteSale();

            // Assert
            Assert.True(subTotal > 0);
            Assert.NotNull(receipt);
            Assert.Equal(CustomerName, receipt.CustomerName);
        }

        // Helper test for keeping the items list up to date as items are added
        [Fact]
        public void GetCurrentSaleItems_WhenItemAdded_ReturnsItem()
        {
            // Arrange
            int saleQuantity = 2;

            SaleServiceTestContext context = new SaleServiceTestContext(
                productId: "B0001-65mm-9Y",
                quantityOnHand: 10,
                description: "Test Product",
                sellPrice: 199.99m,
                saleQuantity: saleQuantity
            );
            var saleService = new SaleService(
                context.Catalogue,
                context.Inventory,
                context.Calculator,
                context.IdGenerator
            );
            saleService.CreateSale(new Customer(1, "Test Customer", 10));
            saleService.AddItem(context.Product.ProductId, saleQuantity);

            // Act
            var items = saleService.GetCurrentSaleItems();

            // Assert
            Assert.Single(items);
            Assert.Equal(context.Product.ProductId, items[0].ProductId);
            Assert.Equal(saleQuantity, items[0].Quantity);
        }

        //
        [Fact]
        public void AddItemAndGetCurrentSummary_AddsItemAndReturnsUpdatedSummary()
        {
            // Arrange
            int saleQuantity = 2;

            SaleServiceTestContext context = new SaleServiceTestContext(
                productId: "B0001-65mm-9Y",
                quantityOnHand: 10,
                description: "Test Product",
                sellPrice: 199.99m,
                saleQuantity: saleQuantity
            );
            var saleService = new SaleService(
                context.Catalogue,
                context.Inventory,
                context.Calculator,
                context.IdGenerator
            );
            saleService.CreateSale(new Customer(1, "Test Customer", 10));
            // Act
            CurrentSaleSummaryDto summary = saleService.AddItemAndGetCurrentSummary(context.Product.ProductId,saleQuantity);

            // Assert
            Assert.Single(summary.Items);
            Assert.Equal(context.Product.ProductId, summary.Items[0].ProductId);
            Assert.Equal(saleQuantity, summary.Items[0].Quantity);
        }


        // Guard tests
        [Fact]
        public void AddItem_WithoutExistingSale_ThrowsException()
        {
            // Arrange
            var saleService = new SaleService(
                new FakeProductCatalogue(),
                new FakeInventoryManagement(),
                new FakeSaleCalculator(),
                new FakeSaleIdGenerator()
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
                new FakeProductCatalogue(),
                new FakeInventoryManagement(),
                new FakeSaleCalculator(),
                new FakeSaleIdGenerator()
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
                new FakeProductCatalogue(),
                new FakeInventoryManagement(),
                new FakeSaleCalculator(),
                new FakeSaleIdGenerator()
            );
            saleService.CreateSale(new Customer(1, "Test Customer 1", 10));

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(
                () => saleService.CreateSale(new Customer(2, "Test Customer 2", 10))
            );

            Assert.Contains("already in progress.", exception.Message);
        }
    }
}
