using PointOfSale.Inventory.StockLevel;
using PointOfSale.Shared;
using Xunit;

namespace PointOfSale.Tests.InventoryTests.StockLevelTests
{
    public class StockItemTests
    {
        [Fact]
        public void Constructor_CreatesStockItemWithGivenParameters()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int initialQuantity = 10;

            // Act
            StockItem stockItem = new StockItem(productId, initialQuantity);

            // Assert
            Assert.NotNull(stockItem);
            Assert.Equal(productId, stockItem.ProductId);
            Assert.Equal(initialQuantity, stockItem.QuantityOnHand);
        }

        [Fact]
        public void Constructor_NegativeQuantity_ThrowsException()
        {
            // Act & Assert
            var exception = Assert.Throws<QuantityException>(
                () => new StockItem("B0001-65mm-9Y", -1)
            );

            Assert.Equal("Quantity cannot be negative.", exception.Message);
        }

        [Fact]
        public void IncreaseQuantity_NegativeQuantity_ThrowsException()
        {
            // Arrange
            StockItem stockItem = new StockItem("B0001-65mm-9Y", 10);

            // Act & Assert
            var exception = Assert.Throws<QuantityException>(() => stockItem.IncreaseQuantity(-1));
            Assert.Equal("Quantity cannot be negative.", exception.Message);
        }

        [Fact]
        public void ReduceStock_NegativeQuantity_ThrowsException()
        {
            // Arrange
            StockItem stockItem = new StockItem("B0001-65mm-9Y", 5);

            // Act & Assert
            var exception = Assert.Throws<QuantityException>(() => stockItem.ReduceQuantity(-1));

            Assert.Equal("Quantity to reduce stock by cannot be negative.", exception.Message);
        }

        [Fact]
        public void ReduceStock_MoreThanAvailable_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int initialQuantity = 5;
            int reductionQuantity = 10;
            StockItem stockItem = new StockItem(productId, initialQuantity);

            // Act & Assert
            var exception = Assert.Throws<InsufficientStockException>(
                () => stockItem.ReduceQuantity(reductionQuantity)
            );

            Assert.Equal(
                $"Not enough stock on hand. There is only {initialQuantity} items available.",
                exception.Message
            );
        }
    }
}
