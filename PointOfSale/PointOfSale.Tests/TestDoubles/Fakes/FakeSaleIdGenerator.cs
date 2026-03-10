using PointOfSale.Application.Sales;

namespace PointOfSale.Tests.TestFixtures
{
    public class FakeSaleIdGenerator : ISaleIdGenerator
    {
        public int NextId()
        {
            return 11;
        }
    }
}