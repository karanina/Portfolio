namespace PointOfSale.Inventory.Products
{
    // This is an abstract class that describes the common attributes of a product in inventory.
    public abstract class ProductSpecification
    {
        public string ProductId { get; private set; } // will be automatically generated from BaseStyle-Width-Gemstone-Size-MetalCode

        //         // Rings: BaseStyle-Width-Gemstone-RingSizeType-MetalCode OR BaseStyle-Width-RingSizeType-MetalCode OR BaseStyle-Gemstone-RingSizeType-MetalCode OR BaseStyle-RingSizeType-MetalCode
        //         // Bangles: BaseStyle-Size-MetalCode OR BaseStyle-Gemstone-Size-MetalCode
        //         // Bracelets/Chains/Necklaces/Anklets: BaseStyle-Length-MetalCode OR BaseStyle-Gemstone-Length-MetalCode
        //         // Brooches/Charms/Cufflinks/Earrings/Pendants: BaseStyle-MetalCode OR BaseStyle-Gemstone-MetalCode
        // public string Brand { get; set; }
        //  public string BaseStyle { get; set; }
        //         public string Metal { get; set; }
        //         public string Gemstone { get; set; }
        //         public string Size { get; set; }
        public string Description { get; private set; }

        //         public decimal CostPrice { get; set; }
        public decimal SellPrice { get; private set; }

        //         public int MarkUp { get; set; } // percentage as whole number
        //         public int Width { get; set; } // in size measurement type
        //         public int Length { get; set; } // in size measurement type
        //         public ProductType JewelleryType { get; set; }
        //         public RingSizeType RingSizeType { get; set; }
        //         public SizeMeasurementType SizeMeasurementType { get; set; }
        //         public bool IsTaperedBand { get; set; }
        //         public bool TaperedWidthTop { get; set; }
        //         public bool TaperedWidthBottom { get; set; }
        //         public bool IsCastRing { get; set; }

        //         // Audit Fields
        //         public DateTime CreatedAt { get; set; }
        //          public DateTime CreatedBy { get; set; }
        //         public DateTime LastUpdatedAt { get; set; }
        //         public DateTime LastUpdatedBy { get; set; }
        //         public bool IsActive { get; set; }



        // Protected constructor to prevent direct instantiation of ProductSpecification, which is an abstract class.
        // ProductSpecification should only be used by inherittance from specific product types (e.g. RingSpecification,
        // BangleSpecification) that can have additional attributes and validation logic as needed.
        protected ProductSpecification(string productId, string description, decimal sellPrice)
        {
            ProductId = productId;
            Description = description;
            SellPrice = sellPrice;
        }
    }
}
