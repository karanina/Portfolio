using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace PointOfSale
{
    public enum ProductType
    {
        Ring,
        Necklace,
        Pendant,
        Chain,
        Earring,
        Bracelet,
        Bangle,
        Brooch,
        Cufflink,
        Anklet,
    }

    public enum RingSizeType
    {
        ExtraSmall,
        Small,
        Medium,
        Large,
        ExtraLarge,
        NotApplicable, // when ring size is not applicable
    }

    public enum SizeMeasurementType
    {
        Cm, // centimeters used for length measurements in necklaces, chains, bracelets, anklets etc
        Mm, // millimeters used for diameter measurements in bangles
        UKRing, // UK ring sizing system
        NotApplicable, // Not applicable - when measurement is not relevant
    }

    public static class ProductSizeRules
    {
        private static readonly Dictionary<RingSizeType, List<string>> ValidUKRingSizes = new()
        {
            {
                RingSizeType.ExtraSmall,
                new List<string> { "A", "B" }
            },
            {
                RingSizeType.Small,
                new List<string> { "C", "D", "E", "F", "G", "H", "I", "J" }
            },
            {
                RingSizeType.Medium,
                new List<string> { "K", "L", "M", "N", "O", "P", "Q", "R" }
            },
            {
                RingSizeType.Large,
                new List<string> { "S", "T", "U", "V", "W", "X", "Y", "Z" }
            },
            {
                RingSizeType.ExtraLarge,
                new List<string> { "Z+1", "Z+2", "Z+3", "Z+4", "Z+5", "Z+6", "Z+7", "Z+8" }
            },
        };

        private static readonly List<string> ValidNecklaceLengths = new List<string>()
        {
            "40", "45", "50", "55", "60", "65", "70", "75", "80", "85", "90", "95", "100"
        };

        private static readonly List<string> ValidChainLengths = new List<string>()
        {
            "40", "45", "50", "55", "60", "65", "70", "75", "80", "85", "90", "95", "100"
        };

        private static readonly List<string> ValidBraceletLengths = new List<string>()
        {
            "10", "11", "12", "13", "14", "15", "16", "17", "18"
        };
        
        private static readonly List<string> ValidAnkletLengths = new List<string>()
        {
            "19", "20", "21", "22", "23", "24", "25"   
        };

        public static void ValidateSize(
            // Required parameters
            ProductType productType,
            SizeMeasurementType sizeMeasurementType,
            string size,
            // Optional parameter
            RingSizeType ringSizeType = RingSizeType.NotApplicable // this is only relevant for rings, so default is 'not applicable'
        )
        {
            switch (productType)
            {
                case ProductType.Ring:
                    if (ValidUKRingSizes.ContainsKey(ringSizeType))
                    {
                        if (!ValidUKRingSizes[ringSizeType].Contains(size))
                        {
                            throw new ArgumentException(
                                $"Invalid ring size '{size}' for ring size type '{ringSizeType}'."
                            );
                        }
                    }
                    break;
                case ProductType.Necklace:
                    if (sizeMeasurementType == SizeMeasurementType.Cm)
                    {
                        if (!ValidNecklaceLengths.Contains(size))
                        {
                            throw new ArgumentException($"{size + sizeMeasurementType} is an invalid size for {productType}.");
                        }
                    }
                    break;
                default:
                    // For other product types, no specific size validation is implemented yet
                    break;
            }
        }
    }

    public class Product
    {
        public string Id { get; set; }
        public string Metal { get; set; }
        public string Gemstone { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int MarkUp { get; set; } // percentage as whole number
        public int InStockQuantity { get; set; }
        public ProductType JewelleryType { get; set; }
    }
}
