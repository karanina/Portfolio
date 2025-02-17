using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout;
using Xunit;


namespace Checkout.Tests
{
    public class CheckoutTests
    {
        [Fact]
        public void Checkout_ShouldCreateDataStructures()
        {
            int expected_pricingRules_count = 0;
            int expected_cart_count = 0;

            Checkout co = new Checkout();

            Assert.Equal(expected_pricingRules_count, co.pricingRules.Count);
            Assert.Equal(expected_cart_count, co.cart.Count);
        }

        [Fact]
        public void New_ShouldAddUniquePricingRule()
        {
            string item = "A";
            decimal unitPrice = 10;
            string specialPrice = "2 for 15";

            PricingRules rule = new PricingRules(item, unitPrice, specialPrice);

            Checkout co = new Checkout();
            co.New(rule);

            Assert.True(co.pricingRules.Count == 1);
            Assert.Contains(rule, co.pricingRules);
        }

        [Fact]
        public void New_ShouldNotAddDuplicatePricingRule()
        {
            string item = "A";
            decimal unitPrice = 10;
            string specialPrice = "2 for 15";

            PricingRules rule = new PricingRules(item, unitPrice, specialPrice);

            Checkout co = new Checkout();
            co.New(rule);

            Assert.Throws<ArgumentException>("item", () => co.New(rule));
            Assert.True(co.pricingRules.Count == 1);
            Assert.Contains(rule, co.pricingRules);
        }

        [Fact]
        public void PricingRuleExists_DoesExist()
        {
            string item = "A";
            decimal unitPrice = 10;
            string specialPrice = "2 for 15";

            PricingRules rule = new PricingRules(item, unitPrice, specialPrice);

            Checkout co = new Checkout();
            co.New(rule);

            Assert.True(co.PricingRuleExists(item));
        }

        [Fact]
        public void PricingRuleExists_DoesNotExist()
        {
            string item = "B";

            Checkout co = new Checkout();

            Assert.False(co.PricingRuleExists(item));
        }

        [Fact]
        public void GetPricingRuleByItemCode_PricingRuleExists()
        {
            string item = "A";
            decimal unitPrice = 10;
            string specialPrice = "2 for 15";

            PricingRules rule = new PricingRules(item, unitPrice, specialPrice);

            Checkout co = new Checkout();
            co.New(rule);

            PricingRules returnedRule = co.GetPricingRuleByItemCode(item);

            Assert.Equal(rule, returnedRule);
        }

        [Fact]
        public void GetPricingRuleByItemCode_PricingRuleDoesNotExists()
        {
            string item = "A";
            string expected_item = "";
            decimal expected_unitPrice = 0;
            string expected_specialPrice = "";

            Checkout co = new Checkout();

            PricingRules returnedRule = co.GetPricingRuleByItemCode(item);

            Assert.Equal(expected_item, returnedRule.item);
            Assert.Equal(expected_unitPrice, returnedRule.unitPrice);
            Assert.Equal(expected_specialPrice, returnedRule.specialPrice);
        }

        [Fact]
        public void Scan_AddsValidNewItemToCart()
        {
            string item = "A";
            int expected_cart_count = 1;
            int expected_item_count = 1;

            Checkout co = new Checkout();
            TestSetup.SetUp_PricingRules(co);

            co.Scan(item);

            Assert.Equal(expected_cart_count, co.cart.Count);
            Assert.Equal(expected_item_count, co.cart[item]);
        }

        [Fact]
        public void Scan_DoesNotAddInvalidNewItemToCart()
        {
            string item = "A";
            int expected_cart_count = 0;

            Checkout co = new Checkout();

            Assert.Throws<ArgumentException>("item", () => co.Scan(item));
            Assert.Equal(expected_cart_count, co.cart.Count);
        }

        [Fact]
        public void Scan_AddsValidDuplicateItemsToCart()
        {
            string item = "A";
            int expected_cart_count = 1;
            int expected_item_count = 2;

            Checkout co = new Checkout();
            TestSetup.SetUp_PricingRules(co);

            co.Scan(item);
            co.Scan(item);

            Assert.Equal(expected_cart_count, co.cart.Count);
            Assert.Equal(expected_item_count, co.cart[item]);
        }

        [Fact]
        public void Scan_AddsValidMultipleItemsToCart()
        {
            string first_item = "A";
            string second_item = "B";

            int expected_cart_count = 2;
            int expected_first_item_count = 1;
            int expected_second_item_count = 1;

            Checkout co = new Checkout();
            TestSetup.SetUp_PricingRules(co);

            co.Scan(first_item);
            co.Scan(second_item);

            Assert.Equal(expected_cart_count, co.cart.Count);
            Assert.Equal(expected_first_item_count, co.cart[first_item]);
            Assert.Equal(expected_second_item_count, co.cart[second_item]);
        }

        [Theory]
        [MemberData(nameof(TestSetup.SetUp_CheckoutTotalTestData), MemberType = typeof(TestSetup))]
        public void Total_DoesAdd(decimal expectedTotal, string[] itemsInCart)
        {
            Checkout co = new Checkout();

            TestSetup.SetUp_PricingRules(co);
            TestSetup.SetUp_Cart(co, itemsInCart);

            decimal actualTotal = co.Total();

            Assert.Equal(expectedTotal, actualTotal);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(3.1, 2, 6.2)]
        [InlineData(3.1, 4.1, 12.71)]
        [InlineData(3.5, 5, 17.5)]
        [InlineData(3.5, 4.5, 15.75)]
        [InlineData(4.99, 6, 29.94)]
        [InlineData(4.99, 5.99, 29.89)]
        public void CalculateLineTotalUnitPrice_ShouldCalculate(decimal unitPrice, decimal quantity, decimal expected)
        {
            Checkout co = new Checkout();
            decimal actual = co.CalculateLineTotalUnitPrice(unitPrice, quantity);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(3.1, 4.1, 13)]
        [InlineData(3.5, 4.5, 16)]
        [InlineData(4.99, 5.99, 20)]
        public void CalculateLineTotalUnitPrice_ShouldNotCalculate(decimal unitPrice, decimal quantity, decimal expected)
        {
            Checkout co = new Checkout();
            decimal actual = co.CalculateLineTotalUnitPrice(unitPrice, quantity);

            Assert.NotEqual(expected, actual);
        }

        [Theory]
        [InlineData("3 for 130", 50, 3, 130)]
        [InlineData("3 for 130", 50, 4, 180)]
        [InlineData("3 for 130", 50, 6, 260)]
        public void CalculateLineTotalSpecialPrice_CalculatesPrice(string specialPrice, decimal unitPrice, decimal quantity, decimal expected)
        {
            Checkout co = new Checkout();
            decimal actual = co.CalculateLineTotalSpecialPrice(specialPrice, unitPrice, quantity);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("3 for 130", 3, 130)]
        [InlineData("1.50 per gram", 1, 1.5)]
        [InlineData("3 for $130", 3, 130)]
        [InlineData("$1.50 per gram", 1, 1.5)]
        public void ExtractSpecialPrice_ExtractsFromStandardFormat(string specialPrice, decimal expected_multiQty, decimal expected_multiPrice)
        {
            Checkout co = new Checkout();
            (decimal actual_multiQty, decimal actual_multiPrice) = co.ExtractSpecialPrice(specialPrice);

            Assert.Equal(expected_multiQty, actual_multiQty);
            Assert.Equal(expected_multiPrice, actual_multiPrice);
        }


        [Theory]
        [InlineData("three for one hundred and thirty")]
        [InlineData("")]
        public void ExtractSpecialPrice_DoesNotExtractFromUnrecognisedFormat(string specialPrice)
        {
            Checkout co = new Checkout();

            Assert.Throws<ArgumentException>("specialPrice", () => co.ExtractSpecialPrice(specialPrice));
        }
    }
}
