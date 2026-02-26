using System;
using System.Drawing;

namespace Lab1.Shapes
{
    public class Square : ShapeBase
    {
        public float Width { get; set; }       
        public Square(float x, float y, float width) : base(x, y)
        {
            Width = width;
            Color = Color.Blue;
        }       
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color, 2))
            {
                float drawX = X - Width / 2;
                float drawY = Y - Width / 2;

                g.DrawRectangle(pen, drawX, drawY, Width, Width);
            }
        }
    }
}