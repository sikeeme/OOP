using System;
using System.Drawing;

namespace Lab2.Shapes
{
    public class RectangleShape : Shape
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public override void StartCreation(Point startPoint)
        {
            X = startPoint.X;
            Y = startPoint.Y;
            Width = 0;
            Height = 0;
        }

        public override void UpdateCreation(Point currentPoint)
        {
            Width = Math.Abs(currentPoint.X - X);
            Height = Math.Abs(currentPoint.Y - Y);
            // Correct top-left corner if dragged left/up
            if (currentPoint.X < X) X = currentPoint.X;
            if (currentPoint.Y < Y) Y = currentPoint.Y;
        }

        public override void FinishCreation(Point endPoint)
        {
            UpdateCreation(endPoint);
        }

        public override string ToString()
        {
            return $"Rectangle (X:{X}, Y:{Y}, W:{Width}, H:{Height})";
        }
    }
}