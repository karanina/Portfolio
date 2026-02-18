using PointOfSale.Inventory.StockLevel;
using Xunit;

namespace PointOfSale.Tests.InventoryTests.StockLevelTests
{
    public class InventoryManagementTests
    {
        // private Product validProduct;
        // private Product invalidProduct;

        // public InventoryManagementTests()
        // {
        //     validProduct = new Product
        //     {
        //         Id = "B0001-65mm-9Y",
        //         Description = "9ct Yellow Gold Bangle",
        //         Metal = "9ct Yellow Gold",
        //         Gemstone = "None",
        //         Size = "65",
        //         CostPrice = 150.00m,
        //         SellPrice = 299.99m,
        //         MarkUp = 100,
        //         JewelleryType = ProductType.Bangle,
        //         RingSizeType = RingSizeType.NotApplicable,
        //         SizeMeasurementType = SizeMeasurementType.Millimetres,
        //     };
        // }

        [Fact]
        public void Constructor_Success_CreatesEmptyInventoryDictionary()
        {
            // Arrange & Act
            InventoryManagement inventory = new InventoryManagement();

            // Assert
            Assert.NotNull(inventory);
            Assert.Empty(inventory.GetAllStockItems());
        }

        [Fact]
        public void IncreaseStock_AddsStockItemToInventory()
        {
            // Arrange
            InventoryManagement inventory = new InventoryManagement();
            string productId = "B0001-65mm-9Y";
            int quantity = 10;

            // Act
            inventory.IncreaseStock(productId, quantity);

            // Assert
            Assert.Single(inventory.GetAllStockItems());
            Assert.True(inventory.GetAllStockItems().ContainsKey(productId));
            Assert.Equal(quantity, inventory.GetAllStockItems()[productId].QuantityOnHand);
        }

        [Fact]
        public void IncreaseStock_ExistingStockItem_IncreasesQuantity()
        {
            // Arrange
            InventoryManagement inventory = new InventoryManagement();
            string productId = "B0001-65mm-9Y";
            int initialQuantity = 10;
            int additionalQuantity = 5;
            inventory.IncreaseStock(productId, initialQuantity);

            // Act
            inventory.IncreaseStock(productId, additionalQuantity);

            // Assert
            Assert.Single(inventory.GetAllStockItems());
            Assert.True(inventory.GetAllStockItems().ContainsKey(productId));
            Assert.Equal(
                initialQuantity + additionalQuantity,
                inventory.GetAllStockItems()[productId].QuantityOnHand
            );
        }

        [Fact]
        public void ReduceStock_ReducesStockItemQuantityInInventory()
        {
            // Arrange
            InventoryManagement inventory = new InventoryManagement();
            string productId = "B0001-65mm-9Y";
            int initialQuantity = 10;
            int reductionQuantity = 4;
            inventory.IncreaseStock(productId, initialQuantity);

            // Act
            inventory.ReduceStock(productId, reductionQuantity);
            // Assert
            Assert.Equal(
                initialQuantity - reductionQuantity,
                inventory.GetAllStockItems()[productId].QuantityOnHand
            );
        }

        [Fact]
        public void ReduceQuantity_StockItemDoesNotExist_ThrowException()
        {
            // Arrange
            InventoryManagement inventory = new InventoryManagement();
            string invalidProductId = "INVALID_PRODUCT_ID";
            int reductionQuantity = 2;

            // Act & Assert
            var exception = Assert.Throws<StockItemNotFoundException>(
                () => inventory.ReduceStock(invalidProductId, reductionQuantity)
            );

            Assert.Equal(
                $"The stock item with ID {invalidProductId} was not found in inventory.",
                exception.Message
            );
        }
    }
}
