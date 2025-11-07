using System;
using System.Collections.Generic;


namespace PointOfSale.Product
{
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
        public RingSizeType RingSizeType { get; set; }
        public SizeMeasurementType SizeMeasurementType { get; set; }
    }
}
