// using System;
// using System.Collections.Generic;

// namespace PointOfSale.Inventory
// {
//     public static class ProductSizeRules
//     {
//         private static Dictionary<
//             SizeMeasurementType,
//             HashSet<ProductType>
//         > UnitOfMeasurementProductTypeMap = new()
//         {
//             {
//                 SizeMeasurementType.Centimetres,
//                 new HashSet<ProductType>()
//                 {
//                     ProductType.Anklet,
//                     ProductType.Bracelet,
//                     ProductType.Chain,
//                     ProductType.Necklace,
//                 }
//             },
//             {
//                 SizeMeasurementType.Millimetres,
//                 new HashSet<ProductType>() { ProductType.Bangle }
//             },
//             {
//                 SizeMeasurementType.OneSizeOnly,
//                 new HashSet<ProductType>()
//                 {
//                     ProductType.Brooch,
//                     ProductType.Charm,
//                     ProductType.Cufflink,
//                     ProductType.Earring,
//                     ProductType.Pendant,
//                 }
//             },
//             {
//                 SizeMeasurementType.UKRing,
//                 new HashSet<ProductType>() { ProductType.Ring }
//             },
//         };
//         private static Dictionary<RingSizeType, HashSet<string>> ValidUKRingSizes = new()
//         {
//             {
//                 RingSizeType.ExtraSmall,
//                 new HashSet<string> { "A", "B" }
//             },
//             {
//                 RingSizeType.Small,
//                 new HashSet<string> { "C", "D", "E", "F", "G", "H", "I", "J" }
//             },
//             {
//                 RingSizeType.Medium,
//                 new HashSet<string> { "K", "L", "M", "N", "O", "P", "Q", "R" }
//             },
//             {
//                 RingSizeType.Large,
//                 new HashSet<string> { "S", "T", "U", "V", "W", "X", "Y", "Z" }
//             },
//             {
//                 RingSizeType.ExtraLarge,
//                 new HashSet<string> { "Z+1", "Z+2", "Z+3", "Z+4", "Z+5", "Z+6", "Z+7", "Z+8" }
//             },
//         };

//         private static HashSet<string> ValidNecklaceLengths = new HashSet<string>()
//         {
//             "40",
//             "45",
//             "50",
//             "55",
//             "60",
//             "65",
//             "70",
//             "75",
//             "80",
//             "85",
//             "90",
//             "95",
//             "100",
//         };

//         private static HashSet<string> ValidChainLengths = new HashSet<string>()
//         {
//             "40",
//             "45",
//             "50",
//             "55",
//             "60",
//             "65",
//             "70",
//             "75",
//             "80",
//             "85",
//             "90",
//             "95",
//             "100",
//         };

//         private static HashSet<string> ValidBraceletLengths = new HashSet<string>()
//         {
//             "10",
//             "11",
//             "12",
//             "13",
//             "14",
//             "15",
//             "16",
//             "17",
//             "18",
//         };

//         private static HashSet<string> ValidAnkletLengths = new HashSet<string>()
//         {
//             "19",
//             "20",
//             "21",
//             "22",
//             "23",
//             "24",
//             "25",
//         };

//         private static HashSet<string> ValidBangleInternalDiameters = new HashSet<string>()
//         {
//             "40",
//             "45",
//             "50",
//             "55",
//             "57",
//             "60",
//             "62",
//             "65",
//             "67",
//             "70",
//             "72",
//             "75",
//             "77",
//         };

//         public static void ValidateSize(
//             // Required parameters
//             SizeMeasurementType sizeMeasurementType,
//             ProductType productType,
//             string size,
//             // Optional parameter
//             RingSizeType ringSizeType = RingSizeType.NotApplicable // this is only relevant for rings, so default is 'not applicable'
//         )
//         {
//             switch (sizeMeasurementType)
//             {
//                 case SizeMeasurementType.Centimetres:
//                     if (
//                         !UnitOfMeasurementProductTypeMap[SizeMeasurementType.Centimetres]
//                             .Contains(productType)
//                     )
//                     {
//                         throw new ArgumentException(
//                             $"{size}cm is an invalid size for {productType}."
//                         );
//                     }
//                     ValidateCmSize(productType, size);
//                     break;
//                 case SizeMeasurementType.Millimetres:
//                     if (
//                         !UnitOfMeasurementProductTypeMap[SizeMeasurementType.Millimetres]
//                             .Contains(productType)
//                     )
//                     {
//                         throw new ArgumentException(
//                             $"{size}millimetres is an invalid size for {productType}."
//                         );
//                     }
//                     ValidateMillimetresSize(productType, size);
//                     break;
//                 case SizeMeasurementType.OneSizeOnly:
//                     if (
//                         !UnitOfMeasurementProductTypeMap[SizeMeasurementType.OneSizeOnly]
//                             .Contains(productType)
//                     )
//                     {
//                         throw new ArgumentException(
//                             $"{productType} must have a size specified. It is not available in One Size Only."
//                         );
//                     }
//                     if (size != "One Size")
//                     {
//                         throw new ArgumentException(
//                             $"{productType} is available in One Size Only."
//                         );
//                     }
//                     break;
//                 case SizeMeasurementType.UKRing:
//                     if (
//                         !UnitOfMeasurementProductTypeMap[SizeMeasurementType.UKRing]
//                             .Contains(productType)
//                     )
//                     {
//                         throw new ArgumentException(
//                             $"{productType} sizes are not measured in ring sizes."
//                         );
//                     }
//                     if (!ValidUKRingSizes[ringSizeType].Contains(size))
//                     {
//                         throw new ArgumentException(
//                             $"Invalid ring size '{size}' for ring size type '{ringSizeType}'."
//                         );
//                     }
//                     break;
//                 default:
//                     break;
//             }
//         }

//         public static void ValidateCmSize(ProductType productType, string size)
//         {
//             string argumentExceptionMessage = $"{size}cm is an invalid size for {productType}.";
//             switch (productType)
//             {
//                 case ProductType.Anklet:
//                     if (!ValidAnkletLengths.Contains(size))
//                     {
//                         throw new ArgumentException(argumentExceptionMessage);
//                     }
//                     break;
//                 case ProductType.Bracelet:
//                     if (!ValidBraceletLengths.Contains(size))
//                     {
//                         throw new ArgumentException(argumentExceptionMessage);
//                     }
//                     break;
//                 case ProductType.Chain:
//                     if (!ValidChainLengths.Contains(size))
//                     {
//                         throw new ArgumentException(argumentExceptionMessage);
//                     }
//                     break;
//                 case ProductType.Necklace:
//                     if (!ValidNecklaceLengths.Contains(size))
//                     {
//                         throw new ArgumentException(argumentExceptionMessage);
//                     }
//                     break;
//                 default:
//                     break;
//             }
//         }

//         public static void ValidateMillimetresSize(ProductType productType, string size)
//         {
//             switch (productType)
//             {
//                 case ProductType.Bangle:
//                     if (!ValidBangleInternalDiameters.Contains(size))
//                     {
//                         throw new ArgumentException(
//                             $"{size}millimetres is an invalid size for {productType}."
//                         );
//                     }
//                     break;
//                 default:
//                     break;
//             }
//         }
//     }
// }
