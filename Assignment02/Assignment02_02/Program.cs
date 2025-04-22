using System;

namespace Assignment02
{

    class Calculator
    {

        public static void Main(string[] args)
        {
            double[] nums = { 2, 3, 0, 5, 10, 9, 12, 6, 8, 0 };

            try
            {
                var results = Compute(nums);
                Console.WriteLine(
                    $"min = {results.Min}, max = {results.Max}, sum = {results.Sum}, average = {results.Average}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // 计算数组的最小值、最大值、和、平均值
        private static (double Min, double Max, double Sum, double Average) Compute(double[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                throw new ArgumentException("数组不能为null或者空数组");
            }

            double min = double.MaxValue, max = double.MinValue, sum = 0;

            foreach (double n in nums)
            {
                if (n > max) max = n;
                if (n < min) min = n;
                sum += n;
            }

            double average = sum / nums.Length;
            return (min, max, sum, average);
        }

    }
}
