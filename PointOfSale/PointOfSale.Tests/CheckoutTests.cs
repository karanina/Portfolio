using PointOfSale;
using Xunit;

namespace PointOfSale.Tests
{
    public class CheckoutTests
    {
        private Customer customerNoDiscount;
        private Customer customerWithDiscount;
        private ShoppingCart cartWithDiscount;
        private ShoppingCart cartNoDiscount;
        private CartItem validBangle;
        private CartItem validNecklace;

        public CheckoutTests()
        {
            // Arrange
            customerWithDiscount = new Customer(1, "Test customer with discount", 10);
            cartWithDiscount = new ShoppingCart(customerWithDiscount);

            customerNoDiscount = new Customer(2, "Test customer with no discount");
            cartNoDiscount = new ShoppingCart(customerNoDiscount);

            validBangle = new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m);
            validNecklace = new CartItem("N0001-60cm-STG", "Silver necklace", 49.99m);
        }

        [Fact]
        public void CalculateLineTotal_SuccessfullyWithSingleItemAndNoCustomerDiscountRate()
        {
            // Arrange
            cartNoDiscount.AddItem(validBangle);
            Checkout checkout = new Checkout(cartNoDiscount);
            CartItem cartItem = cartNoDiscount.GetItems().Values.First();

            // Act
            checkout.CalculateLineTotal(cartItem);
            decimal actual = checkout.GetLineTotals().First();

            // Assert
            Assert.Equal(199.99m, actual);
        }

        [Fact]
        public void CalculateLineTotal_SuccessfulyWithMultipleItemsOfTheSameTypeAndNoCustomerDiscountRate()
        {
            // Arrange
            validBangle.Quantity = 3;
            cartNoDiscount.AddItem(validBangle);
            Checkout checkout = new Checkout(cartNoDiscount);
            CartItem cartItem = cartNoDiscount.GetItems().Values.First();

            // Act
            checkout.CalculateLineTotal(cartItem);
            decimal actual = checkout.GetLineTotals().First();

            // Assert
            Assert.Equal(599.97m, actual);
        }

        [Fact]
        public void CalculateLineTotal_SuccessfullyCalculatesSingleItemLineTotalWithCustomerDiscountRate()
        {
            // Arrange
            cartWithDiscount.AddItem(validBangle);
            Checkout checkout = new Checkout(cartWithDiscount);
            CartItem cartItem = cartWithDiscount.GetItems().Values.First();

            // Act
            checkout.CalculateLineTotal(cartItem);
            decimal actual = checkout.GetLineTotals().First();

            // Assert
            Assert.Equal(179.99m, actual, 2); // rounding to 2 decimal places
        }

        [Fact]
        public void CalculateLineTotal_SuccessfullyCalculatesMultipleItemQuantityLineTotalWIthCustomerDiscountRateToTwoDecimalPlaces()
        {
            // Arrange
            validBangle.Quantity = 4;
            cartWithDiscount.AddItem(validBangle);
            Checkout checkout = new Checkout(cartWithDiscount);
            CartItem cartItem = cartWithDiscount.GetItems().Values.First();

            // Act
            checkout.CalculateLineTotal(cartItem);
            decimal actual = checkout.GetLineTotals().First();

            // Assert
            Assert.Equal(719.96m, actual);
        }

        [Fact]
        public void CalculateLineTotal_SuccessfullyCalculatesLineTotalWithManualItemDiscountRateAndNoCustomerDiscountRate()
        {
            // Arrange
            validBangle.ManualDiscountRate = 20; // 20% manual discount
            cartNoDiscount.AddItem(validBangle);
            Checkout checkout = new Checkout(cartNoDiscount);
            CartItem cartItem = cartNoDiscount.GetItems().Values.First();

            // Act
            checkout.CalculateLineTotal(cartItem);
            decimal actual = checkout.GetLineTotals().First();

            // Assert
            Assert.Equal(159.99m, actual);
        }

        [Fact]
        public void CalculateLineTotal_SuccessfullyCalculatesLineTotalWithManualItemDiscountRateOverridingCustomerDiscountRate()
        {
            // Arrange
            validBangle.ManualDiscountRate = 20; // 20% manual discount
            cartWithDiscount.AddItem(validBangle);
            Checkout checkout = new Checkout(cartWithDiscount);
            CartItem cartItem = cartWithDiscount.GetItems().Values.First();

            // Act
            checkout.CalculateLineTotal(cartItem);
            decimal actual = checkout.GetLineTotals().First();

            // Assert
            Assert.Equal(159.99m, actual);
        }

        [Fact]
        public void CalculateLineTotals_Success_WhenManualUnitPriceNoExtraDiscounts()
        {
            // Arrange
            cartNoDiscount.AddItem(new CartItem("R0001/3-SML-18Y", "3mm wide half round ring", 149.99m, isManualUnitPrice: true));
            Checkout checkout = new Checkout(cartNoDiscount);

            // Act
            checkout.CalculateLineTotals();

            // Assert
            Assert.Equal(149.99m, checkout.GetLineTotals().First());
            
        }

        [Fact]
        public void GetLineTotals_ReturnsAListOfLineTotals()
        {
            // Arrange
            cartWithDiscount.AddItem(validBangle);
            cartWithDiscount.AddItem(validNecklace);
            Checkout checkout = new Checkout(cartWithDiscount);
            foreach (var item in cartWithDiscount.GetItems().Values)
            {
                checkout.CalculateLineTotal(item);
            }

            // Act
            List<decimal> lineTotals = checkout.GetLineTotals();

            // Assert
            Assert.Equal(2, lineTotals.Count);
            Assert.Contains(179.99m, lineTotals);
            Assert.Contains(44.99m, lineTotals);
        }
    }
}
