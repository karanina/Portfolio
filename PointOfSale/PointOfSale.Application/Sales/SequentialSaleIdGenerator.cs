using System.Runtime.InteropServices;

namespace PointOfSale.Application.Sales
{
    public class SequentialSaleIdGenerator : ISaleIdGenerator
    {
        private int _currentId = 0;
        public int NextId()
        {
            _currentId++;
            return _currentId;
        }
    }
}