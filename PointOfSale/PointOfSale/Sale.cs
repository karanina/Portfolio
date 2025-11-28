using System;
using System.Collections.Generic;

namespace PointOfSale
{
    public class SaleItemNotFoundException : Exception
    {
        public SaleItemNotFoundException(string message)
            : base(message) { }
    }

    public class Sale
    {
        private Dictionary<string, SaleItem> Items { get; set; }
        private Customer Customer { get; set; }

        public Sale(Customer customer)
        {
            // TODO: Validate customer is in Customer Collection
            Customer = customer;
            Items = new Dictionary<string, SaleItem>();
        }

        public void AddItem(SaleItem item)
        {
            if (Items.ContainsKey(item.Id))
            {
                UpdateItemQuantity(item.Id, item.Quantity + Items[item.Id].GetQuantity());
            }
            else
            {
                Items[item.Id] = item;
            }
        }

        public void RemoveItem(string itemId)
        {
            if (!Items.ContainsKey(itemId))
            {
                throw new SaleItemNotFoundException(
                    $"The item with ID {itemId} was not found in your sale"
                );
            }
            Items.Remove(itemId);
        }

        public int GetItemQuantity(string itemId)
        {
            if (!Items.ContainsKey(itemId))
            {
                throw new SaleItemNotFoundException(
                    $"The item with ID {itemId} was not found in your sale"
                );
            }
            return Items[itemId].GetQuantity();
        }

        public void UpdateItemQuantity(string itemId, int newQuantity)
        {
            if (!Items.ContainsKey(itemId))
            {
                throw new SaleItemNotFoundException(
                    $"The item with ID {itemId} was not found in your sale"
                );
            }
            Items[itemId].UpdateQuantity(newQuantity + Items[itemId].GetQuantity());
        }

        public void CancelSale()
        {
            Items.Clear();
        }

        public int GetItemCount()
        {
            return Items.Sum(item => item.Value.Quantity);
        }

        public Dictionary<string, SaleItem> GetItems()
        {
            return Items;
        }

        public int GetCustomerDiscountRate()
        {
            return Customer.GetDiscountRate();
        }
    }
}
