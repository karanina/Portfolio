using PointOfSale.Inventory.Products;
using PointOfSale.Inventory.StockLevel;
using PointOfSale.Shared;

namespace PointOfSale.Sales
{
    public class SaleItemNotFoundException : Exception
    {
        public SaleItemNotFoundException(string message)
            : base(message) { }
    }

    // Represents the collection of products being purchased in a sale
    // Is the aggregate root for SaleItems and SaleCalculator, as it is the main point of interaction for the UI and
    // other parts of the system when working with a sale.
    public class Sale
    {
        private readonly Dictionary<string, SaleItem> _items;
        private readonly IProductCatalogue _catalogue;
        private readonly InventoryManagement _inventory;

        // getter only as we don't want to be able to change the customer mid sale.
        public Customer Customer { get; }

        public Sale(Customer customer, InventoryManagement inventory, IProductCatalogue catalogue)
        {
            // Guard clauses to ensure valid objects are provided for the sale.

            // TODO: Validate customer is in Customer Collection

            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
            _catalogue = catalogue ?? throw new ArgumentNullException(nameof(catalogue));

            _items = new Dictionary<string, SaleItem>();
        }

        public void AddItem(string productId, int quantity)
        {
            // Guard clauses to ensure valid product ID and quantity are provided.
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentException(
                    "Product ID cannot be null or whitespace.",
                    nameof(productId)
                );
            }
            // Quantity must be at least 1 to try to add to sale.
            if (quantity < 1)
            {
                throw new QuantityException("Quantity cannot be less than 1.");
            }
            // Inventory Management will throw an exception if there is insufficient stock or the item is not found in inventory,
            // so we will try to reduce stock to take advantage of this before adding to sale.

            _inventory.ReduceStock(productId, quantity);

            if (_items.ContainsKey(productId))
            {
                _items[productId].IncreaseQuantity(quantity);
            }
            else
            {
                ProductSpecification product = _catalogue.GetByProductId(productId);
                SaleItem saleItem = SaleItem.CreateFromProductSpecification(product, quantity);

                _items.Add(productId, saleItem);
            }
        }

        public void RemoveItem(string productId)
        {
            if (!_items.ContainsKey(productId))
            {
                throw new SaleItemNotFoundException(
                    $"The product with ID {productId} was not found in your sale"
                );
            }
            _inventory.IncreaseStock(productId, _items[productId].Quantity);
            _items.Remove(productId);
        }

        public int GetItemQuantity(string productId)
        {
            if (!_items.ContainsKey(productId))
            {
                throw new SaleItemNotFoundException(
                    $"The item with ID {productId} was not found in your sale"
                );
            }
            return _items[productId].Quantity;
        }

        public void ChangeItemQuantity(string productId, int newQuantity)
        {
            if (!_items.ContainsKey(productId))
            {
                throw new SaleItemNotFoundException(
                    $"The item with ID {productId} was not found in your sale."
                );
            }
            int currentQuantity = _items[productId].Quantity;
            int quantityDelta = newQuantity - currentQuantity;

            if (newQuantity < 0)
            {
                throw new QuantityException("Quantity cannot be negative.");
            }
            if (newQuantity == 0)
            {
                _items.Remove(productId);
                _inventory.IncreaseStock(productId, currentQuantity);
                return;
            }

            if (quantityDelta > 0)
            {
                _inventory.ReduceStock(productId, quantityDelta);
                // SaleItem class handles validation of new quantity, so we can call ChangeQuantity directly here without
                // validating again in this method.
                _items[productId].ChangeQuantity(newQuantity);
                return;
            }
            else if (quantityDelta < 0)
            {
                _inventory.IncreaseStock(productId, Math.Abs(quantityDelta));
                // SaleItem class handles validation of new quantity, so we can call ChangeQuantity directly here without
                // validating again in this method.
                _items[productId].ChangeQuantity(newQuantity);
                return;
            }
        }

        public int GetItemCount()
        {
            return _items.Sum(item => item.Value.Quantity);
        }

        public SaleItem GetItem(string productId)
        {
            if (!_items.ContainsKey(productId))
            {
                throw new SaleItemNotFoundException(
                    $"The item with ID {productId} was not found in your sale."
                );
            }
            return _items[productId];
        }

        // We return a IReadOnlyCollection<SaleItemView> instead of a IReadOnlyDictionary to prevent dictionary methods from
        // being used on the collection of items in the sale, which could lead to unintended side effects and bugs and preserve
        // aggregate authority by ensuring that all modifications to the sale items go through the defined methods on the Sale
        // class, which can enforce business rules and maintain the integrity of the sale.
        public IReadOnlyCollection<SaleItemView> GetItems()
        {
            return _items
                .Values.Select(item => new SaleItemView(
                    item.ProductId,
                    item.Description,
                    item.UnitPrice,
                    item.Quantity,
                    item.ManualDiscountRate,
                    item.IsManualUnitPrice
                ))
                // creates a stable snapshot of the current items in the sale to be returned as a read only collection,
                // so that if the underlying _items dictionary is modified after this method is called,
                // it won't affect the collection that was returned.
                .ToList()
                // We return as read only to prevent external code from modifying the collection of items in the sale directly,
                // which could lead to unintended side effects and bugs. By returning a read only collection,
                // we ensure that all modifications to the sale items go through the defined methods on the Sale class,
                // which can enforce business rules and maintain the integrity of the sale.
                .AsReadOnly();
        }
    }
}
