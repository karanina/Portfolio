using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout;
using Xunit;

namespace Checkout.Tests
{
    public class PricingRulesTests
    {
        [Fact]
        public void PricingRules_ShouldConstructDefault()
        {
            string expected_item = "";
            decimal expected_unitPrice = 0;
            string expected_specialPrice = "";

            PricingRules rule = new PricingRules();

            Assert.Equal(expected_item, rule.item);
            Assert.Equal(expected_unitPrice, rule.unitPrice);
            Assert.Equal(expected_specialPrice, rule.specialPrice);
        }

        [Theory]
        [InlineData("A", 0.01)]
        [InlineData("B", 1)]
        [InlineData("C", 1.9)]
        [InlineData("D", 1.99)]
        [InlineData("E", 1.999)]
        [InlineData("F", 1.9999)]
        public void PricingRules_ShouldConstructPartial(string item, decimal unitPrice)
        {
            string expected_specialPrice = "";

            PricingRules rule = new PricingRules(item, unitPrice);

            Assert.Equal(item, rule.item);
            Assert.Equal(unitPrice, rule.unitPrice);
            Assert.Equal(expected_specialPrice, rule.specialPrice);
        }

        [Theory]
        [InlineData("A", -1)]
        [InlineData("B", -0.01)]
        [InlineData("C", 0)]
        public void PricingRules_ShouldNotConstructPartial(string item, decimal unitPrice)
        {
            Assert.Throws<ArgumentException>("unitPrice", () => new PricingRules(item, unitPrice));
        }

        [Theory]
        [InlineData("A", 0.01, "3 for 2")]
        [InlineData("B", 1, "3 for 2")]
        [InlineData("C", 1.9, "4 for 6")]
        [InlineData("D", 1.99, "6 for 10")]
        [InlineData("E", 1.999, "6 for 11")]
        [InlineData("F", 1.9999, "7 for 12")]
        public void PricingRules_ShouldConstructFull(string item, decimal unitPrice, string specialPrice)
        {
            PricingRules rule = new PricingRules(item, unitPrice, specialPrice);

            Assert.Equal(item, rule.item);
            Assert.Equal(unitPrice, rule.unitPrice);
            Assert.Equal(specialPrice, rule.specialPrice);
        }

        [Theory]
        [InlineData("A", -1, "3 for 2")]
        [InlineData("B", -0.01,"2 for 1")]
        [InlineData("C", 0, "4 for 3")]
        public void PricingRules_ShouldNotConstructFull(string item, decimal unitPrice, string specialPrice)
        {
            Assert.Throws<ArgumentException>("unitPrice", () => new PricingRules(item, unitPrice, specialPrice));
        }






    }
}
