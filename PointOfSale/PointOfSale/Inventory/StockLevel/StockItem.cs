using PointOfSale.Shared;

namespace PointOfSale.Inventory.StockLevel
{
    // This class describes the state of a stock item in inventory.
    public class StockItem
    {
        public string ProductId { get; }
        public int QuantityOnHand { get; private set; }

        public StockItem(string productId, int quantityOnHand)
        {
            ProductId = productId;
            if (quantityOnHand < 0)
            {
                throw new QuantityException("Quantity cannot be negative.");
            }
            QuantityOnHand = quantityOnHand;
        }

        public void IncreaseQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new QuantityException("Quantity cannot be negative.");
            }
            QuantityOnHand += quantity;
        }

        public void ReduceQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new QuantityException("Quantity to reduce stock by cannot be negative.");
            }
            if (QuantityOnHand < quantity)
            {
                throw new InsufficientStockException(
                    $"Not enough stock on hand. There is only {QuantityOnHand} items available."
                );
            }
            QuantityOnHand -= quantity;
        }
    }
}
