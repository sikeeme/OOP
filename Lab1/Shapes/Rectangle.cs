using Lab1.Shapes;
public class RectangleShape : ShapeBase
{
    public float Width { get; set; }
    public float Height { get; set; }
    public RectangleShape(float x, float y, float w, float h) : base(x, y)
    {
        Width = w; Height = h;
    }
    public override void Draw(Graphics g) => g.DrawRectangle(new Pen(Color), X, Y, Width, Height);
}

