using PointOfSale.Domain.Inventory.StockLevel;

namespace PointOfSale.Tests.TestDoubles.Fakes
{
    public class FakeInventoryManagement : IInventoryManagement
    {
        // for this fake implementation, we will use a simple in-memory dictionary to store stock levels, where the key is the
        // product ID and the value is the quantity on hand. These two datapoints are usually contained within a stock item.
        // This allows us to simulate inventory management without needing a real database or external system.
        private readonly Dictionary<string, int> _stock = new();

        public void IncreaseStock(string productId, int quantity)
        {
            if (_stock.ContainsKey(productId))
            {
                _stock[productId] += quantity;
            }
            else
            {
                _stock[productId] = quantity;
            }
        }

        public void ReduceStock(string productId, int quantity)
        {
            _stock[productId] -= quantity;
        }

        public IReadOnlyDictionary<string, StockItem> GetAllStockItems()
        {
            return _stock.ToDictionary(
                kvp => kvp.Key, 
                kvp => new StockItem(kvp.Key, kvp.Value)
                );
        }

        public int GetStockLevel(string productId)
        {
            return _stock.TryGetValue(productId, out int quantity) ? quantity : 0;
        }
    }
}
