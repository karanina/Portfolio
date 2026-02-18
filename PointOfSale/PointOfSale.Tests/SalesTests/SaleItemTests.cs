using PointOfSale.Sales;
using PointOfSale.Shared;
using PointOfSale.Tests.TestDoubles;
using Xunit;

namespace PointOfSale.Tests
{
    public class SaleItemTests
    {
        [Fact]
        public void CreateFromProductSpecification_CreateSaleItemWithValidParameters()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            string description = "5mm wide bangle";
            decimal unitPrice = 199.99m;
            int quantity = 2;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                description,
                unitPrice
            );

            // Act
            SaleItem item = SaleItem.CreateFromProductSpecification(product, quantity);

            // Assert
            Assert.NotNull(item);
            Assert.Equal(productId, item.ProductId);
            Assert.Equal(description, item.Description);
            Assert.Equal(unitPrice, item.UnitPrice);
            Assert.Equal(quantity, item.Quantity);
            Assert.False(item.IsManualUnitPrice);
        }

        [Fact]
        public void CreateFromProductSpecification_QuantityLessThanOne_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            string description = "5mm wide bangle";
            decimal unitPrice = 199.99m;
            int quantity = -1;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                description,
                unitPrice
            );

            // Act & Assert
            var exception = Assert.Throws<QuantityException>(
                () => SaleItem.CreateFromProductSpecification(product, quantity)
            );
            Assert.Equal("Quantity cannot be less than 1.", exception.Message);
        }

        [Fact]
        public void CreateFromProductSpecification_UnitPriceIsNegative_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            string description = "5mm wide bangle";
            decimal unitPrice = -0.01m;
            int quantity = 1;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                description,
                unitPrice
            );

            // Act & Assert
            var exception = Assert.Throws<PriceException>(
                () => SaleItem.CreateFromProductSpecification(product, quantity)
            );

            Assert.Equal("Unit price cannot be negative.", exception.Message);
        }

        [Fact]
        public void ApplyManualDiscount_AppliesValidManualDiscount()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            string description = "5mm wide bangle";
            decimal unitPrice = 199.99m;
            var quantity = 2;
            int manualDiscountRate = 10;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                description,
                unitPrice
            );
            SaleItem item = SaleItem.CreateFromProductSpecification(product, quantity);

            // Act
            item.ApplyManualDiscount(manualDiscountRate);

            // Assert
            Assert.Equal(manualDiscountRate, item.ManualDiscountRate);
        }

        [Fact]
        public void ApplyManualDiscount_WhenUnitPriceHasBeenOverriden_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            string description = "5mm wide bangle";
            decimal unitPrice = 199.99m;
            var quantity = 2;
            int manualDiscountRate = 10;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                description,
                unitPrice
            );

            SaleItem item = SaleItem.CreateFromProductSpecification(product, quantity);
            item.OverrideUnitPrice(149.99m);

            // Act & Assert
            var exception = Assert.Throws<DiscountException>(
                () => item.ApplyManualDiscount(manualDiscountRate)
            );

            Assert.Equal(
                "Cannot set a manual discount rate when the sell price has been overridden manually.",
                exception.Message
            );
        }

        [Fact]
        public void ApplyManualDiscount_WhenManualDiscountIsLessThan0_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            string description = "5mm wide bangle";
            decimal unitPrice = 199.99m;
            var quantity = 2;
            int manualDiscountRate = -1;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                description,
                unitPrice
            );

            SaleItem item = SaleItem.CreateFromProductSpecification(product, quantity);
            //  Act & Assert
            var exception = Assert.Throws<DiscountException>(
                () => item.ApplyManualDiscount(manualDiscountRate)
            );

            Assert.Equal("Manual discount rate must be between 0 and 100.", exception.Message);
        }

        [Fact]
        public void ApplyManualDiscount_WhenManualDiscountIsGreaterThan100_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            string description = "5mm wide bangle";
            decimal unitPrice = 199.99m;
            var quantity = 2;
            int manualDiscountRate = 101;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                description,
                unitPrice
            );

            SaleItem item = SaleItem.CreateFromProductSpecification(product, quantity);

            //  Act & Assert
            var exception = Assert.Throws<DiscountException>(
                () => item.ApplyManualDiscount(manualDiscountRate)
            );

            Assert.Equal("Manual discount rate must be between 0 and 100.", exception.Message);
        }

        [Fact]
        public void ChangeQuantity_UpdatesQuantityToPositiveValue()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            string description = "5mm wide bangle";
            decimal unitPrice = 199.99m;
            int initialQuantity = 2;
            int newQuantity = 5;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                description,
                unitPrice
            );

            SaleItem item = SaleItem.CreateFromProductSpecification(product, initialQuantity);

            // Act
            item.ChangeQuantity(newQuantity);

            // Assert
            Assert.Equal(5, item.Quantity);
        }

        [Fact]
        public void ChangeQuantity_WhenQuantityIsLessThanOne_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            string description = "5mm wide bangle";
            decimal unitPrice = 199.99m;
            int initialQuantity = 2;
            int newQuantity = 0;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                description,
                unitPrice
            );

            SaleItem item = SaleItem.CreateFromProductSpecification(product, initialQuantity);

            // Act
            var exception = Assert.Throws<QuantityException>(
                () => item.ChangeQuantity(newQuantity)
            );

            // Assert
            Assert.Equal("Quantity cannot be less than 1.", exception.Message);
        }

        [Fact]
        public void OverrideUnitPrice_UnitPriceChangesToNewValidPrice()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            string description = "5mm wide bangle";
            decimal unitPrice = 199.99m;
            int quantity = 2;

            decimal manualUnitPrice = 149.99m;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                description,
                unitPrice
            );

            SaleItem item = SaleItem.CreateFromProductSpecification(product, quantity);

            // Act
            item.OverrideUnitPrice(manualUnitPrice);

            // Assert
            Assert.Equal(manualUnitPrice, item.UnitPrice);
            Assert.True(item.IsManualUnitPrice);
        }

        [Fact]
        public void OverrideUnitPrice_AfterManualDiscountOverride()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            string description = "5mm wide bangle";
            decimal unitPrice = 199.99m;
            int quantity = 2;

            decimal manualUnitPrice = 149.99m;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                description,
                unitPrice
            );

            SaleItem item = SaleItem.CreateFromProductSpecification(product, quantity);
            item.ApplyManualDiscount(10); // Apply a 10% manual discount

            // Act
            item.OverrideUnitPrice(manualUnitPrice);

            // Assert
            Assert.Equal(manualUnitPrice, item.UnitPrice);
            Assert.True(item.IsManualUnitPrice);
            Assert.Null(item.ManualDiscountRate);
        }

        [Fact]
        public void OverrideUnitPrice_NegativeUnitPrice_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            string description = "5mm wide bangle";
            decimal unitPrice = 199.99m;
            int quantity = 2;

            decimal manualUnitPrice = -0.01m;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                description,
                unitPrice
            );

            SaleItem item = SaleItem.CreateFromProductSpecification(product, quantity);

            // Act & Assert
            var exception = Assert.Throws<PriceException>(
                () => item.OverrideUnitPrice(manualUnitPrice)
            );

            Assert.Equal("Unit price cannot be negative.", exception.Message);
        }

        [Fact]
        public void IncreaseQuantity_IncreasesQuantityByValidAmount()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            string description = "5mm wide bangle";
            decimal unitPrice = 199.99m;
            int initialQuantity = 2;
            int increaseQuantityAmount = 3;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                description,
                unitPrice
            );

            SaleItem item = SaleItem.CreateFromProductSpecification(product, initialQuantity);

            // Act
            item.IncreaseQuantity(increaseQuantityAmount);

            // Assert
            Assert.Equal(initialQuantity + increaseQuantityAmount, item.Quantity);
        }

        [Fact]
        public void IncreaseQuantity_WhenIncreaseAmountIsLessThanOne_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            string description = "5mm wide bangle";
            decimal unitPrice = 199.99m;
            int initialQuantity = 2;
            int increaseQuantityAmount = 0;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                description,
                unitPrice
            );

            SaleItem item = SaleItem.CreateFromProductSpecification(product, initialQuantity);

            // Act & Assert
            var exception = Assert.Throws<QuantityException>(
                () => item.IncreaseQuantity(increaseQuantityAmount)
            );

            Assert.Equal("Quantity cannot be less than 1.", exception.Message);
        }
    }
}
