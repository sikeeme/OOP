using System;
using System.Drawing;

namespace Lab2.Shapes
{
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
            UpdateCreation(endPoint);
        }

        public override string ToString()
        {
            return $"Circle (center: {Center.X},{Center.Y}, radius: {Radius})";
        }
    }
}