using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace PointOfSale.Product
{
    public enum ProductType
    {
        Anklet,
        Bangle,
        Bracelet,
        Brooch,
        Chain,
        Charm,
        Cufflink,
        Earring,
        Necklace,
        Pendant,
        Ring,
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
        OneSizeOnly, // Item is only available in one size / size is not relevent
    }
}
