using PointOfSale;
using Xunit;

namespace PointOfSale.Tests
{
    public class CartItemTests
    {
        [Fact]
        public void Constructor_Success_CreateCartItemWithAllParameters()
        {
            // Arrange & Act
            CartItem item = new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 2, 10, false);

            // Assert
            Assert.NotNull(item);
            Assert.Equal("B0001-65mm-9Y", item.Id);
            Assert.Equal("5mm wide bangle", item.Description);
            Assert.Equal(199.99m, item.SellPrice);
            Assert.Equal(2, item.Quantity);
            Assert.Equal(10, item.ManualDiscountRate);
            Assert.False(item.IsManualUnitPrice);
        }

        [Fact]
        public void Constructor_Success_CreateCartItemWithOnlyRequiredParameters()
        {
            // Arrange & Act
            CartItem item = new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m);

            // Assert
            Assert.NotNull(item);
            Assert.Equal("B0001-65mm-9Y", item.Id);
            Assert.Equal("5mm wide bangle", item.Description);
            Assert.Equal(199.99m, item.SellPrice);
            Assert.Equal(1, item.Quantity);
            Assert.Equal(0, item.ManualDiscountRate);
            Assert.False(item.IsManualUnitPrice);
        }

        [Fact]
        public void Constructor_Success_CreateCartItemWithRequiredParametersAndQuantity()
        {
            // Arrange & Act
            CartItem item = new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, quantity: 5);

            // Assert
            Assert.NotNull(item);
            Assert.Equal("B0001-65mm-9Y", item.Id);
            Assert.Equal("5mm wide bangle", item.Description);
            Assert.Equal(199.99m, item.SellPrice);
            Assert.Equal(5, item.Quantity);
            Assert.Equal(0, item.ManualDiscountRate);
            Assert.False(item.IsManualUnitPrice);
        }

        [Fact]
        public void Constructor_Success_CreateCartItemWithRequiredParametersAndManualDiscountRate()
        {
            // Arrange & Act
            CartItem item = new CartItem(
                "B0001-65mm-9Y",
                "5mm wide bangle",
                199.99m,
                manualDiscountRate: 15
            );

            // Assert
            Assert.NotNull(item);
            Assert.Equal("B0001-65mm-9Y", item.Id);
            Assert.Equal("5mm wide bangle", item.Description);
            Assert.Equal(199.99m, item.SellPrice);
            Assert.Equal(1, item.Quantity);
            Assert.Equal(15, item.ManualDiscountRate);
            Assert.False(item.IsManualUnitPrice);
        }

        [Fact]
        public void Constructor_Success_CreateCartItemWithRequiredParametersAndIsManualUnitPrice()
        {
            // Arrange & Act
            CartItem item = new CartItem(
                "B0001-65mm-9Y",
                "5mm wide bangle",
                199.99m,
                isManualUnitPrice: true
            );

            // Assert
            Assert.NotNull(item);
            Assert.Equal("B0001-65mm-9Y", item.Id);
            Assert.Equal("5mm wide bangle", item.Description);
            Assert.Equal(199.99m, item.SellPrice);
            Assert.Equal(1, item.Quantity);
            Assert.Equal(0, item.ManualDiscountRate);
            Assert.True(item.IsManualUnitPrice);
        }

        [Fact]
        public void Constructor_ThrowsException_WhenManualDiscountRateIsGreaterThan0AndIsManualUnitPriceIsTrue()
        {
            // Arrange, Act & Assert
            var exception = Assert.Throws<ArgumentException>(
                () =>
                    new CartItem(
                        "B0001-65mm-9Y",
                        "5mm wide bangle",
                        199.99m,
                        manualDiscountRate: 10,
                        isManualUnitPrice: true
                    )
            );

            Assert.Equal(
                "Cannot set a manual discount rate when the sell price has been overridden manually.",
                exception.Message
            );
        }

        [Fact]
        public void Constructor_ThrowsException_WhenSellPriceIsNegative()
        {
            // Arrange, Act & Assert
            var exception = Assert.Throws<ArgumentException>(
                () => new CartItem("B0001-65-9Y", "5mm wide bangle", -00.01m)
            );

            Assert.Equal("Sell price cannot be negative.", exception.Message);
        }

        [Fact]
        public void Constructor_ThrowsException_WhenManualDiscountIsLessThan0()
        {
            // Arrange, Act & Assert
            var exception = Assert.Throws<ArgumentException>(
                () =>
                    new CartItem(
                        "B0001-65mm-9Y",
                        "5mm wide bangle",
                        199.99m,
                        manualDiscountRate: -1
                    )
            );
            Assert.Equal("Manual discount rate must be between 0 and 100.", exception.Message);
        }

        [Fact]
        public void Constructor_ThrowsException_WhenManualDiscountIsGreaterThan100()
        {
            // Arrange, Act & Assert
            var exception = Assert.Throws<ArgumentException>(
                () =>
                    new CartItem(
                        "B0001-65mm-9Y",
                        "5mm wide bangle",
                        199.99m,
                        manualDiscountRate: 101
                    )
            );
            Assert.Equal("Manual discount rate must be between 0 and 100.", exception.Message);
        }

        [Fact]
        public void Constructor_ThrowsException_WhenQuantityIsZero()
        {
            // Arrange, Act & Assert
            var exception = Assert.Throws<ArgumentException>(
                () => new CartItem("B0001-65-9Y", "5mm wide bangle", 199.99m, quantity: 0)
            );

            Assert.Equal("Quantity must be at least 1.", exception.Message);
        }

        [Fact]
        public void Constructor_ThrowsException_WhenQuantityIsNegative()
        {
            // Arrange, Act & Assert
            var exception = Assert.Throws<ArgumentException>(
                () => new CartItem("B0001-65-9Y", "5mm wide bangle", 199.99m, quantity: -1)
            );

            Assert.Equal("Quantity must be at least 1.", exception.Message);
        }

        [Fact]
        public void UpdateQuantity_Success_UpdatesQuantityToNewValue()
        {
            // Arrange
            CartItem item = new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, quantity: 2);

            // Act
            item.UpdateQuantity(5);

            // Assert
            Assert.Equal(5, item.GetQuantity());
        }

        [Fact]
        public void UpdateSellPrice_Success_UpdatesSellPriceToNewValue()
        {
            // Arrange
            CartItem item = new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m);

            // Act
            item.UpdateSellPrice(149.99m);

            // Assert
            Assert.Equal(149.99m, item.SellPrice);
        }

    }
}
