using Homework3;

public class Rectangle : Shape
{
    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public double Length { get; set; }
    public double Width { get; set; }

    public string Info => $"矩形: length={Length}, width={Width}";

    public double Area
    {
        get
        {
            if (!IsValid()) throw new InvalidOperationException("形状无效，无法计算面积");
            return Length * Width;
        }
    }

    public bool IsValid() => Length > 0 && Width > 0;
}
