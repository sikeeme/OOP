using Lab2.Shapes;

public class Circle : Shape
{
    public Point Center { get; private set; }
    public int Radius { get; private set; }

    public override void StartCreation(Point startPoint)
    {
        Center = startPoint;
        Radius = 0;
    }

    public override void UpdateCreation(Point currentPoint)
    {
        int dx = currentPoint.X - Center.X;
        int dy = currentPoint.Y - Center.Y;
        Radius = (int)Math.Sqrt(dx * dx + dy * dy);
    }

    public override void FinishCreation(Point endPoint)
    {
        // Можно оставить как в UpdateCreation, или скорректировать если нужно
        UpdateCreation(endPoint);
    }

    public override void Draw(Graphics g)
    {
        using var pen = new Pen(Color, 2);
        g.DrawEllipse(pen,
            Center.X - Radius,
            Center.Y - Radius,
            Radius * 2,
            Radius * 2);
    }

    public override string ToString() => $"Circle (r={Radius}) at {Center}";
}