using ConsoleApp20._1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20._7
{
    internal interface IOrderLogistics
    {
        void ProcessOrder(Order order);
        void UpdateOrderStatus(int orderId, string status);
        void UpdateStock(int productId, int quantity);
    }
}
