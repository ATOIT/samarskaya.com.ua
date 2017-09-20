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
            if (basket.Lines.Count()!=0 && details!= null)
            {
                List<Product> products = new List<Product>();

                Order newOrder = new Order
                {
                    Address = details.Address,
                    ClientName = details.ClientName,
                    Delivery = details.Delivery,
                    Email = details.Email,
                    Payment = details.Payment,
                    Phone = details.Phone,
                    Сomment = details.Сomment,
                    Status = "новый",
                    Products = basket.Lines
                };
                _context.Orders.Add(newOrder);
                _context.SaveChanges();
                //foreach (var i in basket.Lines)
                //{
                //    var product = _context.Product.FirstOrDefault(x => x.ProductId == i.ProductId );
                //    if (product != null) product.Order = newOrder;
                //}
                //_context.SaveChanges();
            }
            else
                    throw new Exception();
            }

        public void RemoveOrder(int orderId)
        {
            var oneOrder = _context.Orders.FirstOrDefault(x => x.OrderId == orderId);
            if (oneOrder != null)
            {
                Order order = _context.Orders.Find(oneOrder.OrderId);
                if (order != null)
                {
                    _context.Orders.Remove(oneOrder);
                    _context.SaveChanges();
                }
                else
                    throw new Exception();
            }
        }

        public void OrderComplite(int orderId)
        {
            var oneOrder = _context.Orders.FirstOrDefault(x => x.OrderId == orderId);
            if (oneOrder != null)
            {
                Order order = _context.Orders.Find(oneOrder.OrderId);
                if (order != null)
                {
                    order.Status = "выполненный";
                    _context.SaveChanges();
                }
                else
                    throw new Exception();
            }
        }

        public void OrderNew(int orderId)
        {
            var oneOrder = _context.Orders.FirstOrDefault(x => x.OrderId == orderId);
            if (oneOrder != null)
            {
                Order order = _context.Orders.Find(oneOrder.OrderId);
                if (order != null)
                {
                    order.Status = "новый";
                    _context.SaveChanges();
                }
                else
                    throw new Exception();
            }
        }
    }
}

