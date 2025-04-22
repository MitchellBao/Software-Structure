using System;
using System.Collections.Generic;

namespace DataStructures
{

    // Node for singly linked list (generic)
    public class ListNode<T>
    {
        public T Value { get; set; }
        public ListNode<T> Next { get; set; }

        public ListNode(T value)
        {
            Value = value;
            Next = null;
        }
    }

    // Custom generic linked list
    public class CustomList<T>
    {
        private ListNode<T> first;
        private ListNode<T> last;

        public CustomList()
        {
            first = last = null;
        }

        public ListNode<T> First => first;

        public void Append(T value)
        {
            var node = new ListNode<T>(value);
            if (first == null)
            {
                first = last = node;
            }
            else
            {
                last.Next = node;
                last = node;
            }
        }

        public void Traverse(Action<T> action)
        {
            var current = first;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public double Aggregate(Func<T, double> selector)
        {
            double total = 0;
            var current = first;
            while (current != null)
            {
                total += selector(current.Value);
                current = current.Next;
            }
            return total;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var numbers = new CustomList<int>();

            for (int i = 0; i < 10; i++)
            {
                numbers.Append(rand.Next(1000));
            }

            Console.WriteLine("Random integers:");
            numbers.Traverse(n => Console.Write(n + "  "));

            double minVal = int.MaxValue;
            double maxVal = int.MinValue;
            double total = 0;

            numbers.Traverse(n => {
                if (n < minVal) minVal = n;
                if (n > maxVal) maxVal = n;
                total += n;
            });

            Console.WriteLine($"\nMin: {minVal}, Max: {maxVal}, Total: {total}");

            // Use Aggregate method to calculate sum again
            double sum = numbers.Aggregate(n => n);
            Console.WriteLine($"Aggregate sum: {sum}");

            // Use Aggregate to calculate total string length
            var words = new CustomList<string>();
            words.Append("hello");
            words.Append("csharp");
            words.Append("linkedlist");

            double totalLength = words.Aggregate(word => word.Length);
            Console.WriteLine($"Total string length: {totalLength}");
        }
    }
}
