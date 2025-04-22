using System;

namespace Assignment02_04 
{ 
    class Program
    {

        static void Main(string[] args)
        {
            int[,] matrix = 
            {
                         { 1, 2, 3, 4 },
                         { 5, 1, 2, 3 },
                         { 9, 5, 1, 2 }
            };
            Console.WriteLine($"The matrix is Toeplitz: {CheckIfToeplitz(matrix)}");
        }

        // check if it's a Toeplitz matrix
        public static bool CheckIfToeplitz(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                throw new ArgumentException("输入的矩阵不能为空或无效");
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != matrix[row - 1, col - 1])
                    {
                        return false; 
                    }
                }
            }
            return true; 
        }
    }
}
