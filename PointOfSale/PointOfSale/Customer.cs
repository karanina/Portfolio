using System;
using System.Collections.Generic;

namespace PointOfSale
{
    public class CustomerCollection
    {
        public List<Customer> Customers;
        public CustomerCollection()
        {
            Customers = new List<Customer>();
        }
    }

    public interface ICustomer
    {
        int Id { get; set; }
        string Name { get; set; }
        int DiscountRate { get; set; } // this is a percentage as a whole number
    }

    public class Customer : ICustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DiscountRate { get; set; } // this is a percentage as a whole number

        public Customer(int id, string name, int discountRate = 0)
        {
            // Required parameters
            Id = id;
            Name = name;

            // Optional parameters
            UpdateDiscountRate(discountRate);
        }

        public int GetDiscountRate()
        {
            return DiscountRate;
        }

        public void UpdateDiscountRate(int newDiscountRate)
        {
            ValidateDiscountRate(newDiscountRate);
            DiscountRate = newDiscountRate;
        }

        public void ValidateDiscountRate(int discountRate)
        {
            if (discountRate < 0 || discountRate > 100)
            {
                throw new ArgumentException("Discount rates must be between 0 and 100 percent");
            }
        }
    }
}
