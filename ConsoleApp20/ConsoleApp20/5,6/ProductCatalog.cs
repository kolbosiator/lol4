using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20._5
{
    public class Product
    {
        public string Name;
        public decimal Price;
        public int Quantity;
        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }

    public class ProductCatalog
    {
        private Dictionary<int, Product> products = new Dictionary<int, Product>();

        public void AddProduct(int id, string name, decimal price, int quantity)
        {
            if (!products.ContainsKey(id))
            {
                products[id] = new Product(name, price, quantity);
            }
            else
            {
                Console.WriteLine("already exists.");
            }
        }

        public void RemoveProduct(int id)
        {
            if (products.ContainsKey(id))
            {
                products.Remove(id);
            }
            else
            {
                Console.WriteLine("not exist.");
            }
        }

        public void IncreaseQuantity(int id, int amount)
        {
            if (products.ContainsKey(id))
            {
                products[id].Quantity += amount;
            }
            else
            {
                Console.WriteLine("does not exist.");
            }
        }

        public void DecreaseQuantity(int id, int amount)
        {
            if (products.ContainsKey(id))
            {
                if (products[id].Quantity >= amount)
                {
                    products[id].Quantity -= amount;
                }
                else
                {
                    Console.WriteLine("Insufficient quantity in stock.");
                }
            }
            else
            {
                Console.WriteLine("does not exist.");
            }
        }
    }
   
}
