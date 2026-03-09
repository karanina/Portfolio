using PointOfSale.Domain.Inventory.Products;
using PointOfSale.Domain.Sales;
using PointOfSale.Domain.Shared;
using PointOfSale.Tests.TestDoubles.Dummies;
using Xunit;

namespace PointOfSale.Tests.Domain.SalesTests
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

            ProductSpecification product = new DummyProductSpecification(
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

            ProductSpecification product = new DummyProductSpecification(
                productId,
                description,
                unitPrice
            );

            // Act & Assert
            var exception = Assert.Throws<QuantityException>(
                () => SaleItem.CreateFromProductSpecification(product, quantity)
            );
            Assert.Contains("less than 1.", exception.Message);
        }

        [Fact]
        public void CreateFromProductSpecification_UnitPriceIsNegative_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            string description = "5mm wide bangle";
            decimal unitPrice = -0.01m;
            int quantity = 1;

            ProductSpecification product = new DummyProductSpecification(
                productId,
                description,
                unitPrice
            );

            // Act & Assert
            var exception = Assert.Throws<PriceException>(
                () => SaleItem.CreateFromProductSpecification(product, quantity)
            );

            Assert.Contains("cannot be negative.", exception.Message);
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

            ProductSpecification product = new DummyProductSpecification(
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

            ProductSpecification product = new DummyProductSpecification(
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

            Assert.Contains("price has been overridden manually.", exception.Message);
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

            ProductSpecification product = new DummyProductSpecification(
                productId,
                description,
                unitPrice
            );

            SaleItem item = SaleItem.CreateFromProductSpecification(product, quantity);
            //  Act & Assert
            var exception = Assert.Throws<DiscountException>(
                () => item.ApplyManualDiscount(manualDiscountRate)
            );

            Assert.Contains("between 0 and 100.", exception.Message);
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

            ProductSpecification product = new DummyProductSpecification(
                productId,
                description,
                unitPrice
            );

            SaleItem item = SaleItem.CreateFromProductSpecification(product, quantity);

            //  Act & Assert
            var exception = Assert.Throws<DiscountException>(
                () => item.ApplyManualDiscount(manualDiscountRate)
            );

            Assert.Contains("between 0 and 100.", exception.Message);
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

            ProductSpecification product = new DummyProductSpecification(
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

            ProductSpecification product = new DummyProductSpecification(
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
            Assert.Contains("less than 1.", exception.Message);
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

            ProductSpecification product = new DummyProductSpecification(
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

            ProductSpecification product = new DummyProductSpecification(
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

            ProductSpecification product = new DummyProductSpecification(
                productId,
                description,
                unitPrice
            );

            SaleItem item = SaleItem.CreateFromProductSpecification(product, quantity);

            // Act & Assert
            var exception = Assert.Throws<PriceException>(
                () => item.OverrideUnitPrice(manualUnitPrice)
            );

            Assert.Contains("cannot be negative.", exception.Message);
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

            ProductSpecification product = new DummyProductSpecification(
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

            ProductSpecification product = new DummyProductSpecification(
                productId,
                description,
                unitPrice
            );

            SaleItem item = SaleItem.CreateFromProductSpecification(product, initialQuantity);

            // Act & Assert
            var exception = Assert.Throws<QuantityException>(
                () => item.IncreaseQuantity(increaseQuantityAmount)
            );

            Assert.Contains("less than 1.", exception.Message);
        }
    }
}
