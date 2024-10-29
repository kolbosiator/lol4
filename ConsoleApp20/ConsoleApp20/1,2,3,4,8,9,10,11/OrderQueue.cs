using ConsoleApp20._1;
using ConsoleApp20._7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20._2
{
    public class OrderQueue : IOrderLogistics
    {
        private Queue<Order> orderQueue;
        private Stack<Order> completedOrders;
        private Dictionary<int, string> orderStatus;

        public OrderQueue()
        {
            orderQueue = new Queue<Order>();
            completedOrders = new Stack<Order>();
            orderStatus = new Dictionary<int, string>();
        }

        public void AddOrder(Order order)
        {
            orderQueue.Enqueue(order);
            orderStatus[order.OrderId] = order.Status;
            Console.WriteLine($"Заказ {order.OrderId} добавлен в очередь.");
        }

        public void ProcessOrder(Order order)
        {
            UpdateOrderStatus(order.OrderId, "обрабатывается");
            MoveToCompletedOrders(order);
        }

        public void UpdateStock(int productId, int quantity)
        {
            Console.WriteLine($"Обновлено количество товара с ID {productId} на {quantity}.");
        }

        private void MoveToCompletedOrders(Order order)
        {
            UpdateOrderStatus(order.OrderId, "завершён");
            completedOrders.Push(order);
            Console.WriteLine($"Заказ {order.OrderId} завершён и перемещён в стек завершённых заказов.");
        }

        public void UpdateOrderStatus(int orderId, string status)
        {
            if (orderStatus.ContainsKey(orderId))
            {
                orderStatus[orderId] = status;
                Console.WriteLine($"Статус заказа {orderId} изменён на '{status}'.");
            }
            else
            {
                Console.WriteLine($"Заказ с ID {orderId} не найден.");
            }
        }

        public List<Order> FilterOrdersByStatus(string status)
        {
            return orderQueue.Where(order => order.Status == status).ToList();
        }

        public List<Order> GetLastCompletedOrders(int count)
        {
            return completedOrders.Take(count).ToList();
        }

        public void ReturnOrder(int orderId)
        {
            if (completedOrders.Count == 0)
            {
                Console.WriteLine("Нет завершённых заказов.");
                return;
            }

            var orderList = completedOrders.ToList();
            var orderToReturn = orderList.FirstOrDefault(o => o.OrderId == orderId);

            if (orderToReturn != null)
            {
                completedOrders = new Stack<Order>(orderList.Where(o => o.OrderId != orderId));
                UpdateOrderStatus(orderId, "возврат");
                Console.WriteLine($"Заказ {orderId} возвращён на склад.");
            }
            else
            {
                Console.WriteLine($"Заказ с ID {orderId} не найден в завершённых заказах.");
            }
        }

        public List<Order> SortOrdersByTotalAmount()
        {
            return orderQueue.OrderByDescending(order => order.TotalAmount).ToList();
        }

        public void ShowCompletedOrders()
        {
            Console.WriteLine("Завершённые заказы:");
            foreach (var order in completedOrders)
            {
                Console.WriteLine(order);
            }
        }
    }
}
