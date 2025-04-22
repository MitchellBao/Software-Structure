using System;
using System.Collections.Generic;

namespace Assignment02_01
{
    public class FactorApp
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("请输入一个整数: ");
                int num = Convert.ToInt32(Console.ReadLine());
                var factors = GetPrimeFactors(num);
                Console.Write("素因子有: ");
                foreach (var factor in factors)
                {
                    Console.Write($"\t{factor}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"错误: {e.Message}");
            }
        }

        // 获取素因子（递归法）
        private static List<int> GetPrimeFactors(int num)
        {
            if (num <= 1)
            {
                throw new ArgumentException("num必须大于1");
            }

            List<int> primeFactors = new List<int>();
            // 从最小的质数开始
            for (int divisor = 2; divisor <= num; divisor++)
            {
                while (num % divisor == 0)
                {
                    primeFactors.Add(divisor);
                    num /= divisor;
                }
            }

            return primeFactors;
        }
    }
}
