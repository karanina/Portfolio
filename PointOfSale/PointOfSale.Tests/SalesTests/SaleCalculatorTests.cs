using PointOfSale.Inventory.Products;
using PointOfSale.Inventory.StockLevel;
using PointOfSale.Sales;
using PointOfSale.Tests.TestDoubles;
using Xunit;

namespace PointOfSale.Tests.SalesTests
{
    public class SaleCalculatorTests
    {
        [Fact]
        public void CalculateLineTotal_MultipliesByQuantity()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            decimal sellPrice = 199.99m;
            int quantityOnHand = 10;
            int saleQuantity = 2;

            ProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                sellPrice
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, quantityOnHand);

            // No customer discount for simplicity in this test, as we're only testing that quantity is multiplied correctly
            Sale sale = new Sale(new Customer(1, "Test customer"), inventory, catalogue);
            sale.AddItem(productId, saleQuantity);

            SaleItemView item = Assert.Single(sale.GetItems());
            // SaleItemView item = sale.GetItems().First(i => i.ProductId == productId);

            SaleCalculator salecalculator = new SaleCalculator(sale);

            // Act
            var total = salecalculator.CalculateLineTotal(item);

            // Assert
            Assert.Equal(sellPrice * saleQuantity, total);
        }

        [Fact]
        public void CalculateLineTotal_AppliesDiscountRate()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            decimal sellPrice = 199.99m;
            int quantityOnHand = 10;
            int saleQuantity = 2;

            ProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                sellPrice
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, quantityOnHand);

            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);
            sale.AddItem(productId, saleQuantity);

            SaleItemView item = Assert.Single(sale.GetItems());

            SaleCalculator salecalculator = new SaleCalculator(sale);

            // Act
            var actual = salecalculator.CalculateLineTotal(item);

            // Assert
            // Discount rate is an integer percentage, so we convert it to a decimal for calculation
            decimal expected = Math.Round(
                sellPrice * saleQuantity * (1 - (sale.Customer.DiscountRate / 100m)),
                2
            );
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateLineTotal_ManualItemDiscountOverridesCustomerDiscount()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            decimal salePrice = 199.99m;
            int quantityOnHand = 10;
            int saleQuantity = 2;
            int manualDiscountRate = 20; // 20% manual discount

            ProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                salePrice
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, quantityOnHand);

            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);
            sale.AddItem(productId, saleQuantity);

            SaleItem item = sale.GetItem(productId);
            item.ApplyManualDiscount(manualDiscountRate);

            SaleCalculator salecalculator = new SaleCalculator(sale);

            // Act
            var actual = salecalculator.CalculateLineTotal(new SaleItemView(
                item.ProductId,
                item.Description,
                item.UnitPrice,
                item.Quantity,
                item.ManualDiscountRate,
                item.IsManualUnitPrice
            ));

            // Assert
            // Discount rate is an integer percentage, so we convert it to a decimal for calculation
            decimal expected = Math.Round(
                salePrice * saleQuantity * (1 - (manualDiscountRate / 100m)),
                2
            );
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateLineTotal_ManualUnitPriceDoesNotGetDiscounted()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            decimal salePrice = 199.99m;
            decimal manualUnitPrice = 149.99m;
            int quantityOnHand = 10;
            int saleQuantity = 2;

            ProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                salePrice
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, quantityOnHand);

            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);
            sale.AddItem(productId, saleQuantity);
            SaleItem item = sale.GetItem(productId);
            item.OverrideUnitPrice(manualUnitPrice);

            SaleCalculator salecalculator = new SaleCalculator(sale);

            // Act
            var total = salecalculator.CalculateLineTotal(new SaleItemView(
                item.ProductId,
                item.Description,
                item.UnitPrice,
                item.Quantity,
                item.ManualDiscountRate,
                item.IsManualUnitPrice
            ));

            // Assert
            Assert.Equal(manualUnitPrice * saleQuantity, total);
        }

        [Fact]
        public void CalculateLineTotal_RoundsToTwoDecimalPlaces()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            decimal salePrice = 199.99m;
            int quantityOnHand = 10;
            int saleQuantity = 2;

            ProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                salePrice
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, quantityOnHand);

            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);
            sale.AddItem(productId, saleQuantity);
            SaleItem item = sale.GetItem(productId);

            SaleCalculator salecalculator = new SaleCalculator(sale);

            // Act
            var actual = salecalculator.CalculateLineTotal(new SaleItemView(
                item.ProductId,
                item.Description,
                item.UnitPrice,
                item.Quantity,
                item.ManualDiscountRate,
                item.IsManualUnitPrice
            ));

            // Assert
            // Discount rate is an integer percentage, so we convert it to a decimal for calculation
            decimal expected = Math.Round(
                salePrice * saleQuantity * (1 - (sale.Customer.DiscountRate / 100m)),
                2
            );
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateSubTotal_IsSumOfAllLineTotals()
        {
            // Arrange
            string productId1 = "B0001-65mm-9Y";
            decimal salePrice1 = 199.99m;
            int quantityOnHand1 = 10;
            int saleQuantity1 = 2;

            string productId2 = "N0001-60cm-STG";
            decimal salePrice2 = 49.99m;
            int quantityOnHand2 = 5;
            int saleQuantity2 = 1;

            ProductSpecification product1 = new TestProductSpecification(
                productId1,
                "Test Product 1",
                salePrice1
            );

            ProductSpecification product2 = new TestProductSpecification(
                productId2,
                "Test Product 2",
                salePrice2
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product1);
            catalogue.AddProduct(product2);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId1, quantityOnHand1);
            inventory.IncreaseStock(productId2, quantityOnHand2);

            Sale sale = new Sale(new Customer(1, "Test customer", 10), inventory, catalogue);
            sale.AddItem(productId1, saleQuantity1);
            sale.AddItem(productId2, saleQuantity2);

            SaleCalculator salecalculator = new SaleCalculator(sale);

            // Act
            var actual = salecalculator.CalculateSubTotal();

            // Assert
            decimal expected = Math.Round(
                product1.SellPrice * saleQuantity1 * (1 - (sale.Customer.DiscountRate / 100m))
                    + product2.SellPrice
                        * saleQuantity2
                        * (1 - (sale.Customer.DiscountRate / 100m)),
                2
            );
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateGST_FromInclusiveSubtotal_CalculatesGSTAtNominatedPercentage()
        {
            // Arrange
            string productId = "B0001-65mm-9Y";
            decimal salePrice = 199.99m;
            int quantityOnHand = 10;
            int saleQuantity = 2;
            int gstRate = 15; // 15% GST

            ProductSpecification product = new TestProductSpecification(
                productId,
                "Test Product",
                salePrice
            );

            IProductCatalogue catalogue = new ProductCatalogue();
            catalogue.AddProduct(product);

            InventoryManagement inventory = new InventoryManagement();
            inventory.IncreaseStock(productId, quantityOnHand);

            Sale sale = new Sale(new Customer(1, "Test customer"), inventory, catalogue);
            sale.AddItem(productId, saleQuantity);

            SaleCalculator salecalculator = new SaleCalculator(sale);
            // customer has no discount, so subtotal is just sale price * quantity
            decimal subTotal = salePrice * saleQuantity;

            // Act
            decimal actual = salecalculator.CalculateGST(gstRate);

            // Assert
            decimal expected = Math.Round(subTotal - (subTotal / (1 + (gstRate / 100m))), 2);
            Assert.Equal(expected, actual);
        }
    }
}
