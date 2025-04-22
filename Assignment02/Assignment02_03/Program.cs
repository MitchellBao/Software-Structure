using System;
using System.Collections.Generic;

namespace Assignment02_03
{
    public class FactorApp
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("please input an interger: ");
                int num = Convert.ToInt32(Console.ReadLine());
                var primeFactors = GetPrimeFactors(num);
                Console.Write("the prime factors are: ");
                foreach (var factor in primeFactors)
                {
                    Console.Write($"\t{factor}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }
        }

        // 获取素因子（通过除法逐步减少）
        private static List<int> GetPrimeFactors(int num)
        {
            if (num <= 1)
            {
                throw new ArgumentException("num must be greater than 1");
            }

            List<int> primeFactors = new List<int>();

            // 从最小的质数开始除
            int divisor = 2;
            while (divisor <= num)
            {
                if (num % divisor == 0)
                {
                    primeFactors.Add(divisor);
                    num /= divisor; // 除以质因子
                }
                else
                {
                    divisor++;
                }
            }

            return primeFactors;
        }
    }
}
