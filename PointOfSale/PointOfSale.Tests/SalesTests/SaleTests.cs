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
        public void CreateingSale_StatusIsOpen()
        {
            // Arrange
            IProductCatalogue catalogue = new ProductCatalogue();
            InventoryManagement inventory = new InventoryManagement();
            Customer customer = new Customer(1, "Test customer", 10);

            // Act
            Sale sale = new Sale(customer, inventory, catalogue);

            // Assert
            Assert.Equal(SaleStatus.Open, sale.Status);
        }

        [Fact]
        public void CreatingSale_HasNoPaymentsRegistered()
        {
            // Arrange
            IProductCatalogue catalogue = new ProductCatalogue();
            InventoryManagement inventory = new InventoryManagement();
            Customer customer = new Customer(1, "Test customer", 10);

            // Act
            Sale sale = new Sale(customer, inventory, catalogue);

            // Assert
            Assert.Equal(0m, sale.GetTotalPaid());
        }

        [Fact]
        public void AddItem_AddsSingleItemToSale()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );

            // Act
            context.Sale.AddItem(productId, 1);

            // Assert
            var items = context.Sale.GetItems();
            Assert.Single(items);
            Assert.Contains(items, i => i.ProductId == productId);
            Assert.Equal(1, context.Sale.GetItemQuantity(productId));
        }

        [Fact]
        public void AddItem_QuantityIsLessThanOne_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            // Act & Assert
            var exception = Assert.Throws<QuantityException>(
                () => context.Sale.AddItem(productId, 0)
            );
            Assert.Equal("Quantity cannot be less than 1.", exception.Message);
        }

        [Fact]
        public void AddItem_ReducesInventoryStock()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int initialQuantity = 10;
            int saleQuantity = 3;

            SaleTestContext context = new SaleTestContext(
                productId,
                initialQuantity,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );

            // Act
            context.Sale.AddItem(productId, saleQuantity);

            // Assert
            Assert.Equal(
                initialQuantity - saleQuantity,
                context.Inventory.GetAllStockItems()[productId].QuantityOnHand
            );
        }

        [Fact]
        public void AddItem_WhenSaleStatusIsCompleted_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );

            context.Sale.AddItem(productId, 1);

            SaleCalculator calculator = new SaleCalculator(context.Sale);
            decimal totalDue = calculator.CalculateSubTotal();
            context.Sale.MakePayment(totalDue);

            context.Sale.CompleteSale(totalDue);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(
                () => context.Sale.AddItem(productId, 1)
            );
            Assert.Equal("Sale cannot be modified unless it is open.", exception.Message);
        }

        [Fact]
        public void RemoveItem_RemovesItemFromSale()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, 1);

            // Act
            context.Sale.RemoveItem(productId);

            // Assert
            Assert.Empty(context.Sale.GetItems());
        }

        [Fact]
        public void RemoveItem_ItemNotInSale_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;
            string nonExistentItemId = "NON-EXISTENT-ID";

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );

            context.Sale.AddItem(productId, 1);

            // Act & Assert
            var exception = Assert.Throws<SaleItemNotFoundException>(
                () => context.Sale.RemoveItem(nonExistentItemId)
            );
            Assert.Equal(
                $"The product with ID {nonExistentItemId} was not found in your sale",
                exception.Message
            );
        }

        [Fact]
        public void RemoveItem_WhenSaleStatusIsCompleted_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, 1);

            SaleCalculator calculator = new SaleCalculator(context.Sale);
            decimal totalDue = calculator.CalculateSubTotal();
            context.Sale.MakePayment(totalDue);
            context.Sale.CompleteSale(totalDue);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(
                () => context.Sale.RemoveItem(productId)
            );
            Assert.Equal("Sale cannot be modified unless it is open.", exception.Message);
        }

        [Fact]
        public void RemoveItem_IncreasesInventoryStock()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int initialQuantity = 10;
            int saleQuantity = 3;

            SaleTestContext context = new SaleTestContext(
                productId,
                initialQuantity,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, saleQuantity);

            int remainingQuantityOnHand = context
                .Inventory.GetAllStockItems()[productId]
                .QuantityOnHand;

            // Act
            context.Sale.RemoveItem(productId);

            // Assert
            Assert.Equal(
                remainingQuantityOnHand + saleQuantity,
                context.Inventory.GetAllStockItems()[productId].QuantityOnHand
            );
        }

        [Fact]
        public void ChangeItemQuanity_UpdatesQuantityOfItem()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;
            int newQuantity = 5;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, 2);

            //Act
            context.Sale.ChangeItemQuantity(productId, newQuantity);

            // Assert
            Assert.Single(context.Sale.GetItems());
            Assert.Equal(newQuantity, context.Sale.GetItemQuantity(productId));
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

            SaleTestContext context = new SaleTestContext(
                productId,
                initialQuantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, initialSaleQuantity);

            //Act
            context.Sale.ChangeItemQuantity(productId, newSaleQuantity);

            // Assert
            Assert.Equal(
                initialQuantityOnHand - newSaleQuantity,
                context.Inventory.GetAllStockItems()[productId].QuantityOnHand
            );
        }

        [Fact]
        public void ChangeItemQuantity_ToZero_RemovesItemFromSale()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, 1);

            //Act
            context.Sale.ChangeItemQuantity(productId, 0);

            // Assert
            Assert.Empty(context.Sale.GetItems());
        }

        [Fact]
        public void ChangeItemQuantity_NegativeQuantity_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );

            context.Sale.AddItem(productId, 1);

            // Act & Assert
            var exception = Assert.Throws<QuantityException>(
                () => context.Sale.ChangeItemQuantity(productId, -1)
            );
            Assert.Equal("Quantity cannot be negative.", exception.Message);
        }

        [Fact]
        public void ChangeItemQuantity_WhenSaleStatusIsCompleted_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );

            context.Sale.AddItem(productId, 1);

            SaleCalculator calculator = new SaleCalculator(context.Sale);
            decimal totalDue = calculator.CalculateSubTotal();
            context.Sale.MakePayment(totalDue);
            context.Sale.CompleteSale(totalDue);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(
                () => context.Sale.ChangeItemQuantity(productId, -1)
            );
            Assert.Equal("Sale cannot be modified unless it is open.", exception.Message);
        }

        [Fact]
        public void ChangeItemQuantity_ItemDoesNotExist_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";

            IProductCatalogue catalogue = new ProductCatalogue();

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

        [Fact]
        public void CompleteSale_ChangesSaleStatusToCompleted()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, 1);

            SaleCalculator calculator = new SaleCalculator(context.Sale);
            decimal totalDue = calculator.CalculateSubTotal();
            context.Sale.MakePayment(totalDue);

            // Act
            context.Sale.CompleteSale(totalDue);

            // Assert
            Assert.Equal(SaleStatus.Completed, context.Sale.Status);
        }

        [Fact]
        public void CompleteSale_StatusAlreadyComplete_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, 1);

            SaleCalculator calculator = new SaleCalculator(context.Sale);
            decimal totalDue = calculator.CalculateSubTotal();
            context.Sale.MakePayment(totalDue);
            context.Sale.CompleteSale(totalDue);

            // Act
            var exception = Assert.Throws<InvalidOperationException>(
                () => context.Sale.CompleteSale(totalDue)
            );
            // Assert
            Assert.Equal("Only an open sale can be completed.", exception.Message);
        }

        [Fact]
        public void CompleteSale_NoItems_ThrowsException()
        {
            // Arrange
            IProductCatalogue catalogue = new ProductCatalogue();
            InventoryManagement inventory = new InventoryManagement();
            Customer customer = new Customer(1, "Test customer", 10);

            Sale sale = new Sale(customer, inventory, catalogue);

            // Act
            var exception = Assert.Throws<InvalidOperationException>(() => sale.CompleteSale(100m));

            // Assert
            Assert.Equal("Cannot complete a sale with no items.", exception.Message);
        }

        [Fact]
        public void CompleteSale_PaymentNotMade_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, 1);

            SaleCalculator calculator = new SaleCalculator(context.Sale);
            decimal totalDue = calculator.CalculateSubTotal();

            // Act
            var exception = Assert.Throws<PaymentException>(
                () => context.Sale.CompleteSale(totalDue)
            );

            // Assert
            Assert.Equal(
                "Cannot complete sale until full payment has been made.",
                exception.Message
            );
        }

        [Fact]
        public void CompleteSale_PaymentOnlyPartiallyMade_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, 1);
            context.Sale.MakePayment(100m);

            SaleCalculator calculator = new SaleCalculator(context.Sale);
            decimal totalDue = calculator.CalculateSubTotal();

            // Act
            var exception = Assert.Throws<PaymentException>(
                () => context.Sale.CompleteSale(totalDue)
            );

            // Assert
            Assert.Equal(
                "Cannot complete sale until full payment has been made.",
                exception.Message
            );
        }

        [Fact]
        public void CancelSale_ChangesStatusToCancelled()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, 1);

            // Act
            context.Sale.CancelSale();

            // Assert
            Assert.Equal(SaleStatus.Cancelled, context.Sale.Status);
        }

        [Fact]
        public void CancelSale_RestoresInventoryStock()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int initialQuantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                initialQuantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );

            context.Sale.AddItem(productId, 1);

            // Act
            context.Sale.CancelSale();

            // Assert
            Assert.Equal(initialQuantityOnHand, context.Inventory.GetStockLevel(productId));
        }

        [Fact]
        public void CancelSale_WhenStatusIsCompleted_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, 1);

            SaleCalculator calculator = new SaleCalculator(context.Sale);
            decimal totalDue = calculator.CalculateSubTotal();
            context.Sale.MakePayment(totalDue);
            context.Sale.CompleteSale(totalDue);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(
                () => context.Sale.CancelSale()
            );
            Assert.Equal("Only an open sale can be cancelled.", exception.Message);
        }

        [Fact]
        public void CancelSale_WhenStatusIsCancelled_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );

            context.Sale.AddItem(productId, 1);
            context.Sale.CancelSale();

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(
                () => context.Sale.CancelSale()
            );
            Assert.Equal("Only an open sale can be cancelled.", exception.Message);
        }

        [Fact]
        public void MakePayment_UpdatesTotalPaid()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, 1);

            // Act
            context.Sale.MakePayment(179.99m);

            // Assert
            // 199.99m - 10% discount = 179.99m
            Assert.Equal(179.99m, context.Sale.GetTotalPaid());
        }

        [Fact]
        public void MakePayment_WhenPaymentMadeTwice_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, 1);
            context.Sale.MakePayment(179.99m);

            // Act
            var exception = Assert.Throws<PaymentException>(
                () => context.Sale.MakePayment(179.99m)
            );

            // Assert
            Assert.Equal("Payment has already been made for this sale.", exception.Message);
        }

        [Fact]
        public void MakePayment_PaymentAmountIsZero_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, 1);

            // Act & Assert
            var exception = Assert.Throws<PaymentException>(() => context.Sale.MakePayment(0.0m));

            Assert.Equal("Payment amount must be greater than zero.", exception.Message);
        }

        [Fact]
        // Separate test from zero payment amount as I'm using a decimal data type and Inline Theory doesn't work with
        // decimal data types.
        public void MakePayment_PaymentAmountIsLessThanZero_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, 1);

            // Act & Assert
            var exception = Assert.Throws<PaymentException>(() => context.Sale.MakePayment(-0.01m));

            Assert.Equal("Payment amount must be greater than zero.", exception.Message);
        }

        [Fact]
        public void MakePayment_SaleIsNotOpen_ThrowsException()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            int quantityOnHand = 10;

            SaleTestContext context = new SaleTestContext(
                productId,
                quantityOnHand,
                "Test Product",
                199.99m,
                new Customer(1, "Test customer", 10)
            );
            context.Sale.AddItem(productId, 1);
            
            SaleCalculator calculator = new SaleCalculator(context.Sale);
            decimal totalDue = calculator.CalculateSubTotal();
            context.Sale.MakePayment(totalDue);
            context.Sale.CompleteSale(totalDue);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(
                () => context.Sale.MakePayment(totalDue)
            );

            Assert.Equal("This sale is not open for payment.", exception.Message);
        }
    }
}
