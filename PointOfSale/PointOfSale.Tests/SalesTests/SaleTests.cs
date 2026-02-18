using PointOfSale.Inventory.Products;
using PointOfSale.Inventory.StockLevel;
using PointOfSale.Sales;
using PointOfSale.Shared;
using PointOfSale.Tests.TestDoubles;
using Xunit;

namespace PointOfSale.Tests
{
    public class SaleTests
    {
        [Fact]
        public void CreatingSale_StartsWithNoItems()
        {
            // Arrange
            IProductCatalogue catalogue = new ProductCatalogue();

            InventoryManagement inventory = new InventoryManagement();
            Customer customer = new Customer(1, "Test customer", 10);

            // Act
            Sale sale = new Sale(customer, inventory, catalogue);

            // Assert
            Assert.NotNull(sale);
            Assert.Empty(sale.GetItems());
        }

        [Fact]
        public void CreatingSale_IsAssociatedWithCorrectCustomer()
        {
            // Arrange
            IProductCatalogue catalogue = new ProductCatalogue();
            InventoryManagement inventory = new InventoryManagement();
            Customer customer = new Customer(1, "Test customer", 10);

            // Act
            Sale sale = new Sale(customer, inventory, catalogue);

            // Assert
            Assert.Equal(customer, sale.Customer);
        }

        [Fact]
        public void AddItem_AddsSingleItemToSale()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                199.99m
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, quantityOnHand);

            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);

            // Act
            sale.AddItem(productId, 1);

            // Assert
            var items = sale.GetItems();
            Assert.Single(items);
            Assert.Contains(items, i => i.ProductId == productId);
            Assert.Equal(1, sale.GetItemQuantity(productId));
        }

        [Fact]
        public void AddItem_QuantityIsLessThanOne_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                199.99m
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, quantityOnHand);

            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);

            // Act & Assert
            var exception = Assert.Throws<QuantityException>(() => sale.AddItem(productId, 0));
            Assert.Equal("Quantity cannot be less than 1.", exception.Message);
        }

        [Fact]
        public void AddItem_ReducesInventoryStock()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int initialQuantity = 10;
            int saleQuantity = 3;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                199.99m
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, initialQuantity);

            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);

            // Act
            sale.AddItem(productId, saleQuantity);

            // Assert
            Assert.Equal(
                initialQuantity - saleQuantity,
                inventory.GetAllStockItems()[productId].QuantityOnHand
            );
        }

        [Fact]
        public void RemoveItem_RemovesItemFromSale()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                199.99m
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, quantityOnHand);

            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);
            sale.AddItem(productId, 1);

            // Act
            sale.RemoveItem(productId);

            // Assert
            Assert.Empty(sale.GetItems());
        }

        [Fact]
        public void RemoveItem_ThrowsException_ItemNotInSale()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;
            string nonExistentItemId = "NON-EXISTENT-ID";

            TestProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                199.99m
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, quantityOnHand);

            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);
            sale.AddItem(productId, 1);

            // Act & Assert
            var exception = Assert.Throws<SaleItemNotFoundException>(
                () => sale.RemoveItem(nonExistentItemId)
            );
            Assert.Equal(
                $"The product with ID {nonExistentItemId} was not found in your sale",
                exception.Message
            );
        }

        [Fact]
        public void RemoveItem_IncreasesInventoryStock()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int initialQuantity = 10;
            int saleQuantity = 3;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                199.99m
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, initialQuantity);

            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);
            sale.AddItem(productId, saleQuantity);

            int remainingQuantityOnHand = inventory.GetAllStockItems()[productId].QuantityOnHand;

            // Act
            sale.RemoveItem(productId);

            // Assert
            Assert.Equal(
                remainingQuantityOnHand + saleQuantity,
                inventory.GetAllStockItems()[productId].QuantityOnHand
            );
        }

        [Fact]
        public void ChangeItemQuanity_UpdatesQuantityOfItem()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;
            int newQuantity = 5;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                199.99m
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, quantityOnHand);

            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);
            sale.AddItem(productId, 2);

            //Act
            sale.ChangeItemQuantity(productId, newQuantity);

            // Assert
            Assert.Single(sale.GetItems());
            Assert.Equal(newQuantity, sale.GetItemQuantity(productId));
        }

        [InlineData(10, 2, 5)]
        [InlineData(10, 5, 2)]
        [Theory]
        public void ChangeItemQuantity_ChangesInventoryStockAccordingly(
            int initialQuantityOnHand,
            int initialSaleQuantity,
            int newSaleQuantity
        )
        {
            // Arrange
            string productId = "B0001-65mm-9Y";

            TestProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                199.99m
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, initialQuantityOnHand);

            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);
            sale.AddItem(productId, initialSaleQuantity);

            //Act
            sale.ChangeItemQuantity(productId, newSaleQuantity);

            // Assert
            Assert.Equal(
                initialQuantityOnHand - newSaleQuantity,
                inventory.GetAllStockItems()[productId].QuantityOnHand
            );
        }

        [Fact]
        public void ChangeItemQuantity_ToZero_RemovesItemFromSale()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                199.99m
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, quantityOnHand);

            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);
            sale.AddItem(productId, 1);

            //Act
            sale.ChangeItemQuantity(productId, 0);

            // Assert
            Assert.Empty(sale.GetItems());
        }

        [Fact]
        public void ChangeItemQuantity_NegativeQuantity_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            TestProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                199.99m
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, quantityOnHand);

            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);
            sale.AddItem(productId, 1);

            // Act & Assert
            var exception = Assert.Throws<QuantityException>(
                () => sale.ChangeItemQuantity(productId, -1)
            );
            Assert.Equal("Quantity cannot be negative.", exception.Message);
        }

        [Fact]
        public void ChangeItemQuantity_ItemDoesNotExist_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";

            TestProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                199.99m
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);

            // Act & Assert
            var exception = Assert.Throws<SaleItemNotFoundException>(
                () => sale.ChangeItemQuantity(productId, 2)
            );
            Assert.Equal(
                $"The item with ID {productId} was not found in your sale.",
                exception.Message
            );
        }
    }
}
