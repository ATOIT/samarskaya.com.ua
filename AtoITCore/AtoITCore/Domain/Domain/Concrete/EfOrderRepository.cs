using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Abstrac;
using Domain.Entityes;

namespace Domain.Concrete
{
    public class EfOrderRepository : IOrderRepository
    {
        readonly ShopContext _context = new ShopContext();
        public IEnumerable<Order> Orders => _context.Orders;

        public void SaveOrder(OrderDetails details, Basket basket)
        {
            if (basket.Lines.Count() != 0 && details != null)
            {
                try
                {
                    Order newOrder = new Order
                    {
                        Address = details.Address,
                        ClientName = details.ClientName,
                        Delivery = details.Delivery,
                        Email = details.Email,
                        Payment = details.Payment,
                        Phone = details.Phone,
                        Сomment = details.Сomment,
                        DateOrder = DateTime.Now,
                        Status = "новый"
                    };
                    _context.Orders.Add(newOrder);
                    _context.SaveChanges();
                    foreach (var i in basket.Lines)
                    {
                        var productInLines = _context.Product.FirstOrDefault(x => x.ProductId == i.ProductId);
                        if (productInLines != null) productInLines.Order = _context.Orders.FirstOrDefault(x => x.OrderId == newOrder.OrderId);
                        _context.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    //ignored
                }
            }
            else
                throw new Exception();
        }

        public void RemoveOrder(int orderId)
        {
            var oneOrder = _context.Orders.FirstOrDefault(x => x.OrderId == orderId);
            if (oneOrder != null)
            {
                _context.Orders.Remove(oneOrder);
                _context.SaveChanges();
            }
            else
                throw new Exception();
        }

        public void OrderComplite(int orderId)
        {
            var oneOrder = _context.Orders.FirstOrDefault(x => x.OrderId == orderId);
            if (oneOrder != null)
            {
                oneOrder.Status = "выполненный";
                _context.SaveChanges();
            }
            else
                throw new Exception();
        }

        public void OrderNew(int orderId)
        {
            var oneOrder = _context.Orders.FirstOrDefault(x => x.OrderId == orderId);
            if (oneOrder != null)
            {
                oneOrder.Status = "новый";
                _context.SaveChanges();
            }
            else
                throw new Exception();
        }
    }
}

