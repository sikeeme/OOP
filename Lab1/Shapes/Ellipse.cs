using Lab1.Shapes;
public class Ellipse : ShapeBase
{
    public float Width { get; set; }
    public float Height { get; set; }
    public Ellipse(float x, float y, float w, float h) : base(x, y)
    {
        Width = w; Height = h;
    }
    public override void Draw(Graphics g) => g.DrawEllipse(new Pen(Color), X, Y, Width, Height);
}