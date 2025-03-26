namespace Assignment01_01
{
    internal class Calculator
    {
        static void Main(string[] args)
        {
            string s = "";
            double x, y = 0;
            double result = 0;
            while (true)
            {
                Console.Write("Please input the first number: ");
                s = Console.ReadLine();
                if (double.TryParse(s, out x))
                    break;
                else
                    Console.WriteLine("INVALID NUMBER!");
            }
            while (true)
            {
                Console.Write("Please input the second number: ");
                s = Console.ReadLine();
                if (double.TryParse(s, out y))
                    break;
                else
                    Console.WriteLine("INVALID NUMBER!");
            }
            while (true)
            {
                Console.Write("Please input the operator: ");
                s = Console.ReadLine();
                if ((s == "+") || (s == "-") || (s == "*") || (s == "/"))
                    break;
                else
                    Console.WriteLine("INVALID OPERATOR!");
            }
            switch (s)
            {
                case "+": result = x + y; break;
                case "-": result = x - y; break;
                case "*": result = x * y; break;    
                case "/":
                    if (y == 0)
                    {
                        Console.WriteLine("THE DIVISOR CANNOT BE ZERO!");
                        return;
                    }
                    else result = x / y; break;
            }
            Console.WriteLine("The result is: " + result);
        }
    }
}