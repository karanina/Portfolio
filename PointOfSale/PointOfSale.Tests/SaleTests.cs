using PointOfSale;
using Xunit;

namespace PointOfSale.Tests
{
    public class SaleTests
    {
        private Sale sale;
        private Customer customer;

        public SaleTests()
        {
            // Arrange
            Customer customer = new Customer(1, "Test customer", 10);
            Sale sale = new Sale(customer);
        }

        [Fact]
        public void Constructor_Success_CreatesEmptySale()
        {
            Assert.NotNull(sale);
            Assert.Empty(sale.GetItems());
        }

        [Fact]
        public void GetItemCount_Success_ReturnsZeroForEmptySale()
        {
            // Act
            int itemCount = sale.GetItemCount();

            // Assert
            Assert.Equal(0, itemCount);
        }

        [Fact]
        public void GetItemCount_Success_ReturnsTotalForSingleItem()
        {
            // Arrange
            sale.AddItem(new SaleItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m));

            // Act
            int itemCount = sale.GetItemCount();

            // Assert
            Assert.Equal(1, itemCount);
        }

        [Fact]
        public void GetItemCount_Success_CalculatesTotalForMultipleItemsOfSameType()
        {
            // Arrange
            sale.AddItem(new SaleItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 2));

            // Act
            int itemCount = sale.GetItemCount();

            // Assert
            Assert.Equal(2, itemCount);
        }

        [Fact]
        public void GetItemCount_Success_CalculatesTotalForMultipleItemsOfDifferentTypes()
        {
            // Arrange
            sale.AddItem(new SaleItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 2));
            sale.AddItem(new SaleItem("N0001-60cm-STG", "Silver necklace", 49.99m, 3));

            // Act
            int itemCount = sale.GetItemCount();

            // Assert
            Assert.Equal(5, itemCount);
        }

        [Fact]
        public void GetItemQuantity_Success_ReturnsQuantityOfSpecificItem()
        {
            // Arrange
            sale.AddItem(new SaleItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 4));

            // Act
            int quantity = sale.GetItemQuantity("B0001-65mm-9Y");

            // Assert
            Assert.Equal(4, quantity);
        }

        [Fact]
        public void GetItemQuantity_ThrowsException_ItemNotInSale()
        {
            // Arrange
            sale.AddItem(new SaleItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 4));

            // Act & Assert
            var exception = Assert.Throws<SaleItemNotFoundException>(
                () => sale.GetItemQuantity("N0001-60cm-STG")
            );

            Assert.Equal(
                "The item with ID N0001-60cm-STG was not found in your sale",
                exception.Message
            );
        }

        [Fact]
        public void GetItems_Success_ReturnsAllItemsInSale()
        {
            //Arrange
            sale.AddItem(new SaleItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m));
            sale.AddItem(new SaleItem("N0001-60cm-STG", "Silver necklace", 49.99m));

            // Act
            var items = sale.GetItems();

            // Assert
            Assert.Equal(2, sale.GetItemCount());
            Assert.Contains("B0001-65mm-9Y", items);
            Assert.Contains("N0001-60cm-STG", items);
        }

        [Fact]
        public void AddItem_Success_AddsSingleItemToSale()
        {
            // Act
            sale.AddItem(new SaleItem("B0001-65-9Y", "5mm wide bangle", 199.99m));

            // Assert
            var items = sale.GetItems();
            Assert.Single(items);
            Assert.Contains("B0001-65-9Y", items);
        }

        [Fact]
        public void AddItem_Success_AddsDifferentItemTypesToSale()
        {
            // Act
            sale.AddItem(new SaleItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m));
            sale.AddItem(new SaleItem("N0001-60cm-STG", "Silver necklace", 49.99m));

            // Assert
            Assert.Equal(2, sale.GetItemCount());

            var items = sale.GetItems();
            Assert.Contains("B0001-65mm-9Y", items);
            Assert.Contains("N0001-60cm-STG", items);
        }

        [Fact]
        public void AddItem_Success_AddsMultipleQuantitiesOfSameItem()
        {
            // Act
            sale.AddItem(new SaleItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 2));

            // Assert
            Assert.Single(sale.GetItems());
            Assert.Equal(2, sale.GetItemQuantity("B0001-65mm-9Y"));
            Assert.Equal(2, sale.GetItemCount());
        }

        [Fact]
        public void AddItem_Success_UpdatesItemQuantityWhenAddingSameItemAgain()
        {
            // Arrange
            sale.AddItem(new SaleItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 2));

            // Act
            sale.AddItem(new SaleItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 3));

            // Assert
            Assert.Single(sale.GetItems());
            Assert.Equal(5, sale.GetItemQuantity("B0001-65mm-9Y"));
        }

        [Fact]
        public void CancelSale_Success_AllItemsRemovedFromSale()
        {
            // Arrange
            sale.AddItem(new SaleItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m));
            sale.AddItem(new SaleItem("N0001-60cm-STG", "Silver necklace", 49.99m));

            // Act
            sale.CancelSale();

            // Assert
            Assert.Empty(sale.GetItems());
            Assert.Equal(0, sale.GetItemCount());
        }

        [Fact]
        public void RemoveItem_Success_ForItemInSale()
        {
            // Arrange
            sale.AddItem(new SaleItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m));

            // Act
            sale.RemoveItem("B0001-65mm-9Y");

            // Assert
            var items = sale.GetItems();
            Assert.DoesNotContain("B0001-65mm-9Y", items);
            Assert.Empty(items);
        }

        [Fact]
        public void RemoveItem_ThrowsException_ItemNotInSale()
        {
            // Arrange
            sale.AddItem(new SaleItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m));

            // Act & Assert
            var exception = Assert.Throws<SaleItemNotFoundException>(
                () => sale.RemoveItem("NON-EXISTENT-ID")
            );
            Assert.Equal(
                "The item with ID NON-EXISTENT-ID was not found in your sale",
                exception.Message
            );
        }

        [Fact]
        public void UpdateItemQuanity_Success_ForItemInSale()
        {
            // Arrange
            sale.AddItem(new SaleItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m, 2));

            //Act
            sale.UpdateItemQuantity("B0001-65mm-9Y", 5);

            // Assert
            Assert.Equal(7, sale.GetItemQuantity("B0001-65mm-9Y"));
        }

        [Fact]
        public void UpdateItemQuantity_ThrowsException_ItemNotInSale()
        {
            // Arrange
            sale.AddItem(new SaleItem("B0001-65mm-9Y", "5mm wide bangle", 199.99m));

            // Act & Assert
            var exception = Assert.Throws<SaleItemNotFoundException>(
                () => sale.UpdateItemQuantity("N0001-60cm-STG", 1)
            );
            Assert.Equal(
                "The item with ID N0001-60cm-STG was not found in your sale",
                exception.Message
            );
        }

        [Fact]
        public void GetCustomerDiscountRate_Success_ReturnsCorrectDiscountRate()
        {
            // Act
            int discountRate = sale.GetCustomerDiscountRate();

            // Assert
            Assert.Equal(10, discountRate);
        }
    }
}
