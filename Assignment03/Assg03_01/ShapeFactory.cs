using Homework3;

public class ShapeFactory
{
    public enum ShapeType { Square, Circle, Rectangle, Triangle };
    static readonly int[] edgeNumbers = { 1, 1, 2, 3 };
    static readonly Random random = new Random();

    public static Shape CreateShape(ShapeType type, double[] edges)
    {
        if (edges == null)
            throw new ArgumentNullException(nameof(edges));

        int index = (int)type;
        if (edges.Length != edgeNumbers[index])
            throw new InvalidOperationException("Invalid number of edges");

        return type switch
        {
            ShapeType.Square => new Square(edges[0]),
            ShapeType.Circle => new Circle(edges[0]),
            ShapeType.Rectangle => new Rectangle(edges[0], edges[1]),
            ShapeType.Triangle => new Triangle(edges[0], edges[1], edges[2]),
            _ => throw new InvalidOperationException($"Invalid shape type: {type}")
        };
    }

    public static Shape CreateRandomShape()
    {
        Shape shape;
        do
        {
            int index = random.Next(edgeNumbers.Length);
            double[] edges = new double[edgeNumbers[index]];
            for (int i = 0; i < edges.Length; i++)
            {
                edges[i] = random.Next(1, 200); // Avoid zero for validity
            }
            shape = CreateShape((ShapeType)index, edges);
        } while (!shape.IsValid());

        return shape;
    }
}
