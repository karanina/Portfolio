using System.Drawing;
using PointOfSale;
using Xunit;
using Xunit.Sdk;

namespace PointOfSale.Tests
{
    public class ProductSizeRulesTests
    {
        [Theory]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.ExtraSmall, "A")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.ExtraSmall, "B")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.Small, "C")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.Small, "J")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.Medium, "K")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.Medium, "R")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.Large, "S")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.Large, "Z")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.ExtraLarge, "Z+1")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.ExtraLarge, "Z+8")]
        public void ValidateSize_Success_WithValidRingSize(
            ProductType productType,
            SizeMeasurementType sizeMeasurementType,
            RingSizeType ringSizeType,
            string size
        )
        {
            // Act
            var exception = Record.Exception(
                () =>
                    ProductSizeRules.ValidateSize(
                        productType,
                        sizeMeasurementType,
                        size,
                        ringSizeType
                    )
            );

            // Assert
            Assert.Null(exception); // in this instance, no exception means validation passed
        }

        [Theory]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.ExtraLarge, "A")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.Small, "B")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.ExtraSmall, "C")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.Medium, "J")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.Small, "K")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.Large, "R")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.Medium, "S")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.ExtraLarge, "Z")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.Large, "Z+1")]
        [InlineData(ProductType.Ring, SizeMeasurementType.UKRing, RingSizeType.ExtraSmall, "Z+8")]
        public void ValidateSize_ThrowsException_WithInvalidRingSize(
            ProductType productType,
            SizeMeasurementType sizeMeasurementType,
            RingSizeType ringSizeType,
            string size
        )
        {
            // Act
            var exception = Assert.Throws<ArgumentException>(
                () =>
                    ProductSizeRules.ValidateSize(
                        productType,
                        sizeMeasurementType,
                        size,
                        ringSizeType
                    )
            );

            // Assert
            Assert.Equal(
                $"Invalid ring size '{size}' for ring size type '{ringSizeType}'.",
                exception.Message
            );
        }

        [Theory]
        [InlineData(ProductType.Necklace, SizeMeasurementType.Cm, "45")]
        [InlineData(ProductType.Chain, SizeMeasurementType.Cm, "55")]
        [InlineData(ProductType.Bracelet, SizeMeasurementType.Cm, "15")]
        [InlineData(ProductType.Anklet, SizeMeasurementType.Cm, "22")]
        public void ValidateSize_Success_WithValidCmMeasurementType(
            ProductType productType,
            SizeMeasurementType sizeMeasurementType,
            string size
        )
        {
            // Act
            var exception = Record.Exception(
                () => ProductSizeRules.ValidateSize(productType, sizeMeasurementType, size)
            );

            // Assert
            Assert.Null(exception); // in this instance, no exception means validation passed
        }

        [Theory]
        [InlineData(ProductType.Necklace, SizeMeasurementType.Cm, "15")]
        [InlineData(ProductType.Chain, SizeMeasurementType.Cm, "10")]
        [InlineData(ProductType.Bracelet, SizeMeasurementType.Cm, "55")]
        [InlineData(ProductType.Anklet, SizeMeasurementType.Cm, "45")]
        public void ValidateSize_ThrowsException_WithInvalidCmMeasurementType(
            ProductType productType,
            SizeMeasurementType sizeMeasurementType,
            string size
        )
        {
            // Act
            var exception = Assert.Throws<ArgumentException>(
                () => ProductSizeRules.ValidateSize(productType, sizeMeasurementType, size)
            );

            // Assert
            Assert.Equal(
                $"{size + sizeMeasurementType} is an invalid size for {productType}.",
                exception.Message
            );
        }
    }
}
