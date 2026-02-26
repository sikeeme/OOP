using System;
using System.Drawing;

namespace Lab1.Shapes
{
    public class Circle : ShapeBase
    {
        public float Radius { get; set; }
                
        public Circle(float x, float y, float radius) : base(x, y)
        {
            Radius = radius;
            Color = Color.Red; 
        }        
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color, 2))
            {                               
                float diameter = Radius * 2;
                float drawX = X - Radius;
                float drawY = Y - Radius;

                g.DrawEllipse(pen, drawX, drawY, diameter, diameter);
            }
        }
    }
}