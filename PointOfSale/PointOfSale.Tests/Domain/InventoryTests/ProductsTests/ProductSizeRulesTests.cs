// using PointOfSale.Inventory;
// using Xunit;

// namespace PointOfSale.Tests.InventoryTests
// {
//     public class ProductSizeRulesTests
//     {
//         [Theory]
//         [InlineData(SizeMeasurementType.Centimetres, ProductType.Necklace, "45")]
//         [InlineData(SizeMeasurementType.Centimetres, ProductType.Chain, "55")]
//         [InlineData(SizeMeasurementType.Centimetres, ProductType.Bracelet, "15")]
//         [InlineData(SizeMeasurementType.Centimetres, ProductType.Anklet, "22")]
//         public void ValidateSize_Success_WithCentimetresMeasurementTypeAndValidProductTypeAndSize(
//             SizeMeasurementType sizeMeasurementType,
//             ProductType productType,
//             string size
//         )
//         {
//             // Act
//             var exception = Record.Exception(
//                 () => ProductSizeRules.ValidateSize(sizeMeasurementType, productType, size)
//             );

//             // Assert
//             Assert.Null(exception); // in this instance, no exception means validation passed
//         }

//         [Theory]
//         [InlineData(SizeMeasurementType.Centimetres, ProductType.Necklace, "15")]
//         [InlineData(SizeMeasurementType.Centimetres, ProductType.Chain, "10")]
//         [InlineData(SizeMeasurementType.Centimetres, ProductType.Bracelet, "55")]
//         [InlineData(SizeMeasurementType.Centimetres, ProductType.Anklet, "45")]
//         public void ValidateSize_ThrowsException_WithCentimetresMeasurementTypeAndValidProductTypeAndInvalidSize(
//             SizeMeasurementType sizeMeasurementType,
//             ProductType productType,
//             string size
//         )
//         {
//             // Act
//             var exception = Assert.Throws<ArgumentException>(
//                 () => ProductSizeRules.ValidateSize(sizeMeasurementType, productType, size)
//             );

//             // Assert
//             Assert.Equal($"{size}centimetres is an invalid size for {productType}.", exception.Message);
//         }

//         [Theory]
//         [InlineData(SizeMeasurementType.Centimetres, ProductType.Bangle, "45")]
//         [InlineData(SizeMeasurementType.Centimetres, ProductType.Brooch, "55")]
//         [InlineData(SizeMeasurementType.Centimetres, ProductType.Charm, "15")]
//         [InlineData(SizeMeasurementType.Centimetres, ProductType.Cufflink, "22")]
//         [InlineData(SizeMeasurementType.Centimetres, ProductType.Earring, "17")]
//         [InlineData(SizeMeasurementType.Centimetres, ProductType.Pendant, "60")]
//         [InlineData(SizeMeasurementType.Centimetres, ProductType.Ring, "65")]
//         public void ValidateSize_ThrowsException_WithCentimetresMeasurementTypeAndInvalidProductTypeAndSize(
//             SizeMeasurementType sizeMeasurementType,
//             ProductType productType,
//             string size
//         )
//         {
//             // Act
//             var exception = Record.Exception(
//                 () => ProductSizeRules.ValidateSize(sizeMeasurementType, productType, size)
//             );

//             // Assert
//             Assert.Equal($"{size}centimetres is an invalid size for {productType}.", exception.Message);
//         }

//         [Theory]
//         [InlineData(SizeMeasurementType.Millimetres, ProductType.Bangle, "65")]
//         public void ValidateSize_Success_WithMillimetresMeasurementTypeAndValidProductTypeAndSize(
//             SizeMeasurementType sizeMeasurementType,
//             ProductType productType,
//             string size
//         )
//         {
//             // Act
//             var exception = Record.Exception(
//                 () => ProductSizeRules.ValidateSize(sizeMeasurementType, productType, size)
//             );

//             // Assert
//             Assert.Null(exception); // in this instance, no exception means validation passed
//         }

//         [Theory]
//         [InlineData(SizeMeasurementType.Millimetres, ProductType.Anklet, "15")]
//         [InlineData(SizeMeasurementType.Millimetres, ProductType.Bracelet, "15")]
//         [InlineData(SizeMeasurementType.Millimetres, ProductType.Brooch, "15")]
//         [InlineData(SizeMeasurementType.Millimetres, ProductType.Chain, "15")]
//         [InlineData(SizeMeasurementType.Millimetres, ProductType.Charm, "15")]
//         [InlineData(SizeMeasurementType.Millimetres, ProductType.Cufflink, "15")]
//         [InlineData(SizeMeasurementType.Millimetres, ProductType.Earring, "15")]
//         [InlineData(SizeMeasurementType.Millimetres, ProductType.Necklace, "15")]
//         [InlineData(SizeMeasurementType.Millimetres, ProductType.Pendant, "15")]
//         [InlineData(SizeMeasurementType.Millimetres, ProductType.Ring, "15")]
//         public void ValidateSize_ThrowsException_WithMillimetresMeasurementTypeAndInvalidProductTypeAndSize(
//             SizeMeasurementType sizeMeasurementType,
//             ProductType productType,
//             string size
//         )
//         {
//             // Act
//             var exception = Assert.Throws<ArgumentException>(
//                 () => ProductSizeRules.ValidateSize(sizeMeasurementType, productType, size)
//             );

//             // Assert
//             Assert.Equal($"{size}millimetres is an invalid size for {productType}.", exception.Message);
//         }

//         [Theory]
//         [InlineData(SizeMeasurementType.Millimetres, ProductType.Bangle, "15")]
//         public void ValidateSize_ThrowsException_WithMillimetresMeasurementTypeAndValidProductTypeAndInvalidSize(
//             SizeMeasurementType sizeMeasurementType,
//             ProductType productType,
//             string size
//         )
//         {
//             // Act
//             var exception = Assert.Throws<ArgumentException>(
//                 () => ProductSizeRules.ValidateSize(sizeMeasurementType, productType, size)
//             );

//             // Assert
//             Assert.Equal($"{size}millimetres is an invalid size for {productType}.", exception.Message);
//         }

//         [Theory]
//         [InlineData(SizeMeasurementType.OneSizeOnly, ProductType.Brooch, "One Size")]
//         [InlineData(SizeMeasurementType.OneSizeOnly, ProductType.Charm, "One Size")]
//         [InlineData(SizeMeasurementType.OneSizeOnly, ProductType.Cufflink, "One Size")]
//         [InlineData(SizeMeasurementType.OneSizeOnly, ProductType.Earring, "One Size")]
//         [InlineData(SizeMeasurementType.OneSizeOnly, ProductType.Pendant, "One Size")]
//         public void ValidateSize_Success_WithOneSizeOnlyMeasurementTypeAndValidProductTypeAndSize(
//             SizeMeasurementType sizeMeasurementType,
//             ProductType productType,
//             string size
//         )
//         {
//             // Act
//             var exception = Record.Exception(
//                 () => ProductSizeRules.ValidateSize(sizeMeasurementType, productType, size)
//             );

//             // Assert
//             Assert.Null(exception); // in this instance, no exception means validation passed
//         }

//         [Theory]
//         [InlineData(SizeMeasurementType.OneSizeOnly, ProductType.Anklet, "One Size")]
//         [InlineData(SizeMeasurementType.OneSizeOnly, ProductType.Bangle, "One Size")]
//         [InlineData(SizeMeasurementType.OneSizeOnly, ProductType.Bracelet, "One Size")]
//         [InlineData(SizeMeasurementType.OneSizeOnly, ProductType.Chain, "One Size")]
//         [InlineData(SizeMeasurementType.OneSizeOnly, ProductType.Necklace, "One Size")]
//         public void ValidateSize_ThrowsException_WithOneSizeOnlyMeasurementTypeAndInvalidProductTypeAndValidSize(
//             SizeMeasurementType sizeMeasurementType,
//             ProductType productType,
//             string size
//         )
//         {
//             // Act
//             var exception = Assert.Throws<ArgumentException>(
//                 () => ProductSizeRules.ValidateSize(sizeMeasurementType, productType, size)
//             );

//             // Assert
//             Assert.Equal(
//                 $"{productType} must have a size specified. It is not available in One Size Only.",
//                 exception.Message
//             );
//         }

//         [Theory]
//         [InlineData(SizeMeasurementType.OneSizeOnly, ProductType.Brooch, "60")]
//         [InlineData(SizeMeasurementType.OneSizeOnly, ProductType.Charm, "65")]
//         [InlineData(SizeMeasurementType.OneSizeOnly, ProductType.Cufflink, "70")]
//         [InlineData(SizeMeasurementType.OneSizeOnly, ProductType.Earring, "75")]
//         [InlineData(SizeMeasurementType.OneSizeOnly, ProductType.Pendant, "80")]
//         public void ValidateSize_ThrowsException_WithOneSizeOnlyMeasurementTypeAndValidProductTypeAndInvalidSize(
//             SizeMeasurementType sizeMeasurementType,
//             ProductType productType,
//             string size
//         )
//         {
//             // Act
//             var exception = Assert.Throws<ArgumentException>(
//                 () => ProductSizeRules.ValidateSize(sizeMeasurementType, productType, size)
//             );

//             // Assert
//             Assert.Equal($"{productType} is available in One Size Only.", exception.Message);
//         }

//         [Theory]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.ExtraSmall, "A")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.ExtraSmall, "B")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.Small, "C")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.Small, "J")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.Medium, "K")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.Medium, "R")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.Large, "S")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.Large, "Z")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.ExtraLarge, "Z+1")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.ExtraLarge, "Z+8")]
//         public void ValidateSize_Success_WithValidUKRingSize(
//             SizeMeasurementType sizeMeasurementType,
//             ProductType productType,
//             RingSizeType ringSizeType,
//             string size
//         )
//         {
//             // Act
//             var exception = Record.Exception(
//                 () =>
//                     ProductSizeRules.ValidateSize(
//                         sizeMeasurementType,
//                         productType,
//                         size,
//                         ringSizeType
//                     )
//             );

//             // Assert
//             Assert.Null(exception); // in this instance, no exception means validation passed
//         }

//         [Theory]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Anklet, RingSizeType.ExtraSmall, "A")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Bangle, RingSizeType.ExtraSmall, "B")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Bracelet, RingSizeType.Small, "C")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Brooch, RingSizeType.Small, "J")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Chain, RingSizeType.Medium, "K")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Charm, RingSizeType.Medium, "R")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Cufflink, RingSizeType.Large, "S")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Earring, RingSizeType.Large, "Z")]
//         [InlineData(
//             SizeMeasurementType.UKRing,
//             ProductType.Necklace,
//             RingSizeType.ExtraLarge,
//             "Z+1"
//         )]
//         [InlineData(
//             SizeMeasurementType.UKRing,
//             ProductType.Pendant,
//             RingSizeType.ExtraLarge,
//             "Z+8"
//         )]
//         public void ValidateSize_ThrowsException_WithUKRingSizeAndInvalidProductType(
//             SizeMeasurementType sizeMeasurementType,
//             ProductType productType,
//             RingSizeType ringSizeType,
//             string size
//         )
//         {
//             // Act
//             var exception = Assert.Throws<ArgumentException>(
//                 () =>
//                     ProductSizeRules.ValidateSize(
//                         sizeMeasurementType,
//                         productType,
//                         size,
//                         ringSizeType
//                     )
//             );

//             // Assert
//             Assert.Equal($"{productType} sizes are not measured in ring sizes.", exception.Message); // in this instance, no exception means validation passed
//         }

//         [Theory]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.ExtraLarge, "A")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.Small, "B")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.ExtraSmall, "C")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.Medium, "J")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.Small, "K")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.Large, "R")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.Medium, "S")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.ExtraLarge, "Z")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.Large, "Z+1")]
//         [InlineData(SizeMeasurementType.UKRing, ProductType.Ring, RingSizeType.ExtraSmall, "Z+8")]
//         public void ValidateSize_ThrowsException_WithInvalidRingSizeAndValidProductTypeAndRingSizeType(
//             SizeMeasurementType sizeMeasurementType,
//             ProductType productType,
//             RingSizeType ringSizeType,
//             string size
//         )
//         {
//             // Act
//             var exception = Assert.Throws<ArgumentException>(
//                 () =>
//                     ProductSizeRules.ValidateSize(
//                         sizeMeasurementType,
//                         productType,
//                         size,
//                         ringSizeType
//                     )
//             );

//             // Assert
//             Assert.Equal(
//                 $"Invalid ring size '{size}' for ring size type '{ringSizeType}'.",
//                 exception.Message
//             );
//         }
//     }
// }
