using PointOfSale.Domain;
using Xunit;

namespace PointOfSale.Tests.Domain
{
    public class CustomerCollectionTests { }

    public class CustomerTests
    {
        public CustomerTests()
        {
            // Customer customer0Discount = new Customer(1, "Test Customer 0 Discount");
            // Customer customer5Discount = new Customer(2, "Test Customer 5 Discount", 5);
            // Customer customer10Discount = new Customer(3, "Test Customer 10 Discount", 10);
            // Customer customer15Discount = new Customer(4, "Test Customer 15 Discount", 15);
        }

        [Fact]
        public void Constructor_Success_CreatesCustomerWithAllParameters()
        {
            // Arrange & Act
            Customer customer = new Customer(1, "Test Customer", 15);

            // Assert
            Assert.NotNull(customer);
            Assert.Equal(1, customer.Id);
            Assert.Equal("Test Customer", customer.Name);
            Assert.Equal(15, customer.DiscountRate);
        }

        [Fact]
        public void Constructor_Success_CreatesCustomerWithRequiredParametersOnly()
        {
            // Arrange & Act
            Customer customer = new Customer(1, "Test Customer");

            // Assert
            Assert.NotNull(customer);
            Assert.Equal(1, customer.Id);
            Assert.Equal("Test Customer", customer.Name);
            Assert.Equal(0, customer.DiscountRate);
        }

        // [Fact]
        // public void UpdateDiscountRate_Success_WithValidDiscountRate()
        // {
        //     // Arrange
        //     Customer customer = new Customer(1, "Test Customer", 10);

        //     // Act
        //     customer.UpdateDiscountRate(20);

        //     // Assert
        //     Assert.Equal(20, customer.GetDiscountRate());
        // }

        // [Fact]
        // public void UpdateDiscountRate_ThrowsException_DiscountRateLessThan0()
        // {
        //     // Arrange
        //     Customer customer = new Customer(1, "Test Customer");

        //     // Act
        //     var exception = Assert.Throws<ArgumentException>(() => customer.UpdateDiscountRate(-1)); ;

        //     // Assert
        //     Assert.Equal("Discount rates must be between 0 and 100 percent", exception.Message);
        // }
        // [Fact]
        // public void UpdateDiscountRate_ThrowsException_DiscountRateGreaterThan100()
        // {
        //     // Arrange
        //     Customer customer = new Customer(1, "Test Customer");

        //     // Act
        //     var exception = Assert.Throws<ArgumentException>(() => customer.UpdateDiscountRate(101)); ;

        //     // Assert
        //     Assert.Equal("Discount rates must be between 0 and 100 percent", exception.Message);
        // }

        // [Fact]
        // public void GetDiscountRate_Success_ReturnsCorrectDiscountRate()
        // {
        //     // Arrange
        //     Customer customer = new Customer(2, "Another Customer", 20);

        //     // Act
        //     int discountRate = customer.GetDiscountRate();

        //     // Assert
        //     Assert.Equal(20, discountRate);
        // }
    }
}
