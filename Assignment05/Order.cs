using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderApp
{
    public class Order : IComparable<Order>
    {
        private readonly List<OrderDetail> _details = new List<OrderDetail>();

        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime CreateTime { get; set; }

        public float TotalPrice => _details.Sum(d => d.TotalPrice);

        public List<OrderDetail> Details => _details;

        public Order() { }

        public Order(int id, Customer customer, DateTime createTime)
        {
            Id = id;
            Customer = customer;
            CreateTime = createTime;
        }

        public void AddProduct(OrderDetail orderDetail)
        {
            if (_details.Contains(orderDetail))
            {
                throw new ApplicationException($"The product ({orderDetail.Product.Name}) is already in order {Id}");
            }
            _details.Add(orderDetail);
        }

        public int CompareTo(Order other)
        {
            return other == null ? 1 : Id - other.Id;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append($"Order ID: {Id}, Customer: ({Customer})");
            _details.ForEach(detail => result.Append("\n\t" + detail));
            return result.ToString();
        }
    }
}

