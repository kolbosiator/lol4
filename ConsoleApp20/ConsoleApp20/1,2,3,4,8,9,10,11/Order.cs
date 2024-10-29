using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20._1
{
    public class Order
    {
        public int OrderId;
        public string CustomerName;
        private List<string> _items;
        public decimal TotalCost;
        internal string Status;
        internal object TotalAmount;

        public Order(int orderId, string customerName)
        {
            OrderId = orderId;
            CustomerName = customerName;
            _items = new List<string>();
            TotalCost = 0.0m;
            Status = "new";
        }

        public void AddItem(string item, decimal price)
        {
            _items.Add(item); 
            TotalCost += price; 
        }


        public IEnumerable<string> GetItems()
        {
            return _items;
        }

        public void ShowOrderDetails()
        {
            Console.WriteLine($"ID Заказа: {OrderId}");
            Console.WriteLine($"Клиент: {CustomerName}");
            Console.WriteLine("Список товаров:");
            foreach (var item in _items)
            {
                Console.WriteLine($"- {item}");
            }
            Console.WriteLine($"Общая стоимость: {TotalCost}");
        }
    }
}
