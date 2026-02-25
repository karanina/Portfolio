namespace PointOfSale.Inventory.StockLevel
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException(string message)
            : base(message) { }
    }

    public class StockItemNotFoundException : Exception
    {
        public StockItemNotFoundException(string message)
            : base(message) { }
    }

    // This class manages the movement of a stock item in inventory.
    public class InventoryManagement
    {
        private readonly Dictionary<string, StockItem> _stock; // Key: Product ID, Value: StockItem details

        public InventoryManagement()
        {
            _stock = new Dictionary<string, StockItem>();
        }

        public IReadOnlyDictionary<string, StockItem> GetAllStockItems()
        {
            return _stock;
        }

        public void IncreaseStock(string productId, int quantity)
        {
            if (_stock.ContainsKey(productId))
            {
                _stock[productId].IncreaseQuantity(quantity);
            }
            else
            {
                _stock[productId] = new StockItem(productId, quantity);
            }
        }

        public void ReduceStock(string productId, int quantity)
        {
            if (!_stock.ContainsKey(productId))
            {
                throw new StockItemNotFoundException(
                    $"The stock item with ID {productId} was not found in inventory."
                );
            }
            _stock[productId].ReduceQuantity(quantity);
        }

        public int GetStockLevel(string productId)
        {
            if (!_stock.ContainsKey(productId))
            {
                throw new StockItemNotFoundException(
                    $"The stock item with ID {productId} was not found in inventory."
                );
            }
            return _stock[productId].QuantityOnHand;
        }
    }
}
