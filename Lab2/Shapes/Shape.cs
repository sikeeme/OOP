using System.Drawing;

namespace Lab2.Shapes
{
    public abstract class Shape
    {
        public Color Color { get; set; } = Color.Black;

        // Called when mouse button is pressed - sets initial position / anchor point.
        public abstract void StartCreation(Point startPoint);

        // Called on mouse move during drag - updates temporary size/position for preview.   
        public abstract void UpdateCreation(Point currentPoint);

        // Called when mouse button is released - finalizes the shape properties.
        public abstract void FinishCreation(Point endPoint);

        // Each concrete shape must implement its own drawing logic.
        public abstract void Draw(Graphics g);

        // For displaying in ListBox (should be overridden in concrete classes).
        public override string ToString()
        {
            return "Unknown Shape";
        }
    }
}