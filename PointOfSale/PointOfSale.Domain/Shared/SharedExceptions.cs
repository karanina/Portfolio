namespace PointOfSale.Domain.Shared
{
    public class QuantityException : Exception
    {
        public QuantityException(string message)
            : base(message) { }
    }

    public class PriceException : Exception
    {
        public PriceException(string message)
            : base(message) { }
    }

    public class DiscountException : Exception
    {
        public DiscountException(string message)
            : base(message) { }
    }
}
