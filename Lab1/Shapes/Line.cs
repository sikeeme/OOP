using Lab1.Shapes;
public class Line : ShapeBase
{
    public float EndX { get; set; }
    public float EndY { get; set; }
    public Line(float x1, float y1, float x2, float y2) : base(x1, y1)
    {
        EndX = x2; EndY = y2;
    }
    public override void Draw(Graphics g) => g.DrawLine(new Pen(Color), X, Y, EndX, EndY);
}

