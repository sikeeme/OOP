using System.Drawing;

namespace Lab1.Shapes
{
    public abstract class ShapeBase : IShape
    {
        public Color Color { get; set; } = Color.Black;
        public float X { get; set; }
        public float Y { get; set; }
        protected ShapeBase(float x, float y)
        {
            X = x; Y = y;
        }   
        public abstract void Draw(Graphics g);
    }
}