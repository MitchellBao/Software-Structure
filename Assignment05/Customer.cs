using System;

namespace OrderApp
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer() { }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"Customer ID: {Id}, Customer Name: {Name}";
        }
    }
}
