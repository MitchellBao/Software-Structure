using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderApp
{
    public class OrderService
    {
        private readonly List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            if (_orders.Contains(order))
            {
                throw new ApplicationException($"Order {order.Id} already exists!");
            }
            _orders.Add(order);
        }

        public Order GetOrderById(int orderId)
        {
            return _orders.FirstOrDefault(o => o.Id == orderId);
        }

        public void RemoveOrderById(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                _orders.Remove(order);
            }
        }

        public List<Order> GetAllOrders()
        {
            return _orders;
        }

        public List<Order> GetOrdersByCustomerName(string customerName)
        {
            return _orders.Where(o => o.Customer.Name == customerName).OrderBy(o => o.TotalPrice).ToList();
        }

        public List<Order> GetOrdersByProductName(string productName)
        {
            return _orders.Where(o => o.Details.Any(d => d.Product.Name == productName)).OrderBy(o => o.TotalPrice).ToList();
        }

        public List<Order> GetOrdersByTotalAmount(float totalPrice)
        {
            return _orders.Where(o => o.TotalPrice >= totalPrice).OrderBy(o => o.TotalPrice).ToList();
        }

        public IEnumerable<Order> GetOrdersByCondition(Predicate<Order> condition)
        {
            return _orders.Where(o => condition(o)).OrderBy(o => o.TotalPrice);
        }

        public void SortOrdersByAmount(Comparison<Order> comparison)
        {
            _orders.Sort(comparison);
        }
    }
}
