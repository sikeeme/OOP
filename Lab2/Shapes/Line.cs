using System.Drawing;

namespace Lab2.Shapes
{
    public class Line : Shape
    {
        public Point Start { get; private set; }
        public Point End { get; private set; }

        public override void StartCreation(Point startPoint)
        {
            Start = startPoint;
            End = startPoint;   // пока совпадает с начальной точкой
        }

        public override void UpdateCreation(Point currentPoint)
        {
            End = currentPoint;
        }

        public override void FinishCreation(Point endPoint)
        {
            End = endPoint;
        }

        public override void Draw(Graphics g)
        {
            using var pen = new Pen(Color, 2);
            g.DrawLine(pen, Start, End);
        }

        public override string ToString()
        {
            return $"Line from {Start} to {End}";
        }
    }
}