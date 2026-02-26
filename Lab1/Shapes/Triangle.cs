using System.Drawing;

namespace Lab1.Shapes
{
    public class Triangle : ShapeBase
    {
        public float Size { get; set; }

        public Triangle(float x, float y, float size) : base(x, y)
        {
            Size = size;
            Color = Color.Green; 
        }
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color, 2))
            {                
                PointF point1 = new PointF(X, Y);                        
                PointF point2 = new PointF(X - Size / 2, Y + Size);      
                PointF point3 = new PointF(X + Size / 2, Y + Size);     

                PointF[] points = { point1, point2, point3 };

                g.DrawPolygon(pen, points);
            }
        }
    }
}