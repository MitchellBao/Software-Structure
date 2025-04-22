using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderApp
{
    class Program
    {
        public static void Main()
        {
            try
            {
                Customer customer1 = new Customer(1, "Customer1");
                Customer customer2 = new Customer(2, "Customer2");

                Product milk = new Product(1, "Milk", 69.9f);
                Product eggs = new Product(2, "Eggs", 4.99f);
                Product apple = new Product(3, "Apple", 5.59f);

                Order order1 = new Order(1, customer1, new DateTime(2021, 3, 21));
                order1.AddProduct(new OrderDetail(apple, 8));
                order1.AddProduct(new OrderDetail(eggs, 10));

                Order order2 = new Order()
                {
                    Id = 2,
                    Customer = customer2,
                    CreateTime = new DateTime(2021, 3, 21),
                    Details = { new OrderDetail(eggs, 10), new OrderDetail(milk, 10) }
                };

                Order order3 = new Order(3, customer2, new DateTime(2021, 3, 21));
                order3.AddProduct(new OrderDetail(milk, 100));

                OrderService orderService = new OrderService();
                orderService.AddOrder(order1);
                orderService.AddOrder(order2);
                orderService.AddOrder(order3);

                Console.WriteLine("\nGetOrder");
                Console.WriteLine(orderService.GetOrderById(1));
                Console.WriteLine(orderService.GetOrderById(5) == null);

                Console.WriteLine("\nGetAllOrders");
                List<Order> orders = orderService.GetAllOrders();
                orders.ForEach(o => Console.WriteLine(o));

                Console.WriteLine("\nGetOrdersByCustomerName:'Customer2'");
                orders = orderService.GetOrdersByCustomerName("Customer2");
                orders.ForEach(o => Console.WriteLine(o));

                Console.WriteLine("\nGetOrdersByProductName:'Eggs'");
                orders = orderService.GetOrdersByProductName("Eggs");
                orders.ForEach(o => Console.WriteLine(o));

                Console.WriteLine("\nGetOrdersByTotalAmount:1000");
                orders = orderService.GetOrdersByTotalAmount(1000);
                orders.ForEach(o => Console.WriteLine(o));

                Console.WriteLine("\nQueryByCondition");
                var query = orderService.GetOrdersByCondition(o => o.TotalPrice > 1000);
                foreach (Order order in query)
                {
                    Console.WriteLine(order);
                }

                Console.WriteLine("\nRemove Order (id=2) and Query All");
                orderService.RemoveOrderById(2);
                orderService.GetAllOrders().ForEach(o => Console.WriteLine(o));

                Console.WriteLine("\nOrder By TotalAmount");
                orderService.SortOrdersByAmount((o1, o2) => o2.TotalPrice.CompareTo(o1.TotalPrice));
                orderService.GetAllOrders().ForEach(o => Console.WriteLine(o));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
