using System;

namespace OrderApp
{
    public class OrderDetail
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public float TotalPrice => Product.Price * Quantity;

        public OrderDetail() { }

        public OrderDetail(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Order Detail: {Product}, Quantity: {Quantity}";
        }
    }
}
