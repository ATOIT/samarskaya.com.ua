using System.Collections.Generic;
using Domain.Entityes;

namespace Domain.Abstrac
{
  public  interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(OrderDetails details, Basket basket);
        void RemoveOrder(int orderId);
        void OrderComplite(int orderId);
        void OrderNew(int orderId);
    }
}
