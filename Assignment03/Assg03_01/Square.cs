using Homework3;

public class Square : Shape
{
    public Square(double side) => Side = side;

    public double Side { get; set; }

    public string Info => $"正方形: side={Side}";

    public double Area
    {
        get
        {
            if (!IsValid()) throw new InvalidOperationException("形状无效，无法计算面积");
            return Side * Side;
        }
    }

    public bool IsValid() => Side > 0;
}
