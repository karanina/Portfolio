using System;
using System.Collections.Generic;

namespace PointOfSale
{
    public class CartItemNotFoundException : Exception
    {
        public CartItemNotFoundException(string message)
            : base(message) { }
    }

    public class ShoppingCart
    {
        private Dictionary<string, CartItem> Items { get; set; }
        private Customer Customer { get; set; }

        public ShoppingCart(Customer customer)
        {
            // TODO: Validate customer is in Customer Collection
            Customer = customer;
            Items = new Dictionary<string, CartItem>();
        }

        public void AddItem(CartItem item)
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
                throw new CartItemNotFoundException(
                    $"The item with ID {itemId} was not found in your cart"
                );
            }
            Items.Remove(itemId);
        }

        public int GetItemQuantity(string itemId)
        {
            if (!Items.ContainsKey(itemId))
            {
                throw new CartItemNotFoundException(
                    $"The item with ID {itemId} was not found in your cart"
                );
            }
            return Items[itemId].GetQuantity();
        }

        public void UpdateItemQuantity(string itemId, int newQuantity)
        {
            if (!Items.ContainsKey(itemId))
            {
                throw new CartItemNotFoundException(
                    $"The item with ID {itemId} was not found in your cart"
                );
            }
            Items[itemId].UpdateQuantity(newQuantity + Items[itemId].GetQuantity());
        }

        public void EmptyCart()
        {
            Items.Clear();
        }

        public int GetItemCount()
        {
            return Items.Sum(item => item.Value.Quantity);
        }

        public Dictionary<string, CartItem> GetItems()
        {
            return Items;
        }

        public int GetCustomerDiscountRate()
        {
            return Customer.GetDiscountRate();
        }
    }
}
