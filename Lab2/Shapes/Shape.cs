using System.Drawing;

namespace Lab2.Shapes
{
    /// <summary>
    /// Abstract base class for all shapes.
    /// Does NOT contain any drawing method (as required).
    /// Contains only data + creation methods for mouse input.
    /// </summary>
    public abstract class Shape
    {
        public Color Color { get; set; } = Color.Black;

        /// <summary>
        /// Called when mouse button is pressed - sets initial position.
        /// </summary>
        public abstract void StartCreation(Point startPoint);

        /// <summary>
        /// Called on mouse move during drag - updates size/position.
        /// </summary>
        public abstract void UpdateCreation(Point currentPoint);

        /// <summary>
        /// Called when mouse button is released - finalizes the shape.
        /// </summary>
        public abstract void FinishCreation(Point endPoint);

        /// <summary>
        /// For displaying in ListBox (override in concrete classes).
        /// </summary>
        public override string ToString()
        {
            return "Unknown Shape";
        }
    }
}