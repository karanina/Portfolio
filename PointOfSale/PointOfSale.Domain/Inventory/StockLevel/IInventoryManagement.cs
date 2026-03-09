namespace PointOfSale.Domain.Inventory.StockLevel
{
    // This interface defines the contract for inventory management operations related to stock levels.
    public interface IInventoryManagement
    {
        void IncreaseStock(string productId, int quantity);
        void ReduceStock(string productId, int quantity);
        IReadOnlyDictionary<string, StockItem> GetAllStockItems();
        int GetStockLevel(string productId);
    }
}
