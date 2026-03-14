using System.Drawing;

namespace Lab2.Shapes
{
    public class RectangleShape : Shape
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        private Point startPoint;

        public override void StartCreation(Point startPoint)
        {
            this.startPoint = startPoint;
            X = startPoint.X;
            Y = startPoint.Y;
            Width = 0;
            Height = 0;
        }

        public override void UpdateCreation(Point currentPoint)
        {
            // Вычисляем прямоугольник так, чтобы он мог рисоваться в любую сторону от начальной точки
            X = Math.Min(startPoint.X, currentPoint.X);
            Y = Math.Min(startPoint.Y, currentPoint.Y);
            Width = Math.Abs(currentPoint.X - startPoint.X);
            Height = Math.Abs(currentPoint.Y - startPoint.Y);
        }

        public override void FinishCreation(Point endPoint)
        {
            UpdateCreation(endPoint);
        }

        public override void Draw(Graphics g)
        {
            using var pen = new Pen(Color, 2);
            g.DrawRectangle(pen, X, Y, Width, Height);
        }

        public override string ToString()
        {
            return $"Rectangle {Width}×{Height} at ({X}, {Y})";
        }
    }
}