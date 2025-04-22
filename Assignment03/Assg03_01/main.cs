using Homework3;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            List<Shape> shapes = new List<Shape>();
            for (int i = 0; i < 10; i++)
            {
                shapes.Add(ShapeFactory.CreateRandomShape());
            }

            shapes.ForEach(s =>
                Console.WriteLine($"{s.Info}, area={s.Area:F2}")
            );

            double total = shapes.Sum(s => s.Area);
            Console.WriteLine($"Total area = {total:F2}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"错误: {e.Message}");
        }
    }
}
