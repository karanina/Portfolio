using PointOfSale;
using Xunit;

namespace PointOfSale.Tests
{
    public class ShoppingCartTests
    {
        private ShoppingCart cart;
        private Customer customer;

        public ShoppingCartTests()
        {
            // Arrange
            Customer customer = new Customer(1, "Test customer", 10);
            cart = new ShoppingCart(customer);
        }

        [Fact]
        public void Constructor_Success_CreatesEmptyCart()
        {
            Assert.NotNull(cart);
            Assert.Empty(cart.GetItems());
        }

        [Fact]
        public void GetItemCount_Success_ReturnsZeroForEmptyCart()
        {
            // Act
            int itemCount = cart.GetItemCount();

            // Assert
            Assert.Equal(0, itemCount);
        }

        [Fact]
        public void GetItemCount_Success_ReturnsTotalForSingleItem()
        {
            // Arrange
            cart.AddItem(new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m));

            // Act
            int itemCount = cart.GetItemCount();

            // Assert
            Assert.Equal(1, itemCount);
        }

        [Fact]
        public void GetItemCount_Success_CalculatesTotalForMultipleItemsOfSameType()
        {
            // Arrange
            cart.AddItem(new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 2));

            // Act
            int itemCount = cart.GetItemCount();

            // Assert
            Assert.Equal(2, itemCount);
        }

        [Fact]
        public void GetItemCount_Success_CalculatesTotalForMultipleItemsOfDifferentTypes()
        {
            // Arrange
            cart.AddItem(new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 2));
            cart.AddItem(new CartItem("N0001-60cm-STG", "Silver necklace", 49.99m, 3));

            // Act
            int itemCount = cart.GetItemCount();

            // Assert
            Assert.Equal(5, itemCount);
        }

        [Fact]
        public void GetItemQuantity_Success_ReturnsQuantityOfSpecificItem()
        {
            // Arrange
            cart.AddItem(new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 4));

            // Act
            int quantity = cart.GetItemQuantity("B0001-65mm-9Y");

            // Assert
            Assert.Equal(4, quantity);
        }

        [Fact]
        public void GetItemQuantity_ThrowsException_ItemNotInCart()
        {
            // Arrange
            cart.AddItem(new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 4));

            // Act & Assert
            var exception = Assert.Throws<CartItemNotFoundException>(
                () => cart.GetItemQuantity("N0001-60cm-STG")
            );

            Assert.Equal(
                "The item with ID N0001-60cm-STG was not found in your cart",
                exception.Message
            );
        }

        [Fact]
        public void GetItems_Success_ReturnsAllItemsInCart()
        {
            //Arrange
            cart.AddItem(new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m));
            cart.AddItem(new CartItem("N0001-60cm-STG", "Silver necklace", 49.99m));

            // Act
            var items = cart.GetItems();

            // Assert
            Assert.Equal(2, cart.GetItemCount());
            Assert.Contains("B0001-65mm-9Y", items);
            Assert.Contains("N0001-60cm-STG", items);
        }

        [Fact]
        public void AddItem_Success_AddsSingleItemToCart()
        {
            // Act
            cart.AddItem(new CartItem("B0001-65-9Y", "5mm wide bangle", 199.99m));

            // Assert
            var items = cart.GetItems();
            Assert.Single(items);
            Assert.Contains("B0001-65-9Y", items);
        }

        [Fact]
        public void AddItem_Success_AddsDifferentItemTypesToCart()
        {
            // Act
            cart.AddItem(new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m));
            cart.AddItem(new CartItem("N0001-60cm-STG", "Silver necklace", 49.99m));

            // Assert
            Assert.Equal(2, cart.GetItemCount());

            var items = cart.GetItems();
            Assert.Contains("B0001-65mm-9Y", items);
            Assert.Contains("N0001-60cm-STG", items);
        }

        [Fact]
        public void AddItem_Success_AddsMultipleQuantitiesOfSameItem()
        {
            // Act
            cart.AddItem(new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 2));

            // Assert
            Assert.Single(cart.GetItems());
            Assert.Equal(2, cart.GetItemQuantity("B0001-65mm-9Y"));
            Assert.Equal(2, cart.GetItemCount());
        }

        [Fact]
        public void AddItem_Success_UpdatesItemQuantityWhenAddingSameItemAgain()
        {
            // Arrange
            cart.AddItem(new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 2));

            // Act
            cart.AddItem(new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 3));

            // Assert
            Assert.Single(cart.GetItems());
            Assert.Equal(5, cart.GetItemQuantity("B0001-65mm-9Y"));
        }

        [Fact]
        public void EmptyCart_Success_AllItemsRemovedFromCart()
        {
            // Arrange
            cart.AddItem(new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m));
            cart.AddItem(new CartItem("N0001-60cm-STG", "Silver necklace", 49.99m));

            // Act
            cart.EmptyCart();

            // Assert
            Assert.Empty(cart.GetItems());
            Assert.Equal(0, cart.GetItemCount());
        }

        [Fact]
        public void RemoveItem_Success_ForItemInCart()
        {
            // Arrange
            cart.AddItem(new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m));

            // Act
            cart.RemoveItem("B0001-65mm-9Y");

            // Assert
            var items = cart.GetItems();
            Assert.DoesNotContain("B0001-65mm-9Y", items);
            Assert.Empty(items);
        }

        [Fact]
        public void RemoveItem_ThrowsException_ItemNotInCart()
        {
            // Arrange
            cart.AddItem(new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m));

            // Act & Assert
            var exception = Assert.Throws<CartItemNotFoundException>(
                () => cart.RemoveItem("NON-EXISTENT-ID")
            );
            Assert.Equal(
                "The item with ID NON-EXISTENT-ID was not found in your cart",
                exception.Message
            );
        }

        [Fact]
        public void UpdateItemQuanity_Success_ForItemInCart()
        {
            // Arrange
            cart.AddItem(new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 2));

            //Act
            cart.UpdateItemQuantity("B0001-65mm-9Y", 5);

            // Assert
            Assert.Equal(7, cart.GetItemQuantity("B0001-65mm-9Y"));
        }

        [Fact]
        public void UpdateItemQuantity_ThrowsException_ItemNotInCart()
        {
            // Arrange
            cart.AddItem(new CartItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m));

            // Act & Assert
            var exception = Assert.Throws<CartItemNotFoundException>(
                () => cart.UpdateItemQuantity("N0001-60cm-STG", 1)
            );
            Assert.Equal(
                "The item with ID N0001-60cm-STG was not found in your cart",
                exception.Message
            );
        }

        [Fact]
        public void GetCustomerDiscountRate_Success_ReturnsCorrectDiscountRate()
        {
            // Act
            int discountRate = cart.GetCustomerDiscountRate();

            // Assert
            Assert.Equal(10, discountRate);
        }
    }
}
